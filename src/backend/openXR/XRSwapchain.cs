


namespace Engine;


public unsafe class XRSwapchain : Disposable
{
    public  readonly XrSwapchain                 swapchain;
    public  readonly XRSwapchainImage[]          images;

    private readonly XrSwapchainImageOpenGLKHR[] imagesKhr;
    
    public           uint             width                     { get; private set; }
    public           uint             height                    { get; private set; }
    
    public readonly  XrView[]         activeViews;
    public           XRSwapchainImage activeSwapchainImage      { get; private set; }
    public           uint             activeSwapchainImageIndex { get; private set; }

    public readonly uint viewCount ;
    public readonly uint imageCount;
    
    private readonly XrViewConfigurationView[]   configurationViews       ;
    
    private readonly XrSwapchainCreateInfo       swapchainCreateInfo      ;

    private readonly XrSwapchainImageAcquireInfo swapchainImageAcquireInfo;
    private readonly XrSwapchainImageWaitInfo    swapchainImageWaitInfo   ;
    private readonly XrSwapchainImageReleaseInfo swapchainImageReleaseInfo;

    private readonly XrFrameWaitInfo             frameWaitInfo            ;
    private readonly XrFrameState                frameState               ;
    
    private readonly  XrFrameBeginInfo            frameBeginInfo           ;
    private           XrFrameEndInfo              frameEndInfo             ;

    private readonly XrCompositionLayerProjectionView[] compositionLayerProjectionViews;
    private          XrCompositionLayerProjection       compositionLayerProjection     ;

    private          XrViewLocateInfo viewLocateInfo;
    private          XrViewState      viewState     ;


