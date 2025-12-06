using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    #region Properties
    public static GameCanvasManager Instance { get; private set; }

    [Header("UI Screen Reference")]
    [SerializeField] private GameObject mainMenuUIObj = null;
    [SerializeField] private GameObject gameplayUIObj = null;
    [SerializeField] private GameObject gameOverUIObj = null;
    [SerializeField] private GameObject victoryUIObj = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }
    #endregion

    #region Public Core Functions
    // Switch UI screens on call
    public void SwitchCanvasUIScreen(UIScreen screen)
    {
        switch (screen)
        {
            case UIScreen.MainMenuUI:
                mainMenuUIObj.SetActive(true);
                gameplayUIObj.SetActive(false);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(false);
                break;
            case UIScreen.GameplayUI:
                mainMenuUIObj.SetActive(false);
                gameplayUIObj.SetActive(true);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(false);
                break;
            case UIScreen.GameOverUI:
                mainMenuUIObj.SetActive(false);
                gameplayUIObj.SetActive(false);
                gameOverUIObj.SetActive(true);
                victoryUIObj.SetActive(false);
                break;
            case UIScreen.VictoryUI:
                mainMenuUIObj.SetActive(false);
                gameplayUIObj.SetActive(false);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(true);
                break;
        }
    }
    #endregion
}
