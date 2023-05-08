using TextCardRpg.Card;
using TextCardRpg.Monster;
using TextCardRpg.Players;
using TextCardRpg.Scenes;

namespace TextCardRpg
{
    public static class Data
    {
        public static Player player;
        public static List<card> Deck;
        public static card card;
        public static monster monster;
        public static void Init()
        {
            player = new Player();
            Deck = new List<card>();
            monster = new slime();
            DeckSeting();
        }
       
        private static void DeckSeting()
        {
            card = new attackCard();
            card.Render(5,1);
            for(int i = 0; i < 5; i++)
                Deck.Add(card);
            card = new defenceCard();
            card.Render(3,1);
            for (int i = 0; i < 5; i++)
                Deck.Add(card);
        }
    }
}
