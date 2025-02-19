using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerStuff
{

    public class player
    {

        public int id {  get; private set; }

        public string name { get; private set; }

        public int plMoney { get; private set; }

        public int playersBet { get; private set; }

        public bool gender {  get; private set; }

        public List<GameObject> plCards { get; private set; }

        public player(int id, string name, int plMoney, bool gender)
        {
            this.id = id;
            this.name = name;
            this.plMoney = plMoney;
            this.gender = gender;
        }


    }

}

