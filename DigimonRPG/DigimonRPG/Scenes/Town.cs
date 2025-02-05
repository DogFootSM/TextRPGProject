using DigimonRPG.Digimons;
using DigimonRPG.Items;
using DigimonRPG.Monsters; 
using DigimonRPG.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace DigimonRPG.Scenes
{
    public class Town : Scene
    {

        ConsoleKey key;
        Map map;
        public event Action TownPortalEvent;
        public event Action ShopEvent;
        private int posX;
        private int posY;

        public Town()
        {
            map = new Map();
            
        }
        
        public override void Enter()
        { 
            Game.instance.player.SaveScene(Game.instance.GetScene());

            //마을 포탈 이벤트 등록
            TownPortalEvent = FieldIn;

            //상점 이벤트 등록
            ShopEvent = ShopIn;

            Render();
            Input();
            Update();
        }
        

        public override void Render()
        { 
            
            Console.Clear(); 
            Map.PrintTownMap();
            StructureObj.Character();
            DeongeonPortalObj.DoengeonPortal();
            DigimonPrint.PrintStats();
            StructureObj.ShopUI();
        } 


        public override void Input()
        { 
            key = Console.ReadKey(true).Key; 
            Game.instance.player.PlayerInteraction(key);
                
        }

        public void Update()
        {
            posX = Game.instance.player.GetPosX();
            posY = Game.instance.player.GetPosY();
            EventRun();
            ShopEventRun();
        }

        public void EventRun()
        {

            if(DeongeonPortalObj.GetX() == posX && DeongeonPortalObj.GetY() == posY)
            {
                TownPortalEvent?.Invoke();
            }

        }

        public void FieldIn()
        { 
            MonsterCreate.Create(); 
            for(int i = 0; i < MonsterCreate.monsters.Length; i++)
            {
                MonsterCreate.monsters[i].SetPosition();
                MonsterCreate.monsters[i].MonsterMaxHp = MonsterCreate.monsters[i].MonsterHp;
            }

            TownPortalEvent -= FieldIn;
            Game.instance.SetScene(Enum.SceneType.Battlefield);
            
        }

        public void ShopEventRun()
        {

            if (Shop.PosX == posX && Shop.PosY == posY)
            {
                ShopEvent?.Invoke();
            }

        }

        public void ShopIn()
        {   
            //상점 판매 아이템 생성
            ItemCreate.ShopItemCreate(); 

            //상점 씬으로 이동
            Game.instance.SetScene(Enum.SceneType.Shop);

        }


    }
}
