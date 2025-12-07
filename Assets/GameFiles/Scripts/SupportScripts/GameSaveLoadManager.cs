using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int gridDataIndex;
    public int totalMatches;
    public int totalTurnsLeft;
    public int playerScore;
    public int playerScoreCombo;
    public List<CardState> cards;
}

[System.Serializable]
public class CardState
{
    public bool isMatched;
    public int cardDataIndex;
};

public class GameSaveLoadManager : MonoBehaviour
{
    #region Properties
    private const string SaveGameKey = "CardMatchSave";
    #endregion

    #region Public Core Functions
    // Save game on call
    public static void SaveGame(int gridDataIndex, int totalMatches, int totalTurnsLeft, int playerScore, int playerScoreCombo, List<CardState> cards)
    {
        SaveData data = new SaveData
        {
            gridDataIndex = gridDataIndex,
            totalMatches = totalMatches,
            totalTurnsLeft = totalTurnsLeft,
            playerScore = playerScore,
            playerScoreCombo = playerScoreCombo,
            cards = cards
        };

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveGameKey, json);
        PlayerPrefs.Save();
    }

    // Load saved game on call
    public static SaveData LoadGame()
    {
        if (!PlayerPrefs.HasKey(SaveGameKey))
        {
            return null;
        }
        else
        {
            string json = PlayerPrefs.GetString(SaveGameKey);
            return JsonUtility.FromJson<SaveData>(json);
        }
    }

    // Clear already existing or saved game
    public static void ClearSavedGame()
    {
        PlayerPrefs.DeleteKey(SaveGameKey); 
    }
    #endregion
}
