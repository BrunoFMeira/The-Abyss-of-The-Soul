using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]private Canvas pauseCanvas;
    [SerializeField]private Canvas inventoryCanvas;
    private InventoryController inventoryController;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        inventoryController = GetComponent<InventoryController>();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(playerInput.IsPauseButtonDown() && pauseCanvas.enabled)
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
        }else if(playerInput.IsPauseButtonDown() && (!pauseCanvas.enabled && !inventoryCanvas.enabled))
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
        }

        if((playerInput.IsInventoryButtonDown() || playerInput.IsPauseButtonDown()) && inventoryCanvas.enabled)
        {
            inventoryCanvas.enabled = false;
            Time.timeScale = 1;
        }else if(playerInput.IsInventoryButtonDown() && (!inventoryCanvas.enabled && !pauseCanvas.enabled))
        {
            inventoryCanvas.enabled = true;
            inventoryController.CheckItens();
            Time.timeScale = 0;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
