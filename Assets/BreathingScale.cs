using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingScale : MonoBehaviour
{
    [SerializeField] private Vector3 minScale, maxScale;
    [SerializeField] private float cycleTimeSeconds;

    private float _timer;
    private int _direction;

    private void Awake()
    {
        _timer = 0;
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * _direction;

        if (_timer < 0 || _timer > cycleTimeSeconds)
        {
            _direction *= -1;
        }

        var percentage = _timer / cycleTimeSeconds;

        var scale = Vector3.Lerp(minScale, maxScale, percentage);

        transform.localScale = scale;
    }
}
