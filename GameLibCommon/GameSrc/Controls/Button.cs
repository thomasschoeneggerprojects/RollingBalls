using GameLibCommon.GameSrc.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Controls
{
    internal class Button
    {
        private Button(float x, float y, float width, float height)
        {
            Position = new Vector2(x, y);
            Bounds = new Rectangle((int)x, (int)y, (int)width, (int)height);
        }

        internal Vector2 Position { get; set; }

        internal Rectangle Bounds { get; set; }

        public void Update(InputInformation inputInformation)
        {
            
        }

        public void Draw(GraphicsDevice graphicsDevice)
        { 
        
        }

        internal static Button Create(float x, float y, float width, float height)
        {
            return new Button(x, y, width, height);
        }
    }
}
