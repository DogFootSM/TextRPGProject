using DigimonRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Scenes
{
    public class BattleScene : Scene
    {
        ConsoleKey key;
        int turn;

        int index;
        public event Action PlayerLoseEvent;
        public event Action PlayerWinEvent;
        public static bool isBattle = true;

        public override void Enter()
        {
            PlayerLoseEvent = End;
            PlayerWinEvent = Reward;
            Render();
            Input();
            Update();
        }

        public void Update()
        {
            LoseEventRun();
            WinEventRun();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("");

            //상대 몬스터 정보
            BattleScenePrint.PrintMonsterInfo();
            //내 캐릭터 정보
            BattleScenePrint.PrintPlayerInfo();
            BattleScenePrint.SelectInteractionPrint();

        }

        public override void Input()
        {
            key = Console.ReadKey(true).Key;
            SelectInteraction(key);
        }

        public void SelectInteraction(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    Attack();
                    break;

                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    Defense();
                    break;

                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    Console.WriteLine("스킬 사용!!");
                    break;

                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    RunAway();
                    break;

                default:
                    break;
            }
        }

        public void Attack()
        {
            Console.SetCursorPosition(40, 10);
            Console.WriteLine($"{Game.instance.player.Name} 공격");
            Thread.Sleep(400);
            index = MonsterCreate.GetRandIndex();

            //플레이어가 살아있는 상태에서만 데미지 호출
            if (Game.instance.player.Life)
            {
                MonsterCreate.monsters[index].TakeDamage(Game.instance.player.Str);     //플레이어의 공격력만큼 데미지를 입음
            }
        }

        public void Defense()
        {
            Console.SetCursorPosition(40, 10);
            Console.WriteLine($"{Game.instance.player.Name} 방어");
            Thread.Sleep(400);
            MonsterCreate.monsters[index].GiveDamage();
        }

        public void RunAway()
        {
            BattleScenePrint.BattleRunText();
            MonsterCreate.monsters[index].MonsterHp = MonsterCreate.monsters[index].MonsterMaxHp;
            Game.instance.SetScene(Enum.SceneType.Battlefield);
        }


        public void LoseEventRun()
        {
            //플레이어가 죽으면 이벤트 실행
            if (Game.instance.player.Life == false)
            {
                PlayerLoseEvent?.Invoke();
            }
        }

        public void End()
        {
            BattleScenePrint.BattleEndText();
            isBattle = false;                       //전투가 끝나면 전투 상태를 false 로 변경
            Game.instance.player.Life = true;       //플레이어가 죽으면 라이프 원상 복구
            Game.instance.player.Hp = Game.instance.player.MaxHp / 2;   //플레이어가 죽으면 최대 체력의 절반으로 회복
            MonsterCreate.monsters[index].MonsterHp = MonsterCreate.monsters[index].MonsterMaxHp; //전투가 끝나면 몬스터 체력 원상 복구
            Game.instance.SetScene(Enum.SceneType.Battlefield);     //사냥터 씬으로 이동
        }

        public void WinEventRun()
        {
            //몬스터가 죽으면 이벤트 실행
            if (MonsterCreate.monsters[index].Life == false)
            {
                PlayerWinEvent?.Invoke();
            }
        }

        public void Reward()
        {
            //아이템 지급 함수 호출
            isBattle = false;                               //전투가 끝나면 전투 상태를 false 로 변경
            MonsterCreate.monsters[index].Life = true;      //전투가 끝난 후 몬스터 라이프 복구
            MonsterCreate.monsters[index].MonsterHp = MonsterCreate.monsters[index].MonsterMaxHp;   //전투가 끝나면 몬스터 체력 원상 복구
            Game.instance.player.AddInventory(MonsterCreate.monsters[index].RewardProvideItem());   //랜덤으로 지급받은 아이템을 인벤토리에 추가
            Game.instance.player.Exp += MonsterCreate.monsters[index].RewardProvideExp();           //지급받은 경험치만큼 증가
            BattleScenePrint.BattleEndText();
            Game.instance.SetScene(Enum.SceneType.Battlefield);     //사냥터 씬으로 이동
        }


    }
}
