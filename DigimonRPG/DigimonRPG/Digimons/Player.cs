using DigimonRPG.Items;
using DigimonRPG.Objects;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigimonRPG.Enum;

namespace DigimonRPG.Digimons
{
    public struct Skill
    {
        string skillName;
        int skillId;
        int skillDamage;
        int coolTime;
    }

    public class PlayerBuilder
    {
        private string name;
        private string stageGrowth;
        private int str;
        private int def;
        private int hp;
        private string disc;

        public PlayerBuilder(string name, string stageGrowth, int str, int def, int hp, string disc)
        {
            this.name = name;
            this.stageGrowth = stageGrowth;
            this.str = str;
            this.def = def;
            this.hp = hp;
            this.disc = disc;
        }


        public Player Build(string name)
        {
            switch (name)
            {
                case "코로몬":
                    Player koromon = new Koromon();
                    koromon.Name = this.name;
                    koromon.StageGrowth = stageGrowth;
                    koromon.Str = str;
                    koromon.Def = def;
                    koromon.Hp = hp;
                    koromon.Disc = disc;

                    return koromon;

                case "토코몬":

                    Player tokomon = new Tokomon();
                    tokomon.Name = this.name;
                    tokomon.StageGrowth = stageGrowth;
                    tokomon.Str = str;
                    tokomon.Def = def;
                    tokomon.Hp = hp;
                    tokomon.Disc = disc;

                    return tokomon;

                case "뿔몬":

                    Player Bbulmon = new Bbulmon();
                    Bbulmon.Name = name;
                    Bbulmon.StageGrowth = stageGrowth;
                    Bbulmon.Str = str;
                    Bbulmon.Def = def;
                    Bbulmon.Hp = hp;
                    Bbulmon.Disc = disc;

                    return Bbulmon;

                default:

                    return null;
            }

        }

        public string GetName()
        {
            return name;
        }

        public string GetGrowth()
        {
            return stageGrowth;
        }

        public int GetStr()
        {
            return str;
        }

        public int GetDef()
        {
            return def;
        }

        public int GetHp()
        {
            return hp;
        }

        public string GetDisc()
        {
            return disc;
        }

    }


    public class Player
    {
        public string Name { get; set; }
        public string StageGrowth { get; set; }

        private int str;
        public int Str { get { return str; } set { str = value; } }

        private int def;
        public int Def { get { return def; } set { def = value; } }

        private int hp;
        public int Hp { get { return hp; } set { hp = value; } }

        public string Disc { get; set; }


        private int level;
        public int Level { get { return level; } set { level = value; } }

        private int exp;
        public int Exp { get { return exp; } set { exp = value; } }

        public int MaxHp { get { return maxHp; } set { maxHp = value; } }
        private int maxHp;
        private int maxExp = 100;

        private bool life = true; 
        public bool Life { get { return life; } set { life = value; } }

        private int gold = 10000;
        public int Gold { get { return gold; } set {  gold = value; } } 


        bool duplicateCheck;
        private int posX;
        private int posY;
        protected Item startChip;
        protected Item startPotion;

        protected Inventory playerInventory;

        public List<SceneType> saveCurScene;

        public Player()
        {
            playerInventory = new Inventory();
            saveCurScene = new List<SceneType>();
        }

        //플레이어 위치 설정
        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public int GetPosX()
        {
            return posX;
        }

        public int GetPosY()
        {
            return posY;
        }

        public void PlayerInteraction(ConsoleKey key)
        { 
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;

                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;

                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;

                case ConsoleKey.I: 
                    Game.instance.SetScene(SceneType.Inventory); 
                    break;

                case ConsoleKey.Escape:
                    Game.instance.SetScene(saveCurScene[saveCurScene.Count-1]);
                    
                    break;
            }
        }

