using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    public Vector3 offset;
    public float time;
    Stack<GameObject> bulletStack = new Stack<GameObject>();

    // Update is called once per frame
    public void Start()
    {
        for (int i=0;i<20;i++)
        {
            bulletStack.Push(Instantiate(bulletPrefab));
            bulletPrefab.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CreateBullet();
            //Instantiate(bulletPrefab,transform.position+offset,Quaternion.identity);
        time = time + Time.deltaTime ;
        if (time >= 3.0f)
        {
            float x = Random.Range(-30.0f, 30.0f);
            float y = Random.Range(0.0f, 13.0f);
            Instantiate(enemyPrefab, new Vector3(x, y, 0), Quaternion.identity);
            time = 0.0f;
        }
    }
    public void CreateBullet()
    {
        GameObject bullet=bulletStack.Pop();
        bullet.SetActive(true);
        bullet.transform.position = transform.position + offset;
    }
    public void BackToPool(GameObject obj)
    {
        obj.SetActive(false);
        bulletStack.Push(obj);
       
    }

}
