using DigimonRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Scenes
{
    public class Shop : Scene
    {
        private static int posX = 14;
        private static int posY = 5;

        public static int PosX { get { return posX; } }
        public static int PosY { get { return posY; } }
        ConsoleKey key;


        public override void Enter()
        {
            Render();
            Input();
            Update();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("\t\t< 상점 >");
            Console.WriteLine();
            DisplayGoods();

        }

        public override void Input()
        {
            key = Console.ReadKey(true).Key;

            ItemBuy();
        }

        public void Update()
        {
            Refresh();
        }


        public void DisplayGoods()
        {

            Console.Clear();
            Console.Write("\tNo.");
            Console.Write("\t 이름");
            Console.Write("\t\t 가격");
            Console.WriteLine();
            Console.WriteLine();

            //진열된 아이템 그려줌
            for (int i = 0; i < ItemCreate.shopItem.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {ItemCreate.shopItem[i].GetName()} \t\t{ItemCreate.shopItem[i].GetPrice()}\n");

            }

            Console.SetCursorPosition(20, 20);
            Console.WriteLine("상점 나가기 : ESC");

        }

        public void ItemBuy()
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ShowBuyItem(1);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowBuyItem(2);
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowBuyItem(3);
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowBuyItem(4);
                    break;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ShowBuyItem(5);
                    break;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    ShowBuyItem(6);
                    break;

                case ConsoleKey.Escape:
                    Game.instance.SetScene(Game.instance.player.CurrentScene());
                    break;
            }
        }

        public void ShowBuyItem(int num)
        {
            Console.Clear();
            int playerGold = Game.instance.player.Gold;                 //현재 보유중인 골드
            int itemPrice = ItemCreate.shopItem[num - 1].GetPrice();    //아이템 가격
            int inventoryCount = Game.instance.player.GetInventoryCount();

            //현재 소지금이 아이템 가격보다 많을 경우에만 구입 가능
            if (playerGold < itemPrice)
            {
                Console.WriteLine("돈이 부족합니다.");
                Thread.Sleep(300);

            }
            else if (inventoryCount > 9)
            {
                Console.WriteLine("인벤토리가 가득 찼습니다.");
                Thread.Sleep(300);
            }
            else
            {
                if (ItemCreate.shopItem[num - 1] != null)
                {
                    Console.WriteLine($"{ItemCreate.shopItem[num - 1].GetName()} 을 구매하셨습니다.");
                    Game.instance.player.ItemBuy(itemPrice);        //아이템 구매 시 아이템 금액만큼 현재 보유 골드에서 차감
                    Game.instance.player.AddInventory(ItemCreate.shopItem[num - 1]);    //구매한 아이템 인벤토리에 추가
                    ItemCreate.shopItem.RemoveAt(num - 1);          //구매한 아이템 상점 목록에서 제거
                }
                Thread.Sleep(300);
            }
        }

        public void Refresh()
        {
            //상점에 모든 아이템이 팔린 상태면 아이템 재생성
            if (ItemCreate.shopItem.Count == 0)
            {
                ItemCreate.IsCreate = false;
                ItemCreate.ShopItemCreate();
            }
        }


    }
}
