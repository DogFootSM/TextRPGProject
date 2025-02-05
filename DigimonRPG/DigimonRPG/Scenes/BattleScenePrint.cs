using DigimonRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Scenes
{
    public static class BattleScenePrint
    {

        public static void BattleStartText()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t:::::::::      :::     ::::::::::: ::::::::::: :::        :::::::::: ::: \r\n" +
                "\t\t\t:+:    :+:   :+: :+:       :+:         :+:     :+:        :+:        :+: \r\n" +
                "\t\t\t+:+    +:+  +:+   +:+      +:+         +:+     +:+        +:+        +:+ \r\n" +
                "\t\t\t+#++:++#+  +#++:++#++:     +#+         +#+     +#+        +#++:++#   +#+ \r\n" +
                "\t\t\t+#+    +#+ +#+     +#+     +#+         +#+     +#+        +#+        +#+ \r\n" +
                "\t\t\t#+#    #+# #+#     #+#     #+#         #+#     #+#        #+#            \r\n" +
                "\t\t\t#########  ###     ###     ###         ###     ########## ########## ### ");
            Thread.Sleep(1000);
        }

        public static void BattleEndText()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t:::::::::: ::::    ::: :::::::::  \r\n" +
                "\t\t\t:+:        :+:+:   :+: :+:    :+: \r\n" +
                "\t\t\t+:+        :+:+:+  +:+ +:+    +:+ \r\n" +
                "\t\t\t+#++:++#   +#+ +:+ +#+ +#+    +:+ \r\n" +
                "\t\t\t+#+        +#+  +#+#+# +#+    +#+ \r\n" +
                "\t\t\t#+#        #+#   #+#+# #+#    #+# \r\n" +
                "\t\t\t########## ###    #### #########  \r\n");
 
            Thread.Sleep(1000);
        }

        public static void BattleRunText()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t:::::::::  :::    ::: ::::    ::: \r\n" +
                "\t\t\t:+:    :+: :+:    :+: :+:+:   :+: \r\n" +
                "\t\t\t+:+    +:+ +:+    +:+ :+:+:+  +:+ \r\n" +
                "\t\t\t+#++:++#:  +#+    +:+ +#+ +:+ +#+ \r\n" +
                "\t\t\t+#+    +#+ +#+    +#+ +#+  +#+#+# \r\n" +
                "\t\t\t#+#    #+# #+#    #+# #+#   #+#+# \r\n" +
                "\t\t\t###    ###  ########  ###    #### \r\n");


            Thread.Sleep(1000);
        }

         
        public static void PrintPlayerInfo()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine($"[{Game.instance.player.Name}]\n");
            Console.WriteLine($"Lv : {Game.instance.player.Level}\n");
            Console.WriteLine($"HP : {Game.instance.player.Hp} / {Game.instance.player.MaxHp}\n");
            Console.WriteLine($"STR : {Game.instance.player.Str}\n");
            Console.WriteLine($"DEF : {Game.instance.player.Def}\n");
            Console.WriteLine($"EXP : {Game.instance.player.Exp}\n");
        }

        public static void PrintMonsterInfo()
        {
            int index = MonsterCreate.GetRandIndex(); 
 
            Console.WriteLine($"[{MonsterCreate.monsters[index].MonsterName}]");
             
            Console.WriteLine($"HP : {MonsterCreate.monsters[index].MonsterHp} / {MonsterCreate.monsters[index].MonsterMaxHp}");
             
            Console.WriteLine($"STR : {MonsterCreate.monsters[index].MonsterStr}");
        }

        public static void SelectInteractionPrint()
        {
            Console.WriteLine("1. 공격하기 ");
            Console.WriteLine("2. 방어하기 ");
            Console.WriteLine("3. 스킬사용(스킬명) ");
            Console.WriteLine("4. 도망가기 ");
        }


    }
}