        public void SaveScene(SceneType curScene)
        { 
            duplicateCheck = saveCurScene.Any(x => x == curScene);

            //리스트에 현재 위치의 씬과 중복된 씬이 없을 경우에만 저장
            if (duplicateCheck == false)
            {
                saveCurScene.Add(curScene);
            }    
        }
        public int GetInventoryCount()
        {
            return playerInventory.GetInventoryCount();
        }

        public void UsePotion(int heal)
        {
            Hp += heal;

            if (Hp > maxHp)
            {
                Hp = maxHp;
            }
        }

        public void UseChip(int ability)
        {
            Str += ability;
        }



        public void RemoveScene()
        { 
            //이동 시 가장 최근 씬 제거
            saveCurScene.RemoveAt(saveCurScene.Count - 1); 
        }
         
        public SceneType CurrentScene()
        {
            //현재 위치를 표시해줄 최근 씬
            return saveCurScene[saveCurScene.Count - 1];
        }

        public void MoveLeft()
        {
            if (posX > 1)
            {
                posX += -1;
            } 
        }

        public void MoveRight()
        {
            if (posX < 16)
            {
                posX += 1;
            }

        }

        public void MoveUp()
        {
            if (posY > 1)
            {
                posY += -1;
            }

        }

        public void MoveDown()
        {
            if (posY < 11)
            {
                posY += 1;
            }

        }

        public void LevelUp()
        { 
            if(exp >= 100)
            {
                exp %= 100;
                level++;
                StrUp();
                HpUp();
                DefUp();
            }

        }

        public void ItemBuy(int price)
        {
            gold -= price;
        }

        public void StrUp()
        {
            str = str + (int)(level * 0.3);
        }

        public void HpUp()
        {
            maxHp = maxHp + (int)(level * 0.3);
            hp = maxHp; 
        }

        public void DefUp()
        {
            def = def + (int)(level * 0.3);
        }

        public void AddInventory(Item item)
        {
 
            Thread.Sleep( 1000 );
            playerInventory.AddItem(item);
        }

        //디지몬에 따라 시작 아이템 다르게 지급
        public virtual void CreateStartItem() { }


        //디지몬 종류에 따라 데미지 수치 적용
        public virtual void TakeDamage(int damage) { }

    }

    public class Koromon : Player
    {

        public Koromon()
        {
             
        }

        public override void CreateStartItem()
        { 
            startChip = new Chip("하급 용기의 문장", "디지몬 생성 시 지급되는 문장", 1, 0, ItemType.Chip);
            startPotion = new Potion("시작의 포션", "디지몬 생성 시 지급되는 포션", 20, 0, ItemType.Potion);
            playerInventory.AddItem(startChip);
            playerInventory.AddItem(startPotion);

        }

        public override void TakeDamage(int damage)
        {
            Hp -= damage;
            Life = Hp < 1 ? false : true;
        }

    }

    public class Tokomon : Player
    {
        public override void CreateStartItem()
        {
            startChip = new Item("하급 희망의 문장", "디지몬 생성 시 지급되는 문장", 1,0, ItemType.Chip);
            startPotion = new Item("시작의 포션", "디지몬 생성 시 지급되는 포션", 20,0, ItemType.Potion);
            playerInventory.AddItem(startChip);
            playerInventory.AddItem(startPotion);

        }

        public override void TakeDamage(int damage)
        {
            Hp -= (int)(damage * 0.7);
            Life = Hp < 1 ? false : true;
        }


    }

    public class Bbulmon : Player
    {
        public override void CreateStartItem()
        {
            startChip = new Item("하급 우정의 문장", "디지몬 생성 시 지급되는 문장", 1, 0,ItemType.Chip);
            startPotion = new Item("시작의 포션", "디지몬 생성 시 지급되는 포션", 20, 0, ItemType.Potion);
            playerInventory.AddItem(startChip);
            playerInventory.AddItem(startPotion);
        }

        public override void TakeDamage(int damage)
        {
            Hp -= (int)(damage * 0.8);
            Life = Hp < 1 ? false : true;
        }

    }



}
