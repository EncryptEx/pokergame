using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public enum CardNum
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public CardSuit actualCardSuit;
    public CardNum actualCardNum;
    public int cardIndex;


    public bool isHidden;
    public Sprite hiddenCardSprite;
    
    
    Image im;

    private Sprite[] clubs;
    private Sprite[] spades;
    private Sprite[] hearts;
    private Sprite[] diamonds;
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        cardIndex = (int)actualCardNum-1;
        im = GetComponentInChildren<Image>();
        clubs = Resources.LoadAll<Sprite>("sprites/topdown/Cards/clubs");
        spades = Resources.LoadAll<Sprite>("sprites/topdown/Cards/spades");
        hearts = Resources.LoadAll<Sprite>("sprites/topdown/Cards/hearts");
        diamonds = Resources.LoadAll<Sprite>("sprites/topdown/Cards/diamonds");
        StartCoroutine(UpdateCardDisplay());

    }


    public IEnumerator UpdateCardDisplay()
    {
        if (isHidden)
        {
            im.sprite = hiddenCardSprite;
            yield return null;
        }
        switch (actualCardSuit)
        {
            case CardSuit.Hearts:
                im.sprite = hearts[cardIndex];
                break;
            case CardSuit.Clubs:
                im.sprite = clubs[cardIndex];
                break;
            case CardSuit.Spades:
                im.sprite = spades[cardIndex];
                break;
            case CardSuit.Diamonds:
                im.sprite = diamonds[cardIndex];
                break;
        }

        yield return null;
    }
}