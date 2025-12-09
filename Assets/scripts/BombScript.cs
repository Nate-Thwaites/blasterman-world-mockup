using System;
using Unity.Collections;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explosionTime;

    public GameObject flamePrefab;
    public GameObject flameEndUp;
    public GameObject flameEndDown;
    public GameObject flameEndLeft;
    public GameObject flameEndRight;

    public LayerMask wall;



    void Start()
    {
        explosionTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        explosionTime -= Time.deltaTime;

        if (explosionTime < 0)
        {
            print("explode");
            explosionTime = 4f;
            Destroy(gameObject);

            CreateFlames();

            
        }
    }

    void CreateFlames()
    {
        GameObject flame;


        Vector3 pos;
        bool collision;
        //left
        pos = transform.position + new Vector3(-1, 0, 0);

        //check using raycast if there is an object at this point

        if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
        {
            flame = Instantiate(flamePrefab, pos, Quaternion.identity);

            pos = transform.position + new Vector3(-2, 0, 0);

            if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
            {
                flame = Instantiate(flameEndLeft, pos, Quaternion.identity);
            }
        }

        //right

        pos = transform.position + new Vector3(1, 0, 0);

        if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
        {
            flame = Instantiate(flameEndRight, pos, Quaternion.identity);

            pos = transform.position + new Vector3(2, 0, 0);

            if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
            {
                flame = Instantiate(flamePrefab, pos, Quaternion.identity);
            }
        }

        //up

        pos = transform.position + new Vector3(0, 1, 0);

        if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
        {
            flame = Instantiate(flamePrefab, pos, Quaternion.identity);

            pos = transform.position + new Vector3(0, 2, 0);

            if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
            {
                flame = Instantiate(flameEndUp, pos, Quaternion.identity);
            }
        }

        //down

        pos = transform.position + new Vector3(0, -1, 0);

        if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
        {
            flame = Instantiate(flamePrefab, pos, Quaternion.identity);

            pos = transform.position + new Vector3(0, -2, 0);

            if (Physics2D.OverlapCircle(pos, 0.2f, wall) == false)
            {
                flame = Instantiate(flameEndDown, pos, Quaternion.identity);
            }
        }
    }

    
}
