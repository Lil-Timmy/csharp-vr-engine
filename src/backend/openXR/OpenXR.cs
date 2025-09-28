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
    
    public static uint[]         framebuffers    { get; private set; }
    public static uint[]         depthTextures   { get; private set; }
    
    
    public static void Initialize(string appName, string engineName)
    {
        instance     = new XRInstance    (appName, engineName);
        systemID     = new XRSystemID    (instance);
        requirements = new XRRequirements(instance, systemID, new XRVersion(4, 5, 0));
        session      = new XRSession     (instance, systemID);
        space        = new XRSpace       (session);
        swapchain    = new XRSwapchain   (instance, space, session, systemID);
        
        framebuffers  = new uint[3];
        depthTextures = new uint[3];
        
        glEnable(GL_DEPTH_TEST);
        
        for (int _i = 0; _i < 2; _i++)
        {
            uint _framebuffer = glGenFramebuffer();
            uint _depthTexture = glGenTexture();
            
            glBindTexture(GL_TEXTURE_2D , _depthTexture);
            glTexImage2D (GL_TEXTURE_2D , 0, GL_DEPTH_COMPONENT16, (int)OpenXR.swapchain.width, (int)OpenXR.swapchain.height, 0, GL_DEPTH_COMPONENT, GL_UNSIGNED_BYTE, null);
            
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            
            glBindFramebuffer     (GL_FRAMEBUFFER, _framebuffer);
            glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, _depthTexture, 0);
            
            framebuffers [_i] = _framebuffer;
            depthTextures[_i] = _depthTexture;
        }
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
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[0]);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 0);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[1]);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 1);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[2]);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        return true;
    }
    public static void End()
    {
        swapchain.End(session, space);
    }
    
    public static void Recenter()
    {
        OpenXR.space.Recreate(session);
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