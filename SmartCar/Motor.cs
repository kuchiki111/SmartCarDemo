using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace SmartCar
{
    class Motor
    {
        public static GpioController gpio = GpioController.GetDefault();
        GpioPin pin1;
        GpioPin pin2;
        GpioPin pwm;

        PWM p;

        public singleMotor motor { get; set; }
        public int speed { get; set; }

        public Motor(singleMotor motor, int pin1, int pin2, int pwm)
        {
            this.motor = motor;

            this.pin1 = gpio.OpenPin(pin1);
            this.pin2 = gpio.OpenPin(pin2);
            this.pwm = gpio.OpenPin(pwm);

            this.pin1.SetDriveMode(GpioPinDriveMode.Output);
            this.pin2.SetDriveMode(GpioPinDriveMode.Output);
            this.pwm.SetDriveMode(GpioPinDriveMode.Output);

            p = new PWM(this.pwm, 15000);
            p.start(50);
        }

        public void ControlMoved(Direction direction, int speed)
        {
            switch (direction)
            {
                case Direction.Foward:
                    pin1.Write(GpioPinValue.High);
                    pin2.Write(GpioPinValue.Low);
                    p.ChangeDutyCycle(speed);
                    break;

                case Direction.Stop:
                    pin1.Write(GpioPinValue.Low);
                    pin2.Write(GpioPinValue.Low);
                    p.ChangeDutyCycle(speed);
                    break;

                case Direction.Backward:
                    pin1.Write(GpioPinValue.Low);
                    pin2.Write(GpioPinValue.High);
                    p.ChangeDutyCycle(speed);
                    break;

                default:
                    break;

            }
        }

    }

    public enum singleMotor
    {
        Lift = 0,
        Right = 1
    }

    public enum Direction
    {
        Foward = 1,
        Stop = 0,
        Backward = -1
    }
}
