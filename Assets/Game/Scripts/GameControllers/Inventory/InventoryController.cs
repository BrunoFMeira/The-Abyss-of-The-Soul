using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject[] itens;

    public void CheckItens()
    {
        for(int i=1; i<=itens.Length; i++)
        {
            if(PlayerPrefs.HasKey("Item_"+ i.ToString()))
            {
                Debug.Log("Item:"+(i-1)+" Foi Encontrado");
                itens[i-1].SetActive(true);
            }
        }
    }
}
