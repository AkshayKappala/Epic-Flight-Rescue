﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMPlayerFallingStart : MonoBehaviour {
    public float t1,x,c,x_previous;
    public void Start()
    {
        x_previous = 0;
        Randgernerator();
    }

    public IEnumerator ThrowChar()
    {
        t1 = Random.Range(5,10);
        yield return new WaitForSeconds(t1);
        Randgernerator();
    }

    public void Randgernerator()
    {
        int i;
        x = Random.Range(-4, 4);
        xCorrecter();
        c = Random.Range(1, 6);
        x_previous = x;
        
            Instantiate(Resources.Load("Happy"+c), this.transform.position + new Vector3(x, 0, 0), Quaternion.identity);
            StartCoroutine(ThrowChar());
    }

    void xCorrecter()
    {
        if((x-x_previous<2&&x-x_previous>0&&x>x_previous)||(x-x_previous>-2&&x-x_previous<0&&x<x_previous))
        {
            x = Random.Range(-4, 4);
            xCorrecter();
        }
    }
}
