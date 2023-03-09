using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour {

    [Header("Dependencies")]
    public Animator animator;

    public void OnMovement(InputAction.CallbackContext value) {
        float movementInput = value.ReadValue<Vector2>().magnitude;

        if (movementInput > 0f) {
            animator.SetBool("IsRunning", true);
        }
        else {
            animator.SetBool("IsRunning", false);
        }

        // animator.SetBool("IsRunning", movementInput != Vector2.zero);
    }
}
