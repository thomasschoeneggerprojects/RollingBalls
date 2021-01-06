using System;
using System.Collections.Generic;
using System.Text;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameLibCommon.GameSrc
{
    internal interface IGameScreenExecution    
    {
        public InnerExecutionState ExecutionState { get; set; }

        void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription);

        void Update(GameTime gameTime, InputInformation inputInformation);

        void Draw(GameTime gameTime, GraphicsDevice graphicsDevice);
    }
}
