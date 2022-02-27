using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Turret))]
public class PlayerInputController : MonoBehaviour
{
    private Turret _turret;
    
    private void Awake()
    {
        _turret = GetComponent<Turret>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _turret.TryFire();
        }
    }
}
