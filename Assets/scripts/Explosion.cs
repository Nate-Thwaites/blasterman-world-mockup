using UnityEngine;

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
}
