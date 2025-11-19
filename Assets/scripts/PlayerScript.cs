using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Animator anim;
        public SpriteRenderer sprite;

        public int speed = 1;

        

        public int facingDirection;


        // variables holding the different player states





        public Transform player; 
            
            
        Vector2 direction;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();

        }


        // Update is called once per frame
        public void Update()
        {
            

            direction = new Vector2(0, 0);

            //output debug info to the canvas

            //rb.linearVelocityX = direction * speed;

            KeyboardInput();

            //read it


        }


        void KeyboardInput()
        {
            if( Input.GetKeyDown("d") )
            {
                RightPressed();
            }
        }

        public void RightPressed()
        {
            direction = new Vector2(10, 0);
            
            facingDirection = 1;
            
        }
        public void LeftPressed()
        {
            direction = new Vector2(-10, 0);
            facingDirection = 2;
        }

        public void UpPressed()
        {
            direction = new Vector2(0, 10);
            facingDirection = 3;
        }

        public void DownPressed()
        {
            direction = new Vector2(0, -10);
            facingDirection = 4;
        }




    }

}