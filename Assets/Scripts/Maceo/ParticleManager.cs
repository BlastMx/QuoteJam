using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] public ParticleSystem[] particleSystems = default;
    [SerializeField] public string[] particleName = default;

    public static ParticleManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void StartParticle(string nameParticle, Vector3 postitionOnScreen)
    {
        for (int i = 0; i < particleName.Length; i++)
        {
            if (particleName[i] == nameParticle)
            {
                particleSystems[i].Play();

                particleSystems[i].transform.position = postitionOnScreen;
            }
        }
    }
    public void StopParticle(string nameParticle)
    {
        for (int i = 0; i < particleName.Length; i++)
        {
            if (particleName[i] == nameParticle)
            {
                particleSystems[i].Stop();
                return;
            }
        }
    }
    public void StopAllParticule()
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            particleSystems[i].Stop();
        }
    }
}
