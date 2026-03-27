using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float minInterval = 0.8f;
    public float maxInterval = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitUntil(() => GameManager.instance != null);
        yield return new WaitUntil(() => GameManager.instance.isRunning);

        while (true)
        {
            if (!GameManager.instance.isRunning)
            {
                yield return new WaitUntil(() => GameManager.instance.isRunning);
            }

            int index = Random.Range(0, obstaclePrefabs.Length);
            GameObject obs = Instantiate(
                obstaclePrefabs[index],
                transform.position,
                Quaternion.identity);


            UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(
                obs,
                gameObject.scene);

            float speed = GameManager.instance.groundEffector.speed;
            float t = Mathf.InverseLerp(6f, 20f, speed);
            float interval = Mathf.Lerp(maxInterval, minInterval, t);
            interval += Random.Range(-0.2f, 0.2f);
            interval = Mathf.Max(interval, minInterval);

            yield return new WaitForSeconds(interval);
        }
    }
}