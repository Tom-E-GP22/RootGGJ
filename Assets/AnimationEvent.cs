using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    void PlayIndependantParticle(GameObject particleSystem)
    {
        var particle = Instantiate(particleSystem, (Vector2)transform.position, Quaternion.identity);
        Destroy(particle, 2f);
    }
}
