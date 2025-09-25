using System;
using System.Collections.Generic;
using System.Reflection;


namespace Engine;


public class AssemblyDomain
{
    public readonly Assembly assembly;
    
    private readonly List<AssemblyMethod>   assemblyMethods = new List<AssemblyMethod>();
    
    
    public AssemblyDomain(Assembly _assembly)
    {
        assembly = _assembly;
        
        foreach (Type _type in _assembly.GetTypes())
        {
            if 
            (
                (_type.IsAbstract &&
                _type.IsSealed)   ||
                _type.IsPublic
            )
            {
                foreach (MethodInfo _method in _type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic))
                {
                    if
                    (
                        _method.ReturnType             == typeof(void)  &&
                        _method.GetParameters().Length == 0             &&
                       !_method.IsGenericMethod
                    )
                    {
                        assemblyMethods.Add(new AssemblyMethod(_method));
                    }
                }
            }
        }
    }
    
    public AssemblyCallback GetCallback(string _methodTarget)
    {
        return new AssemblyCallback(assembly, assemblyMethods, _methodTarget);
    }
}