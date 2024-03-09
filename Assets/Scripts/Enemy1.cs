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
            enemy.GetComponent<Transform>().Translate(new Vector2(-1, 0) * walkspeed * Time.deltaTime);
    }
}
