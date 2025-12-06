using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private GameObject cardPrefab = null;
    [SerializeField] private GridLayoutGroup grid = null;
    #endregion

    #region MonoBehaviour Functions
    #endregion

    #region Public Core Functions
    public void SetupCardsGrid()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(cardPrefab, transform.position, Quaternion.identity, transform);
        }
    }
    #endregion
}
