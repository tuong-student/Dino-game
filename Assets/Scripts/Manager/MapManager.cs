using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject longObstacle, shortObstacle;
    [SerializeField] float2 maxRangeXLong;
    [SerializeField] float2 maxRangeXShort;

    public float speed = 5;

    private void Start()
    {
        StartCoroutine(SpawnLongObstacle());
        StartCoroutine(SpawnShortObstacle());
    }

    private void Update()
    {
        speed += 0.05f * Time.deltaTime;
    }

    IEnumerator SpawnLongObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(10, 30) / speed);
            if (!GameManager.GetInstance.isEndGame)
            {
                GameObject newObj = Instantiate(longObstacle, this.transform);
                Vector2 pos = newObj.transform.position;
                pos.y = UnityEngine.Random.Range(maxRangeXLong.x, maxRangeXLong.y);
                newObj.transform.position = pos;

                newObj.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0f, 0f);
            }
        }
    }

    IEnumerator SpawnShortObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(30, 50) / speed);
            if (!GameManager.GetInstance.isEndGame)
            {
                GameObject newObj = Instantiate(shortObstacle, this.transform);
                Vector2 pos = newObj.transform.position;
                pos.y = UnityEngine.Random.Range(maxRangeXShort.x, maxRangeXShort.y);
                newObj.transform.position = pos;

                newObj.GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0f, 0f);
            }
        }
    }
}
