using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData   // Card data class which includes cardID and card icon sprite
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private Card_ID cardID = Card_ID.None;
    [SerializeField] private Sprite iconSprite = null;
    #endregion

    #region Getter And Setter
    public Card_ID GetCardID { get => cardID; }

    public Sprite GetIconSprite { get => iconSprite; }
    #endregion
}

[CreateAssetMenu(fileName = "CardDataHolder", menuName = "ScriptableObjects/CardDataHolder")]
public class CardDataHolder : ScriptableObject
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private CardData[] cardDataHolder = null;

    private int cardDataIndex = 0;
    #endregion

    #region Public Core Functions
    // Get random card data which includes cardID and card icon sprite
    public CardData RetrieveCardData()
    {
        cardDataIndex = Random.Range(0, cardDataHolder.Length);
        return cardDataHolder[cardDataIndex];
    }
    #endregion
}
