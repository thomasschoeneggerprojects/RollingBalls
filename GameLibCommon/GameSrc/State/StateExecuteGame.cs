using GameLibCommon.GameSrc.Game.GameScreens;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.StateHandling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    internal class StateExecuteGame : IGameState
    {
        public StateExecuteGame(GameScreenContext context)
        {
            Context = context;
        }

        public GameScreenContext Context { get; }

        IGameScreenSequenceExecution _gameScreenSequenceExecution;

        public void Start()
        {
            _gameScreenSequenceExecution = new SingleBallBalanceGame();

            var screenDesc = GlobalScreenDescriptionCreator.CreateTestLevelScreen(Context.ScreenSizeInformation);
            var screenSequence =ScreenSequenceDescription.Create(screenDesc);

            _gameScreenSequenceExecution.LoadContent(Context.GraphicsDevice, Context.ContentManager, screenSequence);
        }

        public void GoBack()
        {
            Context.ActivateState(new StateMainMenuGame(Context));
        }

        public void Finish()
        {
            Context.ActivateState(new StateMainMenuGame(Context));
        }

        public void Update(GameTime gameTime, InputInformation inputInformation)
        {
            _gameScreenSequenceExecution.Update(gameTime, inputInformation);
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _gameScreenSequenceExecution.Draw(gameTime, graphicsDevice);
        }
    }
}
