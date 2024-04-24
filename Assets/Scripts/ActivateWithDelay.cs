using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActivateWithDelay : MonoBehaviour
{
    public float moveDistance = 2.0f;    // Distance to move up and down
    public float moveDuration = 1.0f;    // Time to complete each move in seconds
    public float delayBeforeStart = 1.0f; // Delay before starting the movement

    private Vector3 _originalPosition;

    private void Start()
    {
        // Store the original position
        _originalPosition = transform.position;
        
        // Start the movement after the initial delay
        Invoke(nameof(StartMoving), delayBeforeStart);
    }

    private void StartMoving()
    {
        // Move up
        transform.DOMoveY(_originalPosition.y + moveDistance, moveDuration)
            .SetEase(Ease.InOutQuad) // Smooth start and end
            .SetLoops(-1, LoopType.Yoyo) // Infinite loops, Yoyo makes it go back and forth
            .SetDelay(delayBeforeStart);
    }
}
