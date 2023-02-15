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
    public List<Sprite> explosionSprite;
    public List<Sprite> normalSprite;
    public Sprite hitSprite;
    public abstract void Init();

    public virtual void Move()
    {
        if (ed.hp > 0)      
            transform.Translate(new Vector2(0f, -(Time.deltaTime * ed.speed)));
        
    }

    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
       
        if (collision.gameObject.GetComponent<PlayerBullet>())
        {
            ed.hp -= collision.gameObject.GetComponent<PlayerBullet>().power;

            if(ed.hp <=0)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteAnimation>().SetSprite(explosionSprite, 0.1f, Die);
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
