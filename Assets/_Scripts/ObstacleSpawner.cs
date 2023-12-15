using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField, Range(0, 7)] private float topPointOffset = 0;
    [SerializeField, Range(0, 7)] private float bottomPointOffset = 0;
    [SerializeField] private Transform initialSpawn;
    private bool stop = false;

    private void OnEnable()
    {
        Actions.OnHit += StopSpawn;
        Actions.OnEnableObstacleSpawner += StartGame;
    }

    private void OnDisable()
    {
        Actions.OnHit -= StopSpawn;
        Actions.OnEnableObstacleSpawner -= StartGame;
    }

    private void StopSpawn()
    {
        stop = true;
        StopAllCoroutines();
    }

    private void Awake()
    {
        stop = true;
    }

    private void StartGame()
    {
        stop = false;
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (!stop)
        {
            GameObject spawnedObj = Instantiate(obstacle, initialSpawn.position, Quaternion.identity);
            spawnedObj.transform.position = new Vector2(this.transform.position.x, SpawnPoint(spawnedObj));
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private float SpawnPoint(GameObject spawnedObj)
    {
        BoxCollider2D entry = spawnedObj.transform.GetChild(2).GetComponent<BoxCollider2D>();
        float topEdgeOffset = Vector2.Distance(entry.transform.position, new Vector2(entry.transform.position.x, entry.bounds.max.y));
        float bottomEdgeOffset = Vector2.Distance(entry.transform.position, new Vector2(entry.transform.position.x, entry.bounds.min.y));
        float spawnPoint = Random.Range(pointA.position.y - topPointOffset - topEdgeOffset, pointB.position.y + bottomPointOffset + bottomEdgeOffset);
        return spawnPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 newPointA = new Vector2(pointA.position.x, pointA.position.y - topPointOffset);
        Vector2 newPointB = new Vector2(pointB.position.x, pointB.position.y + bottomPointOffset);
        Gizmos.DrawLine(newPointA, newPointB);
    }
}
