using System;
using System.Diagnostics;
using System.Threading;
using DotGLFW;


namespace Engine;


public static unsafe class Window
{
    ///<summary>The name of the window displayed on the decorator bar and .</summary>///
    public static string title
    {
        get
        {
            return title_;
        }
        set
        {
            // Set the new active-window and glfw context.
            title_ = value;
            Glfw.SetWindowTitle(handle, title_);
        }
    }
    ///<summary>The size of the window.</summary>///
    public static ivec2 size
    {
        get
        {
            return size_;
        }
        set
        {
            // Set the new active-window and glfw context.
            size_    = value;
            monitor_ = null;
            Glfw.SetWindowSize(handle, size_.x, size_.y);
        }
    }
    ///<summary>The aspect ratio of the window. (width/height)</summary>///
    public static float aspectRatio => size_.x / (float)size_.y;
    ///<summary>The position of the window.</summary>///
    public static ivec2 position
    {
        get
        {
            return position_;
        }
        set
        {
            // Set the new active-window and glfw context.
            position_ = value;
            monitor_  = null;
            Glfw.SetWindowPos(handle, position_.x, position_.y);
        }
    }
    ///<summary>Whether or not to sync with the active-monitors refresh-rate.</summary>///
    public static bool vSync
    {
        get
        {
            return vSync_;
        }
        set
        {
            // Ensure the window context is correct, and set the VSync swap-interval.
            vSync_ = value;
            Glfw.SwapInterval(vSync_ ? 1 : 0);
        }
    }
    ///<summary>The maximum refresh rate of the main-loop whilst the window is focused. For multiple windows with different values, the lowest one will take priority.</summary>///
    public static int focusedFPS;
    ///<summary>The maximum refresh rate of the main-loop whilst the window is unfocused. For multiple windows with different values, the lowest one will take priority.</summary>///
    public static int unfocusedFPS;
    ///<summary>Whether or not to sync with the active-monitors refresh-rate.</summary>///
    public static bool focused
    {
        get
        {
            return focused_;
        }
        set
        {
            // Focus the window if necessary and set the new focus-state.
            if (value && !focused_)
            {
                Glfw.FocusWindow(handle);
            }
            
            focused_ = value;
        }
    }
    ///<summary>The state that the window is in, e.g. Maximized, minimized, fullscreen, and windowed.</summary>///
    public static bool minimized
    {
        get
        {
            // Return whether or not the window is minimized.
            return minimized_;
        }
        set
        {
            // Minimize or window the window.
            minimized_ = value;
            if (minimized_)
            {
                Glfw.IconifyWindow(handle);
            }
            else
            {
                Glfw.RestoreWindow(handle);
            }
        }
    }
    ///<summary>The state that the window is in, e.g. Maximized, minimized, fullscreen, and windowed.</summary>///
    public static bool maximized
    {
        get
        {
            // Return whether or not the window is minimized.
            return maximized_;
        }
        set
        {
            // Maximize or window the window.
            maximized_ = value;
            if (maximized_)
            {
                Glfw.MaximizeWindow(handle);
            }
            else
            {
                Glfw.RestoreWindow(handle);
            }
        }
    }
    ///<summary>The state that the window is in, e.g. Maximized, minimized, fullscreen, and windowed.</summary>///
    public static bool fullscreen
    {
        get
        {
            // Return whether or not the window is minimized.
            return fullscreen_;
        }
        set
        {
            // Iconify/minimize the window.
            fullscreen_ = value;
            if (fullscreen_)
            {
                prevPosition_ = position;
                prevSize_     = size;
                
                Glfw.SetWindowMonitor(handle, monitor.handle, 0, 0, monitor.size.x, monitor.size.y, monitor.refreshRate);
            }
            else
            {
                Glfw.SetWindowMonitor(handle, null, prevPosition_.x, prevPosition_.y, prevSize_.x, prevSize_.y, 0);
            }
        }
    }
    ///<summary>The monitor that is overlapping the most by this window instance.</summary>///
    public static Monitor monitor
    {
        get
        {
            // Get the monitor if the current monitor is invalid and return it.
            monitor_ ??= Monitor.FindBest(position, size);
            return monitor_;
        }
    }
    
    private static string  title_;
    private static ivec2   size_;
    private static ivec2   position_;
    private static bool    vSync_;
    private static bool    focused_;
    private static bool    minimized_;
    private static bool    maximized_;
    private static bool    fullscreen_;
    private static ivec2   prevPosition_;
    private static ivec2   prevSize_;
    private static Monitor monitor_;
    
    ///<summary>The GLFW handle for the window instance.</summary>///
    public static DotGLFW.Window handle { get; private set; }
    
