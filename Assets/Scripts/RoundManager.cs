using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoundManager : MonoBehaviour
{
    public int roundCount = 0;

    private int oldRoundCount = 0;

    public GameObject[] tableCards;

    public GameObject[] handCards;

    private List<int> spades = Enumerable.Range(0, 12).ToList();
    private List<int> hearts = Enumerable.Range(0, 12).ToList();
    private List<int> diamonds = Enumerable.Range(0, 12).ToList();
    private List<int> clubs = Enumerable.Range(0, 12).ToList();

    private List<List<int>> allTypes;

    private int cardToReset = 0;
    // Start is called before the first frame update
    void Start()
    {
        roundCount = 0;
        allTypes = new List<List<int>> {spades, hearts, diamonds, clubs };
        // foreach (var card in handCards)
        // {
        //     card.SetActive(false);
        // }

        foreach (var card in tableCards)
        {
            card.SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (roundCount != oldRoundCount)
        {
            ChangeCards();
        }

        oldRoundCount = roundCount;
    }

    void ChangeCards()
    {
        switch (roundCount)
        {
            case 1:
                ShowCards();
                break;
            default:

                for (int i = 0; i < tableCards.Length; i++)
                {
                    if (i < roundCount - 1)
                    {
                        tableCards[i].SetActive(true);
                        if (cardToReset==i)
                        {
                            StartCoroutine(SetRCard(tableCards[i]));
                            cardToReset++;
                            break;
                        }
                    }
                    else
                    {
                        tableCards[i].SetActive(false);
                    }
                }
                break;
        }
    }
    

    void ShowCards()
    {
        
        // Show eveyone's cards
        // foreach (var card in handCards)
        // {
        //     card.SetActive(true);
        //     StartCoroutine(SetRCard(card));
        // }
    }

    IEnumerator SetRCard(GameObject card)
    {
        int tindex = Random.Range(0, allTypes.Count);
        var newType = allTypes[tindex];
        int index = Random.Range(0, newType.Count);
        int newVal = newType[index];
        // remove the card from the array to prevent duplicate cards
        allTypes[tindex].RemoveAt(index);

        // check if suit is empty due to excesive players an massive discart (see prev line)
        if (newType.Count == 0)
        {
            allTypes.RemoveAt(tindex);
            StartCoroutine(SetRCard(card));
        }
        
        CardManager cm = card.GetComponent<CardManager>();
        // set new val to card
        cm.cardIndex = newVal;


        CardManager.CardSuit suit = CardManager.CardSuit.Hearts;
        if(newType == hearts){
            suit = CardManager.CardSuit.Hearts;
        }

        if(newType == diamonds){
            suit = CardManager.CardSuit.Diamonds;
        }

        if(newType == clubs){
            suit = CardManager.CardSuit.Clubs;
        }

        if(newType == spades){
            suit = CardManager.CardSuit.Spades;
        }

        cm.actualCardSuit = suit;
        cm.isHidden = false;
        StartCoroutine(cm.UpdateCardDisplay());
        yield return null;
    }

    public void IncrementRound()
    {
        roundCount++;
    }
}
