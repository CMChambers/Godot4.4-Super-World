using Godot;

namespace CMC.Superworld.Characters
{
    [Tool]
    [GlobalClass]
    public partial class Walk : MovementType
    {
        [Export] public float walkAcceleration = 10f;
        [Export] public float walkDrag = 5f;
        [Export] public float walkSpeed = 10f;
        [Export] public float walkMaxSpeed = 10f;
        private float effectiveMaxSpeed;



        public override bool IsActive(InputState inputState, CharacterBody3D body)
        {
            // if (!body.IsOnFloor()) { return false; }
            if (!inputState.IsMoveInput()) { return false; }
            return true;
        }

        public override Vector3 AddMovement(InputState inputState, MovementController movementController, double delta)
        {
            // Vector3 moveDirection = inputState.GetMoveDirection();
            // float moveVelocity = 0f;
            // effectiveMaxSpeed = walkMaxSpeed;
            // if (walkAcceleration > 0f)
            // {
            // 	moveVelocity = moveVelocity + 1;
            // 	// Vector3 test = test.MoveToward()
            // }
            // else if (walkAcceleration == 0f)
            // { moveVelocity += walkAcceleration * effectiveMaxSpeed; }
            // // GD.Print($"in walk: {inputState.Move}");
            // // Vector3 direction = new Vector3(inputState.MoveHorizontal, 0, inputState.MoveVertical);
            // // return direction * walkAcceleration * (float)delta;
            // Vector3 result = moveDirection * moveVelocity;
            // return result * (float)delta;

            Vector3 inputDirection = GetInputVector(inputState);

            // Rotate using the camera pivot to align movement with camera
            Vector3 cameraForward = GetCameraForward(movementController, inputDirection);

            Vector3 currentHorizontalVelocity = GetCurrentVelocity(movementController);

            return GetNewVelocity(delta, inputDirection, cameraForward, currentHorizontalVelocity);

            static Vector3 GetInputVector(InputState inputState)
            {
                Vector2 input2D = inputState.GetMoveDirection(); // e.g. (WASD or stick)
                Vector3 inputDirection = new Vector3(input2D.X, 0, input2D.Y);
                return inputDirection;
            }

            static Vector3 GetCameraForward(MovementController movementController, Vector3 inputDirection)
            {
                Basis cameraBasis = movementController.cameraPivot.GlobalTransform.Basis;
                Vector3 worldDirection = (cameraBasis * inputDirection).Normalized();
                return worldDirection;
            }

            static Vector3 GetCurrentVelocity(MovementController movementController)
            {
                Vector3 currentVelocity = movementController.Velocity;
                Vector3 horizontalVelocity = new Vector3(currentVelocity.X, 0, currentVelocity.Z);
                return horizontalVelocity;
            }

            Vector3 GetNewVelocity(double delta, Vector3 inputDirection, Vector3 worldDirection, Vector3 horizontalVelocity)
            {
                Vector3 targetVelocity = (inputDirection != Vector3.Zero) ? worldDirection * walkMaxSpeed : Vector3.Zero;
                float blendRate = (inputDirection != Vector3.Zero) ? walkAcceleration : walkDrag;

                Vector3 newVelocity = horizontalVelocity.MoveToward(targetVelocity, (float)(blendRate * delta));
                return newVelocity - horizontalVelocity;
            }

        }

    }
}