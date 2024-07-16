using System;

public interface IPuzzle {
    public TimeSpan TimeElapsed { get;}
    public void Run(bool isTest, ref string result);
}