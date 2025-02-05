using DigimonRPG.Monsters;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigimonRPG.Enum;

namespace DigimonRPG.Items
{
     
    public class Item
    {
        private string itemName;
        private string itemDisc;

        private int itemEffect;
        public int ItemEffect { get { return itemEffect; } }

        private int price;
        private ItemType itemType;

        

        public Item(string itemName, string itemDisc, int itemEffect,int price ,ItemType itemType)
        {

            this.itemName = itemName;
            this.itemDisc = itemDisc;
            this.itemEffect = itemEffect;
            this.itemType = itemType;
            this.price = price;
        }

        public string GetName()
        {
            return itemName;
        }

        public ItemType GetItemType()
        {
            return itemType;
        }

        public string GetDisc()
        {
            return itemDisc;
        }

 
        public int GetPrice()
        {
            return price;
        }

        public virtual void ItemUse(Item item)
        {
            //아이템 효과 다르게 적용
            
        }


    }

    public class Potion : Item
    {
        public Potion(string itemName, string itemDisc, int itemEffect,int price, ItemType itemType) : base(itemName, itemDisc, itemEffect,price, itemType)
        {

        }

        public override void ItemUse(Item item)
        {
            Game.instance.player.UsePotion(item.ItemEffect);
             
        }

    }

    public class Chip : Item
    {
        public Chip(string itemName, string itemDisc, int itemEffect,int price, ItemType itemType) : base(itemName, itemDisc, itemEffect,price, itemType)
        {

        }

        public override void ItemUse(Item item)
        {
            Game.instance.player.UseChip(item.ItemEffect);
        }

    }



}
