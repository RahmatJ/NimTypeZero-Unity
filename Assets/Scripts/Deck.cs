using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{

    private List<int> cardIdxs;
    public Sprite[] imageSource;
    public Sprite backgroundImage;
    private GameController gameController;
    public Card card;

    int count;

    void InitializeDeck()
    {

        Dictionary<int, int> indexList = new Dictionary<int, int>()
        {
            {0,0 },
            {1,0 },
            {2,0 },
            {3,0 }
        };

        bool Builded = true;

        while (Builded)
        {

            int idx = Random.Range(0, 4);

            int countOnIdx = indexList[indexList.Keys.ElementAt(idx)];

            if (countOnIdx < 13)
            {
                int valueList = countOnIdx;

                cardIdxs.Add(idx);

                indexList[idx] = valueList + 1;

            }
            else if((indexList[0] >= 13) && (indexList[1] >= 13) && (indexList[2] >= 13) && (indexList[3] >= 13))
            {
                Builded = false;
            }
        }

        Debug.Log(cardIdxs.Count.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ini start");

        gameController = this.GetComponent<GameController>();
        

        cardIdxs = new List<int>();

        InitializeDeck();

        count = 0;
    }
    //TODO : FIX THIS THING

    public Dictionary<int, List<int>> DistributeCards()
    {
        Dictionary<int, List<int>> cardList = new Dictionary<int, List<int>>()
        {
            {0, new List<int>()},
            {1, new List<int>()},
            {2, new List<int>()},
            {3, new List<int>()}
        };

        for (int i = 0; i < 4; i++)
        {
            // iteration for propagate through card index

            for (int j = 0; j < 4; j++)
            {
                int idxImage = cardIdxs.ElementAt(count);

                cardList[j].Add(idxImage);

                count += 1;
            }
        }

        return cardList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card SetCardValue(Card card, int idx)
    {
        Sprite newSprite = imageSource[idx];

        card.SetImageCard(newSprite);
        card.SetValueCard(idx);

        return card;
    }

}
