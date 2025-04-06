using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip day2ost;
    public AudioClip day3ost;
    public AudioClip valveTurning1, valveTurning2, valveTurning3, valveTurning4;

    private float timeSinceLastValveSound;

    private AudioSource audioSource;

    private void Update()
    {
        timeSinceLastValveSound += Time.deltaTime;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDay2music()
    {
        if (audioSource.clip != day2ost)
        {
            audioSource.clip = day2ost;
            audioSource.Play();
            audioSource.volume = 1f;
        }
    }

    public void StartDay3Music()
    {

    }

    public void PlayValveSound()
    {
        if (timeSinceLastValveSound >= 1) {
            int random = Random.Range(0, 3);

            switch (random)
            {
                case 0:
                    audioSource.PlayOneShot(valveTurning1, 1f);
                    break;
                case 1:
                    audioSource.PlayOneShot(valveTurning1, 1f);
                    break;
                case 2:
                    audioSource.PlayOneShot(valveTurning1, 1f);
                    break;
                case 3:
                    audioSource.PlayOneShot(valveTurning1, 1f);
                    break;
            }
            timeSinceLastValveSound = 0;
        }
    }
}
