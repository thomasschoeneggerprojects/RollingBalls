using System;
using System.Collections.Generic;
using System.Text;
using GameLibCommon.GameSrc.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameLibCommon.GameSrc
{
    public abstract class BaseGameScreen    
    {
        internal virtual void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {

        }

        internal virtual void Update(GameTime gameTime, InputInformation inputInformation)
        {

        }

        internal virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.White);



        }
    }
}
