using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.ConcreteGameObjects
{
    internal class Block : GameObject
    {
        public Block()
        {
            TextureDescriptions.Add("blockredgray", typeof(Texture2D));
        }

        internal override void Initialize(Vector2 currentPosition, params GameObjectItem[] loadedGameObjectItems)
        {
            Speed = 2;
            CurrentPosition = currentPosition;
            GameObjectItems.AddRange(loadedGameObjectItems);
            Stability = 1000;
        }

        internal void AddSpeed(double speed)
        {
            Speed = speed;
        }
    }
}
