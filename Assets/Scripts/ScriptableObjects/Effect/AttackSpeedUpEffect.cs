using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create AttackSpeedUpEffect", fileName = "AttackSpeedUpEffect", order = 0)]
public class AttackSpeedUpEffect : Effect
{
    private bool started = false;
    
    public override void Init()
    {
        
    }

    public override IEnumerator StopEffect(GameObject obj)
    {
        started = false;
        yield break;
    }

    public override IEnumerator StartEffect(GameObject obj)
    {
        if (started) yield break;
        started = true;
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<Turret>().shotsPerSecond += 1;
        yield break;
    }
}
