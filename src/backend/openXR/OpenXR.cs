using System;
using static Engine.GL;


namespace Engine;


public static unsafe class OpenXR
{
    public static XRInstance     instance        { get; private set; }
    public static XRSystemID     systemID        { get; private set; }
    public static XRRequirements requirements    { get; private set; }
    public static XRSession      session         { get; private set; }
    public static XRSpace        space           { get; private set; }
    public static XRSwapchain    swapchain       { get; private set; }
    
    public static XRView[]       views           { get; private set; }
    public static long           nextDisplayTime { get; private set; }
    
    public static uint           framebuffer     { get; private set; }
    
    
    public static void Initialize(string appName, string engineName)
    {
        instance     = new XRInstance    (appName, engineName);
        systemID     = new XRSystemID    (instance);
        requirements = new XRRequirements(instance, systemID, new XRVersion(4, 5, 0));
        session      = new XRSession     (instance, systemID);
        space        = new XRSpace       (session);
        swapchain    = new XRSwapchain   (instance, space, session, systemID);
        
        framebuffer = glGenFramebuffer();
    }
    
    
    public static bool Begin()
    {
        session.UpdateEvents(instance);
        if (!session.isActive || !swapchain.Wait(session, space, out XRView[] _views, out long _predictedDisplayTime))
        {
            return false;
        }
        
        views           = _views;
        nextDisplayTime = _predictedDisplayTime;
        
        swapchain.Begin(session);

        glBindFramebuffer(GL_FRAMEBUFFER, 0);
        glClear(GL_COLOR_BUFFER_BIT);
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffer);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 0);
        glClear(GL_COLOR_BUFFER_BIT);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 1);
        glClear(GL_COLOR_BUFFER_BIT);
        
        return true;
    }
    public static void End()
    {
        swapchain.End(session, space);
    }
    
    public static void Recenter()
    {
        OpenXR.space.Recreate();
    }
    
    
    public static void StringToBuffer(string _text, byte* _buffer, int _bufferSize)
    {
        byte[] _stringChars = System.Text.Encoding.UTF8.GetBytes(_text);
        int    _maxChars    = Math.Min(_stringChars.Length, _bufferSize - 1);

        for (int i = 0; i < _maxChars; i++)
        {
            _buffer[i] = _stringChars[i];
        }

        _buffer[_maxChars] = 0;
    }
}