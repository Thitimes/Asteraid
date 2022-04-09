﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0, 0.5f,1);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition = Offset;
    }


}
