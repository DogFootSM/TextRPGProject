using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Objects
{
    public static class TownPortalObj
    {
        static int posX = 2;
        static int posY = 10;

        public static int GetX()
        {
            return posX;
        }

        public static int GetY()
        {
            return posY;
        }

        public static void TownPortal()
        { 
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(posX, posY);
            Console.Write("O");
            Console.ResetColor();
        }

    }
}
