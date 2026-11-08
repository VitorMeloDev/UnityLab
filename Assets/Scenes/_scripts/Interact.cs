using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Interact : MonoBehaviour
{
    private StudioEventEmitter emitter;

    void Start()
    {
        emitter = AudioManager.instance.CreateEventEmitter(FMODEvents.instance.coinIdle, gameObject);
        emitter.OverrideAttenuation = true;
        emitter.OverrideMaxDistance = 4f;
        emitter.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.coinCollected, transform.position);
            emitter.Stop();
            Destroy(gameObject);
        }
    }
}
