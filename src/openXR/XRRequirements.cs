


namespace Engine;


public unsafe class XRRequirements
{
    public readonly XRVersion openGLApiVersion;


    private readonly XrGraphicsRequirementsOpenGLKHR graphicsRequirements;


    public XRRequirements(XRInstance _xrInstance, XRSystemID _xrSystemID, XRVersion _openGLVersion)
    {
        openGLApiVersion = _openGLVersion;
        
        graphicsRequirements = new XrGraphicsRequirementsOpenGLKHR()
        {
            type = XrStructureType.XR_TYPE_GRAPHICS_REQUIREMENTS_OPENGL_KHR,
            next = null                                                    ,
        };

        fixed (XrGraphicsRequirementsOpenGLKHR* _graphicsRequirementsPtr = &graphicsRequirements)
        {
            TimmyXR.xrGetOpenGLGraphicsRequirementsKHR(_xrInstance.instance, _xrSystemID.id, _graphicsRequirementsPtr);
        }
    }
}