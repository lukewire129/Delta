using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Delta.WPF
{
    public class ApplicationRoot
    {
        public Action StateIndexInitialize { get; set; }
        private static ApplicationRoot? _instance = new ();
        private Component _rootComponent;
        private FrameworkElement? _currentRootVisual;
        protected IElement _currentVisualNode;

        public static ApplicationRoot Instance => _instance ?? throw new InvalidOperationException ("ApplicationRoot is not initialized.");

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
            Debug.WriteLine ("[Rebuild] Resetting _stateIndex to 0.");
            StateIndexInitialize?.Invoke ();
            var newVisualNode = _rootComponent.Render ();

            Debug.WriteLine ("[Rebuild] Render completed. New VisualNode created.");
            var diffOperations = DiffEngine.Diff (_currentVisualNode, newVisualNode);

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
