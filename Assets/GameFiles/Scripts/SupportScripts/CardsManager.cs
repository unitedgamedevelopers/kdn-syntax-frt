using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    #region Properties
    public static CardsManager Instance = null;

    [Header("Components Reference")]
    [SerializeField] internal CardDataHolder cardDataHolder = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(this.gameObject);
        }

        Instance = this;
    }
    #endregion
}
