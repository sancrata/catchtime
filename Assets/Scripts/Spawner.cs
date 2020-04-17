using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject bomb;
    public float xBound, yBound;
    

    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject()
    {
        if (ScoreController.instance.gameOver == false)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));

            int randomFruit = Random.Range(0, fruits.Length);

            if (Random.value <= .6f)
                Instantiate(fruits[randomFruit], new Vector2(Random.Range(-xBound, xBound), yBound), Quaternion.identity);
            else
                Instantiate(bomb, new Vector2(Random.Range(-xBound, xBound), yBound), Quaternion.identity);

            StartCoroutine(SpawnRandomGameObject());
        }
    }
  
}
