using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
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


        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        
        public StateMachine sm;





        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();


            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            
            

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }


        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
           




        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public bool CheckForRunSide()
        {
            if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
            {
                return true;
            }

            return false;
        }


        public bool CheckForIdle()
        {
            if (Input.GetKey("a") == false && Input.GetKey("d") == false)
            {
                return true;
            }

            return false;

        }

       


    }

}