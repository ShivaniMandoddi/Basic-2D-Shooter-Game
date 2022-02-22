using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;

    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed, 0);
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            Destroy(collision.gameObject);
            GameObject.Find("Player").SendMessage("Score");
            //SendMessage("Score");
        }
    }


}
