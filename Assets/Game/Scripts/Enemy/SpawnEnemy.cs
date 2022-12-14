using Random=System.Random;
using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] BoxCollider2D spawArea;
    double rangeX;
    double rangeY;
    Vector3 spawnPos;
    Random rand = new Random();

    void Start()
    {
        rangeX = -11 - 6;
        rangeY = -1 - -2;
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {

        while(true) {
            double sampleX = rand.NextDouble();
            double scaledX = (sampleX * rangeX) + 6;
            float f = (float)scaledX;

            double sampleY = rand.NextDouble();
            double scaledY = (sampleY * rangeY) + -2;
            float j = (float)scaledY;

            spawnPos = new Vector3(f, j, 0f);

            yield return new WaitForSeconds(10f);
            GameObject newObject = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
