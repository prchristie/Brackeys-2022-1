
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Effect : ScriptableObject
{   
    [PreviewField(60), Required]
    public AudioClip pickupSound;
    
    public abstract void Init();
    
    public abstract IEnumerator StopEffect(GameObject obj);

    public abstract IEnumerator StartEffect(GameObject obj);
}