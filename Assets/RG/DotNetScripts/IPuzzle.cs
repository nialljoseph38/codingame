using System;
using System.Diagnostics;

public interface IPuzzle {
    public TimeSpan TimeElapsed { get;}
    public bool createButton { get;}
    public void Run(bool isTest, ref string result);
}