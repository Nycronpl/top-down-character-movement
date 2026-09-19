using UnityEngine;

namespace Nycron.TopDown.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 1f;

        private MovementInput input;

        private void Awake()
        {
            input = new MovementInput();
        }

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        private void Update()
        {
            Vector2 move = input.Movement.Move.ReadValue<Vector2>();
            transform.position += (Vector3)move * speedMultiplier * Time.deltaTime;
        }
    }
}
