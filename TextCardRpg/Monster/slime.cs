using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextCardRpg.Monster
{
    internal class slime: monster
    {
        public slime()
        {
            name = "슬라임";
            curHp = 10;
            maxHp = 10;
            ap = 3;
            coin = 10;
        }
    }
}
