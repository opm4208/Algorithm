using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Card
{
    internal class defenceCard : card
    {
        public override void Render(int defence, int cost)
        {
            coefficient = defence;
            this.cost = cost;
            type = Type.deffence;
        }
    }
}
