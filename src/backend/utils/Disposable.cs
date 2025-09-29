using System;


namespace Engine;


public unsafe abstract class Disposable
{
    ///<summary>The list of disposables per window-instance.</summary>///
    private static event Action disposables = delegate { };
    
    ///<summary>Whether or not this instance has been disposed.</summary>///
    protected bool disposed { get; private set; } = false;


    ///<summary>Creates a disposable interface for handling unmanaged memory.</summary>///
    public Disposable()
    {
        // Add the event to be disposed of on cleanup.
        disposables = Dispose + disposables;
    }

    ///<summary>Disposes of this instance if it was not already disposed of.</summary>///
    public void Dispose()
    {
        // If this instance was already disposed of, safely return.
        if (disposed)
        {
            return;
        }

        // Mark this instance as disposed and trigger the event.
        disposed = true;
        disposables -= Dispose;
        OnDispose();
    }

    ///<summary>A disposable callback used for cleaning up unmanaged memory.</summary>///
    protected virtual void OnDispose() { Debug.Warn($"No OnDispose override method present on [{GetType().Name}]."); }


    ///<summary>Disposes of all disposable-instances in first-in, last-out order.</summary>///
    public static void Cleanup()
    {
        // Ensure the context is set, then call and remove the event from the dict.
        disposables();
        disposables = delegate { };
    }
}