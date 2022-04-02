using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        var instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            Destroy(o);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateScoreWithValue(int value)
    {
        _score += value;
        Mathf.Clamp(_score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
