using System.Windows;

namespace AlgorithmsJournal
{
    public class BouncingBalls
    {
        public void Simulate()
        {
            int ballCount = 15;
            var balls = new Ball[ballCount];

            for (int i = 0; i < ballCount; i++)
            {
                 balls[i] = new Ball();
            }

            while (true)
            {
                //Clear screen 
                //Clear
                for (int i = 0; i < ballCount; i++)
                {
                    balls[i].Move(0.5);
                    balls[i].Draw();
                }

                //Display and pause for some milliseconds
                //Show(50)
            }
        }
    }

    public class Scene : UIElement
    {
        public void DrawFilledCircle()
        {
            this.InvalidateVisual();    
        }
    }


    public class Ball
    {
        private double rx;
        private double ry;

        private double vx;
        private double vy;
        private double radius;

        public void Move(double dt)
        {
            if ((rx + vx*dt < radius) || (rx + vx*dt > 1.0 - radius))
            {
                vx = -vx;
            }
            if ((ry + vy*dt < radius) || (ry + vy*dt > 1.0 - radius))
            {
                vy = -vy;
            }
            rx = rx + vx*dt;
            ry = ry + vy*dt;
        }

        public void Draw()
        {
            //don't know how yet;
        }

    }
}