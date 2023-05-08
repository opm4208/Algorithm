using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Card
{
    public abstract class card
    {
        public enum Type{ none,attack,deffence};
        public Type type;
        public int coefficient;
        public int cost;
        public abstract void Render(int coefficient, int cost);
    }
}
