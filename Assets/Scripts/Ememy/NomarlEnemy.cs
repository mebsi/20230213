using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomarlEnemy : Ememy
{
    public override void Init()
    {
        ed.speed = 0.8f;
        ed.hp = 200f;
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
