using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Direction
    {
        Center = 0,
        Left,
        Right
    }
    private Direction dir = Direction.Center;

    [SerializeField] private List<Sprite> centerSp;
    [SerializeField] private List<Sprite> leftSp;
    [SerializeField] private List<Sprite> rightSp;

    [SerializeField] private Transform parent;
    [SerializeField] private PlayerBullet pbullet;

    [SerializeField] private float power= 0f;

    private SpriteAnimation sa;

    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        sa = GetComponent<SpriteAnimation>();
        sa.SetSprite(centerSp, 0.2f);

        InvokeRepeating("CreateBullet", 1f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        // ĳ���� �̵� ���� ���� x 1.5 y 4.5
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float clampX = Mathf.Clamp(transform.position.x + x, -2.5f, 2.5f);
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float clampY = Mathf.Clamp(transform.position.y + y, -4.5f, 4.5f);

        transform.position = new Vector2(clampX, clampY);
        //transform.Translate(new Vector2(x, y));

        //���⿡ ���� �̹��� ����
        if (x < 0 && dir != Direction.Left)
        {
            dir = Direction.Left;
            sa.SetSprite(leftSp[0], leftSp, 0.2f);
        }
        else if (x > 0 && dir != Direction.Right)
        {
            dir = Direction.Right;
            sa.SetSprite(rightSp[0], rightSp, 0.2f);
        }

        else if (x == 0 && dir != Direction.Center)
        {
            dir = Direction.Center;
            sa.SetSprite(centerSp[0], centerSp, 0.2f);
        }
    }

    public void CreateBullet()
    {
        PlayerBullet pb = Instantiate(pbullet, transform);
        pb.SetPower(power);
        pb.transform.SetParent(parent);
    }

}
