using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SurfaceEffector2D groundEffector;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public float baseSpeed = 6f;
    public float maxSpeed = 20f;
    public float speedIncrement = 0.5f;
    public float phaseInterval = 10f;
    public bool isRunning = false;
    private float score;
    private float hiScore;
    private float phaseTimer;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    void Start()
    {
        hiScore = PlayerPrefs.GetFloat("HiScore", 0);
        isRunning = false;
        groundEffector.speed = 0;
        score = 0;
        if (startPanel != null) startPanel.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (hiScoreText != null) hiScoreText.text = "Recorde: 0";
        if (scoreText != null) scoreText.text = "Pontos: 0";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRunning) StartGame();
        }

        if (!isRunning) return;

        score += Time.deltaTime * groundEffector.speed * 2f;
        if (scoreText != null)
            scoreText.text = "Pontos: " + Mathf.FloorToInt(score);

        phaseTimer += Time.deltaTime;
        if (phaseTimer >= phaseInterval)
        {
            phaseTimer = 0f;
            groundEffector.speed = Mathf.Min(
                groundEffector.speed + speedIncrement, maxSpeed);
        }
    }

    public void StartGame()
    {
        score = 0;
        phaseTimer = 0;
        isRunning = true;
        groundEffector.speed = baseSpeed;
        if (startPanel != null) startPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        isRunning = false;
        groundEffector.speed = 0;
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
            PlayerPrefs.Save();
        }
        if (hiScoreText != null)
            hiScoreText.text = "Recorde: " + Mathf.FloorToInt(hiScore);
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }
}