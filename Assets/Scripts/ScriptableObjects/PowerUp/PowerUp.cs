using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Powers/Create PowerUp", fileName = "PowerUp", order = 0)]
public class PowerUp : ScriptableObject
{
    [PreviewField(60), HideLabel, HorizontalGroup("Split", 60), Required]
    public Sprite sprite;

    [MultiLineProperty]
    public string description;
    
    public float durationSeconds;
    
    public List<Effect> effects;

    public void RunPower(GameObject obj)
    {
        this.StartCoroutine(Run(obj));
    }

    private IEnumerator Run(GameObject obj)
    {
        StartEffects(obj);
        yield return new WaitForSeconds(durationSeconds);
        StopEffects(obj);
    }

    public void InitPowers()
    {
        foreach (var e in effects)
            e.Init();
    }

    private void StartEffects(GameObject applyingObject)
    {
        foreach (var e in effects)
            this.StartCoroutine(e.StartEffect(applyingObject));
    }

    private void StopEffects(GameObject applyingObject)
    {
        foreach (var e in effects)
            this.StartCoroutine(e.StopEffect(applyingObject));
    }
}