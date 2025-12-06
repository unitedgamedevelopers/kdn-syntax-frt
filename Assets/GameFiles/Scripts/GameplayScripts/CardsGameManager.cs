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
    public int TotalPlayerMatches { get; set; }

    public int TotalPairToMatch { get; set; }

    public int TotalTurns { get; set; }
    #endregion

    #region Public Core Functions
    // Stores flipped card and triggers comparison when a pair is complete
    public void StoreFlippedCardData(CardHandler ch)
    {
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
            AudioManager.Instance.PlayCardMatchSFX();

            card_1.IsMatched = true;
            card_2.IsMatched = true;
            TotalPlayerMatches++;
            gameplayUIHandler.UpdateTotalMatchesTMP(TotalPlayerMatches.ToString());
        }
        else
        {
            AudioManager.Instance.PlayCardMismatchSFX();

            card_1.FoldCard();
            card_2.FoldCard();
        }

        TotalTurns--;
        gameplayUIHandler.UpdateTurnsRemainingTMP(TotalTurns.ToString());

        if (TotalTurns <= 0)
        {
            GameCanvasManager.Instance.SwitchCanvasUIScreen(UIScreen.DefeatUI);
        }
        else if (TotalPairToMatch == TotalPlayerMatches)
        {
            GameCanvasManager.Instance.SwitchCanvasUIScreen(UIScreen.VictoryUI);
        }
    }
    #endregion
}
