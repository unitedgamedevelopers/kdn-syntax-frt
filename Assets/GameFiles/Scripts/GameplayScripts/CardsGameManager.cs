using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsGameManager : MonoBehaviour
{
    #region Properties
    public static CardsGameManager Instance { get; private set; }

    [Header("Attributes")]
    [SerializeField] private float cardCompareBuffer = 0f;  // Card comparison delay

    private CardHandler firstCardInPair = null;
    private GameplayUIHandler gameplayUIHandler = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        // Setup gameplay UI handler reference
        gameplayUIHandler = GameCanvasManager.Instance.Gameplay_UIHandler;
    }
    #endregion

    #region Getter And Setter
    public int TotalMatches { get; private set; }

    public int TotalTurns { get; set; }
    #endregion

    #region Public Core Functions
    // Stores flipped card and triggers comparison when a pair is complete
    public void StoreFlippedCardData(CardHandler ch)
    {
        TotalTurns--;
        gameplayUIHandler.UpdateTurnsRemainingTMP("Total Turns:\n" + TotalTurns.ToString());

        if (firstCardInPair == null)
        {
            firstCardInPair = ch;
        }
        else
        {
            // Compare on pair completion
            StartCoroutine(CompareCardsForMatch(firstCardInPair, ch));
            firstCardInPair = null;
        }
    }
    #endregion

    #region Coroutines
    // Compare cards on unfold
    private IEnumerator CompareCardsForMatch(CardHandler card_1, CardHandler card_2)
    {
        yield return new WaitForSeconds(cardCompareBuffer);

        if (card_1.CurrentCardData.GetCardID == card_2.CurrentCardData.GetCardID)
        {
            TotalMatches++;
            gameplayUIHandler.UpdateTotalMatchesTMP("Matches:\n" + TotalMatches.ToString());
        }
        else
        {
            card_1.FoldCard();
            card_2.FoldCard();
        }
    }
    #endregion
}