    public XRSwapchain(XRInstance _xrInstance, XRSpace _xrSpace, XRSession _xrSession, XRSystemID _systemID)
    {
        fixed (uint*                  _viewCountPtr   = &viewCount)
        {
            TimmyXR.xrEnumerateViewConfigurationViews(_xrInstance.instance, _systemID.id, XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO, 0, _viewCountPtr, null);
        }
        
        configurationViews = new XrViewConfigurationView[viewCount];
        
        for (int _i = 0; _i < viewCount; _i++)
        {
            configurationViews[_i] = new XrViewConfigurationView()
            {
                type = XrStructureType.XR_TYPE_VIEW_CONFIGURATION_VIEW,
                next = null                                           ,
            };
        }
        
        fixed (XrViewConfigurationView* _configViewsPtr =  configurationViews)
        fixed (uint*                    _viewCountPtr   = &viewCount         )
        {
            TimmyXR.xrEnumerateViewConfigurationViews(_xrInstance.instance, _systemID.id, XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO, viewCount, _viewCountPtr, _configViewsPtr);
        }


        width  = configurationViews[0].recommendedImageRectWidth ;
        height = configurationViews[0].recommendedImageRectHeight;


        swapchainCreateInfo = new XrSwapchainCreateInfo()
        {
            type        = XrStructureType.XR_TYPE_SWAPCHAIN_CREATE_INFO                       ,
            next        = null                                                                ,
            createFlags = (ulong)XrSwapchainCreateFlags.None                                  ,
            usageFlags  = (ulong)XrSwapchainUsageFlags.XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT,
            format      = GL.GL_SRGB8_ALPHA8                                                  ,
            
            width       = width                                                               ,
            height      = height                                                              ,
            
            arraySize   = viewCount                                                           ,


            sampleCount = 1                                                                   ,
            
            faceCount   = 1                                                                   ,
            mipCount    = 1                                                                   ,
        };

        fixed (XrSwapchain*           _swapchainPtr           = &swapchain          )
        fixed (XrSwapchainCreateInfo* _swapchainCreateInfoPtr = &swapchainCreateInfo)
        {
            TimmyXR.xrCreateSwapchain(_xrSession.session, _swapchainCreateInfoPtr, _swapchainPtr);
        }


        fixed (uint* _imageCountPtr = &imageCount)
        {
            TimmyXR.xrEnumerateSwapchainImages(swapchain, 0, _imageCountPtr, null);
        }

        imagesKhr = new XrSwapchainImageOpenGLKHR[imageCount];
        for (int _i = 0; _i < imageCount; _i++)
        {
            imagesKhr[_i] = new XrSwapchainImageOpenGLKHR()
            {
                type = XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_OPENGL_KHR,
                next = null                                              ,
            };
        }

        fixed (XrSwapchainImageOpenGLKHR* _swapchainImagesPtr =  imagesKhr )
        fixed (uint*                      _imageCountPtr      = &imageCount)
        {
            TimmyXR.xrEnumerateSwapchainImages(swapchain, imageCount, _imageCountPtr, (XrSwapchainImageBaseHeader*)_swapchainImagesPtr);
        }


        images = new XRSwapchainImage[imageCount];

        for (int _i = 0; _i < imageCount; _i++)
        {
            images[_i] = new XRSwapchainImage(imagesKhr[_i].image);
        }


        frameWaitInfo = new XrFrameWaitInfo()
        {
            type = XrStructureType.XR_TYPE_FRAME_WAIT_INFO,
            next = null,
        };

        frameState = new XrFrameState()
        {
            type = XrStructureType.XR_TYPE_FRAME_STATE,
            next = null,
        };


        frameBeginInfo = new XrFrameBeginInfo()
        {
            type = XrStructureType.XR_TYPE_FRAME_BEGIN_INFO,
            next = null,
        };

        frameEndInfo = new XrFrameEndInfo()
        {
            type = XrStructureType.XR_TYPE_FRAME_END_INFO,
            next = null,
            
            environmentBlendMode = XrEnvironmentBlendMode.XR_ENVIRONMENT_BLEND_MODE_OPAQUE,
        };
        

        swapchainImageAcquireInfo = new XrSwapchainImageAcquireInfo()
        {
            type = XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_ACQUIRE_INFO,
            next = null,
        };

        swapchainImageWaitInfo = new XrSwapchainImageWaitInfo()
        {
            type = XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_WAIT_INFO,
            next = null,
            
            timeout = long.MaxValue,
        };


        compositionLayerProjectionViews = new XrCompositionLayerProjectionView[viewCount];

        for (int _i = 0; _i < viewCount; _i++)
        {
            compositionLayerProjectionViews[_i] = new XrCompositionLayerProjectionView()
            {
                type     = XrStructureType.XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW,
                next     = null,
                
                subImage = new XrSwapchainSubImage()
                {
                    swapchain       = swapchain,
                    imageRect       = new XrRect2Di()
                    {
                        offset = new XrOffset2Di { x = 0, y = 0 },
                        extent = new XrExtent2Di { width = (int)width, height = (int)height }
                    },
                    imageArrayIndex = (uint)_i,
                },
            };
        }

        fixed (XrCompositionLayerProjectionView* _compositionLayerProjectionViewsPtr = compositionLayerProjectionViews)
        {
            compositionLayerProjection = new XrCompositionLayerProjection()
            {
                type        = XrStructureType.XR_TYPE_COMPOSITION_LAYER_PROJECTION,
                next        = null                                                ,
                layerFlags  = (ulong)XrCompositionLayerFlags.None                 ,
                
                space       = _xrSpace.space                                      ,
                
                viewCount   = viewCount                                           ,
                views       = _compositionLayerProjectionViewsPtr                 ,
            };
        }


        viewLocateInfo = new XrViewLocateInfo()
        {
            type = XrStructureType.XR_TYPE_VIEW_LOCATE_INFO                                          ,
            next = null                                                                              ,

            viewConfigurationType = XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO,
            space = _xrSpace.space                                                                   ,
        };

        viewState = new XrViewState()
        {
            type = XrStructureType.XR_TYPE_VIEW_STATE    ,
            next = null                                  ,
            
            viewStateFlags = (ulong)XrViewStateFlags.None,
        };


        activeViews = new XrView[viewCount];

        for (int _i = 0; _i < viewCount; _i++)
        {
            activeViews[_i] = new XrView()
            {
                type = XrStructureType.XR_TYPE_VIEW,
                next = null                        ,
            };
        }
        

        swapchainImageReleaseInfo = new XrSwapchainImageReleaseInfo()
        {
            type = XrStructureType.XR_TYPE_SWAPCHAIN_IMAGE_RELEASE_INFO,
            next = null                                                ,
        };
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroySwapchain(swapchain);
    }


