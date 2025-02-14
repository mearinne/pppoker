using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cardObj
{
    public class cardCombObj
    {

       public List<string> cardsList { get; set; }

       public cardComb comb { get; set; }

        public cardCombObj(List<string> cardsList, cardComb cmb) { 
        
            this.cardsList = cardsList;
            comb = cmb;
        
        }

        public cardCombObj(string hcard, cardComb cmb)
        {
            this.cardsList = new List<string>();
            this.comb = cmb;
        }
    }
}

