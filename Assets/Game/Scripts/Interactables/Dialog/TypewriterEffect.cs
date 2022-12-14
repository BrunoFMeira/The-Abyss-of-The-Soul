using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float writeSpeed = 50f;
    Coroutine typingCoroutine;

    public bool isRunning {get; private set;}

    private readonly Dictionary<HashSet<char>, float> punctoantions = new Dictionary<HashSet<char>, float>()
    {
        {new HashSet<char>(){'.','!','?'},0.6f},
        {new HashSet<char>(){',',';',':'},0.3f}
    };

    public void Run(string textToType, TMP_Text textLabel)
    {
        typingCoroutine = StartCoroutine(TypeText(textToType, textLabel));
    }
    
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        isRunning = true;
        textLabel.text = string.Empty;

        yield return new WaitForSeconds(0.5f);

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            t += Time.deltaTime * writeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for(int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLabel.text = textToType.Substring(0, charIndex);

                if(IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i+1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }
            yield return null;
        }

        isRunning = false;
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        isRunning = false;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (KeyValuePair<HashSet<char>, float> punctuationCategory in punctoantions)
        {
            if(punctuationCategory.Key.Contains(character))
            {
                waitTime = punctuationCategory.Value;

                return true;
            }
        }

        waitTime = default;
        return false;
    }
}
