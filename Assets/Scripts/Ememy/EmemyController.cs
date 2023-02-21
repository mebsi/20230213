using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyController : MonoBehaviour
{
    public static EmemyController Instance;
    [SerializeField] private Transform parent;
    [SerializeField] private Ememy[] ememies;
    [SerializeField] private Transform eBullet;

    float delaySpawn = 100f;
    int spwanCount = 0;
    float nextDelay = 2f;

     int stage = 1;

     bool spwanStop = false;
    // Start is called before the first frame update

    public void Awake()
    {
        Instance = this;
    }

    public int Stage
    {
        get; set;
    }
    public int SpwanCount
    {
        get; set;
    }
    public bool SpwanStop
    {
        get; set;
    }
    void Start()
    {
        StageUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (spwanStop)
            return;

        if ((spwanCount != 0) && spwanCount % (stage * 5) == 0)
        {
            Ememy ememy = Instantiate(ememies[ememies.Length - 1], transform);

            ememy.SetPercent(eBullet);
            ememy.transform.localPosition = Vector2.zero;
            ememy.transform.SetParent(parent);
            spwanStop = true;
        }
        else
        {


            delaySpawn += Time.deltaTime;
            if (delaySpawn > nextDelay)
            {
                int rand = Random.Range(0, stage);
                if (rand > ememies.Length - 1)
                    rand = ememies.Length - 2;
                Ememy ememy = Instantiate(ememies[rand], transform);
                ememy.SetPercent(eBullet);
                ememy.transform.localPosition = new Vector2(Random.Range(-2.5f, 2.5f), 0f);
                ememy.transform.SetParent(parent);

                delaySpawn = 0f;
                spwanCount++;
                nextDelay = Random.Range(2, 5);
            }
        }
    }

    public void StageUp()
    {
        Stage = 1;
        SpwanCount = 0;
        SpwanStop = false;
    }
}

