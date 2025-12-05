using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    PlayerScript ps;

    public GameObject bombPrefab;

    public LayerMask wall;

    public int maxNumBomb = 1;
    public int bombNum = 1;

    public float delay = 2f;

    void Start()
    {
        movePoint.parent = null;

        ps = GetComponent<PlayerScript>();

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



        print("l=" + ps.leftHeld + " r=" + ps.rightHeld);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if( ps.leftHeld )
        {
            h = -1;
        }
        if (ps.rightHeld)
        {
            h = 1;
        }

        if (ps.upHeld)
        {
            v = 1;
        }
        if (ps.downHeld)
        {
            v = -1;
        }


        print("h=" + h);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.1f)
        {



            if (h==1 || h==-1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3( h, 0f, 0f), 0.2f, wall))
                {
                    movePoint.position += new Vector3(h, 0f, 0f);
                }
            } 
            
            else if (v==1 || v==-1)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, v, 0f), 0.2f, wall))
                {
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
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);

            bombNum = bombNum - 1;





            print("drop bomb");
        }
    }
}
