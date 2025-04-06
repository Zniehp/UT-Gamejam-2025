using UnityEngine;

public class ContinuousSoundManager : MonoBehaviour
{
    public AudioClip airleak;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartAirLeakSound()
    {
        audioSource.clip = airleak;
        audioSource.Play();
    }

    public void StopAirLeakSound()
    {
        audioSource.Stop();
    }

}
