
using DigimonRPG.Digimons;
using DigimonRPG.Monsters;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG
{


    public class Game
    {

        private bool isRunning = true;
        public static Game instance;
        Enum.SceneType sceneType;

        Title titleScene;
        Create createScene;
        Town townScene;
        Inventory inventoryScene;
        Field fieldScene;
        BattleScene battleScene;
        Shop shopScene;

        public Player player = null;

        public static Game getInstance()
        {
            if (instance == null)
            {
                instance = new Game();
            }

            return instance;
        }


        public void Run()
        {
            Start();

            while (isRunning)
            {
                Render();
            }

        }


        public void Start()
        {
            CreateScene();
            sceneType = Enum.SceneType.Title;
        }

        public void Render()
        {
            switch (sceneType)
            {
                case Enum.SceneType.Title:
                    titleScene.Enter();
                    break;

                case Enum.SceneType.Create:
                    createScene.Enter();
                    break;

                case Enum.SceneType.Town:
                    townScene.Enter();
                    break;

                case Enum.SceneType.Inventory:
                    inventoryScene.Enter();
                    break;

                case Enum.SceneType.Battlefield:
                    fieldScene.Enter();
                    break;

                case Enum.SceneType.Battle:
                    battleScene.Enter();
                    break;

                case Enum.SceneType.Shop:
                    shopScene.Enter();
                    break;
            }
        }


        public void SetScene(Enum.SceneType sceneType)
        {
            this.sceneType = sceneType;
        }

        public Enum.SceneType GetScene()
        {
            return sceneType;
        }

        public void CreateScene()
        {
            createScene = new Create();
            titleScene = new Title();
            townScene = new Town();
            inventoryScene = new Inventory();
            fieldScene = new Field();
            battleScene = new BattleScene();
            shopScene = new Shop();
        }

    }
}
