using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerStuff;

namespace playerStuff { 
public class playerSet 
{

    Dictionary<string, bool> dictionary_names;

    private void fillNames()
    {
        // men
        dictionary_names.Add("John Smith", true);
        dictionary_names.Add("Michael Johnson", true);
        dictionary_names.Add("David Williams", true);
        dictionary_names.Add("James Brown", true);
        dictionary_names.Add("Robert Jones", true);
        dictionary_names.Add("William Garcia", true);
        dictionary_names.Add("Joseph Miller", true);
        dictionary_names.Add("Thomas Davis", true);
        dictionary_names.Add("Christopher Rodriguez", true);
        dictionary_names.Add("Daniel Wilson", true);
        dictionary_names.Add("Matthew Martinez", true);
        dictionary_names.Add("Anthony Anderson", true);
        dictionary_names.Add("Donald Taylor", true);
        dictionary_names.Add("Mark Thomas", true);
        dictionary_names.Add("George Hernandez", true);
        dictionary_names.Add("Paul Moore", true);
        dictionary_names.Add("Andrew Jackson", true);
        dictionary_names.Add("Steven Martin", true);
        dictionary_names.Add("Kevin White", true);
        dictionary_names.Add("Brian Harris", true);

        // women
        dictionary_names.Add("Mary Smith", false);
        dictionary_names.Add("Patricia Johnson", false);
        dictionary_names.Add("Linda Williams", false);
        dictionary_names.Add("Barbara Brown", false);
        dictionary_names.Add("Elizabeth Jones", false);
        dictionary_names.Add("Jennifer Garcia", false);
        dictionary_names.Add("Maria Miller", false);
        dictionary_names.Add("Susan Davis", false);
        dictionary_names.Add("Margaret Rodriguez", false);
        dictionary_names.Add("Dorothy Wilson", false);
        dictionary_names.Add("Sarah Martinez", false);
        dictionary_names.Add("Jessica Anderson", false);
        dictionary_names.Add("Ashley Taylor", false);
        dictionary_names.Add("Kimberly Thomas", false);
        dictionary_names.Add("Amanda Hernandez", false);
        dictionary_names.Add("Melissa Moore", false);
        dictionary_names.Add("Michelle Jackson", false);
        dictionary_names.Add("Angela Martin", false);
        dictionary_names.Add("Karen White", false);
        dictionary_names.Add("Lisa Harris", false);

    }


    public List<player> creationOfPlayer(int number_of_players)
    {
            dictionary_names = new Dictionary<string, bool>();
            fillNames();
            List<player> result = new List<player>();

        List<int> indexes = new List<int>();

        for (int i = 0; i< dictionary_names.Count; i++) { indexes.Add(i); }

        for(int j = 0; j<number_of_players; j++)
        {
            int index = Random.Range(0, indexes.Count);

            int realIndex = indexes[index];

            indexes.RemoveAt(index);

            int counter = 0;

            foreach(KeyValuePair<string,bool> d_names in dictionary_names)
            {
                if(realIndex==counter)
                {
                   result.Add(new player(realIndex,d_names.Key,500,d_names.Value));
                }
                counter++;
            }
        }
        if(result.Count > 0) { return result; }

        return null;
    }

}

}
