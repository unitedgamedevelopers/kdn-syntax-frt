using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUIHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private TextMeshProUGUI gameOverUIHeaderTMP = null;
    [SerializeField] private TextMeshProUGUI totalMatchesTMP = null;
    [SerializeField] private TextMeshProUGUI totalTurnsLeftTMP = null;
    #endregion

    #region Public Core Functions
    public void DisplayVictoryUI()
    {
        gameOverUIHeaderTMP.SetText("Victory");
        totalMatchesTMP.SetText("Matches: " + CardsGameManager.Instance.TotalPlayerMatches);
        totalTurnsLeftTMP.SetText("Turns Left: " + CardsGameManager.Instance.TotalTurns);

        AudioManager.Instance.PlayVictorySFX();
    }

    public void DisplayDefeatUI()
    {
        gameOverUIHeaderTMP.SetText("Defeat");
        totalMatchesTMP.SetText("Matches: " + CardsGameManager.Instance.TotalPlayerMatches + " - Matches To Win: " + CardsGameManager.Instance.TotalPairToMatch);
        totalTurnsLeftTMP.SetText("Turns Left: " + CardsGameManager.Instance.TotalTurns);

        AudioManager.Instance.PlayDefeatSFX();
    }
    #endregion

    #region Btn Events Functions
    public void OnClick_HomeBtn()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
