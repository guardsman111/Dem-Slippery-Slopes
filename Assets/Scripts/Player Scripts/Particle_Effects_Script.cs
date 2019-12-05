using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Effects_Script : MonoBehaviour
{
    public Animator Rider;
    public ParticleSystem pSys;
    private bool racing = false;

    private void FixedUpdate()
    {
        if (!racing)
        {
            if (Rider.GetBool("Racing"))
            {
                pSys.Play(true);
                racing = true;
            }
        }
        else
        {
            pSys.emission.rateOverTime;
        }
    }
}
