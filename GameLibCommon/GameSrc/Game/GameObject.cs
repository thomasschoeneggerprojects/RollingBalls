using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Game
{
    internal abstract class GameObject
    {
        public GameObject()
        {
            Uuid = Guid.NewGuid();
            GameObjectItems = new List<GameObjectItem>();
            TextureDescriptions = new Dictionary<string, Type>();
            Width = 1;
            Height = 1;
            Stability = 100000;
        }

        public List<GameObjectItem> GameObjectItems { get; protected set; }

        internal abstract void Initialize(Vector2 vector, params GameObjectItem[] loadedGameObjectItems);

        public double DirectionDegree { get; internal set; }
        public double Speed { get; protected set; }
        public Guid Uuid { get; protected set; }

        private Vector2 _currentPosition;
        public Vector2 CurrentPosition { 
            get 
            { 
                return _currentPosition; 
            } 
            set 
            { 
                _currentPosition = value;
                RefreshBounds();
            } 
        }

        public Rectangle Bounds { get; protected set; }

        public void RefreshBounds()
        {
            Bounds = new Rectangle((int)_currentPosition.X, (int)_currentPosition.Y, (int)Width, (int)Height);
        }

        public Dictionary<string, Type> TextureDescriptions { get; protected set; }

        public double _width;
        public double Width {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                RefreshBounds();
            }
        }

        public double _height;
        public double Height {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                RefreshBounds();
            }
        }

        public double Stability { get; protected set; }
    }
}
