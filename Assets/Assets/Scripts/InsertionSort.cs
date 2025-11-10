using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class InsertionSort : MonoBehaviour
{
    public List<Enemy> SortEnemies(List<Enemy> enemyList)
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (enemyList[i].health < enemyList[j].health)
                {
                    Enemy temp = enemyList[i];
                    enemyList.RemoveAt(i);
                    enemyList.Insert(j, temp);
                    break;
                }
            }
        }
        return enemyList;
    }
}
