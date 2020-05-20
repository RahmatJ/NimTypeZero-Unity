using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Hand[] hands;
    private int sum;

    //public Image selectedImage;

    private int turn;

    public Text sumText;

    public GameObject panelGameOver;
    public Text textGameOver;

    private Hand loser;

    private Deck deck;

    // Start is called before the first frame update
    void Start()
    {

        panelGameOver.SetActive(false);

        sum = 0;

        turn = 0;

        SetHandActive(turn);

        deck = this.GetComponent<Deck>();

        Dictionary<int, List<int>> listValue = deck.DistributeCards();
        
        for (int i = 0; i < 4; i++)
        {
            Hand currentHand = hands[i];

            List<int> currentList = listValue[i];

            Card[] cards = new Card[4];

            Debug.Log("Name : " + currentHand.name.ToString());

            for (int j = 0; j < 4; j++)
            {
                Card setCard = currentHand.GetCardIndex(j);

                int idx = currentList[j];

                Debug.Log("Name + " + setCard.name.ToString() + " Value : " + setCard.GetValueCard().ToString());

                cards[j] = deck.SetCardValue(setCard, idx);

                Debug.Log("Name + "+ setCard.name.ToString() +" Value : " + setCard.GetValueCard().ToString());
            }

            hands[i].SetCards(cards);

        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(loser != null)
        {
            Debug.Log("Loser : " + loser.name.ToString());
        }
        */
    }

    public void EndTurn(int value)
    {
        sum += value;

        sumText.text = sum.ToString();

        if (CheckSum())
        {
            loser = hands[turn];
            EndGame();
        }
        else
        {
            Debug.Log("Sum : " + sum.ToString());

            TurnChange();
        }

        
    }

    bool CheckSum()
    {
        if(this.sum > 9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void EndGame()
    {
        //inactive all button

        foreach (Hand currHand in hands)
        {
            currHand.SetIsTurn(false);
            currHand.SetCardsActive();
        }

        Debug.Log("Loser : " + loser.name.ToString());
        string loserString = "Loser !!!\n" + loser.name.ToString();
        //display Panel Endgame

        panelGameOver.SetActive(true);
        textGameOver.text = loserString;

    }

    void SetHandActive(int currentTurn)
    {
        for (int i = 0; i < hands.Length; i++)
        {
            if(i == currentTurn)
            {
                hands[i].SetIsTurn(true);
                
                continue;
            }
            hands[i].SetIsTurn(false);
        }
    }

    public void TurnChange()
    {
        turn = (turn + 1) % 4;

        SetHandActive(turn);

        Debug.Log("Turn : " + turn.ToString());
    }
}
