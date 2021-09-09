using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;

    private int score;

    public int Score
    {
        get { return score; }
        set { score = value;
            uiManager.scoreText.text = value.ToString();
        }
    }


    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Defeat()
    {
        uiManager.Defeat();
    }
}