    public bool Wait(XRSession _xrSession, XRSpace _xrSpace, out XRView[] _views, out long _predictedDisplayTime)
    {
        fixed (XrFrameWaitInfo* _frameWaitInfoPtr = &frameWaitInfo)
        fixed (XrFrameState   * _frameStatePtr    = &frameState   )
        {
            TimmyXR.xrWaitFrame(_xrSession.session, _frameWaitInfoPtr, _frameStatePtr);
        }

        if (frameState.shouldRender == 0)
        {
            Delay(_xrSession);
            
            _views = null;
            _predictedDisplayTime = 0;
            
            return false;
        }

        viewLocateInfo.displayTime    = frameState.predictedDisplayTime;
        viewState     .viewStateFlags = (ulong)XrViewStateFlags.None;
        viewLocateInfo.space          = _xrSpace.space;

        fixed (XrViewLocateInfo* _viewLocateInfoPtr = &viewLocateInfo)
        fixed (XrViewState     * _viewState         = &viewState     )
        fixed (uint            * _viewCountPtr      = &viewCount     )
        fixed (XrView          * _viewsPtr          =  activeViews   )
        {
            TimmyXR.xrLocateViews(_xrSession.session, _viewLocateInfoPtr, _viewState, viewCount, _viewCountPtr, _viewsPtr);
        }

        _views = [new XRView(activeViews[0]), new XRView(activeViews[1])];
        _predictedDisplayTime = frameState.predictedDisplayTime;

        return true;
    }
    public void Begin(XRSession _xrSession)
    {
        fixed (XrFrameBeginInfo* _frameBeginInfoPtr = &frameBeginInfo)
        {
            TimmyXR.xrBeginFrame(_xrSession.session, _frameBeginInfoPtr);
        }
  

        uint _activeSwapchainIndex = 0;
        
        fixed(XrSwapchainImageAcquireInfo* _swapchainImageAcquireInfoPtr = &swapchainImageAcquireInfo)
        fixed(XrSwapchainImageWaitInfo*    _swapchainImageWaitInfoPtr    = &swapchainImageWaitInfo   )
        {
            TimmyXR.xrAcquireSwapchainImage(swapchain, _swapchainImageAcquireInfoPtr, &_activeSwapchainIndex);
            TimmyXR.xrWaitSwapchainImage   (swapchain, _swapchainImageWaitInfoPtr                           );
        }
        
        activeSwapchainImageIndex = _activeSwapchainIndex;
        activeSwapchainImage      = images[activeSwapchainImageIndex];
    }

    public void End(XRSession _xrSession, XRSpace _xrSpace)
    {
        fixed (XrSwapchainImageReleaseInfo* _swapchainImageReleaseInfoPtr = &swapchainImageReleaseInfo)
        {
            TimmyXR.xrReleaseSwapchainImage(swapchain, _swapchainImageReleaseInfoPtr);
        }

        
        for (int _i = 0; _i < viewCount; _i++)
        {
            compositionLayerProjectionViews[_i].fov                              = activeViews[_i].fov ;
            compositionLayerProjectionViews[_i].pose                             = activeViews[_i].pose;

            compositionLayerProjectionViews[_i].subImage.imageRect.extent.width  = (int)width     ;
            compositionLayerProjectionViews[_i].subImage.imageRect.extent.height = (int)height    ;
        }
        
        compositionLayerProjection.space = _xrSpace.space;

        fixed (XrCompositionLayerProjection* _compositionLayerProjectionPtr = &compositionLayerProjection)
        {
            frameEndInfo.layerCount  = 1;
            frameEndInfo.layers      = (XrCompositionLayerBaseHeader**)&_compositionLayerProjectionPtr;

            frameEndInfo.displayTime = frameState.predictedDisplayTime;
        }


        fixed(XrFrameEndInfo* _frameEndInfoPtr = &frameEndInfo)
        {
            TimmyXR.xrEndFrame(_xrSession.session, _frameEndInfoPtr);
        }
    }


    public void Delay(XRSession _xrSession)
    {
        fixed (XrFrameBeginInfo* _frameBeginInfoPtr = &frameBeginInfo)
        {
            TimmyXR.xrBeginFrame(_xrSession.session, _frameBeginInfoPtr);
        }
        
        
        frameEndInfo.layerCount  = 0                              ;
        frameEndInfo.layers      = null                           ;
        
        frameEndInfo.displayTime = frameState.predictedDisplayTime;


        fixed(XrFrameEndInfo* _frameEndInfoPtr = &frameEndInfo)
        {
            TimmyXR.xrEndFrame(_xrSession.session, _frameEndInfoPtr);
        }
    }


    public static void DebugAvaliableFormats(XRSession _xrSession)
    {
        uint _formatCount = 0;
        TimmyXR.xrEnumerateSwapchainFormats(_xrSession.session, 0, &_formatCount, null);

        long[] _swapchainFormats = new long[_formatCount];
        fixed (long* _swapchainFormatsPtr = _swapchainFormats)
        {
            TimmyXR.xrEnumerateSwapchainFormats(_xrSession.session, _formatCount, &_formatCount, _swapchainFormatsPtr);
        }

        Debug.Log("Formats:" , System.ConsoleColor.Yellow);
        Debug.Log("--"       , System.ConsoleColor.Yellow);
        foreach (long _format in _swapchainFormats)
        {
            Debug.Log(_format, System.ConsoleColor.Yellow);
        }
        Debug.Log("--"       , System.ConsoleColor.Yellow);
    }
}