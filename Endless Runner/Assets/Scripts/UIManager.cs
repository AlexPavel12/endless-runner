using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu, gameplay, defeat;
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
