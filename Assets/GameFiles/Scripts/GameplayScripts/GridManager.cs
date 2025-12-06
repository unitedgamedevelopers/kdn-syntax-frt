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
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Public Core Functions
    // Dynamic grid setup to fit within the target display area
    public void GenerateGrid(int index)
    {
        gridData = gridDataHolder.GetGridDataByIndex(index);

        // Finalize total turns player would have throughout the game
        CardsGameManager.Instance.TotalTurns = gridData.TotalTurns;

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

        // Core card spawning mechanism
        List<CardData> dataPack = new List<CardData>();
        // Store card pairs data in a list
        int totalCardPairs = (gridData.Row * gridData.Column) / 2;
        CardData dataTemp = null;
        for (int i = 0; i < totalCardPairs; i++)
        {
            dataTemp = cardDataHolder.RetrieveCardData();
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

        // Assign card data to spawned card prefabs
        for (int i = 0; i < dataPack.Count; i++)
        {
            CardHandler ch = Instantiate(cardPrefab, gridParent).GetComponent<CardHandler>();
            ch.SetupCard(dataPack[i]);
        }
    }
    #endregion
}
