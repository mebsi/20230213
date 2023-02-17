using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Ememy
{
    public override void Init()
    {
        ed.speed = 1f;
        ed.hp = 100f;
        ed.isBoss = true;
        player = FindObjectOfType<Player>();
        GetComponent<SpriteAnimation>().SetSprite(normalSprite, 0.2f); ;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
