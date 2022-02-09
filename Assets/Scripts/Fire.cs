using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float timeToDestroy = 400f;

    void Update()
    {      
        transform.Translate(0, speed * Time.deltaTime, 0);
        timeToDestroy --;
        if (timeToDestroy == 0)
        {
            Destroy(gameObject);
        }
    }
}
