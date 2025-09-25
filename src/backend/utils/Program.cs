// using System;
// using System.Collections.Generic;


// namespace Engine;


// public static class Program
// {
//     private static readonly List<string> initCallbacks  = ["OnLoad"       , "OnStart"                             ];
//     private static readonly List<string> frameCallbacks = ["OnEarlyUpdate", "OnUpdate", "OnLateUpdate", "OnRender"];
//     private static readonly List<string> exitCallbacks  = ["OnQuit"       , "OnEnd"                               ];
    
    
//     private static void Main()
//     {
//         try
//         {
//             // Load this assembly and attach event functions e.g. update, render, load, etc.
//             AssemblyLoader.LoadAssembly(typeof(AssemblyLoader).Assembly);
//             foreach (string _callback in initCallbacks ) AssemblyLoader.AddCallback(_callback);
//             foreach (string _callback in frameCallbacks) AssemblyLoader.AddCallback(_callback);
//             foreach (string _callback in exitCallbacks ) AssemblyLoader.AddCallback(_callback);
            
//             // Initialize the window for the application.
//             Window.Initialize("VR-Engine", new ivec2(960, 540), new ivec2(480, 270), false, 100, 30);
            
//             // Initialize the input for the application.
//             Input.Initialize();
            
//             // Call all start event functions.
//             foreach (string _callback in initCallbacks ) AssemblyLoader.Call(_callback);
            
//             // Begin the render loop and call all frame event functions per-frame.
//             Window.Run(() => { foreach (string _callback in frameCallbacks) AssemblyLoader.Call(_callback); });
            
//             // Call all end event functions.
//             foreach (string _callback in exitCallbacks ) AssemblyLoader.Call(_callback);
//         }
//         catch (Exception _exception)
//         {
//             Debug.Throw(_exception);
//             // Debug.Read();
//         }
//         finally
//         {
//             Disposable.Cleanup();
//             Window.Dispose();
//         }
//     }
// }