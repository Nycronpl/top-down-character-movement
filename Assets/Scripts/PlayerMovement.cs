using UnityEngine;

namespace Nycron.TopDown.Movement
{
    public enum DirectionFacing
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 1f;

        private MovementInput input;
        private Rigidbody2D body;
        private Vector2 move;

        private void Awake()
        {
            input = new MovementInput();
            body = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => input.Enable();
        private void OnDisable() => input.Disable();

        private void Update()
        {
            //doesn't use tranform.position because it creates jittering when pushing against the wall
            move = input.Movement.Move.ReadValue<Vector2>();
            body.linearVelocity = move * speedMultiplier;
            
            if (IsPlayerMoving())
                Debug.Log(GetPlayerDirection());
        }

        public DirectionFacing GetPlayerDirection()
        {
            //vertical directions are prioritised over horizontal
            if (move.y > 0)
                return DirectionFacing.Up;
            else if (move.y < 0)
                return DirectionFacing.Down;

            if (move.x > 0)
                return DirectionFacing.Right;
            else if (move.x < 0)
                return DirectionFacing.Left;

            return DirectionFacing.Up; //safety measure so that animations don't break completly when something is wrong
        }

        public bool IsPlayerMoving()
        {
            if (move != Vector2.zero)
                return true;
            else
                return false;
        }
    }
}
