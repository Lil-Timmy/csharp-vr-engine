using System;
using System.Collections;
using System.Linq;
using System.Text;
using DotGLFW;


namespace Engine;


public static class Debug
{
    ///<summary>The printed color when using Debug.Log(...)</summary>///
    private const ConsoleColor LOGCOLOR   = ConsoleColor.Gray;
    ///<summary>The printed color when using Debug.Read(...)</summary>///
    private const ConsoleColor READCOLOR  = ConsoleColor.White;
    ///<summary>The printed color when using Debug.Throw(...)</summary>///
    private const ConsoleColor ERRORCOLOR = ConsoleColor.Red;
    ///<summary>The printed color when using Debug.Warn(...)</summary>///
    private const ConsoleColor WARNCOLOR = ConsoleColor.Red;
    
    
    ///<summary>Prints the specified string to the console with an optional color.</summary>///
    public static void Log(string _message, ConsoleColor _color = LOGCOLOR)
    {
        // Set, then reset the text color, and write the type to the console.
        Console.ForegroundColor = _color;
        Console.WriteLine($" - {_message}");
        Console.ResetColor();
    }
    ///<summary>Prints the specified type to the console with an optional color.</summary>///
    public static void Log(object _type, ConsoleColor _color = LOGCOLOR)
    {
        // Write the type as a string to the console using the specified color.
        string _message = _type.ToString();
        Log(_message, _color);
    }
    ///<summary>Prints the specified collection to the console with an optional color.</summary>///
    public static void Log(IEnumerable _collection, ConsoleColor _color = LOGCOLOR)
    {
        // Turn the collection into a stringified message, then log it using the specified color.
        string _message = $"[ {string.Join(", ", _collection.Cast<object>())} ]";
        Log(_message, _color);
    }

    ///<summary>Returns a single read-line command from the console with an optional color. Thread-blocking.</summary>///
    public static string Read(ConsoleColor _color = READCOLOR)
    {
        // Set the color, write a simple line to specify the intention to write to the console, and read the input line.
        Console.ForegroundColor = _color;
        Console.Write(" > ");
        string _output = Console.ReadLine();
        return _output;
    }
    ///<summary>Prints a specified message, then returns a single read-line command from the console. Thread-blocking.</summary>///
    public static string Read(object _message, ConsoleColor _color = READCOLOR)
    {
        // Log the specified message, then read the line.
        Log(_message, _color);
        string _output = Read(_color);
        return _output;
    }

    ///<summary>Throws an exception with a specified message.</summary>///
    public static void Error(string _message)
    {
        // Throw an exception with the specified message.
        throw new Exception(_message);
    }
    ///<summary>Cleanly formats a thrown exception using an optional color.</summary>///
    public static void Throw(Exception _exception, ConsoleColor _color = ERRORCOLOR)
    {
        // Set the text, error-type, exception-message, and thrown-location.
        StringBuilder _text = new StringBuilder();
        
        // If the inner exception exists, override the outer exception's error.
        if (_exception.InnerException != null)
        {
            _exception = _exception.InnerException;
        }
        
        // Log the exception cleanly by removing any excess logs (specifically from the Debug.Throw(..) and Debug.Error(..)).
        string _type     = _exception.GetType().ToString();
        string _message  = _exception.Message;
        string _location = string.Join("\n", _exception.StackTrace.Split(Environment.NewLine).Where(_line => !_line.Contains("Engine.Debug"))).Trim();
        
        // Build the string and log it to the console.
        _text.AppendLine($"[ERROR]:"          );
        _text.AppendLine($"    -> {_type}"    );
        _text.AppendLine($"    -> {_message}" );
        _text.AppendLine($"    -> \n   {_location}");

        Log(_text.ToString(), _color);
    }
    
    ///<summary>Prints out a specified message to the console in an optional color.</summary>///
    public static void Warn(string _message, ConsoleColor _color = WARNCOLOR)
    {
        // Log the specified message and color.
        Log(_message, _color);
    }
    
    
    
    ///<summary>Prints out a specified message if an OpenXR command fails.</summary>///
    public static void Result(XrResult _result, string _message)
    {
        if (_result < 0)
        {
            Error($"OpenXR - {_message} - {_result}");
        }
    }
    ///<summary>Prints out a specified message and error-description for if a glfw commmand might fail.</summary>///
    public static unsafe void Glfw(string _message)
    {
        // Retreive the error code + message and log them as an error.
        ErrorCode _errorCode = DotGLFW.Glfw.GetError(out string _description);
        Debug.Error($"{_message} <{_errorCode}> [{_description}]");
    }
}