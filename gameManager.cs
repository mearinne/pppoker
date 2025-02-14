using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cardObj;

public enum cardComb {high_card,one_pair,two_pair,three_of_a_kind,straight,flush,full_house,four_of_a_kind,straight_flush,royal_flush,nothing}
public class gameManager : MonoBehaviour
{

    private List<string> bankCards;

    private List<List<string>> playersCardsInHand;

    private List<List<string>> playersCombinations;

    cards myCardsClass;

    private int numberOfPlayers;

    Dictionary<cardComb,string> cardCombDic;

    private void Start()
    {
        numberOfPlayers = 2;
        playersCardsInHand = new List<List<string>>();
        bankCards = new List<string>();

        myCardsClass = this.gameObject.GetComponent<cards>();

        cardCombDic = new Dictionary<cardComb,string>();
        combinationInCorrectText();

        StartCoroutine(doItLater(0.1f));
        //firstSteps();
    }


    IEnumerator doItLater(float secs)
    {
        yield return new WaitForSeconds(secs);
        firstSteps();
    }

    private void combinationInCorrectText() {
        cardCombDic.Add(cardComb.high_card, "high card");
        cardCombDic.Add(cardComb.one_pair, "one pair");
        cardCombDic.Add(cardComb.two_pair, "two pair");
        cardCombDic.Add(cardComb.three_of_a_kind, "three of a kind");
        cardCombDic.Add(cardComb.straight, "straight");
        cardCombDic.Add(cardComb.flush, "flush");
        cardCombDic.Add(cardComb.full_house, "full house");
        cardCombDic.Add(cardComb.four_of_a_kind, "four of a kind");
        cardCombDic.Add(cardComb.straight_flush, "straight flush");
        cardCombDic.Add(cardComb.royal_flush, "royal flush");
    }
    
    private void firstSteps()
    {
        List<string> allCards = myCardsClass.selectedCards(numberOfPlayers);

        for (int i = 0; i < allCards.Count; i++)
        {

            if (i <= 4)
            {
                bankCards.Add(allCards[i]);
            }
        }

        int playersCards_num = allCards.Count - 5;

        print("playersCards_num: " + playersCards_num);

        for (int i = 5; i < allCards.Count; i++)
        {

            if (i % 2 != 0)
            {
                List<string> cardsx = new List<string>();

                cardsx.Add(allCards[i]);
                cardsx.Add(allCards[i + 1]);

                playersCardsInHand.Add(cardsx);

            }

        }

        print("bankCards.Count: " + bankCards.Count);
        print("playersCardsInHand.Count: " + playersCardsInHand.Count);
    }


    private cardCombObj getPlayersHighestCombination(List<string> bankCards,List<string> plyrHandCards) {

        if (myCardsClass.isRoyalStraight(bankCards, plyrHandCards) != null) { 
            return new cardCombObj(myCardsClass.isRoyalStraight(bankCards, plyrHandCards),cardComb.royal_flush); 
        }
        else if (myCardsClass.isStraight(bankCards, plyrHandCards) != null) { 
            return  new cardCombObj(myCardsClass.isStraight(bankCards, plyrHandCards), cardComb.straight_flush);  
        }
        else if (myCardsClass.isFourCardsSame(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isFourCardsSame(bankCards, plyrHandCards), cardComb.four_of_a_kind);
        }
        else if (myCardsClass.isFullHouse(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isFullHouse(bankCards, plyrHandCards), cardComb.full_house);
        }
        else if (myCardsClass.isFiveSameColorCards(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isFiveSameColorCards(bankCards, plyrHandCards), cardComb.flush);
        }
        else if (myCardsClass.isDirtyStraight(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isDirtyStraight(bankCards, plyrHandCards), cardComb.straight);
        }
        else if (myCardsClass.isThreeCardsSame(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isThreeCardsSame(bankCards, plyrHandCards), cardComb.three_of_a_kind);
        }
        else if (myCardsClass.isTwoPairs(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isTwoPairs(bankCards, plyrHandCards), cardComb.two_pair);
        }
        else if (myCardsClass.isTwoCardsSame(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isTwoCardsSame(bankCards, plyrHandCards), cardComb.one_pair);
        }
        else if (myCardsClass.isHighCard(bankCards, plyrHandCards) != null) {
            return new cardCombObj(myCardsClass.isHighCard(bankCards, plyrHandCards), cardComb.high_card);
        }
        return null;    
    }


}
