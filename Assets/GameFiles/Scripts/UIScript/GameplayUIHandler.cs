using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUIHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private MainMenuUIHandler mainMenuUIHandler = null;
    [SerializeField] private GridManager gridManager = null;
    [SerializeField] private TextMeshProUGUI totalMatchesTMP = null;
    [SerializeField] private TextMeshProUGUI turnsRemainingTMP = null;
    [SerializeField] private TextMeshProUGUI playerScoreTMP = null;

    private bool isLoadingSavedGame = false;
    private CardsGameManager cardsGameManager = null;
    #endregion

    #region MonoBehaviour Functions
    private void OnEnable()
    {
        cardsGameManager = CardsGameManager.Instance;
        if (!IsLoadingSavedGame)
        {
            gridManager.GenerateGrid(mainMenuUIHandler.GridIndex);
            gridManager.SpawnCards();
        }
        else
        {
            gridManager.GenerateGrid(SavedGame.gridDataIndex);
            gridManager.LoadSavedCards(SavedGame);
        }

        UpdateTurnsRemainingTMP(cardsGameManager.TotalTurns.ToString());
        UpdateTotalMatchesTMP(cardsGameManager.TotalPlayerCardMatches.ToString());
        UpdatePlayerScoreTMP(cardsGameManager.PlayerScore.ToString());
    }
    #endregion

    #region Getter And Setter
    public bool IsLoadingSavedGame { get => isLoadingSavedGame; set => isLoadingSavedGame = value; }

    public SaveData SavedGame { get; set; }
    #endregion

    #region UI Functions
    public void OnClick_RetryBtn()
    {
        gridManager.RegenerateGrid();

        UpdateTurnsRemainingTMP(cardsGameManager.TotalTurns.ToString());
        UpdateTotalMatchesTMP(cardsGameManager.TotalPlayerCardMatches.ToString());
        UpdatePlayerScoreTMP(cardsGameManager.PlayerScore.ToString());
    }

    // Update total number of matches
    public void UpdateTotalMatchesTMP(string txt)
    {
        totalMatchesTMP.SetText("Matches:\n"+txt);
    }

    // Update turns remaining
    public void UpdateTurnsRemainingTMP(string txt)
    {
        turnsRemainingTMP.SetText("Total Turns:\n"+txt);
    }

    // Update player score
    public void UpdatePlayerScoreTMP(string txt)
    {
        playerScoreTMP.SetText("Score: " + txt);
    }

    // Save game on btn click
    public void OnClick_SaveGame()
    {
        // Save current game
        GameSaveLoadManager.ClearSavedGame();

        List<CardState> cards = new List<CardState>();
        foreach (CardHandler ch in gridManager.cardHandlers)
        {
            CardState cs = new CardState();
            cs.cardDataIndex = gridManager.CardData_Holder.GetIndexOfCardData(ch.CurrentCardData);
            cs.isMatched = ch.IsMatched;
            cards.Add(cs);
        }

        GameSaveLoadManager.SaveGame(gridManager.gridDataIndex, cardsGameManager.TotalPlayerCardMatches, cardsGameManager.TotalTurns, cardsGameManager.PlayerScore, cardsGameManager.playerScoreCombo, cards);
    }
    #endregion
}
