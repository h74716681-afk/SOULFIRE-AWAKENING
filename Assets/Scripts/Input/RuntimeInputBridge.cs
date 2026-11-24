using UnityEngine;

namespace Soulfire.Input
{
    /// <summary>Simple bridge for UI joystick/buttons and future platform-specific input.</summary>
    public static class RuntimeInputBridge
    {
        public static Vector2 Move { get; set; }
        public static Vector2 Look { get; set; }
        public static bool AttackPressed { get; private set; }
        public static bool DodgePressed { get; private set; }

        public static void SetMove(Vector2 value) => Move = Vector2.ClampMagnitude(value, 1f);
        public static void SetLook(Vector2 value) => Look = value;
        public static void PressAttack() => AttackPressed = true;
        public static void PressDodge() => DodgePressed = true;
        public static bool ConsumeAttack() { bool value = AttackPressed; AttackPressed = false; return value; }
        public static bool ConsumeDodge() { bool value = DodgePressed; DodgePressed = false; return value; }
        public static void ResetAll() { Move = Vector2.zero; Look = Vector2.zero; AttackPressed = false; DodgePressed = false; }
    }
}
