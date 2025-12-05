using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour, IPointerClickHandler
{
    #region Properties
    [Header("Attributes")]
    [SerializeField] private float flipDuration = 0.5f;
    [SerializeField] private float elapsed = 0f;

    [Header("Components Reference")]
    [SerializeField] private Image cardIconImg = null;

    private bool isFrontVisible = false;
    private bool isFlippingCard = false;
    #endregion

    #region Getter And Setter
    public CardData CurrentCardData { get; set; }
    #endregion

    #region Interface Functions
    // Testing
    private void Start()
    {
        SetupCard(CardsManager.Instance.cardDataHolder.RetrieveCardData());
    }

    // On click event for card (Flips card when user click/touch any card)
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isFlippingCard)
        {
            StartCoroutine(FlipCard(!isFrontVisible));
        }
    }
    #endregion

    #region Public Core Functions
    // Setup card on call
    public void SetupCard(CardData data)
    {
        CurrentCardData = data;
        cardIconImg.sprite = CurrentCardData.GetIconSprite;
    }
    #endregion

    #region Coroutines
    // Card flipping animation coroutine
    private IEnumerator FlipCard(bool showFront)
    {
        isFlippingCard = true;
        elapsed = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0, showFront ? 180 : 0, 0);

        // Flip card within fixed time frame i.e flip duration
        while (elapsed < flipDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / flipDuration;

            transform.rotation = Quaternion.Slerp(startRot, endRot, t);
        
            if (t>=0.5f && cardIconImg.enabled != showFront)
            {
                cardIconImg.enabled = showFront;
            }

            yield return null;
        }

        transform.rotation = endRot;
        isFrontVisible = showFront;
        isFlippingCard = false;
    }
    #endregion
}
