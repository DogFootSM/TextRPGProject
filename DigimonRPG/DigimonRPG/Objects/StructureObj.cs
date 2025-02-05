using DigimonRPG.Monsters;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Objects
{
    public static class StructureObj
    {
        public static void TownWall()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("#");
            Console.ResetColor();
        }

        public static void FieldWall()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Console.ResetColor();
        }


        public static void Ground()
        { 
            Console.Write(" "); 
        }


        public static void Character()
        {  
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Game.instance.player.GetPosX(), Game.instance.player.GetPosY());
            Console.Write("P");
            Console.ResetColor(); 
        }

        public static void ShopUI()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(Shop.PosX, Shop.PosY);
            Console.Write("S");
            Console.ResetColor(); 
        }

    }
}
