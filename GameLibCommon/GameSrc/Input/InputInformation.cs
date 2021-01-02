using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Input
{
    internal class InputInformation
    {
        public bool ScreenTouched  { get; private set; }
        public Rectangle LastTouchArea { get; private set; }

        internal void Update(Rectangle touchArea, Vector3 acceleration) 
        {
            ExitPressed = false;
            ScreenTouched = true;
            LastTouchArea = touchArea;
            Acceleration = acceleration;
        }

        public Vector3 Acceleration { get; private set; }
        internal void Update( Vector3 acceleration) 
        {
            ExitPressed = false;
            ScreenTouched = false;
            Acceleration = acceleration;
        }

        internal void Exit(bool exitPressed)
        {
            ExitPressed = true;
        }

        public bool ExitPressed { get; private set; }
    }
}
