using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Monster
{
    internal class Dragon: monster
    {
        public Dragon()
        {
            name = "드래곤";
            curHp = 30;
            maxHp = 30;
            ap = 6;
            coin = 50;
        }
    }
}
