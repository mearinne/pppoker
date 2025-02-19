using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace csuport
{

    public class cardSupport
    {


        private List<int> list;
        private bool isHand;

        public cardSupport(List<int> list, bool isHand)
        {
            this.list = list;
            this.isHand = isHand;
        }

        public List<int> getListVals() { return list; }

        public bool isInHand() { return isHand; }


    }

}
