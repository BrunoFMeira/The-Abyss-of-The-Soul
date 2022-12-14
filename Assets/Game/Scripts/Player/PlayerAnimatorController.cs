using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator waeponAnimator;
    PlayerController player;
    float moveInputVal;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        playerAnimator.SetFloat("horizontalMouseInput", playerInput.GetMouseInput().x);
        playerAnimator.SetFloat("verticalMouseInput", playerInput.GetMouseInput().y);
        moveInputVal = playerInput.GetMovementInput().x + playerInput.GetMovementInput().y;
        if(moveInputVal != 0){
            playerAnimator.SetBool("moveInput", true);
        }else{
            playerAnimator.SetBool("moveInput", false);
        }
        waeponAnimator.SetBool("Attack", player.weapon.IsAttacking);

    }
}
