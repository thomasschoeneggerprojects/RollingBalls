using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Input
{
    internal class InputDataReader
    {
        private Accelerometer _accelerometer;

        private object _lock = new object();

        public InputDataReader()
        {
            _info = new InputInformation();

            _accelerometer = new Accelerometer();
            _accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500);

            _accelerometer.CurrentValueChanged += 
                new EventHandler<SensorReadingEventArgs<AccelerometerReading>>
                (AccelerometerCurrentValueChanged);

            _accelerometer.Start();
        }

        private Vector3 _acceleration;

        private void AccelerometerCurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            _acceleration = e.SensorReading.Acceleration;
            lock (_lock)
            {
                _info.Update(_acceleration);
            }            
        }

        InputInformation _info;

        internal InputInformation Update()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //GamePad.res;
                lock (_lock)
                {
                    _info.Exit(true);
                    return _info;
                }
            }

            TouchCollection touchCollection = TouchPanel.GetState();
            var touchArea = new Rectangle(0, 0, 0, 0);
            if (touchCollection.Count > 0)
            {
                //Only Fire Select Once it's been released
                if (touchCollection[0].State == TouchLocationState.Moved ||
                    touchCollection[0].State == TouchLocationState.Pressed)
                {
                    touchArea = new Rectangle((int)touchCollection[0].Position.X, 
                        (int)touchCollection[0].Position.Y, 1, 1);
                    _info.Update(touchArea, _acceleration);
                }
            }

            return _info;
        }
    }
}
