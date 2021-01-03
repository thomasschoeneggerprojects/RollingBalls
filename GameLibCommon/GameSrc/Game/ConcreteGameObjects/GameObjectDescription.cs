using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game.ConcreteGameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal class GameObjectDescription
    {
        internal Vector2 CurrentPosition { get; set; }
        
        public string AssetName { get;  set; }
        public double Width { get; set; }        
        public double Height { get; set; }   
        public ObjectOrientation ObjectOrientation { get; set; }      
        public GameObjectType GameObjectType { get; set; }      

        public double Stability { get; set; }

    }
}
