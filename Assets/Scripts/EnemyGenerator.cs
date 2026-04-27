using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject citizen1;
    public GameObject citizen2;
    public GameObject old1;
    public GameObject old2;

    public float span = 1.5f;
    float delta = 0;

    float[] lanes = { -3.0f, -1.75f, -0.5f };
    int lastLane = -1;

    public float fastSpeed = 0.07f;
    public float slowSpeed = 0.04f;

    void Update()
    {
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy;

        int type = Random.Range(0, 4);


        if (type == 0)
            enemy = Instantiate(citizen1);
        else if (type == 1)
            enemy = Instantiate(citizen2);
        else if (type == 2)
            enemy = Instantiate(old1);
        else
            enemy = Instantiate(old2);



        int lane = Random.Range(0, lanes.Length);
        while (lane == lastLane)
        {
            lane = Random.Range(0, lanes.Length);
        }

        lastLane = lane;
        float y = lanes[lane];

        int direction = Random.Range(0, 2);


        float speed = (type <= 1) ? fastSpeed : slowSpeed;

        if (direction == 0)
        {
            enemy.transform.position = new Vector3(-6.5f, y, 0);
            enemy.GetComponent<EnemyController>().vx = speed;
        }
        else
        {
            enemy.transform.position = new Vector3(6.5f, y, 0);
            enemy.GetComponent<EnemyController>().vx = -speed;
        }

        enemy.GetComponent<EnemyController>().waitTime = 0.5f;
    }
}