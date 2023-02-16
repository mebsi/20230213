using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EmemyData
{
    public float speed;
    public float hp;
}

public abstract class Ememy : MonoBehaviour
{
    public EmemyData ed = new EmemyData();
    public Transform fireTrans;
    public EnemyBullet eBullet;

    public List<Sprite> explosionSprite;
    public List<Sprite> normalSprite;
    public Sprite hitSprite;

    protected Player player;//Å¸°Ù
    public Transform parent;
    public abstract void Init();

    public virtual void Move()
    {
        if (ed.hp > 0)
            transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));

    }

    float testTime = 0;

    void Update()
    {
        Move();

        if (player != null)
        {
            Vector2 vec = fireTrans.position - player.transform.position;
            float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        testTime += Time.deltaTime;
        if (testTime > 2f)
        {
            EnemyBullet bullet = Instantiate(eBullet, fireTrans);
            bullet.transform.SetParent(parent);
            testTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            ed.hp -= collision.gameObject.GetComponent<PlayerBullet>().power;

            if (ed.hp <= 0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.2f, Die);
            }
            else
            {
                GetComponent<SpriteAnimation>().SetSprite(hitSprite, normalSprite, 0.1f);
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
