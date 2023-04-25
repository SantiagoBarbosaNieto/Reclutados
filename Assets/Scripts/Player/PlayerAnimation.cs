using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour {

    [Header("Dependencies")]
    public Animator animator;
    public AudioSource steps;

    public void OnMovement(InputAction.CallbackContext value) {
        float movementInput = value.ReadValue<Vector2>().magnitude;

        if(Time.timeScale == 1) {
            if (movementInput > 0f) {
            animator.SetBool("IsRunning", true);
            if(!steps.isPlaying) {
                steps.Play();
            }
            }
            else {
                animator.SetBool("IsRunning", false);
                steps.Stop();
            }
        }
        // animator.SetBool("IsRunning", movementInput != Vector2.zero);
    }
}
