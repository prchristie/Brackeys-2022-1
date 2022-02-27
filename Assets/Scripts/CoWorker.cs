using System.Collections;
using UnityEngine;
 
public class CoWorker : MonoBehaviour
{
    public void Work(IEnumerator coroutine)
    {
        StartCoroutine(WorkCoroutine(coroutine));
    }
 
    private IEnumerator WorkCoroutine(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine);
        Destroy(this.gameObject);
    }
}