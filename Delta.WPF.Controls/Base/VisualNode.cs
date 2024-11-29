using Delta.WPF.Controls.Diffing;
using SkiaSharp;

namespace Delta.WPF.Controls.Base
{
    public abstract class VisualNode
    {
        private readonly Dictionary<string, object> _properties = new ();

        protected void SetProperty(string key, object value)
        {
            _properties[key] = value;
        }

        protected T GetProperty<T>(string key, T defaultValue = default)
        {
            return _properties.TryGetValue (key, out var value) ? (T)value : defaultValue;
        }

        // Diff 구현
        public virtual List<DiffOperation> Diff(VisualNode newNode)
        {
            var operations = new List<DiffOperation> ();

            // 속성 비교
            foreach (var property in _properties)
            {
                if (!newNode._properties.TryGetValue (property.Key, out var newValue) || !Equals (property.Value, newValue))
                {
                    operations.Add (new DiffOperation
                    {
                        Type = DiffOperationType.UpdateProperty,
                        PropertyKey = property.Key,
                        NewValue = newValue
                    });
                }
            }

            return operations;
        }

        public abstract void Render(SKCanvas canvas, SKRect bounds);
    }
}
