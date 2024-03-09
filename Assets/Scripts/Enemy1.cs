using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject enemy;
    public float walkspeed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            enemy.GetComponent<Transform>().Translate(new Vector2(5, 0) * walkspeed * Time.deltaTime);
        }
        
    }
}
