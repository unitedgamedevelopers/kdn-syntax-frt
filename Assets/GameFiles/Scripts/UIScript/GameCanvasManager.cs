using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    #region Properties
    public static GameCanvasManager Instance { get; private set; }

    [Header("UI Screen Reference")]
    [SerializeField] private MainMenuUIHandler mainMenuUIHandler = null;
    [SerializeField] private GameplayUIHandler gameplayUIHandler = null;
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

    #region Getter And Setter
    public MainMenuUIHandler MainMenu_UIHandler => mainMenuUIHandler;

    public GameplayUIHandler Gameplay_UIHandler => gameplayUIHandler;
    #endregion

    #region Public Core Functions
    // Switch UI screens on call
    public void SwitchCanvasUIScreen(UIScreen screen)
    {
        switch (screen)
        {
            case UIScreen.MainMenuUI:
                mainMenuUIHandler.gameObject.SetActive(true);
                gameplayUIHandler.gameObject.SetActive(false);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(false);
                break;
            case UIScreen.GameplayUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(true);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(false);
                break;
            case UIScreen.GameOverUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(false);
                gameOverUIObj.SetActive(true);
                victoryUIObj.SetActive(false);

                AudioManager.Instance.PlayGameOverSFX();
                break;
            case UIScreen.VictoryUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(false);
                gameOverUIObj.SetActive(false);
                victoryUIObj.SetActive(true);

                AudioManager.Instance.PlayVictorySFX();
                break;
        }
    }
    #endregion
}
