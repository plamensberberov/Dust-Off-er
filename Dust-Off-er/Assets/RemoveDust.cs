﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDust : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            ps.Play();
        }
    }
}
