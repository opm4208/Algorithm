using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Scenes
{
    internal class EndingScene:Scene
    {
        public EndingScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            Console.WriteLine("축하합니다 보스를 처치하였습니다.");
        }

        public override void Update()
        {
            Thread.Sleep(1000);
        }
    }
}
