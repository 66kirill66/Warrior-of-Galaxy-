using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpoon : MonoBehaviour
{
    [SerializeField] Transform plase;
    [SerializeField] GameObject enemyPrifab; 
    [SerializeField] GameObject bonus;
    [SerializeField] Text levelText;
    public int countBonus;
    public int level;
    public int countEnemy;
    int enemyEditor = 5;

    // Start is called before the first frame update
    private void Start()
    {
        Vector2 enemyPos = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, 4.5f));
        level = 0;       
        SpoonBonus();
        countEnemy = 0; 
    }
    private void Update()
    {
        levelText.text = "Level :" + level.ToString();
        SpoonEnemy();
    }
    private void SpoonEnemy()
    {
        if(countEnemy <= 0)
        {
            SpoonBonus();
            while (countEnemy < enemyEditor)
            {
                Vector2 enemyPos = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, 4.5f));
                GameObject instP = Instantiate(enemyPrifab, enemyPos, transform.rotation);
                countEnemy++;
                instP.transform.parent = plase;
            }
            level++;
            enemyEditor += 1;            
        }       
    }
    private void SpoonBonus()
    {
        if(countBonus <= 0 || countEnemy == 0)
        {
            while (countBonus < 1)
            {
                Vector2 bonusPos = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, -4.5f));
                Instantiate(bonus, bonusPos, transform.rotation);
                countBonus++;
            }
        }       
    }
}
