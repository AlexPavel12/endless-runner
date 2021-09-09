using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu, gameplay, defeat;
    public Text scoreText;

    private void Start()
    {
        GameManager.instance.uiManager = this;
    }

    public void Defeat()
    {
        gameplay.SetActive(false);
        defeat.SetActive(true);
    }
}
