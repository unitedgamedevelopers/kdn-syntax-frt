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
    #endregion

    #region MonoBehaviour Functions
    private void OnEnable()
    {
        gridManager.GenerateGrid(mainMenuUIHandler.GridIndex);
    }
    #endregion

    #region UI Functions
    public void OnClick_RetryBtn()
    {
        // Todo: retry same grid 
    }

    // Update total number of matches
    public void UpdateTotalMatchesTMP(string txt)
    {
        totalMatchesTMP.SetText(txt);
    }

    // Update turns remaining
    public void UpdateTurnsRemainingTMP(string txt)
    {
        turnsRemainingTMP.SetText(txt);
    }

    // Save game on btn click
    public void OnClick_SaveGame()
    {
        // Todo: save game on call
    }
    #endregion
}
