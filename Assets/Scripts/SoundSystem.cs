
using JetBrains.Annotations;
using UnityEngine;

public class SoundSystem
{
    private static readonly Vector3 SoundLocation = Camera.main!.transform.position;

    public static void PlaySound([CanBeNull] AudioClip audioClip)
    {
        if (audioClip == null) return;
        AudioSource.PlayClipAtPoint(audioClip, SoundLocation);
    }

}
