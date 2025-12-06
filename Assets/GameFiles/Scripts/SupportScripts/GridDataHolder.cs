using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridData
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private int row = 0;
    [SerializeField] private int col = 0;
    #endregion

    #region Getter And Setter
    public int Row => row;

    public int Column => col;
    #endregion
}

[CreateAssetMenu(fileName = "GridDataHolder", menuName = "ScriptableObjects/GridDataHolder")]
public class GridDataHolder : ScriptableObject
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private List<GridData> gridDataPack = new List<GridData>();
    #endregion

    #region Public Core Functions
    public GridData GetGridDataByIndex(int index)
    {
        return gridDataPack[index];
    }
    #endregion
}
