using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    private void Start()
    {
        spawnManager = GameObject.Find("Player").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, bulletSpeed, 0);
        if(transform.position.y>13.5f) //Pushing a bullet into bulletStack,when it is out of screen.
            spawnManager.BackToPool(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            Destroy(collision.gameObject);
            spawnManager.BackToPool(gameObject);
            GameObject.Find("Player").SendMessage("Score");
            //SendMessage("Score");
        }
    }



}
