using DigimonRPG.Objects;
using DigimonRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigimonRPG.Monsters
{
    public static class MonsterCreate
    {
        public static Monster[] monsters;
        private static Random rand = new Random();
        private static int randIndex;

        public static void Create()
        {
            if (monsters == null)
            {
                monsters = new Monster[5];

                monsters[0] = new Pinokimon("피노키몬", 20, 4);
                monsters[1] = new Etemon("에테몬", 50, 3);
                monsters[2] = new Myotismon("묘티스몬", 4, 4);
                monsters[3] = new Piemon("피에몬", 4, 10);
                monsters[4] = new Powerdramon("파워드라몬", 4, 4);
                randIndex = rand.Next(0, 5);
            }
        }

        public static void Print()
        {
            if (BattleScene.isBattle == false)
            {
                randIndex = rand.Next(0, 5); 
            }

            monsters[randIndex].EnemyCharacter();
        }

        public static int GetRandIndex()
        {
            return randIndex;
        }

    }
}
