using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCardRpg.Monster;
using TextCardRpg.Card;
using TextCardRpg.Players;

namespace TextCardRpg.Scenes
{
    public class battleScene: Scene
    {
        public battleScene(Game game) : base(game)
        {
        }
        private monster monster;
        int handSize = Data.player.hands;
        int deckSize = Data.Deck.Count;
        bool check = true;
        bool start = true;
        List<card> useDeck = new List<card>();
        public override void Render()
        {
            if(start)
            {
                DeckShuffle();
            }
            Console.WriteLine($"{monster.name}");
            Console.WriteLine($"HP: {monster.curHp}");
            Console.WriteLine();
            Console.WriteLine($"플레이어 HP:{ Data.player.CurHp }");
            Console.WriteLine($"플레이어 GP:{Data.player.gard}");
            for (int i=0; i< handSize; i++)
            {
                Console.WriteLine($"{i + 1}.{useDeck[i].type}: {useDeck[i].coefficient}");
            }
            Console.WriteLine($"사용할 카드를 선택해 주세요 1~{handSize}");
        }

        public override void Update()
        {
            if (check)  // 덱 셔플 : 처음 게임을 시작했을때, 덱에서 가져올 카드가 부족할때.
            {
                DeckShuffle();
                check = false;
            }

            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            if(0<index&& index < handSize+1)
            {
                if(useDeck[index - 1].type == card.Type.attack)
                {
                    Data.player.Attack(monster, useDeck[index - 1].coefficient);
                }
                else if(useDeck[index - 1].type == card.Type.deffence)
                {
                    Data.player.Gard(useDeck[index - 1].coefficient);
                }
                for(int i=0; i<handSize; i++)
                {
                    useDeck.RemoveAt(0);
                }
            }
            if (useDeck.Count<handSize)
            {
                check = true;
            }
            // 턴 결과
            if (monster.curHp <= 0)
            {
                Data.player.GetCoin(monster.coin);
                Console.WriteLine($"{monster.name}을 처치 했습니다");
                Thread.Sleep(1000);
                game.Map();
                return;
            }

            // 몬스터 턴
            monster.Attack(Data.player);

            // 턴 결과
            if (Data.player.CurHp <= 0)
            {
                game.GameOver("몬스터에게 패배했습니다.");
                return;
            }
        }
        private void DeckShuffle()
        {
            bool[] check = new bool[deckSize];
            Array.Fill(check, false);
            Random rand = new Random();
            List<card> deck = new List<card>();
            while (true)
            {
                int num= rand.Next(0, deckSize);
                if (!check[num])
                {
                    deck.Add(Data.Deck[num]);
                    check[num] = true;
                }
                if (deck.Count == deckSize) break;
            }
            useDeck = deck;
        }
        public void StartBattle(monster monster)
        {
            this.monster = monster;

            Console.Clear();
            Console.WriteLine($"{monster.name}(와/과) 전투 시작!");
            Thread.Sleep(1000);
        }
    }
}
