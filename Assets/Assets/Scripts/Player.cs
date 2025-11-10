using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class Player : MonoBehaviour
{
    public GameObject enemies;
    private List<Enemy> enemyList = new List<Enemy>();
    private Enemy targetEnemy;
    float playerSpeed = 20.0f;
    int targetIndex = 0;
    void Start()
    {
        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            enemyList.Add(enemies.transform.GetChild(i).gameObject.GetComponent<Enemy>());
        }
    }

   
    string ListToString(List<Enemy> input)
    {
        int[] healthArray = new int[input.Count];

        foreach (Enemy enemy in input)
        {
            healthArray[input.IndexOf(enemy)] = enemy.health;
        }

        return string.Join(", ", healthArray); 
    }

    public List<Enemy> SortEnemies(List<Enemy> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (inputList[i].health < inputList[j].health)
                {
                    Enemy temp = inputList[i];
                    inputList.RemoveAt(i);
                    inputList.Insert(j, temp);
                    break;
                }
            }
        }
        targetEnemy = inputList[targetIndex];
        
        return inputList;
    }

    private void Update()
    {
        if (targetEnemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(ListToString(enemyList));
            enemyList = SortEnemies(enemyList);
            Debug.Log(ListToString(enemyList));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            targetIndex++;
            targetEnemy = enemyList[targetIndex];
        }

    }
}

