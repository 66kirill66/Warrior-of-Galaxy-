using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] Vector2 movementVector = new Vector2(1f, 1f);
    [SerializeField] float period = 7f;  // time

    [SerializeField] [Range(0, 1)] float movementFactor;

    Vector2 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //set movement factor
        if (period <= Mathf.Epsilon) { return; }  //return = stop
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;   //  about 6.28
        float rawSin = Mathf.Sin(cycles * tau);

        movementFactor = rawSin / 2f + 0.5f;
        Vector2 offset = movementFactor * movementVector;
        transform.position = startingPos + offset; 
    }
}
