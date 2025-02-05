using DigimonRPG.Digimons;
using DigimonRPG.Items;
using DigimonRPG.Objects;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Monsters
{
    //어떻게 사용할지 고민
    public class MonsterDictionary
    {
        private string monsterName;
        private int monsterHp;
        private int monsterStr;

        public static Dictionary<string, MonsterDictionary> monsterList = new Dictionary<string, MonsterDictionary>();

        public MonsterDictionary(string monsterName, int monsterHp, int monsterStr)
        {
            this.monsterName = monsterName;
            this.monsterHp = monsterHp;
            this.monsterStr = monsterStr;
        }

        public string GetName()
        {

            return monsterName;
        }

        public int GetMonsterHp()
        {
            return monsterHp;
        }

        public int GetMonsterStr()
        {
            return monsterStr;
        }

    }



    public class Monster
    {
        private string monsterName; 
        public string MonsterName { get { return monsterName; } }

        private int monsterHp;
        public int MonsterHp { get { return monsterHp; } set { monsterHp = value; } }

        private int monsterMaxHp;
        public int MonsterMaxHp { get { return monsterMaxHp; } set { monsterMaxHp = value; } }

        private int monsterStr;
        public int MonsterStr { get { return monsterStr; } }

        private static int posX;
        private static int posY;

        private int playerPosY;
        private int playerPosX;
        private int portalPosX;
        private int portalPosY;

        public static int PosX { get { return posX; } set { posX = value; } }
        public static int PosY { get { return posY; } set { posY = value; } }

        private bool life = true;

        public bool Life { get { return life; } set { life = value; } }

        Random rand = new Random(Environment.TickCount);
        Item[] items = new Item[5];


        public Monster(string monsterName, int monsterHp, int monsterStr)
        {
            MonsterDictionary.monsterList.Add(monsterName, new MonsterDictionary(monsterName, monsterHp, monsterStr));

            this.monsterName = monsterName;
            this.monsterHp = monsterHp;
            this.monsterStr = monsterStr;
        }

        public Item RewardProvideItem()
        {
            ItemCreate.RandomItemCreate();      //보상으로 지급할 아이템들을 생성

            return ItemCreate.items[rand.Next(0, 5)]; 
        }

        public virtual int RewardProvideExp(){ return 0;}
 

        //플레이어와 포탈의 위치와 겹치지 않게 몬스터 랜덤한 위치 설정
        public void SetPosition()
        {
            playerPosX = Game.instance.player.GetPosX();
            playerPosY = Game.instance.player.GetPosY();
            portalPosX = TownPortalObj.GetX();
            portalPosY = TownPortalObj.GetY();

            
            do
            {
                PosX = rand.Next(1, 17);
                PosY = rand.Next(1, 12);

            } while (((playerPosX != PosX) && (playerPosY != PosY)) && ((portalPosX != PosX) && (portalPosY != PosY))); 
        }

        public virtual void EnemyCharacter() { }

        public int GetMonsterPosX()
        {
            return posX;        //몬스터의 X위치 반환
        }

        public int GetMonsterPosY()
        {
            return posY;        //몬스터의 y위치 반환
        }

        public void TakeDamage(int damage)
        {
            int choice = rand.Next(2);

            //0이 들어오면 몬스터가 공격 1이 들어오면 몬스터 방어
            

            if (choice == 0)
            { 
                Console.SetCursorPosition(40, 10); 
                monsterHp -= damage; 
            }
            else
            { 
                Console.SetCursorPosition(40, 10); 
                monsterHp -= (int)(damage * 0.6);
            }

            life = monsterHp < 1 ? false : true;

            if (life)
            {
                Game.instance.player.TakeDamage(monsterStr);
            }

        }

        public void GiveDamage()
        {
            int choice = rand.Next(2);

            //0이 들어오면 몬스터가 공격 1이 들어오면 몬스터 방어
            if (choice == 0)
            { 
                Console.SetCursorPosition(40, 10); 
                Game.instance.player.TakeDamage((int)(monsterStr*0.6));
            } 
 
        } 
    }

    public class Pinokimon : Monster
    {
        public Pinokimon(string monsterName, int monsterHp, int monsterStr):base (monsterName, monsterHp, monsterStr)
        {

        }

        public override void EnemyCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("V");
            Console.ResetColor();
        }

        public override int RewardProvideExp()
        {
            //경험치 지급  
            return 120;
        }

    }

    public class Etemon : Monster
    {
        public Etemon(string monsterName, int monsterHp, int monsterStr) : base(monsterName, monsterHp, monsterStr)
        {

        }

        public override void EnemyCharacter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("B");
            Console.ResetColor();
        }

        public override int RewardProvideExp()
        {
            //경험치 지급  
            return 120;
        }


    }

    public class Myotismon : Monster
    {
        public Myotismon(string monsterName, int monsterHp, int monsterStr) : base(monsterName, monsterHp, monsterStr)
        {

        }
        public override void EnemyCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("N");
            Console.ResetColor();
        }

        public override int RewardProvideExp()
        {
            //경험치 지급  
            return 120;
        }

    }

    public class Piemon : Monster
    {
        public Piemon(string monsterName, int monsterHp, int monsterStr) : base(monsterName, monsterHp, monsterStr) { }

        public override void EnemyCharacter()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("M");
            Console.ResetColor();
        }

        public override int RewardProvideExp()
        {
            //경험치 지급  
            return 120;
        }
    }

    public class Powerdramon : Monster
    {
        public Powerdramon(string monsterName, int monsterHp, int monsterStr) : base(monsterName, monsterHp, monsterStr) { }

        public override void EnemyCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(PosX, PosY);
            Console.Write("C");
            Console.ResetColor();
        }

        public override int RewardProvideExp()
        {
            //경험치 지급  
            return 120;
        }

    }
        
}
