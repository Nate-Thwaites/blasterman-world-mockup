using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject speedPowerup;
    public GameObject bombPrefab;
    public GameObject destSprite;

    public int maxNumBomb = 1;
    public int bombNum = 1;


    public bool upHeld = false;
    public bool downHeld = false;
    public bool leftHeld = false;
    public bool rightHeld = false;

    public float delay = 2f;

    public int facingDirection;
    float speed = 5;

    public bool isMoving;

    float positionX;
    float positionY;
    float destX;
    float destY;

    




    private void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        float tx = 2.0f;
        print("tx=" + tx + "  rounded=" + Mathf.Ceil(tx));
        
    }

    private void Update()
    {

       

        isMoving = false;

        

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
            isMoving = true;
            rb.linearVelocity = new Vector2(speed, 0);
            facingDirection = 1;
            anim.Play("walk side");

            positionX = transform.position.x;
            

            destX = Mathf.Round(positionX);
            

            
        }

        if (rightHeld == false && positionX < destX)
        {

            print("magnet");
            positionX = destX;
            transform.position = new Vector3(positionX + 0.5f, transform.position.y);

            

        }

        if (leftHeld == true)
        {
            isMoving = true;
            rb.linearVelocity = new Vector2(-speed, 0);
            facingDirection = 2;
            anim.Play("walk left");

            positionX = transform.position.x;


            destX = Mathf.Round(positionX);
        }

        if (leftHeld == false && positionX > destX)
        {
            positionX = destX;
            transform.position = new Vector3(positionX - 0.5f,  transform.position.y);
        }

        

        if (upHeld == true)
        {
            isMoving = true;
            rb.linearVelocity = new Vector2(0, speed);
            facingDirection = 3;
            anim.Play("up walk");

            positionY = transform.position.y;


            destY = Mathf.Round(positionY);
        }

        if (upHeld == false)
        {
            positionY = destY;
            transform.position = new Vector3(transform.position.x, positionY + 0.5f);
        }

        if (downHeld == true)
        {
            isMoving = true;
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

