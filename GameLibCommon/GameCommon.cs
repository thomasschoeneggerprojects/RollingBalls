using GameLibCommon.GameSrc;
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game.Types;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Menue.Screens;
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

        private BaseGameScreen _gameScreen;

        //private SingleBallBalanceGame _singleBallBalance;

        //private MainMenue _mainMenue;

        private InputDataReader _inputDataReader;

        //private GameMediator _gameMediator;

        public GameCommon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _gameScreen = new MainMenue();

            _inputDataReader = new InputDataReader();
            base.Initialize();
        }

        private const int WALL_THICKNESS = 20;
        protected override void LoadContent()
        {
            _gameScreen.LoadContent(GraphicsDevice, Content);
        }

        bool _isInGame = false;
        protected override void Update(GameTime gameTime)
        {
            var currentInputInfo = _inputDataReader.Update();

            
            if (currentInputInfo.ExitPressed)
            {
                if (_isInGame)
                {
                    _gameScreen = new MainMenue();
                    LoadContent();
                    _isInGame = false;
                }
                else 
                {
                    _isInGame = false;
                    Exit();
                }
            }

            if (currentInputInfo.ScreenTouched && !_isInGame)
            {
                _gameScreen = new SingleBallBalanceGame();
                LoadContent();
                _isInGame = true;
            }

            _gameScreen.Update(gameTime, currentInputInfo);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            _gameScreen.Draw(gameTime, GraphicsDevice );

            base.Draw(gameTime);
        }
    }
}
