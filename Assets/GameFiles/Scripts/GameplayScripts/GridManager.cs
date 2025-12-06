using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private GameObject cardPrefab = null;
    [SerializeField] private GridLayoutGroup gridLayout = null;
    [SerializeField] private Transform gridParent = null;
    [SerializeField] private GridDataHolder gridDataHolder = null;
    [SerializeField] private CardDataHolder cardDataHolder = null;

    private GridData gridData = null;
    internal List<CardHandler> cardHandlers = new List<CardHandler>();
    internal int gridDataIndex = 0;
    #endregion

    #region Getter And Setter
    public CardDataHolder CardData_Holder => cardDataHolder;
    #endregion

    #region Public Core Functions
    // Dynamic grid setup to fit within the target display area
    public void GenerateGrid(int index)
    {
        gridData = gridDataHolder.GetGridDataByIndex(index);
        gridDataIndex = index;

        foreach (Transform c in gridParent)
        {
            Destroy(c.gameObject);
        }

        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = gridData.Column;

        Vector2 spacing = gridLayout.spacing;
        RectOffset padding = gridLayout.padding;

        RectTransform parentRect = gridParent.GetComponent<RectTransform>();
        float cellWidth = (parentRect.rect.width - (spacing.x * (gridData.Column - 1)) - padding.left - padding.right) / gridData.Column;
        float cellHeight = (parentRect.rect.height - (spacing.y * (gridData.Row - 1)) - padding.top - padding.bottom) / gridData.Row;
        gridLayout.cellSize = new Vector2(cellWidth, cellHeight);
    }

    // Spawn cards on call
    public void SpawnCards()
    {
        // Set total turns count for player and reset player score
        CardsGameManager.Instance.TotalTurns = gridData.TotalTurns;
        CardsGameManager.Instance.TotalPlayerMatches = 0;

        // Core card spawning mechanism
        List<CardData> dataPack = new List<CardData>();

        // Store card pairs data in a list
        int totalCardPairs = (gridData.Row * gridData.Column) / 2;
        CardData dataTemp = null;
        for (int i = 0; i < totalCardPairs; i++)
        {
            dataTemp = cardDataHolder.RetrieveRandomCardData();
            dataPack.Add(dataTemp);
            dataPack.Add(dataTemp);
        }

        // Shuffle card data
        for (int i = 0; i < dataPack.Count; i++)
        {
            int randomIndex = Random.Range(0, dataPack.Count);
            dataTemp = dataPack[i];
            dataPack[i] = dataPack[randomIndex];
            dataPack[randomIndex] = dataTemp;
        }

        cardHandlers.Clear();
        // Assign card data to spawned card prefabs
        for (int i = 0; i < dataPack.Count; i++)
        {
            CardHandler ch = Instantiate(cardPrefab, gridParent).GetComponent<CardHandler>();
            cardHandlers.Add(ch);
            ch.SetupCard(dataPack[i]);
        }
        CardsGameManager.Instance.TotalPairToMatch = cardHandlers.Count / 2;
    }

    // Load and retrieve saved cards data
    public void LoadSavedCards(SaveData data)
    {
        // Set total turns count for player and reset player score
        CardsGameManager.Instance.TotalTurns = data.totalTurnsLeft;
        CardsGameManager.Instance.TotalPlayerMatches = data.totalMatches;

        cardHandlers.Clear();
        // Assign card data to spawned card prefabs
        for (int i = 0; i < data.cards.Count; i++)
        {
            CardHandler ch = Instantiate(cardPrefab, gridParent).GetComponent<CardHandler>();
            cardHandlers.Add(ch);
            print(data.cards[i].cardDataIndex);
            ch.SetupCard(CardData_Holder.RetrieveCardDataByIndex(data.cards[i].cardDataIndex), data.cards[i].isMatched);
        }
        CardsGameManager.Instance.TotalPairToMatch = cardHandlers.Count / 2;
    }

    // Regenerate entire grid
    public void RegenerateGrid()
    {
        // Clear all previous cards
        foreach (Transform c in gridParent)
        {
            Destroy(c.gameObject);
        }

        SpawnCards();
    }
    #endregion
}
