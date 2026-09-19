using UnityEngine;

namespace Nycron.TopDown.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 1f;

        private MovementInput input;
        private Rigidbody2D body;

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
            Vector2 move = input.Movement.Move.ReadValue<Vector2>();
            body.linearVelocity = move * speedMultiplier;
        }
    }
}
