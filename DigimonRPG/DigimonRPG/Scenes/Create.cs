using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DigimonRPG.Digimons;

namespace DigimonRPG.Scenes
{
    public class Create : Scene
    {
        ConsoleKey key;
        private string[] digimonName = { "코로몬", "토코몬", "뿔몬" };
        string[] selectArrow = { "\t\t\t   ▲", "\t\t\t\t\t\t   ▲", "\t\t\t\t\t\t\t\t\t   ▲" };

        public static PlayerBuilder[] digimons = new PlayerBuilder[(int)Enum.DigimonType.Max - 1];
         
        Confirm confirm;

        //선택한 디지몬 설정 값
        private static int choiceNumber = 1;
        public static Enum.DigimonType digimonType;
        private int digimonIndex;

        public override void Enter()
        {
             
            DigimonBuild();
            Render();
            Input();
            
        }

        public override void Render()
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\t\t===================================================================");
            Console.WriteLine("\t\t\t\t<원하는 디지몬을 선택해주세요.>");
            Console.WriteLine();
            Console.WriteLine();

            //현재 선택된 디지몬 enum 값 업데이트
            digimonType = (Enum.DigimonType)choiceNumber;
            //디지몬 배열 인덱스
            digimonIndex = (int)digimonType - 1;


            //현재 선택된 디지몬 설명 노출
            switch (digimonType)
            {
                case Enum.DigimonType.Koromon:
                    PrintDigimon();
                    PrintDigimonName();
                    Console.WriteLine(selectArrow[0]);

                    break;

                case Enum.DigimonType.Tokomon:
                    PrintDigimon();
                    PrintDigimonName();
                    Console.WriteLine(selectArrow[1]);

                    break;

                case Enum.DigimonType.Bbulmon:
                    PrintDigimon();
                    PrintDigimonName();
                    Console.WriteLine(selectArrow[2]);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t선택 : ENTER");


        }

        public override void Input()
        {
            key = Console.ReadKey(true).Key;
            SelectDigimon();
        }

        public void SelectDigimon()
        { 
            switch (key)
            {
                //방향키 좌,우 변경 시 디지몬 선택 변경
                case ConsoleKey.RightArrow:
                    if (choiceNumber < 3)
                    {
                        choiceNumber += 1;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (choiceNumber > 1)
                    {
                        choiceNumber -= 1;
                    }
                    break;

                case ConsoleKey.Enter:
                    //선택한 디지몬 화면 이동
                    //선택한 디지몬으로 Build
                    Game.instance.player = digimons[digimonIndex].Build(digimonName[digimonIndex]);
                    confirm = new Confirm();
                    confirm.Enter();
                    
                    break;
            }
        }
        public void PrintDigimonName()
        {
            //디지몬 선택 목록
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"\t\t\t1.{digimonName[0]}\t");
            Console.Write($"\t2.{digimonName[1]}\t");
            Console.Write($"\t3.{digimonName[2]}\t\n\n");
        }
         

        public void PrintDigimon()
        {
            //디지몬 설명
            Console.WriteLine($"\t\t\t[{digimons[digimonIndex].GetName()}]\n");
            Console.WriteLine($"\t\t\t성정단계 : {digimons[digimonIndex].GetGrowth()}");
            Console.WriteLine($"\t\t\t스탯 : 공격 {digimons[digimonIndex].GetStr()} " +
                $"/ 방어 {digimons[digimonIndex].GetDef()} / " +
                $"체력 {digimons[digimonIndex].GetHp()}");
            Console.WriteLine("\t\t\t스킬 : 거품발사");
            Console.WriteLine();
            Console.WriteLine($"{digimons[digimonIndex].GetDisc()}");
            
        }
         
        public void DigimonBuild()
        {

            //선택한 디지몬
            if (digimons[0] == null)
            {
                digimons[0] = new PlayerBuilder("코로몬", "유년기", 4, 1, 50, "\t\t\t표면을 덮고 있던 솜털이 빠지고 몸도 한층 더 커진 소형 디지몬.\n\n" +
                "\t\t\t활발하게 돌아다닐 수 있게 됐지만 아직 싸우기엔 무리다. \n\n" +
                "\t\t\t입에서 거품을 뿜어내 적을 위협한다.\n");
            }

            else if (digimons[1] == null)
            {
                digimons[1] = new PlayerBuilder("토코몬", "유년기", 2, 3, 70, "\t\t\t몸의 아래에 팔다리 같은 무언가가 자라난 소형 디지몬. \n\n" +
                "\t\t\t팔다리가 난 유년기 디지몬은 비상히 희귀하며 보기에도 엄청나게 귀엽다. \n\n" +
                "\t\t\t하지만 귀엽다고 섣불리 다가가 손을 뻗으면, 돌연 입을 크게 벌려, \n\n" +
                "\t\t\t빽빽히 나 있는 송곳니에 물릴 수도 있으므로 신경써야 한다. \n\n" +
                "\t\t\t단, 성격은 순진무구하므로 악의는 없다.\n");
            }
            else if (digimons[2] == null)
            {
                digimons[2] = new PlayerBuilder("뿔몬", "유년기", 3, 2, 50, "\t\t\t푸니몬의 머리에 난 촉수 중 하나가 단단해진 소형 디지몬. \n\n" +
                "\t\t\t푸니몬에서 보다 동물적 진화를 하여, 몸이 복슬복슬한 털에 싸여있다. \n\n" +
                "\t\t\t아직 잔뜩 놀고 싶어하는 성격이며, 장난꾸러기 같은 성격이지만, \n\n" +
                "\t\t\t전투 본능은 각성 되지 않았다.\n");
            } 
        }

        
 

    }
}
