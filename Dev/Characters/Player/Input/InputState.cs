using Godot;

namespace CMC.Superworld.Characters
{
    public class InputState
    {
        public Vector2 Move;    // From left stick or WASD
        public bool JumpPressed;
        public bool JumpJustPressed;
        public bool JumpJustReleased;
        // public float MoveHorizontal;      // Individual axes, for legacy fallback
        // public float MoveVertical;
        public bool AnyInput;         // Optional
        public Vector2 Look;
        // public float LookVertical;
        // public float LookHorizontal;
        public Vector2 MouseDelta;

        public InputState()
        {
            Move = Vector2.Zero;
            // MoveHorizontal = 0;
            // MoveVertical = 0;

            Look = Vector2.Zero;
            // LookVertical = 0;
            // LookHorizontal = 0;

            JumpPressed = false;
            JumpJustPressed = false;
            JumpJustReleased = false;

            AnyInput = false;
        }
        public Vector2 GetMoveDirection()
        {
            return new Vector2(Move.X, Move.Y);
        }
        public bool IsMoveInput()
        {
            if (Move != Vector2.Zero)// (MoveHorizontal != 0 || MoveVertical != 0)
            { return true; }
            return false;
        }

        public float GetLookHorizontal()
        {
            return Look.X;
        }
        public float GetLookVertical()
        {
            return Look.Y;
        }
    }
}
