using System;

internal class Unary : IPuzzle {
    private IPuzzle puzzleImplementation;
    public void Run(bool isTest, ref string result) {

        string MESSAGE = Console.ReadLine();
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


        Console.WriteLine(unary);
    }
}