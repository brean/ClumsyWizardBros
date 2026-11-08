using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollRectPager : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float transitionTime = 0.3f; // 0 = instant

    private RectTransform viewport;
    private RectTransform content;
    private RectTransform[] pages;
    private float pageWidth;
    private int currentPage = 0;
    private Coroutine scrollRoutine;

    private void Start()
    {
        viewport = scrollRect.viewport != null ? scrollRect.viewport : scrollRect.GetComponent<RectTransform>();
        content = scrollRect.content;

        // Make sure the layout has been calculated before reading sizes
        Canvas.ForceUpdateCanvases();

        // Use the Content's direct children as pages
        int count = content.childCount;
        pages = new RectTransform[count];
        for (int i = 0; i < count; i++)
            pages[i] = content.GetChild(i) as RectTransform;

        pageWidth = viewport.rect.width;

        // Remove any layout group, since we position pages manually
        var layout = content.GetComponent<HorizontalLayoutGroup>();
        if (layout != null) layout.enabled = false;

        // Anchor everything to the left edge
        content.anchorMin = new Vector2(0f, 0.5f);
        content.anchorMax = new Vector2(0f, 0.5f);
        content.pivot = new Vector2(0f, 0.5f);
        content.sizeDelta = new Vector2(pageWidth * count, content.sizeDelta.y);
        content.anchoredPosition = Vector2.zero;

        for (int i = 0; i < count; i++)
        {
            RectTransform page = pages[i];
            page.anchorMin = new Vector2(0f, 0f);
            page.anchorMax = new Vector2(0f, 1f);
            page.pivot = new Vector2(0f, 0.5f);
            page.sizeDelta = new Vector2(pageWidth, 0f);
            page.anchoredPosition = new Vector2(i * pageWidth, 0f);
        }
    }

    public void NextPage()
    {
        GoToPage(currentPage + 1);
    }

    public void PreviousPage()
    {
        GoToPage(currentPage - 1);
    }

    // Call this from your index buttons, passing the page index
    public void GoToPage(int index)
    {
        if (pages == null || pages.Length == 0) return;

        index = Mathf.Clamp(index, 0, pages.Length - 1);
        currentPage = index;

        // Move the Content left by one page width per index
        Vector2 target = new Vector2(-index * pageWidth, content.anchoredPosition.y);

        if (scrollRoutine != null)
            StopCoroutine(scrollRoutine);

        scrollRect.velocity = Vector2.zero; // stop any inertia

        if (transitionTime <= 0f)
            content.anchoredPosition = target;
        else
            scrollRoutine = StartCoroutine(SmoothScrollTo(target));
    }

    private IEnumerator SmoothScrollTo(Vector2 target)
    {
        Vector2 start = content.anchoredPosition;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / transitionTime;
            content.anchoredPosition = Vector2.Lerp(start, target, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        content.anchoredPosition = target;
        scrollRoutine = null;
    }
}
