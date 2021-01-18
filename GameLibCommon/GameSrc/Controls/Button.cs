using GameLibCommon.GameSrc.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameLibCommon.GameSrc.Controls
{
    internal class Button
    {
        private Button(float x, float y, float width, float height)
        {
            Position = new Vector2(x, y);
            Bounds = new Rectangle((int)x, (int)y, (int)width, (int)height);
        }

        internal Func<bool> OnClick { get; set; }

        internal Vector2 Position { get; set; }

        internal Rectangle Bounds { get; set; }

        public void Update(InputInformation inputInformation)
        {
            if (inputInformation.ScreenTouched)
            {
                if (inputInformation.LastTouchArea.Intersects(Bounds))
                {
                    OnClick.Invoke();
                }
            }
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
