using System;
using System.Diagnostics;
using System.IO;

internal class Unary : IPuzzle {
    public TimeSpan TimeElapsed { get; private set; }
    public bool createButton { get; private set; } = true;
    public StreamReader streamReader { get; set; }
    public void Run(bool isTest, ref string result) {
        streamReader = new StreamReader(@"C:\Users\thele\codingame\Assets\RG\Data\Input.txt");
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        string MESSAGE = isTest ? streamReader.ReadLine() : Console.ReadLine();
        string binary = "";
        for(int i = 0; i < MESSAGE.Length; i++) {
            char letter = MESSAGE[i];
            int dec = letter;
            binary += Convert.ToString(dec, 2).PadLeft(7, '0');
        }
        string unary = "";
        int index = 0;
        while(true) {
            if(binary[index] == '1') {
                unary += "0 ";
                while(binary[index] == '1') {
                    unary += "0";
                    index++;
                    if(index == binary.Length) {
                        break;
                    }
                }
                unary += " ";

            }
            else {
                unary += "00 ";
                while(binary[index] == '0') {
                    unary += "0";
                    index++;
                    if(index == binary.Length) {
                        break;
                    }
                }
                unary += " ";
            }
            if(index == binary.Length) {
                break;
            }
        }
        unary = unary[0..^1];

        stopWatch.Stop();
        TimeElapsed = stopWatch.Elapsed;
        result = unary;
        Console.WriteLine(unary);
    }
}