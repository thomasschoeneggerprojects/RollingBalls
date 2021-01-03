
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.Screen.GameScreens;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibCommon.GameSrc.Game.GameScreens
{
    internal class MainMenuSequence : GameLevelScreenSequenceExecutionBase
    {
        public override void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager,
            ScreenSequenceDescription screenSequenceDescription)
        {
            base.LoadContent(graphicsDevice, contentManager, screenSequenceDescription);
        }

        public override void Update(GameTime gameTime, InputInformation inputInformation)
        {
            base.Update(gameTime, inputInformation);
        }

        public override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            base.Draw(gameTime, graphicsDevice);
        }
    }
}
