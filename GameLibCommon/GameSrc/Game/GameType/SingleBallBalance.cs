
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibCommon.GameSrc.Game.Type
{
    internal class SingleBallBalanceGame : IGameScreen
    {
        private SpriteBatch _spriteBatch;

        private GameMediator _gameMediator;

        private const int WALL_THICKNESS = 20;
        void IGameScreen.LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription)
        {
            var width = (int)screenDescription.ScreenSizeInformation.Widht;
            var height = (int)screenDescription.ScreenSizeInformation.Height;

            graphicsDevice.Viewport = new Viewport(0, 0, width, height);

            _spriteBatch = new SpriteBatch(graphicsDevice);
            
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (GameObjectDescription description in screenDescription.Items)
            {
                var texture = contentManager.Load<Texture2D>(description.AssetName);
                var obj =GameObjectBuilder.Create()
                    .SetPosition(description.CurrentPosition.X, description.CurrentPosition.Y)
                    .SetOrientation(description.ObjectOrientation)
                    .SetAssetName(description.AssetName)
                    .SetSize((int)description.Width, (int)description.Height)
                    .SetObjectType(description.GameObjectType)
                    .Build(contentManager);
                gameObjects.Add(obj);
            }

            //var textureBall = contentManager.Load<Texture2D>("ballblue");

            //Ball ball = new Ball();
            //ball.Initialize(new Vector2(180, 150), new GameObjectItem(textureBall, new Vector2(0, 0)));

            //var wallLeft = GameObjectBuilder.Create()
            //    .SetSize(WALL_THICKNESS, height)
            //    .SetPosition(0, 0)
            //    .SetOrientation(ObjectOrientation.Vertical)
            //    .Build(contentManager);

            //var wallRight = GameObjectBuilder.Create()
            //    .SetSize(WALL_THICKNESS, height)
            //    .SetPosition(width - WALL_THICKNESS, 0)
            //    .SetOrientation(ObjectOrientation.Vertical)
            //    .Build(contentManager);

            //var wallTop = GameObjectBuilder.Create()
            //    .SetSize(height - WALL_THICKNESS - WALL_THICKNESS, WALL_THICKNESS)
            //    .SetPosition(WALL_THICKNESS, 0)
            //    .SetOrientation(ObjectOrientation.Horizontal)
            //    .Build(contentManager);

            //var wallBottom = GameObjectBuilder.Create()
            //    .SetSize(height - WALL_THICKNESS - WALL_THICKNESS, WALL_THICKNESS)
            //    .SetPosition(WALL_THICKNESS, height - WALL_THICKNESS)
            //    .SetOrientation(ObjectOrientation.Horizontal)
            //    .Build(contentManager);

            //var wallvert1 = GameObjectBuilder.Create()
            //    .SetSize(WALL_THICKNESS * 2, 500)
            //    .SetPosition(150, 200)
            //    .SetOrientation(ObjectOrientation.Vertical)
            //    .Build(contentManager);

            //var wallvert2 = GameObjectBuilder.Create()
            //    .SetSize(WALL_THICKNESS * 3, 500)
            //    .SetPosition(700, 400)
            //    .SetOrientation(ObjectOrientation.Vertical)
            //    .Build(contentManager);

            //var wallhorizontal1 = GameObjectBuilder.Create()
            //   .SetSize(300, WALL_THICKNESS * 1.5f)
            //   .SetPosition(300, 800)
            //   .SetOrientation(ObjectOrientation.Horizontal)
            //   .Build(contentManager);

            //var wallhorizontal2 = GameObjectBuilder.Create()
            //  .SetSize(300, WALL_THICKNESS * 1.5f)
            //  .SetPosition(400, 1200)
            //  .SetOrientation(ObjectOrientation.Horizontal)
            //  .Build(contentManager);

            //Texture2D textureblck1 = contentManager.Load<Texture2D>("blockredgray"); ;
            //Block block1 = new Block();
            //block1.DirectionDegree = 90;
            //block1.Width = 50;
            //block1.Height = 50;
            //block1.Initialize(new Vector2(600, 700), new GameObjectItem(textureblck1, new Vector2(0, 0)));

            _gameMediator = new GameMediator(width, height);
            _gameMediator.Set(gameObjects.ToArray());


            // TODO remove after test
            _gameMediator.Set(contentManager.Load<SpriteFont>("Labels/LabelLarge"));
        }

        void IGameScreen.Update(GameTime gameTime, InputInformation inputInformation)
        {
            _gameMediator.Refresh(_spriteBatch, inputInformation);
        }

        void IGameScreen.Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Wheat);

            _gameMediator.DrawScreen(_spriteBatch);

        }

    }
}
