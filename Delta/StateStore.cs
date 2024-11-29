using System;
using System.Collections.Generic;
using System.Text;

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

            if (stateList.Count <= index)
            {
                stateList.Add (initialValue);
            }

            return (T)stateList[index];
        }

        public void UpdateState<T>(string componentId, int index, T newValue)
        {
            if (_stateDictionary.TryGetValue (componentId, out var stateList))
            {
                stateList[index] = newValue;
            }
        }

        public void RemoveComponentState(string componentId)
        {
            _stateDictionary.Remove (componentId);
        }
    }
}
