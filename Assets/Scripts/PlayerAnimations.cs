using UnityEngine;

namespace Nycron.TopDown.Movement
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimations : MonoBehaviour
    {
        private Animator animator;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            bool isPlayerMoving = playerMovement.IsPlayerMoving();
            animator.SetBool("Moving", isPlayerMoving);

            if (isPlayerMoving)
                animator.SetInteger("Direction", (int)playerMovement.GetPlayerDirection());
        }
    }
}
