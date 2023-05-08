using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCardRpg.Monster;

namespace TextCardRpg.Scenes
{
    internal class mapScene : Scene
    {
        private monster monster;
        int count = 0;
        public mapScene(Game game) : base(game)
        {
        }
        public override void Render()
        {
            if (count < 5)
            {
                Console.WriteLine("오른쪽 왼쪽중 원하는 방향을 고르세요");
                Console.WriteLine("오른쪽 1, 왼쪽 2 입력:");
            }
            else
            {
                Console.WriteLine("보스방에 진입합니다.");
            }
        }

        public override void Update()
        {
            Random random = new Random();
            int num = random.Next(0, 2);
            string input = Console.ReadLine();

            if (count >= 5)
            {
                monster = new Dragon();
                game.Battle(monster);
            }
            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }
            switch (index)
            {
                case 1:
                    count++;
                    if (num == 0)
                    {
                        num = random.Next(0, 2);
                        if (num == 0)
                        {
                            monster = new slime();
                        }
                        else
                        {
                            monster = new ougeo();
                        }
                        game.Battle(monster);
                    }
                    else
                    {
                        game.Rest();
                    }
                    break;
                case 2:
                    count++;
                    if (num == 1)
                    {
                        game.Rest();
                    }
                    else
                    {
                        num = random.Next(0, 2);
                        if (num == 0)
                        {
                            monster = new slime();
                        }
                        else
                        {
                            monster = new ougeo();
                        }
                        game.Battle(monster);
                    }
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
}
