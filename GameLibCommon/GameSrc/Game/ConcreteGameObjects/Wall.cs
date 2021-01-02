using GameLibCommon.GameSrc.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.ConcreteGameObjects
{
    internal class Wall : GameObject
    {
        public Wall()
        {
            TextureDescriptions.Add("wall", typeof(Texture2D));
        }

        internal override void Initialize(Vector2 currentPosition, params GameObjectItem[] loadedGameObjectItems)
        {
            Speed = 0;
            CurrentPosition = currentPosition;
            GameObjectItems.AddRange(loadedGameObjectItems);
        }

        internal void AddSpeed(double speed)
        {
            Speed = speed;
        }
    }

}
