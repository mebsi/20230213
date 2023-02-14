using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Transform[] buttomTs;
    [SerializeField] private Transform[] middleTs;
    [SerializeField] private Transform[] topTs;

    [SerializeField] private float buttomSpeed;
    [SerializeField] private float middleSpeed;
    [SerializeField] private float topSpeed;


    [SerializeField] private int initPos;
    [SerializeField] private int lastPos;
    // Update is called once per frame
    void Update()
    {
        foreach (var item in buttomTs)
        {
            BGMove(item, buttomSpeed);
        }

        foreach (var item in middleTs)
        {
            BGMove(item, middleSpeed);
        }

        foreach (var item in topTs)
        {
            BGMove(item, topSpeed);
        }

    }

    void BGMove(Transform trans, float speed)
    {
        trans.Translate(new Vector2(0f, -(Time.deltaTime * speed)));
        if (trans.position.y < lastPos)
        {
            trans.position = new Vector3(0, initPos);
        }

    }
}
