using GameLibCommon.GameSrc;
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game.GameScreens;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.StateHandling;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace GameLibCommon
{
    public class GameCommon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameScreenContext _gameScreenContext;

        private IInputDataProvider _inputDataProvider;
        private ScreenSizeInformation _screenSizeInformation;
        //private ScreenDescription _screenDescription;

        public GameCommon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _screenSizeInformation = ScreenSizeCalculator
                .Calculate(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            //_screenDescription = GlobalScreenDescriptionCreator.CreateMainScreen(_screenSizeInformation);

            _inputDataProvider = new InputDataReader();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameScreenContext = new GameScreenContext(GraphicsDevice, Content, _screenSizeInformation);
            //_gameScreen.LoadContent(GraphicsDevice, Content, _screenDescription);
        }

        protected override void Update(GameTime gameTime)
        {
            var currentInputInfo = _inputDataProvider.Update();


            _gameScreenContext.Update(gameTime, currentInputInfo);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _gameScreenContext.Draw(gameTime, GraphicsDevice );

            base.Draw(gameTime);
        }
    }
}
