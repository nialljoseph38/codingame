using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        int[,] points = new int[surfaceN, 2];
        int markerX = 0;
        int markerY = 0;
        int startup = -1;
        int maxY = -1;
        int direction = 0;
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            points[i, 0] = landX;
            points[i, 1] = landY;
            if (i != 0 && points[i, 1] == points[i - 1, 1])
            {
                markerX = ((points[i, 0] + points[i - 1, 0]) / 2);
                markerY = points[i, 1];
            }
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            if (startup == -1)
            {
                //Determine Direction
                if (X > markerX)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }



                //Find Obstacles
                for (int i = 0; i < surfaceN; i++)
                {
                    if (direction == -1)
                    {
                        if (points[i, 0] < X && points[i, 0] > markerX)
                        {
                            if (points[i, 1] > maxY)
                            {
                                maxY = points[i, 1];
                            }
                        }
                    }
                    else
                    {
                        if (points[i, 0] > X && points[i, 0] < markerX)
                        {
                            if (points[i, 1] > maxY)
                            {
                                maxY = points[i, 1];
                            }
                        }
                    }
                }
            }
            // Negating Horizontal Speed while maintaining low vertical speed
            if (Y < maxY + 100)
            {
                rotate = 0;
                power = 4;
            }
            else if (hSpeed * direction > 15 || (hSpeed * direction < 8 && (((X - markerX) * direction * -1) > 500)))
            {
                rotate = direction * 45;
                power = 4;
            }
            else if (vSpeed < -10)
            {
                rotate = 0;
                power = 4;
            }
            else
            {
                power = 0;
            }





            //Not changing horizontal speed while mainting low vertical speed above desired height.






            //




            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            if (startup == -1)
            {
                startup = 1;
            }
            Console.WriteLine(rotate.ToString() + " " + power);
        }
    }
}