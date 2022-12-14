using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string nextScene;
    [SerializeField] Vector3 position;
    [SerializeField] string nameKey;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(PlayerPrefs.HasKey(nameKey) || nameKey == "")
            {
                SceneController.Instance.LoadSceneAsync(nextScene, position);
            }
        }
    }
}