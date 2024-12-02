using System.Collections.Generic;

namespace Delta
{
    public class StateStore
    {
        private readonly Dictionary<string, List<object>> _stateDictionary = new Dictionary<string, List<object>> ();

        public T GetOrCreateState<T>(string componentId, int index, T initialValue)
        {
            if (!_stateDictionary.TryGetValue (componentId, out var stateList))
            {
                stateList = new List<object> ();
                _stateDictionary[componentId] = stateList;
            }

            // Ensure the state list has enough capacity
            while (stateList.Count <= index)
            {
                stateList.Add (null); // Fill with null until the index is available
            }

            // Initialize the state if not already set
            if (stateList[index] == null)
            {
                stateList[index] = initialValue;
            }

            return (T)stateList[index];
        }

        public void UpdateState<T>(string componentId, int index, T newValue)
        {
            if (_stateDictionary.TryGetValue (componentId, out var stateList))
            {
                if (stateList.Count > index)
                {
                    stateList[index] = newValue;
                }
            }
        }

        public void RemoveComponentState(string componentId)
        {
            _stateDictionary.Remove (componentId);
        }
    }
}
