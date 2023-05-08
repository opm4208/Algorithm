using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TextCardRpg;
using TextCardRpg.Monster;

namespace TextCardRpg.Players
{
    public class Player
    {
        public monster monster;
        public int hands = 4;
        public Player()
        {
            CurHp = 30;
            MaxHP = 30;
            gard = 0;
            Coin = 0;
        }

        public int CurHp { get; private set; }
        public int MaxHP { get; private set; }
        public int gard { get; private set; }
        public int Coin { get; private set; }
        public void Attack(monster monster, int damage)
        {
            Console.WriteLine($"플레이어가 {monster.name}(을/를) 공격한다.");
            Thread.Sleep(1000);
            monster.TakeDamage(damage);
        }

        public void Gard(int gard)
        {
            Console.WriteLine($"플레이어가 {gard}만큼의 방어도를 얻는다.");
            Thread.Sleep(1000);
            this.gard = gard;
        }
        public void TakeDamage(int damage)
        {
            if (damage > gard)
            {
                Console.WriteLine($"플레이어는 {damage - gard} 데미지를 받았다.");
                CurHp -= damage - gard;
            }
            else
                Console.WriteLine($"공격은 플레이어에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (CurHp <= 0)
            {
                Console.WriteLine($"플레이어는 쓰려졌다!");
                Thread.Sleep(1000);
            }
            gard = 0;
        }
        public void Heal(int heal)
        {
            CurHp += heal;
            if(CurHp>MaxHP)CurHp = MaxHP;
        }
        public void GetCoin(int coin)
        {
            Coin += coin;
        }
    }

}
