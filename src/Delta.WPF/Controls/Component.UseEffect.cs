using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Delta.WPF
{
    public abstract partial class Component
    {
        private readonly List<Action> _effects = new ();
        private readonly List<Action?> _cleanupEffects = new ();
        private readonly Dictionary<string, object[]> _dependencies = new ();

        /// <summary>
        /// Registers an effect that will run when the dependencies change.
        /// </summary>
        /// <param name="effect">The effect to execute.</param>
        /// <param name="dependencies">The dependencies to monitor.</param>
        protected void UseEffect(Func<Action?> effect, params object[] dependencies)
        {
            string key = string.Join (",", dependencies.Select (d => d?.GetHashCode () ?? 0));

            Debug.WriteLine ($"UseEffect called. Key: {key}");

            if (!_dependencies.TryGetValue (key, out var cachedDependencies) ||
                !dependencies.SequenceEqual (cachedDependencies))
            {
                Debug.WriteLine ($"Dependencies changed for key: {key}");

                // 이전 클린업 호출
                if (_cleanupEffects.Count > 0 && _cleanupEffects[^1] != null)
                {
                    Debug.WriteLine ($"Executing cleanup for key: {key}");
                    _cleanupEffects[^1]?.Invoke ();
                }

                // 새로운 효과 등록
                _effects.Add (() =>
                {
                    Debug.WriteLine ($"Registering new effect for key: {key}");
                    var cleanup = effect.Invoke ();
                    _cleanupEffects.Add (cleanup);
                });

                // 의존성 캐싱
                _dependencies[key] = dependencies.ToArray ();
            }
            else
            {
                Debug.WriteLine ($"No dependency changes detected for key: {key}");
            }
        }

        private void UseEffect()
        {
            foreach (var effect in _effects)
            {
                effect.Invoke ();
            }
            _effects.Clear ();
        }
    }
}
