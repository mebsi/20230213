using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : Item
{
    public override void Init()
    {
        speed = 3f;
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    
}
