using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 GetMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        return new Vector2(horizontalInput, verticalInput);
    }

    public Vector2 GetMouseInput()
    {
        Vector3 mouseDir = Input.mousePosition;
        mouseDir = Camera.main.ScreenToWorldPoint(mouseDir);
        
        return new Vector2(
        mouseDir.x-transform.position.x,
        mouseDir.y-transform.position.y);
    }
    
    public bool IsAttackButtonDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsInteractionButtomDown()
    {
        return Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X);
    }

    public bool IsDashButtomDown()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }

    public bool IsPauseButtonDown()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }
    public bool IsInventoryButtonDown()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
