using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }

    [Header("Coin SFX")]
    [field: SerializeField] public EventReference coinCollected { get; private set; }
    [field: SerializeField] public EventReference coinIdle { get; private set; }

    public static FMODEvents instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
