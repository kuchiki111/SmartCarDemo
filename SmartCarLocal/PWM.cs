using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.Foundation;

namespace SmartCarLocal
{
    class PWM
    {
        public GpioPin channel;
        public double frequency;
        public double dc;

        public double currentDirection;
        public double pulseFrequency;

        private Stopwatch stopwatch;

        public PWM(GpioPin channel, double frequency)
        {
            this.frequency = frequency;
            this.channel = channel;
        }

        public void start(double dc)
        {
            this.dc = dc;
            setValue();
            PWMStart();
        }

        public void ChangeFrequency(double frequency)
        {
            this.frequency = frequency;
            setValue();
        }

        public void ChangeDutyCycle(double dc)
        {
            this.dc = dc;
            setValue();
        }

        public void PWMStart()
        {
            stopwatch = Stopwatch.StartNew();

            Windows.System.Threading.ThreadPool.RunAsync(PWMthread, Windows.System.Threading.WorkItemPriority.High);
        }

        private void PWMthread(IAsyncAction action)
        {
            while (true)
            {
                if (currentDirection != 0)
                {
                    channel.Write(GpioPinValue.High);
                }
                //Task.Delay(Convert.ToInt32(currentDirection));
                wait(currentDirection);

                channel.Write(GpioPinValue.Low);
                //Task.Delay(Convert.ToInt32(pulseFrequency - currentDirection));
                wait(pulseFrequency - currentDirection);
            }
        }

        private void wait(double ms)
        {
            long initialTick = stopwatch.ElapsedTicks;
            long initialElapsed = stopwatch.ElapsedMilliseconds;

            double desiredTicks = ms / 1000 * Stopwatch.Frequency;
            double finalTick = initialTick + desiredTicks;

            while (stopwatch.ElapsedTicks < finalTick)
            {

            }
        }

        private void setValue()
        {
            pulseFrequency = (1000 * (1 / frequency));
            currentDirection = dc * pulseFrequency / 100;
        }

    }
}
