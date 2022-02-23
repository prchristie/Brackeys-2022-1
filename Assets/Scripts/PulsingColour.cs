using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PulsingColour : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float cycleTimeSeconds;
    [SerializeField] private Renderer colorRenderer;

    private float _timer = 0;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _timer %= cycleTimeSeconds;
    
        // Find the percentage of time we've passed through the timer.
        var percentage = _timer / cycleTimeSeconds;

        colorRenderer.material.color = Color.Lerp(startColor, endColor, percentage);
    }
}
