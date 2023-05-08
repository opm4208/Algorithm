using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCardRpg.Scenes
{
    internal class RestScene : Scene
    {
        public RestScene(Game game) : base(game)
        {
        }
        public override void Render()
        {
            Console.WriteLine("휴식하는 장소를 찾았습니다.");
            Console.WriteLine("플레이어의 체력을 10 회복합니다.");
        }

        public override void Update()
        {
            Data.player.Heal(10);
            Thread.Sleep(1000);
            game.Map();
        }
    }
}
