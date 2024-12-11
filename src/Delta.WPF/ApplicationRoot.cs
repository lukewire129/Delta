using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Delta.WPF
{
    public class ApplicationRoot
    {
        public static List<IElement> Components { get; set; } = new ();
        public event EventHandler? StateIndexInitialize;
        private static ApplicationRoot? _instance = new ();
        private Component _rootComponent;
        private FrameworkElement? _currentRootVisual;
        protected IElement _currentVisualNode;

        private static readonly object _rebuildLock = new ();

        public static ApplicationRoot Instance => _instance ?? throw new InvalidOperationException ("ApplicationRoot is not initialized.");
        static ApplicationRoot()
        {

        }
        private ApplicationRoot()
        {
        }

        public static void Initialize(Component rootComponent, Window mainWindow)
        {
            _instance.InitializeInternal (rootComponent);
            _instance.InitializeInternal (mainWindow);
        }

        private void InitializeInternal(Component rootComponent)
        {
            _rootComponent = rootComponent;
        }

        private void InitializeInternal(Window mainWindow)
        {
            _currentVisualNode = _rootComponent.Render ();
            var rootVisual = MarkupBuilder.Build (_currentVisualNode);

            if (rootVisual == null)
                throw new InvalidOperationException ("Root component must render a FrameworkElement.");

            mainWindow.Content = rootVisual;
            _currentRootVisual = rootVisual;
        }
        public void Rebuild()
        {
            lock (_rebuildLock)
            {
                Debug.WriteLine ("[Rebuild] Resetting _stateIndex to 0.");
                StateIndexInitialize?.Invoke (this, EventArgs.Empty);
                var newVisualNode = _rootComponent.Render ();

               
                Debug.WriteLine ("[Rebuild] Render completed. New VisualNode created.");
                var diffOperations = DiffEngine.Diff (_currentVisualNode, newVisualNode);

                var removeChilds = diffOperations.Where (x => x.type == Enums.DiffOperationType.RemoveChild);
                foreach (var child in removeChilds)
                {
                    var temp = ((RemoveChildOperation)child).Target;

                    var realComponent = Components.FirstOrDefault (x => x.Id == temp.Id);
                    if (realComponent == null)
                        continue;

                    if(realComponent is Component component)
                    {
                        component.Dispose ();
                        Components.Remove (realComponent);
                    }
                }

                if (_currentRootVisual is FrameworkElement rootElement)
                {
                    Debug.WriteLine ("[Rebuild] Applying diff operations to root element.");
                    RenderingEngine.ApplyDiff (rootElement, diffOperations);
                }

                Debug.WriteLine ("[Rebuild] Updating _currentVisualNode.");
                _currentVisualNode = newVisualNode;
            }
        }
    }
}
