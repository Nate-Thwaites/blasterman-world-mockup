using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    PlayerScript ps;
    private Animator anim;

    public GameObject bombPrefab;

    public LayerMask wall;

    public int maxNumBomb = 1;
    public int bombNum = 1;

    public int facingDirection;

    

    public float delay = 2f;

    void Start()
    {
        movePoint.parent = null;

        ps = GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (bombNum == 0)
        {
            delay -= Time.deltaTime;

            if (delay < 0)
            {
                bombNum = maxNumBomb;
                delay = 2f;
            }
        }

        

        

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(ps.leftHeld )
        {
            facingDirection = 1;
            h = -1;
            anim.Play("walk left");
        }

        

        if (ps.rightHeld)
        {
            facingDirection = 2;
            h = 1;
            anim.Play("walk side");
        }

        if (ps.upHeld)
        {
            facingDirection = 3;
            v = 1;
            anim.Play("up walk");
        }

        if (ps.downHeld)
        {
           facingDirection= 4;
            v = -1;
            anim.Play("walk down");
        }

        
        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {



            if (h==1 || h==-1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( h, 0f, 0f), 0.2f, wall))
                {
                    FindObjectOfType<AudioManager>().Play("walk");
                    movePoint.position += new Vector3(h, 0f, 0f);
                }
            } 
            
            else if (v==1 || v==-1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, v, 0f), 0.2f, wall))
                {
                    FindObjectOfType<AudioManager>().Play("walk");
                    movePoint.position += new Vector3(0f, v, 0f);
                }

            }

           
        }
    }
    public void DropBomb()
    {
        if (bombNum > 0)
        {
            Vector2 position = transform.position;
            //position.x = Mathf.Round(position.x);
            //position.y = Mathf.Round(position.y);

            GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

            bombNum = bombNum - 1;


            FindObjectOfType<AudioManager>().Play("bomb place");


            print("drop bomb");
        }
    }

    public void StopMoving()
    {
        ps.upHeld = false;
        ps.downHeld = false;
        ps.leftHeld = false;
        ps.rightHeld = false;


        if (ps.upHeld == false && ps.downHeld == false && ps.leftHeld == false && ps.rightHeld == false)
        {
            


            if (facingDirection == 4)
            {
                anim.Play("idle");
            }

            if (facingDirection == 3)
            {
                anim.Play("up idle");
            }

            if (facingDirection == 2)
            {
                anim.Play("side idle");
            }

            if (facingDirection == 1)
            {
                anim.Play("left idle");

            }
        }

    }
}
