using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explosionTime = 4f;

    
    void Start()
    {
        
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

            
        }
    }
}
