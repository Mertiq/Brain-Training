﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayRandom();
    }
}
