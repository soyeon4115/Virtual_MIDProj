using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public GameObject meron;
    public GameObject chocolate;
    public GameObject cake;

    public Image uiMeron;
    public Image uiChocolate;
    public Image uiCake;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    int hp = 3;
    float score = 0;
    float timeLimit = 60.0f;

    bool isGameOver = false;

    void Start()
    {
        chocolate = GameObject.Find("HP_0");
        meron = GameObject.Find("HP_2");
        cake = GameObject.Find("HP_5");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        timeLimit -= Time.deltaTime;
        if (timeLimit < 0)
        {
            timeLimit = 0;
        }

        if (timeText != null)
        {
            timeText.text = "제한시간:\n" + timeLimit.ToString("F1");
        }

        score += 10 * Time.deltaTime;

        if (scoreText != null)
        {
            scoreText.text = "점수: " + (int)score;
        }

        if (timeLimit <= 0 || hp <= 0)
        {
            GameOver();
        }
    }

    public void DecreaseHp()
    {
        if (isGameOver) return;

        hp -= 1;
        score -= 30;

        if (score < 0)
        {
            score = 0;
        }

        if (hp == 2)
        {
            meron.SetActive(false);
        }
        else if (hp == 1)
        {
            chocolate.SetActive(false);
        }
        else if (hp == 0)
        {
            cake.SetActive(false);
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        // 기존 UI 숨김
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(false);
        }

        if (timeText != null)
        {
            timeText.gameObject.SetActive(false);
        }

        if (meron != null) meron.SetActive(false);
        if (chocolate != null) chocolate.SetActive(false);
        if (cake != null) cake.SetActive(false);

        // 최종 점수 먼저 넣기
        if (finalScoreText != null)
        {
            finalScoreText.text = "게임오버!!\n\n최종 점수: " + (int)score;
        }

        // 그 다음 패널 켜기
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
    }
}