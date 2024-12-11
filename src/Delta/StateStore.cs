using System;
using System.Collections.Generic;

namespace Delta
{
    public class StateStore
    {
        private readonly Dictionary<string, Dictionary<int, object>> _store = new Dictionary<string, Dictionary<int, object>> ();

        public T GetOrCreateState<T>(string componentId, int index, T initialValue)
        {
            if (!_store.TryGetValue (componentId, out var states))
            {
                states = new Dictionary<int, object> ();
                _store[componentId] = states;
            }

            if (!states.TryGetValue (index, out var value))
            {
                states[index] = initialValue;
                return initialValue;
            }

            return (T)value;
        }

        public void UpdateState<T>(string componentId, int index, T newValue)
        {
            if (!_store.TryGetValue (componentId, out var states))
                throw new InvalidOperationException ($"Component {componentId} not found");

            if (states.TryGetValue (index, out var existingValue) && !(existingValue is T))
                throw new InvalidOperationException ($"Cannot change state type at index {index} from {existingValue.GetType ()} to {typeof (T)}.");

            states[index] = newValue;
        }

        public void RemoveComponentState(string componentId)
        {
            _store.Remove (componentId);
        }

        public void Clear()
        {
            _store.Clear ();
        }
    }
}
