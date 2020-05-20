using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite backgroundImage;
    public Sprite imageCard;
    private Button buttonCard;
    public bool isActive;
    private int valueCard;

    public void SetValueCard(int value)
    {
        this.valueCard = value;
    }

    public int GetValueCard()
    {
        return this.valueCard;
    }

    public void SetImageCard(Sprite sprite)
    {
        this.imageCard = sprite;
        //SetImage();
    }

    public void SetIsActive(bool toggle)
    {
        this.isActive = toggle;
        //SetImage();
    }

    void SetImage()
    {
        Image cardImage = this.GetComponent<Image>();
        if (this.isActive)
        {
            cardImage.sprite = imageCard;
            buttonCard.interactable = true;
        }
        else
        {
            cardImage.sprite = backgroundImage;
            buttonCard.interactable = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonCard = this.GetComponent<Button>();
        buttonCard.onClick.AddListener(CardClicked);
    }

    // Update is called once per frame
    void Update()
    {

        SetImage();

    }

    public void CardClicked()
    {
        Transform parentTransform = this.transform.parent;

        GameObject parentObject = parentTransform.gameObject;

        Hand parentHand = parentObject.GetComponent<Hand>();

        parentHand.SetSelectedCard(this);

        Destroy(this.gameObject);
    }


}
