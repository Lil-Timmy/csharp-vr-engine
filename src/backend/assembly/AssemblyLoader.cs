using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Engine;


public static class AssemblyLoader
{
    private static readonly List<AssemblyDomain>                       domains   = new List<AssemblyDomain>();
    private static readonly Dictionary<string, List<AssemblyCallback>> callbacks = new Dictionary<string, List<AssemblyCallback>>();
    
    
    ///<summary>Loads a specified assembly as a domain to be called by current and future callbacks.</summary>///
    public static void LoadAssembly(Assembly _assembly)
    {
        AssemblyDomain _domain = new AssemblyDomain(_assembly);
        domains.Add(_domain);
        
        foreach (string _methodTarget in callbacks.Keys)
        {
            callbacks[_methodTarget].Add(_domain.GetCallback(_methodTarget));
        }
    }
    
    public static void UnloadAssembly(Assembly _assembly)
    {
        AssemblyDomain _domain = domains.Find(_domain => _domain.assembly == _assembly);
        domains.Remove(_domain);
        
        foreach (string _methodTarget in callbacks.Keys)
        {
            callbacks[_methodTarget].Remove(callbacks[_methodTarget].First(_callback => _callback.assembly == _assembly));
        }
    }
    
    public static void AddCallback(string _methodTarget)
    {
        callbacks.Add(_methodTarget, new List<AssemblyCallback>());
        
        foreach (AssemblyDomain _domain in domains)
        {
            callbacks[_methodTarget].Add(_domain.GetCallback(_methodTarget));
        }
    }
    
    
    public static void Call(string _target)
    {
        foreach (AssemblyCallback _callback in callbacks[_target])
        {
            _callback.callback();
        }
    }
}