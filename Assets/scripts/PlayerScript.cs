using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject speedPowerup;
    public GameObject bombPrefab;

    public int maxNumBomb = 1;
    public int bombNum = 1;
    private int bombsRemaining;


    bool upHeld = false;
    bool downHeld = false;
    bool leftHeld = false;
    bool rightHeld = false;

    public float delay = 2f;

    public int facingDirection;
    float speed = 5;

   

    


    private void Start()
    {
        bombsRemaining = bombNum;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if(!rightHeld || !leftHeld || !downHeld || !upHeld)
        {
            Vector2 position = transform.position;
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);
        }
       
        if (bombNum == 0)
        {
            delay -= Time.deltaTime;

            if (delay < 0)
            {
                bombNum = maxNumBomb;
                delay = 2f;
            }
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
            Vector2 position = transform.position;
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

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
        /*if( moving==false)
        {
            //calculate dest

            moving = true;
        }*/


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

