using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public int health;

    void Start()
    {
        health = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
