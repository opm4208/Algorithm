using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TextCardRpg.Players;

namespace TextCardRpg.Monster
{
    public abstract class monster
    {
        Player player = new Player();
        public string name;
        public int curHp;
        public int maxHp;
        public int ap;
        public int coin;
        public void TakeDamage(int damage)
        {
            Console.WriteLine($"{name}(은/는) {damage} 데미지를 받았다.");
            curHp -= damage;
            
            Thread.Sleep(1000);

            if (curHp <= 0)
            {
                Console.WriteLine($"{name}(은/는) 쓰려졌다!");
                Thread.Sleep(1000);
                Console.WriteLine($"{name}(은/는) {coin}코인을 떨어뜨렸다.");
                Thread.Sleep(1000);
            }
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}(이/가) 플레이어를 공격합니다.");
            Thread.Sleep(1000);
            player.TakeDamage(ap);
        }
    }
}
