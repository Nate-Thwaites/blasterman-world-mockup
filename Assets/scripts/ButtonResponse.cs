using UnityEngine;

public class ButtonResponse : MonoBehaviour
{
    Animator anim;

    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        

        if (down == true)
        {
            anim.Play("down button anim");
        }
    }

    public void ClickUp()
    {
        up = true;
        if (up == true)
        {
            anim.Play("up button anim");
        }
    }

    public void NoClickUp()
    {
        up = false;
        if (up == false)
        {
            anim.Play("up button idle");
        }
    }

    public void ClickDown()
    {
        down = true;
        
    }

    public void ClickRight()
    {
        right = true;
        anim.Play("right button anim");
    }

    public void ClickLeft()
    {
        left = true;
        anim.Play("left button anim");
    }
}
