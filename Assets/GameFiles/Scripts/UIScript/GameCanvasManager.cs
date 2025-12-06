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
    [SerializeField] private GameOverUIHandler gameOverUIHandler = null;
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

        SwitchCanvasUIScreen(UIScreen.MainMenuUI);
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
                gameOverUIHandler.gameObject.SetActive(false);
                break;
            case UIScreen.GameplayUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(true);
                gameOverUIHandler.gameObject.SetActive(false);
                break;
            case UIScreen.DefeatUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(false);
                gameOverUIHandler.gameObject.SetActive(true);
                gameOverUIHandler.DisplayDefeatUI();
                break;
            case UIScreen.VictoryUI:
                mainMenuUIHandler.gameObject.SetActive(false);
                gameplayUIHandler.gameObject.SetActive(false);
                gameOverUIHandler.gameObject.SetActive(true);
                gameOverUIHandler.DisplayVictoryUI();
                break;
        }
    }
    #endregion
}
