using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen.GameScreens.SubScreens
{
    internal class LoadGame : IGameScreenExecution
    {
        public InnerExecutionState ExecutionState { get; set; }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, ScreenDescription screenDescription)
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime, InputInformation inputInformation)
        {
            throw new NotImplementedException();
        }
    }
}
