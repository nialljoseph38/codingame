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
        int landXPrev = -1;
        int landYPrev = -1;
        int initDistance = -1;
        int maxSpeed = -32;
        string flatCoords = "";
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            if (landY == landYPrev)
            {
                flatCoords += landXPrev.ToString() + "," + landX.ToString();
            }
            landXPrev = landX;
            landYPrev = landY;


        }
        bool stabilized = false;
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
            string[] flatPos = flatCoords.Split(',');
            int flatL = int.Parse(flatPos[0]);
            int flatR = int.Parse(flatPos[1]);
            int distance = -1;
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            if (hSpeed > 20 && !stabilized)
            {
                rotate = 45;
                power = 4;
            }
            else if (hSpeed < -20 && !stabilized)
            {
                rotate = -45;
                power = 4;
            }
            else
            {
                stabilized = true;
                if (X < flatL)
                {
                    if (initDistance == -1)
                    {
                        initDistance = flatL - X;
                    }
                    distance = flatL - X;
                }
                else if (X > flatR && distance == -1)
                {
                    if (initDistance == -1)
                    {
                        initDistance = X - flatR;
                    }
                    distance = X - flatR;
                }
                if (X < flatL)
                {
                    if (distance > initDistance / 2)
                    {
                        rotate = -20;
                        power = 4;
                    }
                    else
                    {
                        rotate = 20;
                        power = 4;
                    }
                }
                else if (X > flatR)
                {
                    if (distance > initDistance / 2)
                    {
                        rotate = 20;
                        power = 4;
                    }
                    else
                    {
                        rotate = -20;
                        power = 4;
                    }
                }
                else if (X > flatL && X < flatR)
                {
                    if (hSpeed > 0)
                    {
                        rotate = 10;
                    }
                    else if (hSpeed < 0)
                    {
                        rotate = -10;
                    }
                    else
                    {
                        rotate = 0;
                        if (vSpeed < maxSpeed - 1 && Y < 2300)
                        {
                            if (power != 4)
                            {
                                power += 1;
                            }
                        }
                        else
                        {
                            if (power != 0)
                            {
                                power -= 1;
                            }
                        }
                    }
                }
            }
            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            Console.WriteLine(rotate.ToString() + " " + power);
        }
    }
}