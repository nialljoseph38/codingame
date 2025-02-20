using System;
using System.Diagnostics;
using System.IO;

internal class MarsLanderOne : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = false;
    public void Run(bool isTest, ref string result, StreamReader streamReader) {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string results = "";
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        int landXPrev = -1;
        int landYPrev = -1;
        int flatY = -1;
        for(int i = 0; i < surfaceN; i++) {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            if(landY == landYPrev) {
                flatY = landY;
            }
            landXPrev = landX;
            landYPrev = landY;
        }

        // game loop
        while(true) {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).
            if(Y < 2300) {
                if(vSpeed < -39) {
                    if(power != 4) {
                        power += 1;
                    }
                }
                else {
                    if(power != 0) {
                        power -= 1;
                    }
                }
            }
            if(isTest) {
                results += rotate.ToString() + " " + power + "   ";
            }
            else {
                Console.WriteLine(rotate.ToString() + " " + power);
            }
            if (Y <= flatY+10) {
                break;
            }
        }
        stopWatch.Stop();
        TimeElapsed = stopWatch.Elapsed;
        result = results;
    }
}