using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDirect : MonoBehaviour
{
    public ParticleSystem ps;
    public Collider col;

    public float timeLeft;

    public Transform astronaut; 

    public Camera firstPersonCamera;
    public Camera overheadCamera;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
        col = GetComponent<Collider>();
        astronaut = GetComponent<Transform>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            timeLeft = 2.0f;
            ps.Play();
        }

        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            ps.Stop();
        }
        if(Input.GetKey("w"))
        {
            astronaut.Translate(astronaut.right * 0.01f);
        }
        if(Input.GetKey("s"))
        {
            astronaut.Translate(astronaut.right * -0.01f);
        }
        if(Input.GetKey("a"))
        {
            astronaut.Translate(astronaut.forward * 0.01f);
        }
        if(Input.GetKey("d"))
        {
            astronaut.Translate(astronaut.forward * -0.01f);
        }
        if(Input.GetKeyDown("p"))
        {
            if(overheadCamera.enabled)
            {
                overheadCamera.enabled = false;
                firstPersonCamera.enabled = true;
            }
            else
            {
                overheadCamera.enabled = true;
                firstPersonCamera.enabled = false;
            }
        }
    }

    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        // iterate through the particles which entered the trigger and make them red
        for (int i = 0; i < numEnter; i++)
        {
            ParticleSystem.Particle p = enter[i];
            enter[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }

}
