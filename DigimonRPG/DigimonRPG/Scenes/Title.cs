using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Scenes
{
    public class Title : Scene
    {
  
        public override void Enter()
        {
            Render();
            Input();
        }

        public override void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t######                                     ######  ######   #####  \r\n");
            Console.WriteLine("\t\t\t#     # #  ####  # #    #  ####  #    #    #     # #     # #     # \r\n");
            Console.WriteLine("\t\t\t#     # # #    # # ##  ## #    # ##   #    #     # #     # #       \r\n");
            Console.WriteLine("\t\t\t#     # # #      # # ## # #    # # #  #    ######  ######  #  #### \r\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t#     # # #  ### # #    # #    # #  # #    #   #   #       #     # \r\n");
            Console.WriteLine("\t\t\t#     # # #    # # #    # #    # #   ##    #    #  #       #     # \r\n");
            Console.WriteLine("\t\t\t######  #  ####  # #    #  ####  #    #    #     # #        #####  \r\n");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t시작하려면 아무 키나 누르세요."); 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        public override void Input()
        {
             ConsoleKey key = Console.ReadKey().Key;
             Game.instance.SetScene(Enum.SceneType.Create); 
        }


    }
}
