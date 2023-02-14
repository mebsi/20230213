using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed = 5f;
    

    void Update()
    {
        transform.Translate(new Vector2(0f, Time.deltaTime * speed));
    }
}
