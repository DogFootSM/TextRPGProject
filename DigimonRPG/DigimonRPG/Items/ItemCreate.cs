using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Items
{
    public static class ItemCreate
    {
        public static Item[] items = new Item[5];
        public static List<Item> shopItem = new List<Item>();
        private static bool isCreate = false;
        public static bool IsCreate { get { return isCreate; } set { isCreate = value; } }


        public static void RandomItemCreate()
        {
            items[0] = new Chip("성실의 문장", "공격력 2증가시켜줌", 2, 0, Enum.ItemType.Chip);
            items[1] = new Chip("빛의 문장", "공격력 1증가 시켜줌", 1, 0, Enum.ItemType.Chip);
            items[2] = new Chip("디지몬 디바이스", "공격력 1증가 시켜줌", 1, 0, Enum.ItemType.Chip);
            items[3] = new Potion("마법의 수프", "체력을 20 회복시켜 준다.", 1, 0, Enum.ItemType.Potion);
            items[4] = new Potion("마법의 사탕", "공격력을 영구적으로 2 증가시켜 준다.", 1, 0, Enum.ItemType.Potion);
        }


        public static void ShopItemCreate()
        {
            
            if (isCreate == false)
            {
                isCreate = true;
                shopItem.Add(new Chip("장난감 칼", "공격력을 1 증가시켜주는 장난감 칼이다.", 1, 100, Enum.ItemType.Chip));
                shopItem.Add(new Chip("장난감 날개", "방어력을 1 증가시켜주는 장난감 날개이다.", 1, 150, Enum.ItemType.Chip));
                shopItem.Add(new Potion("초코칩 쿠키", "체력을 30 회복시켜주는 아이템", 30, 250,Enum.ItemType.Potion));
                shopItem.Add(new Potion("떡국", "체력을 50 회복시켜주는 아이템", 50, 350,Enum.ItemType.Potion));
                shopItem.Add(new Potion("호떡", "체력을 10 회복시켜주는 아이템", 10,200, Enum.ItemType.Potion));
                shopItem.Add(new Chip("광선검", "공격력을 10 증가시켜주는 아이템", 10,6000, Enum.ItemType.Chip));
 

            }
        }

 


    }
}
