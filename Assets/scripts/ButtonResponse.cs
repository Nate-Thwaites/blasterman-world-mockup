using UnityEngine;

public class ButtonResponse : MonoBehaviour
{
    Animator anim;

    bool up;
    bool down;
    bool left;
    bool right;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (up == true)
        {
            anim.Play("up button anim");
        }

        if (down == true)
        {
            anim.Play("down button anim");
        }
    }

    public void ClickUp()
    {
        up = true;
        
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
