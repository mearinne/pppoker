using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using csuport;
using System;

public class cards : MonoBehaviour
{

    List<string> cardList;

    List<string> cardColors;

    List<string> cardValues;

    private void Start()
    {
        cardList = new List<string>();
        cardColors = new List<string>();
        cardValues = new List<string>();

        fillIt();
        // List<string> xc = selectedCards(4);

        List<string> xx = new List<string>();
        xx.Add("4-1");
        xx.Add("2-1");

        List<string> yy = new List<string>();
        yy.Add("10-1");
        yy.Add("A-1");
        yy.Add("8-1");
        yy.Add("3-1");
        yy.Add("5-1");

       //  print(isHighCard(xx));

        // List<string> duos = isTwoCardsSame(yy, xx);

        List<string> duos = null;

        if (duos != null)
        {
            foreach (var d in duos)
            {
                print(d);
            }
        }
        else print("duos is null");

    }

    private void fillIt()
    {
        //SRDCE
        cardList.Add("A-0");
        cardList.Add("2-0");
        cardList.Add("3-0");
        cardList.Add("4-0");
        cardList.Add("5-0");
        cardList.Add("6-0");
        cardList.Add("7-0");
        cardList.Add("8-0");
        cardList.Add("9-0");
        cardList.Add("10-0");
        cardList.Add("J-0");
        cardList.Add("Q-0");
        cardList.Add("K-0");
        //PIKY
        cardList.Add("A-1");
        cardList.Add("2-1");
        cardList.Add("3-1");
        cardList.Add("4-1");
        cardList.Add("5-1");
        cardList.Add("6-1");
        cardList.Add("7-1");
        cardList.Add("8-1");
        cardList.Add("9-1");
        cardList.Add("10-1");
        cardList.Add("J-1");
        cardList.Add("Q-1");
        cardList.Add("K-1");
        //KARY
        cardList.Add("A-2");
        cardList.Add("2-2");
        cardList.Add("3-2");
        cardList.Add("4-2");
        cardList.Add("5-2");
        cardList.Add("6-2");
        cardList.Add("7-2");
        cardList.Add("8-2");
        cardList.Add("9-2");
        cardList.Add("10-2");
        cardList.Add("J-2");
        cardList.Add("Q-2");
        cardList.Add("K-2");
        //LISTY
        cardList.Add("A-3");
        cardList.Add("2-3");
        cardList.Add("3-3");
        cardList.Add("4-3");
        cardList.Add("5-3");
        cardList.Add("6-3");
        cardList.Add("7-3");
        cardList.Add("8-3");
        cardList.Add("9-3");
        cardList.Add("10-3");
        cardList.Add("J-3");
        cardList.Add("Q-3");
        cardList.Add("K-3");

        //Card colors
        cardColors.Add("SRDCE");
        cardColors.Add("PIKY");
        cardColors.Add("KARY");
        cardColors.Add("LISTY");

        cardValues.Add("2");
        cardValues.Add("3");
        cardValues.Add("4");
        cardValues.Add("5");
        cardValues.Add("6");
        cardValues.Add("7");
        cardValues.Add("8");
        cardValues.Add("9");
        cardValues.Add("10");
        cardValues.Add("J");
        cardValues.Add("Q");
        cardValues.Add("K");
        cardValues.Add("A");
    }

    public List<string> selectedCards(int numberOfPlayers)
    {

        List<string> slcCards = new List<string>();

        List<int> numbers = new List<int>();

        for (int i = 0; i < cardList.Count; i++){
            numbers.Add(i);
        }

        int cardNumber = (numberOfPlayers * 2) + 5;

        if(cardNumber <= cardList.Count)
        {

            for(int i = 0;i < cardNumber; i++) {

                int index = UnityEngine.Random.Range(0, numbers.Count);

                slcCards.Add(cardList[numbers[index]]);
                numbers.RemoveAt(index);
            }

            return slcCards;
        }
        return null;
    }

   

    private int getIndexOfCard(string cardVal)
    {
        for(int i = 0; i< cardValues.Count; i++)
        {
             if (cardValues[i] == cardVal) return i;
        }
        return -1;
    }

    private string getCardByIndex(int index)
    {
        if(index<=cardValues.Count-1)
        {
            return cardValues[index];
        }
        return null;
    }
    public string isHighCard(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<string> temp = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        if (indexes[indexes.Count - 1] == 12 ||
            indexes[indexes.Count - 1] == 11 ||
            indexes[indexes.Count - 1] == 10 ||
            indexes[indexes.Count - 1] == 9)
        {
            return getCardByIndex(indexes[indexes.Count - 1]);
        }


        return null;
    }

