using TMPro;
using UnityEngine;

public class UiGameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        var score = _scoreKeeper.Score.ToString("000000000");
        scoreText.text = $"You scored:\n{score}";
    }
}
