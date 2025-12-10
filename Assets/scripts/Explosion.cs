using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{

    float life;
    void Start()
    {
        life = 1;
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;

        if( life <0 )
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<NewPlayerScript>().dead = true;
            FindObjectOfType<AudioManager>().Play("death");
            FindObjectOfType<AudioManager>().Stop("music");

            
        }

        
    }
}