    ///<summary>A stopwatch that tracks the time-per-frame in order to slow down to match the max FPS value.</summary>///
    private static Stopwatch frameTimer   = new Stopwatch();
    ///<summary>A counter of how many frames have passed since initialization. A single "Run()" counts as a frame.</summary>///
    private static double    previousTime = 0.0;
    ///<summary>A counter of how many frames have passed since initialization. A single "Run()" counts as a frame.</summary>///
    private static double    sleepTime    = 0.0;
    ///<summary>The current maximum fps based on whether or not the window is focused.</summary>///
    private static int       maxFPS        => focused ? focusedFPS : unfocusedFPS;
    private static double    frameDuration => 1000.0 / maxFPS;


    ///<summary>Creates and initializes a glfw-window with specified parameters.</summary>///
    public static void Initialize(string _title, ivec2 _size, ivec2 _position, bool _vSync, int _focusedFPS, int _unfocusedFPS)
    {
        // Initialize the GLFW API.
        Glfw.Init();
        
        // Specify the version window-hints.
        Glfw.WindowHint(WindowHint.ClientAPI          , ClientAPI.OpenGLAPI);
        Glfw.WindowHint(WindowHint.OpenGLForwardCompat, true);
        Glfw.WindowHint(WindowHint.OpenGLProfile      , GL.GetProjectOpenGLProfile     () == "CORE" ? OpenGLProfile.CoreProfile : OpenGLProfile.CompatProfile);
        Glfw.WindowHint(WindowHint.ContextVersionMajor, GL.GetProjectOpenGLVersionMajor());
        Glfw.WindowHint(WindowHint.ContextVersionMinor, GL.GetProjectOpenGLVersionMinor());
        
        // Specify miscallanous hints like the top-decorator-bar.
        Glfw.WindowHint(WindowHint.Decorated, true );
        Glfw.WindowHint(WindowHint.Resizable, true );
        Glfw.WindowHint(WindowHint.Visible  , false);
        
        // Set the window's parameters.
        title_       = _title;
        size_        = _size;
        position_    = _position;
        vSync_       = _vSync;
        focusedFPS   = _focusedFPS;
        unfocusedFPS = _unfocusedFPS;
        
        // Generate the window-handle.
        handle = Glfw.CreateWindow(size.x, size.y, title, null, null);
        if (handle is null)
        {
            Debug.Glfw("Failed to create the GLFW window.");
        }
        
        // Set the glfw-callbacks to update the engine-side.
        Glfw.SetWindowPosCallback      (handle, (_handle, _x, _y    ) => { position_  = new ivec2(_x, _y); monitor_  = null; } );
        Glfw.SetFramebufferSizeCallback(handle, (_handle, _x, _y    ) => { size_      = new ivec2(_x, _y); monitor_  = null; } );
        Glfw.SetWindowFocusCallback    (handle, (_handle, _focus    ) => { focused_   = _focus;                              } );
        Glfw.SetWindowIconifyCallback  (handle, (_handle, _minimized) => { minimized_ = _minimized;                          } );
        Glfw.SetWindowMaximizeCallback (handle, (_handle, _maximized) => { maximized_ = _maximized;                          } );
        
        // Set the current glfw-window context.
        Glfw.MakeContextCurrent(handle);
        
        // Specify any window parameters that must be set after the window-context has been created. (Annoying.)
        vSync    = vSync_;
        position = position_;
        
        // Display the window after setup to avoid visual artifacts.
        Glfw.ShowWindow(handle);
        
        // Start the frame-timer for maintaining the max FPS value.
        frameTimer.Start();
        
        GL.Import(Glfw.GetProcAddress);
    }
    ///<summary>Destroys the glfw-window instance.</summary>///
    public static void Dispose()
    {
        // Terminate the window and glfw context.
        if (handle != null)
        {
            Glfw.DestroyWindow(handle);
            Glfw.Terminate();
        }
    }

    ///<summary>Runs a single loop for the window, updating and rendering a single frame.</summary>///
    public static void Run(Action _callback)
    {
        // Ensure that while resizing the window is updated.
        // Glfw.SetWindowSizeCallback(handle, (_handle, _x, _y) => { Callback(_callback); } );
        
        while (!Glfw.WindowShouldClose(handle))
        {
            // Delay for a specified amount of time until the frame-duration has passed.
            sleepTime    += Maths.Clamp(frameDuration - (frameTimer.Elapsed.TotalMilliseconds - previousTime), -frameDuration, frameDuration);
            previousTime += frameDuration;
            if (sleepTime >= 1.0)
            {
                int _timeout = (int)sleepTime;
                sleepTime -= _timeout;
                Thread.Sleep(_timeout);
            }
            
            // Poll the window events, and call all per-frame events.
            Glfw.PollEvents();
            _callback();
            Glfw.SwapBuffers(handle);
        }
    }
    ///<summary>Signals the event loop to close.</summary>///
    public static void Close()
    {
        // Set the window to be closed.
        Glfw.SetWindowShouldClose(handle, true);
    }
    
    
    ///<summary>The possible states of a window-instance.</summary>///
    public enum State
    {
        WINDOWED  ,
        MAXIMIZED ,
        MINIMIZED ,
        FULLSCREEN,
    }
}