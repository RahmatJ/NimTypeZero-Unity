using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{

    private Card[] cards;
    public bool isTurn;
    private Card selectedCard;

    public GameObject selectedCardObject;

    public GameController gameController;

    public GameObject pointer;

    // Start is called before the first frame update
    void Start()
    {
        this.cards = this.GetComponentsInChildren<Card>();

        selectedCardObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetChild();
        SetCardsActive();
    }

    public void SetIsTurn(bool toggle)
    {
        this.isTurn = toggle;
    }

    public void SetCards(Card[] setCard)
    {
        this.cards = setCard;
    }

    public void SetCardsActive()
    {
        pointer.SetActive(this.isTurn);

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].SetIsActive(this.isTurn);
        }
    }

    public void SetSelectedCard(Card selected)
    {
        this.selectedCard = selected;

        Image selectedImage = selectedCardObject.GetComponent<Image>();

        selectedImage.sprite = selectedCard.imageCard;

        int valueCard = selectedCard.GetValueCard();

        gameController.EndTurn(valueCard);

        StartCoroutine(FLashCard());
    }

    public int GetCountCards()
    {
        return cards.Length;
    }

    public Card[] GetCards()
    {
        return this.cards;
    }

    public Card GetCardIndex(int idx)
    {
        this.cards = this.GetComponentsInChildren<Card>();

        return this.cards[idx];
    }

    void GetChild()
    {
        cards = this.GetComponentsInChildren<Card>();
    }

    IEnumerator FLashCard()
    {
        this.selectedCardObject.SetActive(true);
        yield return new WaitForSeconds(2);
        this.selectedCardObject.SetActive(false);

        //gameController.TurnChange();
    }

}
