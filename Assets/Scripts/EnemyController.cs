using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float vx; // 좌우로 움직이는 속도
    public float waitTime = 0.5f;

    GameObject player;
    GameObject director;

    void Start()
    {
        player = GameObject.Find("character_0");
        director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        // 처음 0.5초는 정지
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            return;
        }

        // 좌우 이동
        transform.Translate(vx, 0, 0);

        // 화면 밖으로 충분히 나간 뒤 삭제
        if (transform.position.x < -8.5f || transform.position.x > 8.5f)
        {
            Destroy(gameObject);
        }

        // 플레이어 충돌 판정
        if (player != null)
        {
            Vector2 p1 = transform.position;
            Vector2 p2 = player.transform.position;
            Vector2 dir = p1 - p2;

            float d = dir.magnitude;
            float r1 = 0.7f;
            float r2 = 0.7f;

            if (d < r1 + r2)
            {
                if (director != null)
                {
                    director.GetComponent<GameDirector>().DecreaseHp();
                }

                Destroy(gameObject);
            }
        }
    }
}