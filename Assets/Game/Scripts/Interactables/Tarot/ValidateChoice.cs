using UnityEngine;

public class ValidateChoice : MonoBehaviour
{
    [SerializeField] private  GameObject item;
    [SerializeField] private  GameObject validAnswers;
    public int corrects;

    public void OnPut()
    {
        if(corrects >= 6)
        {
            validAnswers.SetActive(true);
            item.SetActive(true);
        }
    }
}
