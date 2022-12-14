using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //TODO Mudar de Singleton para Dependency Injection
    [SerializeField] GameObject Player_obj;
    [SerializeField] Vector3 initialPoss;
    [SerializeField] private CanvasGroup loadingOverlay = null;

    [Range(0.01f, 3f)]
    private float fadeTime = 0.5f;
    //[SerializeField] private AudioClip Menu_Inicial;
    //[SerializeField] private AudioClip Floor_1;
    //[SerializeField] private AudioClip Floor_2;
    //[SerializeField] private AudioClip Floor_3;

    public static SceneController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        initialPoss = new Vector3(0, 0, 0);
    }

    public void LoadSceneAsync(string sceneName, Vector3 position)
    {
        StartCoroutine(PerformLoadSceneAsync(sceneName, position));
        //SoundManager.instance.ChangeMusic(sceneName);
    }

    IEnumerator PerformLoadSceneAsync(string sceneName, Vector3 position)
    {
        yield return StartCoroutine(FadeIn());
        var operation = SceneManager.LoadSceneAsync(sceneName);
        while (operation.isDone == false)
        {
            yield return null;

        }

        Player_obj = GameObject.FindGameObjectWithTag("Player");
        if (Player_obj != null)
        {
            Player_obj.transform.position = position;
        }
        yield return StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;

        while (loadingOverlay.alpha < end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;

    }
    IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / fadeTime;

        loadingOverlay.alpha = start;

        while (loadingOverlay.alpha > end)
        {
            loadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        loadingOverlay.alpha = end;
    }
}