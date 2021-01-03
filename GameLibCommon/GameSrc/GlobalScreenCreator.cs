using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game.ConcreteGameObjects;
using GameLibCommon.GameSrc.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc
{
    internal class GlobalScreenCreator
    {
        internal static ScreenDescription CreateMainScreen(ScreenSizeInformation info)
        {
            ScreenDescription mainscreen = ScreenDescription.Create( info, null, "RollingBallsMainScreen");

            return mainscreen;
        }
        private const int WALL_THICKNESS = 10;
        internal static ScreenDescription CreateTestLevelScreen(ScreenSizeInformation info)
        {

            var width = (int)info.Widht;
            var height = (int)info.Height;

            List<GameObjectDescription> descriptions = new List<GameObjectDescription>
            {
                new GameObjectDescription()
                {
                    AssetName = "ballblue",
                    CurrentPosition = new Vector2(200, 100),
                    Width = 40,
                    Height = 40, 
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100,
                    GameObjectType = GameObjectType.BALL
                },
                new GameObjectDescription()
                {
                    AssetName = "wallvertical",
                    CurrentPosition = new Vector2(0, 0),
                    Width = WALL_THICKNESS,
                    Height = height,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                new GameObjectDescription()
                {
                    AssetName = "wallvertical",
                    CurrentPosition = new Vector2(width - WALL_THICKNESS, 0),
                    Width = WALL_THICKNESS,
                    Height = height,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                new GameObjectDescription()
                {
                    AssetName = "wallhorizontal",
                    CurrentPosition = new Vector2(WALL_THICKNESS, 0),
                    Width = height - WALL_THICKNESS - WALL_THICKNESS,
                    Height = WALL_THICKNESS,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                new GameObjectDescription()
                {
                    AssetName = "wallhorizontal",
                    CurrentPosition = new Vector2(WALL_THICKNESS, height - WALL_THICKNESS),
                    Width = height - WALL_THICKNESS - WALL_THICKNESS,
                    Height = WALL_THICKNESS,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                new GameObjectDescription()
                {
                    AssetName = "wallvertical",
                    CurrentPosition = new Vector2(150, 200),
                    Width = WALL_THICKNESS,
                    Height = 500,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                }

            };

           
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

            ScreenDescription testscreen = ScreenDescription.Create(info, descriptions, "RollingBallsMainScreen");

            return testscreen;
        }
    }
}
