using System.Collections;
using UnityEngine;


public static class ScriptableObjectExtensions
{
    public static void StartCoroutine(this ScriptableObject so, IEnumerator _task)
    {
        if (!Application.isPlaying)
        {
            Debug.LogError("Can not run coroutine outside of play mode.");
            return;
        }

        var coworker = new GameObject("CoWorker_" + _task.ToString()).AddComponent<CoWorker>();
        coworker.Work(_task);
    }
}
