using System.Diagnostics;


namespace Engine;


public class Timer
{
    private readonly Stopwatch stopwatch;
    
    public float time => (float)stopwatch.Elapsed.TotalSeconds;
    
    
    public Timer()
    {
        stopwatch = new Stopwatch();
        stopwatch.Restart();
    }
    
    public void Restart()
    {
        stopwatch.Restart();
    }
}