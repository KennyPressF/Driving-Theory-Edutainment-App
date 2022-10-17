using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFX : MonoBehaviour
{
    void Start()
    {
        var emissionSystem = gameObject.GetComponent<ParticleSystem>();
        float effectDuration = emissionSystem.main.duration;

        emissionSystem.Play();

        Invoke(nameof(DestroyMyself), effectDuration);
    }

    void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
