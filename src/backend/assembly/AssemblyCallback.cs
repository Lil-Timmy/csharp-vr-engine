using System;
using System.Collections.Generic;
using System.Reflection;


namespace Engine;


public class AssemblyCallback
{
    public readonly Assembly assembly;
    public readonly Action   callback = delegate { };
    
    
    ///<summary>Destroys the glfw-window instance.</summary>///
    public AssemblyCallback(Assembly _assembly, List<AssemblyMethod> _assemblyMethods, string _methodTarget)
    {
        assembly = _assembly;
        
        foreach (AssemblyMethod _method in _assemblyMethods)
        {
            if (_method.name == _methodTarget)
            {
                callback += _method.callback;
            }
        }
    }
}