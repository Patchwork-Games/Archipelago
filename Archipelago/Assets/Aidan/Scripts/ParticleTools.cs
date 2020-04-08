using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTools
{
    public static void StartEmission(ParticleSystem particle)
    {
        ParticleSystem.EmissionModule emit = particle.emission;
        emit.enabled = true;
        particle.Play();
    }

    public static void StopEmission(ParticleSystem particle)
    {
        ParticleSystem.EmissionModule emit = particle.emission;
        emit.enabled = false;
    }
}
