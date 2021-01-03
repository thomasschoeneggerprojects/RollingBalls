using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen.GameScreens
{
    internal class GameScreenSequenceExecutionBase : IGameScreenSequenceExecution
    {
        public InnerExecutionState ExecutionState { get; set; }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, ScreenSequenceDescription screenSequenceDescription)
        {
            
        }

        public void Update(GameTime gameTime, InputInformation inputInformation)
        {

            
        }

        private void HandleGameState(GameTime gameTime, InputInformation inputInformation)
        {

        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            
        }
    }
}