    public List<string> isTwoCardsSame(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<string> temp = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

     //   foreach(int indx in indexes) { print(indx); }


        for(int i = indexes.Count - 1; i>0; i--)
        {
            if (indexes[i] == indexes[i-1])
            {
                if (getCardByIndex(indexes[i]) != null)
                {
                    temp.Add(getCardByIndex(indexes[i]));
                    temp.Add(getCardByIndex(indexes[i-1]));
                }
                if (temp.Count > 0) { return temp; }
            }
        }
        

        return null;
    }

    public List<string> isThreeCardsSame(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<string> temp = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        //   foreach(int indx in indexes) { print(indx); }


        for (int i = indexes.Count - 1; i > 1; i--)
        {
            if (indexes[i] == indexes[i - 1] && indexes[i - 1] == indexes[i - 2])
            {
                if (getCardByIndex(indexes[i]) != null)
                {
                    temp.Add(getCardByIndex(indexes[i]));
                    temp.Add(getCardByIndex(indexes[i - 1]));
                    temp.Add(getCardByIndex(indexes[i - 2]));
                }
                if (temp.Count > 0) { return temp; }
            }
        }


        return null;
    }

    public List<string> isFourCardsSame(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<string> temp = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        //   foreach(int indx in indexes) { print(indx); }


        if (indexes[indexes.Count - 1] == indexes[indexes.Count-2] &&
            indexes[indexes.Count - 2] == indexes[indexes.Count - 3] &&
            indexes[indexes.Count - 3] == indexes[indexes.Count - 4])
        {
            temp.Add(getCardByIndex(indexes[indexes.Count - 1]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 2]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 3]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 4]));
            return temp;
        }

        if (indexes[indexes.Count - 2] == indexes[indexes.Count - 3] &&
            indexes[indexes.Count - 3] == indexes[indexes.Count - 4] &&
            indexes[indexes.Count - 4] == indexes[indexes.Count - 5])
        {
            
            temp.Add(getCardByIndex(indexes[indexes.Count - 2]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 3]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 4]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 5]));
            return temp;
        }

        if (indexes[indexes.Count - 3] == indexes[indexes.Count - 4] &&
            indexes[indexes.Count - 4] == indexes[indexes.Count - 5] &&
            indexes[indexes.Count - 5] == indexes[indexes.Count - 6])
        {
            
            temp.Add(getCardByIndex(indexes[indexes.Count - 3]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 4]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 5]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 6]));
            return temp;
        }

        if (indexes[indexes.Count - 4] == indexes[indexes.Count - 5] &&
            indexes[indexes.Count - 5] == indexes[indexes.Count - 6] &&
            indexes[indexes.Count - 6] == indexes[indexes.Count - 7])
        {
            
            temp.Add(getCardByIndex(indexes[indexes.Count - 4]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 5]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 6]));
            temp.Add(getCardByIndex(indexes[indexes.Count - 7]));
            return temp;
        }
        return null;
    }

    public List<string> isTwoPairs(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<int> temp;

        List<string>xcards = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        //   foreach(int indx in indexes) { print(indx); }

        temp = indexesRepeated(indexes);
      
        if (temp.Count >= 2) {
            temp.Sort();
            xcards.Add(getCardByIndex(temp[temp.Count-1]));
            xcards.Add(getCardByIndex(temp[temp.Count - 2]));
            return xcards;
        }


        return null;
    }

    public List<string> isFiveSameColorCards(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<string> temp = new List<string>();

        List<string> xcolors= new List<string>();

        List<string> bankAndHand_copy = new List<string>(bankAndHand);

        Dictionary<List<int>,List<string>> index_and_colorPiky = new Dictionary<List<int>, List<string>>();
        Dictionary<List<int>, List<string>> index_and_colorKary = new Dictionary<List<int>, List<string>>();
        Dictionary<List<int>, List<string>> index_and_colorSrdce = new Dictionary<List<int>, List<string>>();
        Dictionary<List<int>, List<string>> index_and_colorListy = new Dictionary<List<int>, List<string>>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        for(int i = indexes.Count-1; i>-1; i--) {

            for(int j = bankAndHand_copy.Count-1; j>= 0; j--)
            {
                string[] cardVal_and_cardCol = bankAndHand_copy[j].Split("-");

                if (getCardByIndex(indexes[i]) == cardVal_and_cardCol[0])
                {
                   // xcolors.Add(cardVal_and_cardCol[1]);
                    
                   if(cardVal_and_cardCol[1] =="0") {
                        List<int> ind = new List<int>();
                        List<string> col = new List<string>();
                        ind.Add(indexes[i]);
                        col.Add(cardVal_and_cardCol[1]);
                        index_and_colorSrdce.Add(ind,col);
                    }
                   else if (cardVal_and_cardCol[1] == "1")
                    {
                        List<int> ind = new List<int>();
                        List<string> col = new List<string>();
                        ind.Add(indexes[i]);
                        col.Add(cardVal_and_cardCol[1]);
                        index_and_colorPiky.Add(ind, col);
                    }
                    else if (cardVal_and_cardCol[1] == "2")
                    {
                        List<int> ind = new List<int>();
                        List<string> col = new List<string>();
                        ind.Add(indexes[i]);
                        col.Add(cardVal_and_cardCol[1]);
                        index_and_colorKary.Add(ind, col);
                    }
                    else if (cardVal_and_cardCol[1] == "3")
                    {
                        List<int> ind = new List<int>();
                        List<string> col = new List<string>();
                        ind.Add(indexes[i]);
                        col.Add(cardVal_and_cardCol[1]);
                        index_and_colorListy.Add(ind, col);
                    }

                    bankAndHand_copy.RemoveAt(j);
                }
            }
        }
        if(index_and_colorSrdce.Count >=5)
        {
            foreach(KeyValuePair<List<int>,List<string>> kv in index_and_colorSrdce)
            {
                List<int> indxVal = kv.Key;
                List<string> col = kv.Value;

                string concVal = getCardByIndex(indxVal[0]) + "-" + col[0];
                temp.Add(concVal);
            }
        }
        if (index_and_colorKary.Count >= 5)
        {
            foreach (KeyValuePair<List<int>, List<string>> kv in index_and_colorKary)
            {
                List<int> indxVal = kv.Key;
                List<string> col = kv.Value;

                string concVal = getCardByIndex(indxVal[0]) + "-" + col[0];
                temp.Add(concVal);
            }
        }
        if (index_and_colorPiky.Count >= 5)
        {
            foreach (KeyValuePair<List<int>, List<string>> kv in index_and_colorPiky)
            {
                List<int> indxVal = kv.Key;
                List<string> col = kv.Value;

                string concVal = getCardByIndex(indxVal[0]) + "-" + col[0];
                temp.Add(concVal);
            }
        }
        if (index_and_colorListy.Count >= 5)
        {
            foreach (KeyValuePair<List<int>, List<string>> kv in index_and_colorListy)
            {
                List<int> indxVal = kv.Key;
                List<string> col = kv.Value;

                string concVal = getCardByIndex(indxVal[0]) + "-" + col[0];
                temp.Add(concVal);
            }
        }
        if (temp.Count > 0) { return temp; }

        return null;
    }

    public List<string> isDirtyStraight(List<string> cardBank, List<string> cardHand)
    {
        
           // print("I am here");
            List<string> bankAndHand = new List<string>();
            bankAndHand.AddRange(cardBank);
            bankAndHand.AddRange(cardHand);

            List<int> indexes = new List<int>();

            List<string> temp = new List<string>();

            for (int i = 0; i < bankAndHand.Count; i++)
            {
                string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
                indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
            }
            indexes.Sort();

      //  foreach (int i in indexes) { print(i); }

        
        if (indexes[6] - indexes[5] == 1 &&
            indexes[5] - indexes[4] == 1 &&
            indexes[4] - indexes[3] == 1 &&
            indexes[3] - indexes[2] == 1)
        {
            for (int i = indexes.Count - 1; i >= 2; i--)
            {

                temp.Add(getCardByIndex(indexes[i]));

            }
            //  print("Alfa");
            return temp;
        }
        else if (indexes[5] - indexes[4] == 1 &&
                indexes[4] - indexes[3] == 1 &&
                indexes[3] - indexes[2] == 1 &&
                indexes[2] - indexes[1] == 1)
        {
            for (int i = indexes.Count - 2; i >= 1; i--)
            {

                temp.Add(getCardByIndex(indexes[i]));

            }
            //  print("Beta");
            return temp;
        }
        else if (indexes[4] - indexes[3] == 1 &&
                indexes[3] - indexes[2] == 1 &&
                indexes[2] - indexes[1] == 1 &&
                indexes[1] - indexes[0] == 1)
        {
            for (int i = indexes.Count - 3; i >= 0; i--)
            {

                temp.Add(getCardByIndex(indexes[i]));

            }
            //   print("Gama");
            return temp;
        }

        if (indexes[6] == 12)
        {
            
            temp.Add(getCardByIndex(indexes[6]));
            foreach(int vl in indexes){
                if(vl == 0 && !isInTheListAlready_string(temp, getCardByIndex(0))) { temp.Add(getCardByIndex(0)); }
                if (vl == 1 && !isInTheListAlready_string(temp, getCardByIndex(1))) { temp.Add(getCardByIndex(1)); }
                if (vl == 2 && !isInTheListAlready_string(temp, getCardByIndex(2))){ temp.Add(getCardByIndex(2)); }
                if (vl == 3 && !isInTheListAlready_string(temp, getCardByIndex(3))) { temp.Add(getCardByIndex(3)); }
            }
            print("temp.Count: "+ temp.Count);
            if (temp.Count == 5) { return temp; }
        }
    
            return null;
        
    }

    public List<string> isFullHouse(List<string> cardBank, List<string> cardHand)
    {
        List<string> bankAndHand = new List<string>();
        bankAndHand.AddRange(cardBank);
        bankAndHand.AddRange(cardHand);

        List<int> indexes = new List<int>();

        List<int> temp;

        List<string> xcards = new List<string>();

        for (int i = 0; i < bankAndHand.Count; i++)
        {
            string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
            indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
        }
        indexes.Sort();

        if (indexes[6] == indexes[5] && indexes[4] == indexes[3] && indexes[4] == indexes[2]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
        }
        if (indexes[6] == indexes[5] && indexes[3] == indexes[2] && indexes[3] == indexes[1]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
        }
        if (indexes[6] == indexes[5] && indexes[2] == indexes[1] && indexes[2] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }

        if (indexes[5] == indexes[4] && indexes[3] == indexes[2] && indexes[3] == indexes[1]) {
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
        }
        if (indexes[5] == indexes[4] && indexes[2] == indexes[1] && indexes[2] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }

        if (indexes[4] == indexes[3] && indexes[2] == indexes[1] && indexes[2] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }

        if (indexes[6] == indexes[5] && indexes[5] == indexes[4] && indexes[3] == indexes[2]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
        }
        if (indexes[6] == indexes[5] && indexes[5] == indexes[4] && indexes[2] == indexes[1]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
        }
        if (indexes[6] == indexes[5] && indexes[5] == indexes[4] && indexes[1] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[6]));
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }
        
        if (indexes[5] == indexes[4] && indexes[4] == indexes[3] && indexes[2] == indexes[1]) {
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
        }
        if (indexes[5] == indexes[4] && indexes[4] == indexes[3] && indexes[1] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[5]));
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }
        
        if (indexes[4] == indexes[3] && indexes[4] == indexes[2] && indexes[1] == indexes[0]) {
            xcards.Add(getCardByIndex(indexes[4]));
            xcards.Add(getCardByIndex(indexes[3]));
            xcards.Add(getCardByIndex(indexes[2]));
            xcards.Add(getCardByIndex(indexes[1]));
            xcards.Add(getCardByIndex(indexes[0]));
        }
        if(xcards.Count > 0) { return xcards; }

        return null;
    }

    public List<string> isStraight(List<string> cardBank, List<string> cardHand)
    {
        List<string> result = new List<string>();
        List<int> indexes = new List<int>();

        if(isFiveSameColorCards(cardBank, cardHand) != null)
        {
            List<string> bankAndHand = isFiveSameColorCards(cardBank,cardHand);

            for(int i = bankAndHand.Count - 1; i >= 0; i--)
            {
                string[] cardVal_and_cardCol = bankAndHand[i].Split("-");
                indexes.Add(getIndexOfCard(cardVal_and_cardCol[0]));
            }
        
        indexes.Sort();
        print("indexes.Count: " + indexes.Count);

        if (indexes[indexes.Count - 1] - indexes[indexes.Count - 2] == 1 &&
            indexes[indexes.Count - 2] - indexes[indexes.Count - 3] == 1 &&
            indexes[indexes.Count - 3] - indexes[indexes.Count - 4] == 1 &&
            indexes[indexes.Count - 4] - indexes[indexes.Count - 5] == 1)
        {
            result.Add(getCardByIndex(indexes[indexes.Count - 1]));
            result.Add(getCardByIndex(indexes[indexes.Count - 2]));
            result.Add(getCardByIndex(indexes[indexes.Count - 3]));
            result.Add(getCardByIndex(indexes[indexes.Count - 4]));
            result.Add(getCardByIndex(indexes[indexes.Count - 5]));
            return result;
        }
        if (indexes.Count == 6)
        {
            if (indexes[indexes.Count - 2] - indexes[indexes.Count - 3] == 1 &&
                indexes[indexes.Count - 3] - indexes[indexes.Count - 4] == 1 &&
                indexes[indexes.Count - 4] - indexes[indexes.Count - 5] == 1 &&
                indexes[indexes.Count - 5] - indexes[indexes.Count - 6] == 1)
            {   
                result.Add(getCardByIndex(indexes[indexes.Count - 2]));
                result.Add(getCardByIndex(indexes[indexes.Count - 3]));
                result.Add(getCardByIndex(indexes[indexes.Count - 4]));
                result.Add(getCardByIndex(indexes[indexes.Count - 5]));
                result.Add(getCardByIndex(indexes[indexes.Count - 6]));
                return result;
            }
        }
        if (indexes.Count == 7)
        {
                if (indexes[indexes.Count - 2] - indexes[indexes.Count - 3] == 1 &&
               indexes[indexes.Count - 3] - indexes[indexes.Count - 4] == 1 &&
               indexes[indexes.Count - 4] - indexes[indexes.Count - 5] == 1 &&
               indexes[indexes.Count - 5] - indexes[indexes.Count - 6] == 1)
                {
                    result.Add(getCardByIndex(indexes[indexes.Count - 2]));
                    result.Add(getCardByIndex(indexes[indexes.Count - 3]));
                    result.Add(getCardByIndex(indexes[indexes.Count - 4]));
                    result.Add(getCardByIndex(indexes[indexes.Count - 5]));
                    result.Add(getCardByIndex(indexes[indexes.Count - 6]));
                    return result;
                }

                if (indexes[indexes.Count - 3] - indexes[indexes.Count - 4] == 1 &&
                indexes[indexes.Count - 4] - indexes[indexes.Count - 5] == 1 &&
                indexes[indexes.Count - 5] - indexes[indexes.Count - 6] == 1 &&
                indexes[indexes.Count - 6] - indexes[indexes.Count - 7] == 1)
            {
                result.Add(getCardByIndex(indexes[indexes.Count - 3]));
                result.Add(getCardByIndex(indexes[indexes.Count - 4]));
                result.Add(getCardByIndex(indexes[indexes.Count - 5]));
                result.Add(getCardByIndex(indexes[indexes.Count - 6]));
                result.Add(getCardByIndex(indexes[indexes.Count - 7]));
                return result;
            }
        }
            if (indexes[indexes.Count-1] == 12)
            {

                result.Add(getCardByIndex(indexes[indexes.Count - 1]));
                foreach (int vl in indexes)
                {
                    if (vl == 0 && !isInTheListAlready_string(result, getCardByIndex(0))) { result.Add(getCardByIndex(0)); }
                    if (vl == 1 && !isInTheListAlready_string(result, getCardByIndex(1))) { result.Add(getCardByIndex(1)); }
                    if (vl == 2 && !isInTheListAlready_string(result, getCardByIndex(2))) { result.Add(getCardByIndex(2)); }
                    if (vl == 3 && !isInTheListAlready_string(result, getCardByIndex(3))) { result.Add(getCardByIndex(3)); }
                }
                print("temp.Count: " + result.Count);
                if (result.Count == 5) { return result; }
            }

        }
        return null;
    }

    public List<string> isRoyalStraight(List<string> cardBank, List<string> cardHand)
    {

        if(isStraight(cardBank,cardHand) != null)
        {
              List<string> xcards = isStraight(cardBank, cardHand);


              if (xcards[0] == "A") {
                 print("heeeeeeeeereeeeeeeeeeeeeeeeee");
                return xcards;
              }
              else { print("xcards[xcards.Count - 1]: " + xcards[xcards.Count - 1]); }
           
        }

        return null;
    }



    private List<int> indexesRepeated(List<int>orderedList)
    {
        List<int> indxs = new List<int>();

        for (int i = 0;i < orderedList.Count;i++)
        {
            int counter = 0;
            for (int j = 0; j< orderedList.Count;j++)
            {
                if (orderedList[i] == orderedList[j] && i != j && counter == 0) {
                    if(!isInTheListAlready(indxs, orderedList[j]))
                    {
                        indxs.Add(orderedList[i]);
                        counter++;
                    }
                }
            }
        }
        if (indxs.Count > 0) { return indxs; }
        return null;
    }

    private bool isInTheListAlready(List<int> aList, int checkedVal) { 
        
        foreach (int i in aList)
        {
            if(i == checkedVal) return true;
        }

        return false;

    }

    private bool isInTheListAlready_string(List<string> aList, string checkedVal)
    {

        foreach (string i in aList)
        {
            if (i == checkedVal) return true;
        }

        return false;

    }

    private bool isAceInTheList(List<int> aList, int aceIndex)
    {
        foreach (int i in aList)
        { if(i == aceIndex) return true; }
        return false;
    }

}
