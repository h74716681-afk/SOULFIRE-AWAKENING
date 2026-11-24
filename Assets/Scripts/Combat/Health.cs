using UnityEngine;
using System;

namespace Soulfire.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField, Min(1)] private float maxHealth = 100f;
        public float Current { get; private set; }
        public float Max => maxHealth;
        public bool IsDead => Current <= 0f;
        public event Action<float, float> Changed;
        public event Action Died;

        private void Awake() { Current = maxHealth; }

        public void ApplyDamage(float amount)
        {
            if (IsDead || amount <= 0f) return;
            Current = Mathf.Max(0f, Current - amount);
            Changed?.Invoke(Current, maxHealth);
            if (IsDead) Died?.Invoke();
        }

        public void Restore(float amount)
        {
            if (IsDead || amount <= 0f) return;
            Current = Mathf.Min(maxHealth, Current + amount);
            Changed?.Invoke(Current, maxHealth);
        }
    }
}
