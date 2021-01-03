using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using GameLibCommon.GameSrc.Game;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Game.Handler;
using GameLibCommon.GameSrc.Screen;

namespace GameLibCommon.GameSrc.Game
{
    internal class GameMediator
    {
        private List<GameObject> _gameObjects;
        private PhysicsEngine _physicsEngine;
        private InputHandler _inputHandler;
        private Area _arena;
        private ScreenSizeInformation _screenSizeInformation;


        public GameMediator(ScreenSizeInformation screenSizeInformation)
        {
            _screenSizeInformation = screenSizeInformation;
            _arena = new Area((int)_screenSizeInformation.WidhtInnerScreen, 
                (int)_screenSizeInformation.HeightInnerScreen);
            _physicsEngine = new PhysicsEngine();
            _gameObjects = new List<GameObject>();
            _inputHandler = new InputHandler();
        }

        internal void Set(params GameObject[] gameObjects)
        {
            _gameObjects.AddRange(gameObjects);
        }

        #region remove after Test

        private SpriteFont _font;
        internal void Set(SpriteFont font)
        {
            _font = font;
        }

        #endregion
        public void Refresh(SpriteBatch spriteBatch, InputInformation inputInformation)
        {
            HandleInput(_gameObjects, inputInformation);
            CalculatePhysics(_gameObjects);
        }

        private InputInformation _inputInformation;
        private void HandleInput(List<GameObject> gameObjects, InputInformation inputInformation)
        {
            _inputInformation = inputInformation;
            // !!!!!!!!!!! Comment in after test !!!!!!!!!!!!
            //_inputHandler.Handle(gameObjects, inputInformation);
        }

        public void DrawScreen(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
        }

        public void CalculatePhysics(List<GameObject> gameObjects) 
        {
            _physicsEngine.CalculatePhysics(gameObjects, _arena);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate);

            foreach (var gameObj in _gameObjects)
            {
                foreach (var item in gameObj.GameObjectItems)
                {
                    var position = gameObj.CurrentPosition + item.Offset + _screenSizeInformation.OffsetFromOutherScreen;
                    spriteBatch.Draw(item.Texture, new Rectangle((int)position.X,(int) position.Y, 
                        gameObj.Bounds.Width, gameObj.Bounds.Height),  Color.White);

                }
            }

            // TODO remove after test
            spriteBatch.DrawString(_font, $"x:{_inputInformation.Acceleration.X} /y:{_inputInformation.Acceleration.Y} /z:{_inputInformation.Acceleration.Z}"
                , new Vector2(100, _arena .Height/ 6 * 5), Color.Black);

            spriteBatch.End();

        }

    }
}
