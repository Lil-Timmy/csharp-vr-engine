using System;
using static Engine.GL;


namespace Engine;


public static unsafe class Program
{
    public static bool isActive = true;
    
    
    public static void Main()
    {
        try
        {
            Window.Initialize("OpenXR Triangle", new ivec2(960, 540), new ivec2(480, 270), false, 72, 30);
            
            XRInstance     _instance     = new XRInstance    ("App Name", "Engine Name");
            XRSystemID     _systemID     = new XRSystemID    (_instance                );
            XRRequirements _requirements = new XRRequirements(_instance, _systemID, new XRVersion(4, 3, 0));
            XRSession      _session      = new XRSession     (_instance, _systemID);
            XRSpace        _space        = new XRSpace       (_session);
            XRInputs       _inputs       = new XRInputs      (_instance, _session);
            
            XRSwapchain    _swapchain    = null;

            Window.Run(() =>
            {
                _session.UpdateEvents(_instance);
                if (!isActive)
                {
                    Window.Close();
                    return;
                }
                
                if (_session.isRendering)
                {
                    _swapchain ??= new XRSwapchain   (_instance, _space, _session, _systemID);
                    
                    if (_swapchain.Wait(_session, out XrView[] _test, out long _predictedDisplayTime))
                    {
                        _swapchain.Begin(_session);
                        
                        glClearColor(new Random().Next(256) / 255f, 0.2f, 0.3f, 1.0f);
                        glClear(GL_COLOR_BUFFER_BIT);
                        
                        _swapchain.End  (_session);
                    }
                    
                    Debug.Read();
                }
                else if (_session.isActive)
                {
                    XRSwapchain.Wait(_session);
                }
            });
        }
        catch (Exception _exception)
        {
            Debug.Throw(_exception);
        }
        finally
        {
            Disposable.Cleanup();
            Window.Dispose();
        }
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