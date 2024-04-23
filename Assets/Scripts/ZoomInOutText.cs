using System.Collections;
using UnityEngine;
using DG.Tweening; // Import DOTween namespace

public class ZoomInOutText : MonoBehaviour
{
    public float maxScale = 1.5f; // Maximum scale of the text
    public float minScale = 1.0f; // Minimum scale of the text
    public float duration = 2f; // Duration of the zoom effect

    private bool zoomingIn = true;

    void Start()
    {
        // Start the zoom coroutine
        StartCoroutine(ZoomCoroutine());
    }

    IEnumerator ZoomCoroutine()
    {
        while (true)
        {
            // Calculate the target scale based on the current scale and zoom direction
            float targetScale = zoomingIn ? maxScale : minScale;

            // Use DOTween to animate the scale with easing
            transform.DOScale(targetScale, duration).SetEase(Ease.InOutQuad);

            // Toggle the zoom direction
            zoomingIn = !zoomingIn;

            // Wait for the duration of the animation
            yield return new WaitForSeconds(duration);
        }
    }
}