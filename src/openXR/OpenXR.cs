using System;
using static Engine.GL;


namespace Engine;


public static unsafe class OpenXR
{
    private static XRInstance     instance;
    private static XRSystemID     systemID;
    private static XRRequirements requirements;
    private static XRSession      session;
    private static XRSpace        space;
    private static XRSwapchain    swapchain;
    
    private static XRView[]       views;
    
    private static uint[]         framebuffers ;
    private static uint[]         depthTextures;
    private static mat4[]         screenMatrices;
    private static XRPose[]       screenPoses;
    
    
    public static void Initialize(string appName, string engineName)
    {
        instance     = new XRInstance    (appName, engineName);
        systemID     = new XRSystemID    (instance);
        requirements = new XRRequirements(instance, systemID, new XRVersion(4, 5, 0));
        session      = new XRSession     (instance, systemID);
        space        = new XRSpace       (session);
        swapchain    = new XRSwapchain   (instance, space, session, systemID);
        
        framebuffers   = new uint  [3];
        depthTextures  = new uint  [3];
        screenMatrices = new mat4  [3];
        screenPoses    = new XRPose[3];
        
        glEnable(GL_DEPTH_TEST);
        
        for (int _i = 0; _i < 2; _i++)
        {
            uint _framebuffer  = glGenFramebuffer();
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
        
        Input.Initialize(instance, session);
    }
    
    
    public static bool Begin()
    {
        session.UpdateEvents(instance);
        if (!session.isActive || !swapchain.Wait(session, space, out views, out long _predictedDisplayTime))
        {
            return false;
        }
        
        swapchain.Begin(session);
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[0]);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 0);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[1]);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 1);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        glBindFramebuffer(GL_FRAMEBUFFER, framebuffers[2]);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        
        Input.Update(instance, session, space, views, _predictedDisplayTime);
        
        return true;
    }
    public static void End()
    {
        swapchain.End(session, space);
        
        Input.Clear();
    }
    
    private static void OnEndUpdate()
    {
        XRView _leftEye  = views[0];
        XRView _rightEye = views[1];
        
        vec3 _leftEyePos  = Camera.position + quat.Rotate(Camera.rotation + quat.Inverse(Input.headsetRotation), _leftEye .position - Input.headsetPosition);
        quat _leftEyeRot  =                               Camera.rotation + _leftEye .rotation + quat.Inverse(Input.headsetRotation);
        
        vec3 _rightEyePos = Camera.position + quat.Rotate(Camera.rotation + quat.Inverse(Input.headsetRotation), _rightEye.position - Input.headsetPosition);
        quat _rightEyeRot =                               Camera.rotation + _rightEye.rotation + quat.Inverse(Input.headsetRotation);
        
        screenPoses   [0] = new XRPose(_leftEyePos    , _leftEyeRot    );
        screenPoses   [1] = new XRPose(_rightEyePos   , _rightEyeRot   );
        screenPoses   [2] = new XRPose(Camera.position, Camera.rotation);
        
        screenMatrices[0] = mat4.Position(-_leftEyePos        ) * mat4.Rotation(quat.Inverse(_leftEyeRot        )) * mat4.Projection(_leftEye                     , Input.NEAR, Input.FAR);
        screenMatrices[1] = mat4.Position(-_rightEyePos       ) * mat4.Rotation(quat.Inverse(_rightEyeRot       )) * mat4.Projection(_rightEye                    , Input.NEAR, Input.FAR);
        screenMatrices[2] = mat4.Position(-TestCamera.position) * mat4.Rotation(quat.Inverse(TestCamera.rotation)) * mat4.Projection(Input.FOV, Window.aspectRatio, Input.NEAR, Input.FAR);
    }
    
    public static void Draw(Shader _shader, Action _callback)
    {
        GL.glViewport(0, 0, (int)OpenXR.swapchain.width, (int)OpenXR.swapchain.height);
        
        GL.glBindFramebuffer(GL.GL_FRAMEBUFFER, OpenXR.framebuffers  [0]);
        _shader.Uniform     ("uScreenMat"     , OpenXR.screenMatrices[0]);
        _callback();
        
        GL.glBindFramebuffer(GL.GL_FRAMEBUFFER, OpenXR.framebuffers  [1]);
        _shader.Uniform     ("uScreenMat"     , OpenXR.screenMatrices[1]);
        _callback();
        
        GL.glViewport(0, 0, Window.size.x, Window.size.y);
        
        GL.glBindFramebuffer(GL.GL_FRAMEBUFFER, OpenXR.framebuffers  [2]);
        _shader.Uniform     ("uScreenMat"     , OpenXR.screenMatrices[2]);
        _callback();
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