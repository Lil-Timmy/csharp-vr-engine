using System.Collections.Generic;
using System.Linq;
using DotGLFW;


namespace Engine;


public sealed unsafe class Monitor
{
    ///<summary>The monitor that acts as the global origin for windows.</summary>///
    public static               Monitor  primaryMonitor { get; private set; }
    
    ///<summary>All currently connected monitors to the OS.</summary>///
    private static readonly List<Monitor> avaliableMonitors;
    
    
    ///<summary>Gets all avaliable monitors currently avaliable, and in later callbacks.</summary>///
    static Monitor()
    {
        // Retreive all currently avaliable monitors.
        avaliableMonitors = Glfw.GetMonitors().Select(_handle => new Monitor(_handle)).ToList();
        
        DotGLFW.Monitor _primaryHandle = Glfw.GetPrimaryMonitor();
        primaryMonitor = avaliableMonitors.First(_monitor => _monitor.handle == _primaryHandle);
        
        // Assign the connect/disconnect monitor callback for monitors that change during runtime.
        Glfw.SetMonitorCallback((_handle, _state) =>
        {
            // If the monitor is being conntected, add it, otherwise, find and remove the monitor.
            if (_state == ConnectionState.Connected)
            {
                avaliableMonitors.Add(new Monitor(_handle));
            }
            else
            {
                avaliableMonitors.Remove(avaliableMonitors.First(_monitor => _monitor.handle == _handle));
            }
            
            DotGLFW.Monitor _primaryHandle = Glfw.GetPrimaryMonitor();
            primaryMonitor = avaliableMonitors.First(_monitor => _monitor.handle == _primaryHandle);
        });
    }
    
    
    ///<summary>The pointer to the actual glfw-monitor.</summary>///
    public readonly DotGLFW.Monitor handle;
    ///<summary>The position of the monitor in pixels about the "main" monitor.</summary>///
    public readonly ivec2 position;
    ///<summary>The size of the monitor in pixels.</summary>///
    public readonly ivec2 size;
    ///<summary>The maximum fps of the monitor in hertz.</summary>///
    public readonly int refreshRate;
    
    
    ///<summary>Creates a new monitor instance with a given position and size.</summary>///
    public Monitor(DotGLFW.Monitor _monitor)
    {
        // Get the glfw monitor pointer, position and size.
        handle = _monitor;
        Vidmode _videoMode = Glfw.GetVideoMode(handle);
        
        Glfw.GetMonitorPos(handle, out position.x, out position.y);
        size = new ivec2(_videoMode.Width, _videoMode.Height);
        refreshRate = _videoMode.RefreshRate;
    }
    
    ///<summary>Returns the monitor with the largest overlap with the specified position/size in pixel-coordinates.</summary>///
    public static Monitor FindBest(ivec2 _position, ivec2 _size)
    {
        Monitor _bestMonitor = avaliableMonitors[0];
        int     _bestOverlap = 0;
        
        foreach(Monitor _monitor in avaliableMonitors)
        {
            int _overlap = 
                (Maths.Clamp(_position.x - _monitor.position.x, 0, _monitor.size.x) - Maths.Clamp(_position.x +_size.x - _monitor.position.x, 0, _monitor.size.x)) * 
                (Maths.Clamp(_position.y - _monitor.position.y, 0, _monitor.size.y) - Maths.Clamp(_position.y +_size.y - _monitor.position.y, 0, _monitor.size.y));

            if (_overlap > _bestOverlap)
            {
                _bestOverlap = _overlap;
                _bestMonitor = _monitor;
            } 
        }
        
        return _bestMonitor;
    }
}