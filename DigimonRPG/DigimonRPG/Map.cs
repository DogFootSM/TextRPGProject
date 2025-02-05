using DigimonRPG.Digimons;
using DigimonRPG.Objects;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG
{
    public class Map
    {
        public static bool[,] mapTiles;
        public Map()
        {
            MapTileSetting();
        }

        public void MapTileSetting()
        {
            
            mapTiles = new bool[13, 18]{

                {false, false, false, false, false,false,false,false, false, false, false, false, false, false, false, false, false, false},
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false,  true,  true,  true,  true, true, true, true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                {false, false, false, false, false,false,false,false, false, false, false, false, false, false, false, false, false, false}

            };
        }

        

        public static void PrintTownMap()
        {
            for (int y = 0; y < mapTiles.GetLength(0); y++)
            {
                for (int x = 0; x < mapTiles.GetLength(1); x++)
                {
                    if (mapTiles[y, x] == true)
                    {
                        StructureObj.Ground();
                    }
                    else
                    {
                        StructureObj.TownWall();
                    }
                }
                Console.WriteLine();
            }
 
            Console.WriteLine($"현재 위치 : {(Game.instance.player.CurrentScene() == Enum.SceneType.Town ? "마을" : "사냥터")}");
        }

        public static void PrintFieldMap()
        {
            for (int y = 0; y < mapTiles.GetLength(0); y++)
            {
                for (int x = 0; x < mapTiles.GetLength(1); x++)
                {
                    if (mapTiles[y, x] == true)
                    {
                        StructureObj.Ground();
                    }
                    else
                    {
                        StructureObj.FieldWall();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"현재 위치 : {(Game.instance.player.CurrentScene() == Enum.SceneType.Town ? "마을" : "사냥터")}");
        }



    }
}
