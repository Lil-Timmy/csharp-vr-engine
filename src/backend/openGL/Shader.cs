using System.Collections.Generic;
using static Engine.GL;


namespace Engine;


public unsafe class Shader : Disposable
{
    public  readonly uint handle;
    
    private readonly Dictionary<string, int> uniforms = new Dictionary<string, int>();
    
    
    public Shader(string _vertCode, string _fragCode)
    {
        handle = glCreateProgram();
        
        uint _vert = glCreateShader(GL_VERTEX_SHADER);
        uint _frag = glCreateShader(GL_FRAGMENT_SHADER);
        
        glShaderSource (_vert, _vertCode);
        glShaderSource (_frag, _fragCode);
        

        int[] _status = new int[1];
        glCompileShader(_vert);
        glGetShaderiv  (_vert, GL_COMPILE_STATUS, ref _status);
        if (_status[0] == 0)
        {
            Debug.Error($"Vertex shader compilation failed:\n{glGetShaderInfoLog(_vert, 256)}");
        }
        glCompileShader(_frag);
        glGetShaderiv  (_frag, GL_COMPILE_STATUS, ref _status);
        if (_status[0] == 0)
        {
            Debug.Error($"Fragment shader compilation failed:\n{glGetShaderInfoLog(_frag, 256)}");
        }
        
        glAttachShader(handle, _vert);
        glAttachShader(handle, _frag);
        glLinkProgram(handle);
        
        glGetProgramiv(handle, GL_LINK_STATUS, ref _status);
        if (_status[0] == 0) Debug.Error($"Program linking failed:\n{glGetProgramInfoLog(handle, 256)}");
        
        glDetachShader(handle, _vert);
        glDetachShader(handle, _frag);
        glDeleteShader(        _vert);
        glDeleteShader(        _frag);
        
        Bind();
    }
    protected override void OnDispose()
    {
        glDeleteProgram(handle);
    }
    public void Bind()
    {
        glUseProgram(handle);
    }
    
    public void Uniform(string _name, float _value) => glUniform1f (UniformLocation(_name), _value);
    public void Uniform(string _name, int   _value) => glUniform1i (UniformLocation(_name), _value);
    public void Uniform(string _name, uint  _value) => glUniform1ui(UniformLocation(_name), _value);
    public void Uniform(string _name, vec2  _value) => glUniform2f (UniformLocation(_name), _value.x, _value.y);
    public void Uniform(string _name, ivec2 _value) => glUniform2i (UniformLocation(_name), _value.x, _value.y);
    public void Uniform(string _name, uvec2 _value) => glUniform2ui(UniformLocation(_name), _value.x, _value.y);
    public void Uniform(string _name, vec3  _value) => glUniform3f (UniformLocation(_name), _value.x, _value.y, _value.z);
    public void Uniform(string _name, ivec3 _value) => glUniform3i (UniformLocation(_name), _value.x, _value.y, _value.z);
    public void Uniform(string _name, uvec3 _value) => glUniform3ui(UniformLocation(_name), _value.x, _value.y, _value.z);
    public void Uniform(string _name, vec4  _value) => glUniform4f (UniformLocation(_name), _value.x, _value.y, _value.z, _value.w);
    public void Uniform(string _name, ivec4 _value) => glUniform4i (UniformLocation(_name), _value.x, _value.y, _value.z, _value.w);
    public void Uniform(string _name, uvec4 _value) => glUniform4ui(UniformLocation(_name), _value.x, _value.y, _value.z, _value.w);
    public void Uniform(string _name, Texture _texture, int _index)
    {
        glActiveTexture(GL_TEXTURE0 + _index);
        _texture.Bind();
        glUniform1i(UniformLocation(_name), _index);
    }
    
    private int UniformLocation(string _name)
    {
        if (uniforms.TryGetValue(_name, out int _location))
        {
            return _location;
        }
        
        _location = glGetUniformLocation(handle, _name);
        uniforms.Add(_name, _location);
        return _location;
    }
}