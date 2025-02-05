using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigimonRPG.Digimons;

namespace DigimonRPG.Scenes
{
    public abstract class Scene
    {
         
        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
    }
}
