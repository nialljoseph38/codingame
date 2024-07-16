using System;

internal class MarsLanderOne : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public void Run(bool isTest, ref string result) {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        for(int i = 0; i < surfaceN; i++) {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
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
            Console.WriteLine(rotate.ToString() + " " + power);
        }
    }
}