using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject speedPowerup;

    bool upHeld = false;
    bool downHeld = false;
    bool leftHeld = false;
    bool rightHeld = false;

    public int facingDirection;
    float speed = 5;

    public GameObject bomb;

    public int maxNumBomb = 1;
    public int bombNum = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        print(bombNum);

        if (bombNum == 0)
        {
            //delay into bomb added back
        }

        if (rightHeld == true)
        {
            rb.linearVelocity = new Vector2(speed, 0);
            facingDirection = 1;
            anim.Play("walk side");
            
        }

        if (leftHeld == true)
        {
            rb.linearVelocity = new Vector2(-speed, 0);
            facingDirection = 2;
            anim.Play("walk left");


        }

        

        if (upHeld == true)
        {
            rb.linearVelocity = new Vector2(0, speed);
            facingDirection = 3;
            anim.Play("up walk");
        }

        if (downHeld == true)
        {
            rb.linearVelocity = new Vector2(0, -speed);
            facingDirection = 4;
            anim.Play("walk down");
            
        }
    }

    public void DropBomb()
    {
        if (bombNum > 0)
        {
            bombNum = bombNum - 1;
            print("drop bomb");
        }
    }

    public void MovePlayerRight()
    { 
        rightHeld = true;
        


    }

    public void MovePlayerLeft()
    {
        leftHeld = true;
        


    }

    public void MovePlayerUp()
    {
        upHeld = true;
        
        
    }

    public void MovePlayerDown()
    {
        downHeld = true;

        
    }

    public void StopMoving()
    {
        upHeld = false;
        downHeld = false;
        leftHeld = false;
        rightHeld = false;


        if (upHeld == false || downHeld == false || leftHeld == false || rightHeld == false)
        {
            rb.linearVelocity = new Vector2(0, 0);

            if (facingDirection == 4)
            {
                anim.Play("idle");
            }

            if(facingDirection == 3)
            {
                anim.Play("up idle");
            }

            if(facingDirection == 1)
            {
                anim.Play("side idle");
            }

            if(facingDirection == 2)
            {
                anim.Play("left idle");
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == speedPowerup)
        {
            print("go fast");
            speed = speed * 1.5f;
            Destroy(speedPowerup);
        }
    }

}

