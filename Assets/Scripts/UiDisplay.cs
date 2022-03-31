using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private Health playerHealth;

    [Header("Score")]
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = _scoreKeeper.Score.ToString();
    }
}
