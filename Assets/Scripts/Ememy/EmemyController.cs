using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyController : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Ememy[] ememies;

    [SerializeField] private Transform eBullet;

    float delaySpawn = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        delaySpawn += Time.deltaTime;
        if (delaySpawn > 5f)
        {
            int rand = Random.Range(0, ememies.Length);
            Ememy ememy = Instantiate(ememies[rand], transform);
            ememy.SetPercent(eBullet);
            ememy.transform.localPosition = new Vector2(Random.Range(-2.5f, 2.5f),0f);
            ememy.transform.SetParent(parent);
                
            delaySpawn = 0f;
        }
    }
}
