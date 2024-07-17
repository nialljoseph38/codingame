using System;
using System.Diagnostics;
using System.IO;

public interface IPuzzle {
    public TimeSpan TimeElapsed { get; }
    public bool createButton { get; }
    public void Run(bool isTest, ref string result, StreamReader streamReader);
}