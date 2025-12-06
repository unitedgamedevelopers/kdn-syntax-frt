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

    private GridData gridData = null;
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Public Core Functions
    // Dynamic grid setup to fit within the target display area
    public void GenerateGrid(int index)
    {
        gridData = gridDataHolder.GetGridDataByIndex(index);

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

        int totalCards = gridData.Row * gridData.Column;
        for (int i = 0; i < totalCards; i++)
        {
            Instantiate(cardPrefab, gridParent);
        }
    }
    #endregion
}
