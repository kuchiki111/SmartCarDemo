using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCarLocal
{
    class SmartCar
    {
        public static List<Motor> Motors = new List<Motor>
        {
            new Motor(singleMotor.Lift,17,27,22),
            new Motor(singleMotor.Right,23,24,25)
        };

        public SmartCar()
        {

        }

        public void FowardBackword(Direction direction, int speed)
        {
            
            foreach(Motor motor in Motors)
            {
                motor.ControlMoved(direction, speed);
            }
        }

        public void Stop()
        {
            foreach (Motor motor in Motors)
            {
                motor.ControlMoved(Direction.Stop, 90);
            }
        }

        public void TurnLeft(int speed)
        {
            MotorControlMoved(singleMotor.Lift, Direction.Stop, speed);
            MotorControlMoved(singleMotor.Right, Direction.Foward, speed);
        }

        public void TurnRight(int speed)
        {
            MotorControlMoved(singleMotor.Lift, Direction.Foward, speed);
            MotorControlMoved(singleMotor.Right, Direction.Stop, speed);
        }

        public void TurnAround(int speed)
        {
            MotorControlMoved(singleMotor.Lift, Direction.Foward, speed);
            MotorControlMoved(singleMotor.Right, Direction.Backward, speed);
        }

        public void MotorControlMoved(singleMotor motor,Direction direction,int speed)
        {
            Motors.FirstOrDefault(itm => itm.motor == motor).ControlMoved(direction, speed);
        }
    }
}
