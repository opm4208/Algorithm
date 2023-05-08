using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Card
{
    internal class attackCard : card
    {
        public override void Render(int damage, int cost)
        {
            coefficient = damage;
            this.cost = cost;
            type = Type.attack;
        }
    }
}
