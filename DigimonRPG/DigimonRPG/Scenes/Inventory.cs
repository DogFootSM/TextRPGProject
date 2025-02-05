using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigimonRPG.Items;

namespace DigimonRPG.Scenes
{
    public class Inventory
    {
        ConsoleKey key;
        public static List<Item> inventory = new List<Item>();

        public void Enter()
        {
            Render();
            Input();
            Update();
        }
        

        public void Render()
        {
            PrintInventory();
        }

        public void Input()
        {
            key = Console.ReadKey().Key;
            Game.instance.player.PlayerInteraction(key);
        }

        public void Update()
        {
            InventoryUseItem();
        }

        public void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine("<\t인벤토리\t>");
            Console.WriteLine();

            if (inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있는 상태");
            }
            else
            {
                //아이템 목록 출력
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write($"{i + 1}.{inventory[i].GetName()} : {inventory[i].GetDisc()}");
                    Console.WriteLine();
                }
            }
        }

        //현재 인벤토리에 들어있는 아이템 개수 반환
        public int GetInventoryCount()
        {
            return inventory.Count;
        }
 
        //인벤토리 10칸 제한
        public void AddItem(Item item)
        {
            if (inventory.Count < 10)
            {
                inventory.Add(item);
            }
            else
            {
                Console.WriteLine("인벤토리가 가득 찼습니다."); 
            } 
        }

        public void InventoryUseItem()
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: 

                    if(EmptyInventoryCheck(1))
                    {
                        
                        ItemUseInventory(1);
                    }
                    else
                    {
                        Console.WriteLine("비어있는 인벤토리 칸입니다.");
                    } 
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    if (EmptyInventoryCheck(2))
                    {
                        ItemUseInventory(2);
                    }
                    else
                    {
                        Console.WriteLine("비어있는 인벤토리 칸입니다.");
                    }

                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    if (EmptyInventoryCheck(3))
                    { 
                         
                        ItemUseInventory(3);
                    }
                    else
                    {
                        Console.WriteLine("비어있는 인벤토리 칸입니다.");
                    }

                    break;
            }
        }

        public void ItemUseInventory(int num)
        {
            //인벤토리에 들어있는 아이템 사용
            inventory[num - 1].ItemUse(inventory[num - 1]);
            
            //사용 아이템 제거
            inventory.RemoveAt(num - 1);
            Thread.Sleep(500);

        }


        public bool EmptyInventoryCheck(int num)
        { 
            return num > inventory.Count ? false : true;
        }


    }
}
