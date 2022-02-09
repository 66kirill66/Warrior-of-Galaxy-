using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject enemyFire;
    float startTime = 0.5f;
    [SerializeField] int randomNum;
    [SerializeField] float timerToFire = 6;
   
    void Start()
    {      
        RandomNumber();      
    }

    // Update is called once per frame
    void Update()
    {
        timerToFire -= startTime * Time.deltaTime;

        if (timerToFire <= randomNum)
        {
            timerToFire = 6;
            RandomNumber();
            Instantiate(enemyFire, transform.position, transform.rotation);
        }
        else if (timerToFire < 0)
        {
            timerToFire = 6;
        }
        else if (Time.timeScale == 0)
        {
            startTime = 0;
        }            
    }
    private void RandomNumber()
    {
        randomNum = Random.Range(0, 6);
    }   
}
