using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomZRotation : MonoBehaviour
{
    [SerializeField] private Vector2 rotationRange;
    [SerializeField] private float cycleTimeSeconds;

    private float _timer = 0;
    private float startRotationSpeed;

    private void Awake()
    {
        startRotationSpeed = Random.Range(rotationRange.x, rotationRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _timer %= cycleTimeSeconds;
    
        // Find the percentage of time we've passed through the timer.
        var percentage = _timer / cycleTimeSeconds;

        // var rotationSpeed = Mathf.Lerp(startRotationSpeed, endRotationSpeed, percentage);
        
        transform.Rotate(new Vector3(0, 0, startRotationSpeed) * Time.deltaTime, Space.Self);
    }
}
