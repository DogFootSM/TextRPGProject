using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Scenes
{
    public static class DigimonPrint
    {
        private static string playerName;
        private static string playerGrowth;
        private static int playerStr;
        private static int playerDef;
         
        public static void SelectDigimonInstance()
        {  
            playerName = Create.digimons[(int)Create.digimonType - 1].GetName();
            playerGrowth = Create.digimons[(int)Create.digimonType - 1].GetGrowth();
            playerStr = Create.digimons[(int)Create.digimonType - 1].GetStr();
            playerDef = Create.digimons[(int)Create.digimonType - 1].GetDef(); 
        }

        public static void Print()
        {
            SelectDigimonInstance();

            switch (playerName)
            { 
                case "코로몬":
                    SelectKormon();
                    break;

                case "토코몬":
                    SelectTokomon();
                    break;

                case "뿔몬":
                    SelectBbulmon();
                    break;
            }

            Console.WriteLine($"\t\t\t\t\t\t\t{playerName}을 생성하시겠습니까? [Y] [N]");
        }

        public static void SelectKormon()
        { 
            Console.WriteLine("           .  ,  ,    ,   . ,           ");
            Console.WriteLine("           .  .  ,    . .     .         ");
            Console.WriteLine("           .  ,    ...  .    ..,...     ");
            Console.WriteLine("           .  .,.,,,.. .    ,  .   .    ");
            Console.WriteLine("           .  -       .   , .           ");
            Console.Write("              .       ,  ,.  ..  . .    "); Console.WriteLine("\t\t\t<선택한 디지몬 정보>");
            Console.WriteLine("           ,.           .  .            ");
            Console.WriteLine("                            .           ");
            Console.Write("          . .               .           "); Console.WriteLine($" \t\t이름 : {playerName}");
            Console.WriteLine("         .-*:!         ~!!,. .          ");
            Console.Write("         .:, ~~      .!  ~!= .          "); Console.WriteLine($" \t\t성장 단계 : {playerGrowth}");
            Console.WriteLine("        . ~:$#;      ;- ~;;- .          ");
            Console.Write("        . --@$;     .!:#@!~.            "); Console.WriteLine($" \t\t공격력 : {playerStr}");
            Console.WriteLine("       ,  ,-~.;     .;,$$,:   .         ");
            Console.Write("       -   -:!.     -*-.,,;   .         "); Console.WriteLine($" \t\t방어력 : {playerDef}");
            Console.WriteLine("       ,              ,!!-              ");
            Console.WriteLine("       ,  .                .  .         ");
            Console.WriteLine("          ,;::,.,,.....-~;-   .         ");
            Console.WriteLine("        .  .:,...  ...-~~.   .          ");
            Console.WriteLine("         .    .,,,,,,,,     .           ");
            Console.WriteLine("          .                .            ");
            Console.WriteLine("            ,            ,              ");
            Console.WriteLine("              ..      ..                ");
            Console.WriteLine("                  ..                    ");

        }

        public static void SelectTokomon()
        {
            Console.WriteLine("  .,                      ~   ");
            Console.WriteLine("  . ,                    , .  ");
            Console.WriteLine("  . -                    , ,  ");
            Console.WriteLine("  . ..                ,~-  .  ");
            Console.WriteLine("  ,  -               ,.    .  ");
            Console.Write("  ..  .-       .   .-.  ,-~.  "); Console.WriteLine("\t\t\t\t<선택한 디지몬 정보>");
            Console.WriteLine("   -    ,:~~,. ...-- .~~,     ");
            Console.WriteLine("   -~,    -      - .-        ");
            Console.Write("      .,:~ ,      , -,,       "); Console.WriteLine($"\t\t\t이름 : {playerName}");
            Console.WriteLine("       ,..- -     .-  .       ");
            Console.Write("      ..  .-,    -,.   ,      "); Console.WriteLine($"\t\t\t성장 단계 : {playerGrowth}");
            Console.WriteLine("      -    .-,   ,,    ,      ");
            Console.Write("      ,     .    ,      ,     "); Console.WriteLine($"\t\t\t공격력 : {playerStr}");
            Console.WriteLine("     ..                 -     ");
            Console.Write("     -   -*.       ~:   -     "); Console.WriteLine($"\t\t\t방어력 : {playerDef}");
            Console.WriteLine("     -  ~=#;      :~#~  ,     ");
            Console.WriteLine("     -  ,#@~      :@@~  ,     ");
            Console.WriteLine("     -    .        ~-   ~     ");
            Console.WriteLine("     -  . -        -.   -     ");
            Console.WriteLine("     -   ..         -.  ,     ");
            Console.WriteLine("      .  .,         -   -     ");
            Console.WriteLine("      -   -.  ..   -.  ,~     ");
            Console.WriteLine("      --   ~;~. ~::,    -     ");
            Console.WriteLine("      ~  .           .  ,     ");
            Console.WriteLine("      ,. -,-,,,,-,,,,,,.-     ");
            Console.WriteLine("       ,-                  ");
        }

        public static void SelectBbulmon()
        {
            Console.WriteLine("            ;##$=!            ");
            Console.WriteLine("            !##=!!            ");
            Console.WriteLine("            *##=;*            ");
            Console.WriteLine("           .=##=:!            ");
            Console.WriteLine("           .=##=:!.           ");
            Console.Write("           ,$##=:!.           "); Console.WriteLine("\t\t\t\t<선택한 디지몬 정보>");
            Console.WriteLine("           ,=@#=~!.           ");
            Console.WriteLine("           ,$##=:!.           ");
            Console.Write("          .~$##=:!~           "); Console.WriteLine($"\t\t\t이름 : {playerName}");
            Console.WriteLine("        ,~:;!=$*;::~-.        ");
            Console.Write("      .~:~~--~;:~~---~-       "); Console.WriteLine($"\t\t\t성장 단계 : {playerGrowth}");
            Console.WriteLine("     ,:~~----------~--~~      ");
            Console.Write("    .:~~:~~~-----~~~~~-~-     "); Console.WriteLine($"\t\t\t공격력 : {playerStr}");
            Console.WriteLine("    ~::~,.,~~----~-,.,-::,    ");
            Console.Write("   .:~,,,,,,~~-~~-,.,.,-:~    "); Console.WriteLine($"\t\t\t방어력 : {playerDef}");
            Console.WriteLine("   ~~-.,,,,.,~~~-,,,,-,,~~,   ");
            Console.WriteLine("  ,:~--:~-,,.,~~.,,,::~--~:   ");
            Console.WriteLine("  -~~:*~:!~,,.~-.,,;:--*~~:   ");
            Console.WriteLine("  ~~-~;~:~;,,.,,.,~=::,!-~:.  ");
            Console.WriteLine(" .~-~-;:;*=~.,,,,.;$=!~:,-~,  ");
            Console.WriteLine(" -~-~~~;:*=;,,,.,,!;;!~-~-~~. ");
            Console.WriteLine(" ~~-~~.--~:-,.,.,,--~-.~~~-~, ");
            Console.WriteLine(" ~~~,,..,...,...,,,.....,-~~. ");
            Console.WriteLine(" ~;-...,....,,...,,.,.....~~. ");
            Console.WriteLine(" -!~...,,,-,..,,,,-.......~:. ");
            Console.WriteLine(" .;;-.,.,,,--~~--~-......,;-  ");
            Console.WriteLine("  ,*;-,,,,.,,,,,,,,,,,,.,~:   ");
            Console.WriteLine("   .::~-,,,.,---.,,,,,--~~    ");
            Console.WriteLine("     .-~~~~--~:~--~~~--,.     ");
            Console.WriteLine("         ..----~~-,..         ");
        }


        public static void SelectYesButton()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t{playerName}을 선택하셨습니다.");
            Console.WriteLine($"\n\t\t\t\t\t마을로 이동합니다...");
            Thread.Sleep(1000);
        }

        public static void SelectNoButton()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t디지몬 선택 화면으로 이동합니다...");
            Thread.Sleep(1000);
        }

        //화면 하단 능력치
        public static void PrintStats()
        {
            Console.SetCursorPosition(0, 15);
            Game.instance.player.LevelUp();
            Console.WriteLine($"[{Game.instance.player.Name}]\n");
            Console.WriteLine($"Gold : {Game.instance.player.Gold}\n"); 
            Console.WriteLine($"Lv : {Game.instance.player.Level}\n");
            Console.WriteLine($"Hp : {Game.instance.player.Hp} / {Game.instance.player.MaxHp}\n");
            Console.WriteLine($"STR : {Game.instance.player.Str}\n");
            Console.WriteLine($"DEF : {Game.instance.player.Def}\n");
            Console.WriteLine($"EXP : {Game.instance.player.Exp}\n");
        }

    }
}
