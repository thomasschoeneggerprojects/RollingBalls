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
    internal class GlobalScreenDescriptionCreator
    {
        internal static ScreenDescription CreateMainScreen(ScreenSizeInformation info)
        {
            ScreenDescription mainscreen = ScreenDescription.Create( info, null, "RollingBallsMainScreen", WellKnownGameScreenExecutions.MENUE_MAIN_SCREEN, TimeSpan.FromDays(360));

            return mainscreen;
        }
        
        internal static ScreenDescription CreateTestLevelScreen(ScreenSizeInformation info)
        {
            float WALL_THICKNESS = 10 * info.ScaleFactor;

            float width = info.WidhtInnerScreen;
            float height = info.HeightInnerScreen;

            List<GameObjectDescription> descriptions = new List<GameObjectDescription>
            {
                new GameObjectDescription()
                {
                    AssetName = "wallvertical",
                    CurrentPosition = new Vector2(150, 200),
                    Width = WALL_THICKNESS*info.ScaleFactor,
                    Height = 500*info.ScaleFactor,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                new GameObjectDescription()
                {
                    AssetName = "blockredgray",
                    CurrentPosition = new Vector2(350, 700),
                    Width = 50*info.ScaleFactor,
                    Height = 50*info.ScaleFactor,
                    ObjectOrientation = ObjectOrientation.Vertical,
                    Stability = 1000,
                    GameObjectType = GameObjectType.BLOCK
                }
            };
            descriptions.AddRange(CreateArenaBorder(width, height, info.ScaleFactor));
            descriptions.Add(CreateBall(info.ScaleFactor));

            ScreenDescription testscreen = ScreenDescription.Create(info, descriptions, "BackgroundMamor", 
                WellKnownGameScreenExecutions.RUNNING_GAME_BALANCE_SCREEN, TimeSpan.FromDays(1));

            return testscreen;
        }

        internal static GameObjectDescription CreateBall(float scalefactor)
        {
            var gobj = new GameObjectDescription()
            {
                AssetName = "ballblue",
                CurrentPosition = new Vector2(200 * scalefactor, 100 * scalefactor),
                Width = 30 * scalefactor,
                Height = 30 * scalefactor,
                ObjectOrientation = ObjectOrientation.Vertical,
                Stability = 100,
                GameObjectType = GameObjectType.BALL
            };
            return gobj;
        }

        internal static List<GameObjectDescription> CreateArenaBorder(float width, float height, float scalefactor)
        {
            float WALL_THICKNESS = 10 * scalefactor;
            List<GameObjectDescription> descriptions = new List<GameObjectDescription>
            {
                // Left
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
                // Right
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
                // top
                new GameObjectDescription()
                {
                    AssetName = "wallhorizontal",
                    CurrentPosition = new Vector2(WALL_THICKNESS, 0),
                    Width = width - WALL_THICKNESS - WALL_THICKNESS,
                    Height = WALL_THICKNESS,
                    ObjectOrientation = ObjectOrientation.Horizontal,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                },
                // Bottom
                new GameObjectDescription()
                {
                    AssetName = "wallhorizontal",
                    CurrentPosition = new Vector2(WALL_THICKNESS, height - WALL_THICKNESS),
                    Width = width - WALL_THICKNESS - WALL_THICKNESS,
                    Height = WALL_THICKNESS,
                    ObjectOrientation = ObjectOrientation.Horizontal,
                    Stability = 100000,
                    GameObjectType = GameObjectType.WALL
                }

            };
            return descriptions;
        }
    }
}
