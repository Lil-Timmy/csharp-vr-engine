


namespace Engine;


public static class Time
{
    public static float time  { get; private set; }
    public static float delta { get; private set; }
    
    private static readonly Timer timer = new Timer();
    
    
    private static void OnLoad()
    {
        time = timer.time;
    }
    
    private static void OnRender()
    {
        float _time = timer.time;
        
        delta = _time - time;
        time  = _time;
    }
}