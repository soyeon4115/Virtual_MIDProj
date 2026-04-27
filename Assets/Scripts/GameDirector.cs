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

    public Sprite crushedMeron;
    public Sprite crushedChocolate;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    public AudioClip dropSound;
    public AudioClip gangNamSound;

    bool playedGangNam = false;

    int hp = 3;
    float score = 0;
    float timeLimit = 60.0f;

    bool isGameOver = false;

    void Start()
    {

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

        if (timeLimit <= 20.0f && !playedGangNam)
        {
            GetComponent<AudioSource>().PlayOneShot(gangNamSound);
            playedGangNam = true;
        }

        if (timeLimit <= 0 || hp <= 0)
        {
            GameOver();
        }
    }

    public void DecreaseHp()
    {
        if (isGameOver) return;

        GetComponent<AudioSource>().PlayOneShot(dropSound);

        hp -= 1;
        score -= 30;
        if (score < 0) score = 0;

        if (hp == 2)
        {
            meron.SetActive(false);
            uiMeron.sprite = crushedMeron;
        }
        else if (hp == 1)
        {
            chocolate.SetActive(false);
            uiChocolate.sprite = crushedChocolate;
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

        if (finalScoreText != null)
        {
            finalScoreText.text = "게임종료!!\n\n최종 점수: " + (int)score;
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
    }
}