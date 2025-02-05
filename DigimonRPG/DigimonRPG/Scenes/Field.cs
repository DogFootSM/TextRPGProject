using DigimonRPG.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigimonRPG.Monsters;

namespace DigimonRPG.Scenes
{
    public class Field : Scene
    {
        ConsoleKey key;
        public event Action FieldPortalEvent;
        public event Action BattleEvent;
        
        public override void Enter()
        {
            Game.instance.player.SaveScene(Game.instance.GetScene());

            //던전 포탈 이벤트 등록
            FieldPortalEvent = TownIn;
            //배틀 이벤트 등록
            BattleEvent = BattleStart;

            Render();
            Input();
            Update();
        }

        public void Update()
        {
            BattleScene.isBattle = true;
        }
         
        public override void Render()
        {
            Console.Clear();
            Map.PrintFieldMap();
            StructureObj.Character();
            TownPortalObj.TownPortal(); 
            MonsterCreate.Print();      //몬스터 그려줌
            DigimonPrint.PrintStats(); 
        }

        public override void Input()
        {
            key = Console.ReadKey(true).Key;
            Game.instance.player.PlayerInteraction(key);
            Meeting();
            EventRun();
            
        }

        public void Meeting()
        {
            int index = MonsterCreate.GetRandIndex();
            //Battle Event Invoke할 조건
            //플레이어와 몬스터가 만났을 때
            if ((Game.instance.player.GetPosX() == MonsterCreate.monsters[index].GetMonsterPosX()) && (Game.instance.player.GetPosY() == MonsterCreate.monsters[index].GetMonsterPosY()))
            {  
                BattleEvent?.Invoke(); 
            } 
        }


        public void BattleStart()
        {
            //Battle Event 발생
            BattleScenePrint.BattleStartText();
            Game.instance.SetScene(Enum.SceneType.Battle);
            FieldPortalEvent -= BattleStart;
        }

        //마을 포탈 이동 이벤트
        public void EventRun()
        {
            int posX = Game.instance.player.GetPosX();
            int posY = Game.instance.player.GetPosY();

            if (TownPortalObj.GetX() == posX && TownPortalObj.GetY() == posY)
            {
                //이벤트 Null이 아니면 Invoke  
                FieldPortalEvent?.Invoke();
            } 
        }

        public void TownIn()
        {
            Game.instance.player.RemoveScene();
            Game.instance.player.SetPosition(10, 10);
            FieldPortalEvent -= TownIn;
            Game.instance.SetScene(Enum.SceneType.Town); 
        }

    }
}
