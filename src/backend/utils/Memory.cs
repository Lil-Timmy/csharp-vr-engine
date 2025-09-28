using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace Engine;


public static unsafe class Memory
{
    private static readonly List<GCHandle> handles = new List<GCHandle>();
    
    
    public static T* Pin<T>(T _objToPin) where T : unmanaged
    {
        GCHandle    _handle = GCHandle.Alloc(_objToPin, GCHandleType.Pinned);
        handles.Add(_handle);
        return (T*) _handle.AddrOfPinnedObject();
    }
    
    public static void Cleanup()
    {
        foreach (GCHandle _handle in handles) _handle.Free();
        handles.Clear();
    }
}