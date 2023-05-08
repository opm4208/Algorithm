using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextCardRpg.Scenes;
using TextCardRpg.Monster;

namespace TextCardRpg
{
    public class Game
    {
        private bool running = true;

        private Scene scene;
        private MainMenuScene mainMenu;
        private mapScene mapScene;
        private battleScene battleScene;
        private RestScene restScene;
        private EndingScene endingScene;

        public void Run()
        {
            Init();

            while (running)
            {
                Render();
                Update();
            }

        }
        private void Render()
        {
            Console.Clear();
            scene.Render();
        }

        private void Update()
        {
            scene.Update();
        }

        
        private void Init()
        {
            Console.CursorVisible = false;

            Data.Init();
            mainMenu = new MainMenuScene(this);
            battleScene = new battleScene(this);
            mapScene = new mapScene(this);
            restScene = new RestScene(this);
            endingScene = new EndingScene(this);

            scene = mainMenu;
        }
        public void MainMenu()
        {
            scene = mainMenu;
        }

        public void Map()
        {
            scene = mapScene;
        }

        public void Battle(monster monster)
        {
            scene = battleScene;
            battleScene.StartBattle(monster);
        }
        public void Rest()
        {
            scene = restScene;
        }
        public void GameStart()
        {
            scene = mapScene;
        }
        public void GameEnd()
        {
            scene = endingScene;
        }

        public void GameOver(string text = "")
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            running = false;
        }
    }
}
