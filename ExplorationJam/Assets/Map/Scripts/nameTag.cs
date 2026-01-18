using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class nameTag : MonoBehaviour
{
    private bool isVisible = false;
    private Coroutine currentFade;
    private bool shouldBeVisible;
    private TMP_Text textTMP;

    void Awake()
    {
        textTMP = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        // make sure the name tag is invisibe at start
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
        isVisible = false;
        shouldBeVisible = false;
    }

    void Update()
    {   
        if (shouldBeVisible && !isVisible)
        {
            Debug.Log("Appearing");
            if (currentFade != null) StopCoroutine(currentFade);
            currentFade = StartCoroutine(FadeIn());
            isVisible = true;
        }
        else if (!shouldBeVisible && isVisible)
        {
            Debug.Log("Disappearing");
            if (currentFade != null) StopCoroutine(currentFade);
            currentFade = StartCoroutine(FadeOut());
            isVisible = false;
        }
    }

    private IEnumerator FadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        
        float duration = 1.0f;
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha; // Start from current alpha
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, elapsedTime / duration);
            yield return null;
        }
        
        canvasGroup.alpha = 1f;
        currentFade = null;
    }

    private IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        
        float duration = 1.0f;
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha; // Start from current alpha
        
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / duration);
            yield return null;
        }
        
        canvasGroup.alpha = 0f;
        currentFade = null;
    }

    public void SetVisibility(bool visible)
    {
        shouldBeVisible = visible;
    }

    public void setText(string text)
    {
        if (textTMP != null)
        {
            textTMP.text = text;
        }

    }
}