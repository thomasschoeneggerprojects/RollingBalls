using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc
{
    internal class GameObjectItem
    {
        public GameObjectItem(Texture2D texture, Vector2 offset)
        {
            Texture = texture;
            Offset = offset;
        }

        internal Vector2 Offset { get; private set; }

        internal Texture2D Texture { get; }
    }
}
