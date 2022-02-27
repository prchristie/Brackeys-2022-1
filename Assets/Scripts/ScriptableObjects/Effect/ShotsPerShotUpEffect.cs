using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ShotsPerShotUpEffect", fileName = "ShotsPerShotUpEffect", order = 0)]
public class ShotsPerShotUpEffect : Effect
{
    private bool started;
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<Turret>().bulletsPerShot += 1;
    }
}
