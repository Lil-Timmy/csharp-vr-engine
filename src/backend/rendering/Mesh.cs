using System.Collections.Generic;
using System.IO;


namespace Engine;


public class Mesh
{
    public readonly Buffer<float> vertexBuffer;
    public readonly Texture  texture;
    
    
    public Mesh(string _objPath)
    {
        string[] _file = File.ReadAllLines(_objPath);
        
        List<vec3  > _positions = new List<vec3  >();
        List<vec3  > _normals   = new List<vec3  >();
        List<vec2  > _uvs       = new List<vec2  >();
        
        List<string> _tris      = new List<string>();
        
        foreach (string _line in _file)
        {
            string[] _data = _line.Split(' ');
            string   _type = _data[0];
            
            switch (_type)
            {
                case "v":
                {
                    _positions.Add(new vec3(float.Parse(_data[1]), float.Parse(_data[2]), float.Parse(_data[3])));
                    break;
                }
                case "vn":
                {
                    _normals.Add(new vec3(float.Parse(_data[1]), float.Parse(_data[2]), float.Parse(_data[3])));
                    break;
                }
                case "vt":
                {
                    _uvs.Add(new vec2(float.Parse(_data[1]), float.Parse(_data[2])));
                    break;
                }
                case "f":
                {
                    _tris.Add(_line.Replace("f ", ""));
                    break;
                }
            }
        }
        
        float[] _vertices = new float[_tris.Count * 24];
        
        for (int _i = 0, _v = 0; _i < _tris.Count; _i++, _v += 24)
        {
            string   _tri      = _tris[_i];
            string[] _data     = _tri.Split(' ');
            
            string[] _vertA = _data[0].Split('/');
            string[] _vertB = _data[1].Split('/');
            string[] _vertC = _data[2].Split('/');
            
            vec3 _posA    = _positions[int.Parse(_vertA[0]) - 1];
            vec3 _posB    = _positions[int.Parse(_vertB[0]) - 1];
            vec3 _posC    = _positions[int.Parse(_vertC[0]) - 1];
            
            vec2 _uvA     = _uvs      [int.Parse(_vertA[1]) - 1];
            vec2 _uvB     = _uvs      [int.Parse(_vertB[1]) - 1];
            vec2 _uvC     = _uvs      [int.Parse(_vertC[1]) - 1];
            
            vec3 _normalA = _normals  [int.Parse(_vertA[2]) - 1];
            vec3 _normalB = _normals  [int.Parse(_vertB[2]) - 1];
            vec3 _normalC = _normals  [int.Parse(_vertC[2]) - 1];
            
            _vertices[_v + 0 ] = _posA.x;
            _vertices[_v + 1 ] = _posA.y;
            _vertices[_v + 2 ] = _posA.z;
            _vertices[_v + 3 ] = _uvA.x;
            _vertices[_v + 4 ] = _uvA.y;
            _vertices[_v + 5 ] = _normalA.x;
            _vertices[_v + 6 ] = _normalA.y;
            _vertices[_v + 7 ] = _normalA.z;
            
            _vertices[_v + 8 ] = _posB.x;
            _vertices[_v + 9 ] = _posB.y;
            _vertices[_v + 10] = _posB.z;
            _vertices[_v + 11] = _uvB.x;
            _vertices[_v + 12] = _uvB.y;
            _vertices[_v + 13] = _normalB.x;
            _vertices[_v + 14] = _normalB.y;
            _vertices[_v + 15] = _normalB.z;
            
            _vertices[_v + 16] = _posC.x;
            _vertices[_v + 17] = _posC.y;
            _vertices[_v + 18] = _posC.z;
            _vertices[_v + 19] = _uvC.x;
            _vertices[_v + 20] = _uvC.y;
            _vertices[_v + 21] = _normalC.x;
            _vertices[_v + 22] = _normalC.y;
            _vertices[_v + 23] = _normalC.z;
        }
        
        vertexBuffer = new Buffer<float>(Buffer.Target.VERTEXARRAY, Buffer.Usage.STATIC, _vertices);
    }
}