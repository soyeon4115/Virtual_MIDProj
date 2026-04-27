using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject citizen1;
    public GameObject citizen2;
    public GameObject old1;
    public GameObject old2;

    // Generate 간격, 시간
    public float span = 1.5f;
    float delta = 0;

    float[] lanes = { -0.1f, -1.65f, -3.5f };

    public float fastSpeed = 0.1f;
    public float slowSpeed = 0.05f;

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
        float y = lanes[lane];

        int direction = Random.Range(0, 2); // 좌 우 랜덤


        float speed = (type <= 1) ? fastSpeed : slowSpeed;

        if (direction == 0)
        {
            enemy.transform.position = new Vector3(-6.5f, y, 0);
            enemy.GetComponent<EnemyController>().vx = speed; // 오른쪽
        }
        else
        {
            enemy.transform.position = new Vector3(6.5f, y, 0);
            enemy.GetComponent<EnemyController>().vx = -speed; // 왼쪽
        }


        // 레이어 설정
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();

        if (lane == 0)
        {
            sr.sortingOrder = 1;
        }
        else if (lane == 1)
        {
            sr.sortingOrder = 2;
        }
        else if (lane == 2)
        {
            sr.sortingOrder = 3;
        }

        enemy.GetComponent<EnemyController>().waitTime = 0.5f;
    }
}