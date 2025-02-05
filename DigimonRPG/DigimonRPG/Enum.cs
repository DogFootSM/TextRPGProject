using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG
{
    public class Enum
    {
        public enum ItemType
        {
            Chip, Potion
        }

        public enum SceneType
        {
            Title, Create, Town, Inventory, Battlefield, Battle, Shop
        }

        public enum DigimonType
        {
            Koromon =1, Tokomon, Bbulmon, Max
        }
         
    }
}
