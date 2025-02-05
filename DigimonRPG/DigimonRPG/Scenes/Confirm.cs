using DigimonRPG.Digimons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigimonRPG.Enum;

namespace DigimonRPG.Scenes
{
   
    public class Confirm : Scene
    {
        ConsoleKey key;
         
        public override void Enter()
        { 
            Render();
            Input(); 
        }

        public override void Render()
        {
            Console.Clear();

            //선택한 디지몬 정보 그림
            DigimonPrint.Print();
        }

        public override void Input()
        {
            key = Console.ReadKey(true).Key;
            ButtonSelect(); 
        }

        public void ButtonSelect()
        {

            switch (key)
            {
                case ConsoleKey.Y:
                    DigimonPrint.SelectYesButton();

                    //초기 디지몬 설정
                    Game.instance.player.SetPosition(10, 10);
                    Game.instance.player.Level = 1;
                    Game.instance.player.MaxHp = Game.instance.player.Hp;
                    Game.instance.player.CreateStartItem();

                     
                    Game.instance.SetScene(SceneType.Town);
                    break;

                case ConsoleKey.N:
                    DigimonPrint.SelectNoButton(); 
                    break;

                default:
                    //Y,N 외 입력 시 재진입
                    Enter(); 
                    break;
            }

        }
         
    }
}
