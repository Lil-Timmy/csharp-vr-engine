using System;
using System.Reflection;


namespace Engine;


public class AssemblyMethod
{
    public readonly string name;
    public readonly Action callback;
    
    
    public AssemblyMethod(MethodInfo _method)
    {
        name     = _method.Name;
        callback = _method.CreateDelegate<Action>();
    }
}