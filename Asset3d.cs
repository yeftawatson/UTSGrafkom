using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertemuan1
{
    internal class Asset3d
    {
        //float[] _vertices =
        //{
        //    //x     //y   //z
        //    //vertices 1
        //    //vertices 2
        //    //vertices 3
        //};
        //uint[] _indices =
        //{

        //};
        List<Vector3> _vertices = new List<Vector3>();
        List<uint> _indices = new List<uint>();
        int _vertexBufferObject;
        int _vertexArrayObject;
        int _elementBufferObject;
        Shader _shader;
        //Matrix4 _view; //camera
        //Matrix4 _projection; //settingan camera
        Matrix4 _model; //Merubah transformasi
        Vector3 _color; //coloring
        public Vector3 _center;
        public Vector3 _rotateCenter;
        public List<Vector3> _euler;
        public List<Asset3d> Child;

        int index;
        int[] _pascal = { };
        public Asset3d(List<Vector3> vertices, List<uint> indices)
        {
            this._vertices = vertices;
            this._indices = indices;
        }
        public Asset3d()
        {
            _vertices = new List<Vector3>();
            setDefault();
        }

        public void setDefault()
        {
            _model = Matrix4.Identity;
            _euler = new List<Vector3>();
            _euler.Add(new Vector3(1, 0, 0));
            _euler.Add(new Vector3(0, 1, 0));
            _euler.Add(new Vector3(0, 0, 1));
            //_euler.Add(new Vector3(0, 0, 1));
            Child = new List<Asset3d>();
        }

        public void setColor(Vector3 color)
        {
            _color.X = color.X / 255f;
            _color.Y = color.Y / 255f;
            _color.Z = color.Z / 255f;
        }
        public void load(string shaderVert, string shaderFrag, float Size_x, float Size_y)
        {
            //Background color changing
            GL.ClearColor(82.0f/255.0f, 229.0f/255.0f, 255.0f/255.0f, 1.0f);
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count * Vector3.SizeInBytes,
                _vertices.ToArray(), BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            // If object has different setting(s)


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false,
                3 * sizeof(float), 0);
            //0 referensi dari param pertama di vertex attrib
            GL.EnableVertexAttribArray(0);

            if (_indices.Count != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Count
                    * sizeof(uint), _indices.ToArray(), BufferUsageHint.StaticDraw);
            }
            //_shader = new Shader("E:/My Stuff(s)/UKP/Informatika/Materi/Semester 4/" +
            //    "Grafika Komputer/Visual Studio/Pertemuan4/" +
            //    "Pertemuan1/Shader/shader.vert",
            //    "E:/My Stuff(s)/UKP/Informatika/Materi/Semester 4/" +
            //    "Grafika Komputer/Visual Studio/Pertemuan4/" +
            //    "Pertemuan1/Shader/shader.frag");
            _shader = new Shader(shaderVert, shaderFrag);
            _shader.Use();

            //_view = Matrix4.CreateTranslation(0f, 0f, -3.0f);

            //_projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size_x / (float)Size_y, 0.1f, 100.0f);
            foreach (var i in Child)
            {
                i.load(shaderVert, shaderFrag, Size_x, Size_y);

            }
        }

        public void render(int _lines, Matrix4 temp, Matrix4 camera_view, Matrix4 camera_projection)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            //_model = temp;

            _shader.SetVector3("ourColor", _color);
            _shader.SetMatrix4("model", _model);
            _shader.SetMatrix4("view", camera_view);
            _shader.SetMatrix4("projection", camera_projection);

            if (_indices.Count != 0)
            {
                GL.DrawElements(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, _indices.Count, OpenTK.Graphics.OpenGL4.DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (_lines == 0)
                {
                    GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleFan, 0, _vertices.Count);
                }
                else if (_lines == 1)
                {
                    GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleFan, 0, (_vertices.Count));
                }
                else if (_lines == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, index);
                }
                else if (_lines == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, _vertices.Count);
                }
                else if (_lines == 4)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, _vertices.Count / 3);
                }
            }
            foreach (var i in Child)
            {
                i.render(_lines, temp, camera_view, camera_projection);
            }
        }
        public Vector3 getRotationResult(Vector3 pivot, Vector3 vector, float angle, Vector3 point, bool isEuler = false)
        {
            Vector3 temp, newPosition;

            if (isEuler)
            {
                temp = point;
            }
            else
            {
                temp = point - pivot;
            }

            newPosition.X =
                temp.X * (float)(Math.Cos(angle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Y * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) - vector.Z * Math.Sin(angle)) +
                temp.Z * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) + vector.Y * Math.Sin(angle));

            newPosition.Y =
                temp.X * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) + vector.Z * Math.Sin(angle)) +
                temp.Y * (float)(Math.Cos(angle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Z * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) - vector.X * Math.Sin(angle));

            newPosition.Z =
                temp.X * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) - vector.Y * Math.Sin(angle)) +
                temp.Y * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) + vector.X * Math.Sin(angle)) +
                temp.Z * (float)(Math.Cos(angle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(angle)));

            if (isEuler)
            {
                temp = newPosition;
            }
            else
            {
                temp = newPosition + pivot;
            }
            return temp;
        }

        public void rotate(Vector3 pivot, Vector3 vector, float angle)
        {
            var radAngle = MathHelper.DegreesToRadians(angle);

            var arbRotationMatrix = new Matrix4
                (
                new Vector4((float)(Math.Cos(radAngle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) + vector.Z * Math.Sin(radAngle)), (float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.Y * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) - vector.Z * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.X * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.Y * Math.Sin(radAngle)), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.X * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(radAngle))), 0),
                Vector4.UnitW
                );

            _model *= Matrix4.CreateTranslation(-pivot);
            _model *= arbRotationMatrix;
            _model *= Matrix4.CreateTranslation(pivot);

            for (int i = 0; i < 3; i++)
            {
                _euler[i] = Vector3.Normalize(getRotationResult(pivot, vector, radAngle, _euler[i], true));
            }

            //_rotateCenter = getRotationResult(pivot, vector, radAngle, _rotateCenter);
            _center = getRotationResult(pivot, vector, radAngle, _center);

            foreach (var i in Child)
            {
                i.rotate(pivot, vector, angle);
            }
        }
        public void addChild(float radiusX, float radiusY, float radiusZ,
            float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            Asset3d newChild = new Asset3d();
            newChild.createEllipsoid2(radiusX, radiusY, radiusZ, _x, _y, _z, sectorCount, stackCount);
            Child.Add(newChild);
        }
        public void addChildClass(Asset3d child)
        {
            Child.Add(child);
        }
        public void createBoxVertices(float x, float y, float z, float length)
        {
            ////FRONT FACE
            ////SEGITIGA FRONT 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            ////SEGITIGA FRONT 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

            ////BACK FACE
            ////SEGITIGA BACK 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            ////SEGITIGA BACK 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));

            ////LEFT FACE
            ////SEGITIGA LEFT 1
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            ////SEGITIGA LEFT 2
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));

            ////RIGHT FACE
            ////SEGITIGA RIGHT 1
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            ////SEGITIGA LEFT 2
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));

            ////BOTTOM FACE
            ////SEGITIGA BOTTOM 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            ////SEGITIGA BOTTOM 2
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

            ////FRONT FACE
            ////SEGITIGA BOTTOM 1
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            ////SEGITIGA BOTTOM 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            _center.X = x;
            _center.Y = y;
            _center.Z = z;
            Vector3 temp_vector;

            //Titik 1
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 2
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 3
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 4
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 5
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 6
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 7
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);
            //Titik 8
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);

            _indices = new List<uint>
            {
                //Segitiga 
                0,1,2,
                1,2,3,
                0,4,5,
                0,1,5,
                1,3,5,
                3,5,7,
                0,2,4,
                2,4,6,
                4,5,6,
                5,6,7,
                2,3,6,
                3,6,7
            };
        }

        //public void createCircle(float center_x, float center_y, float radius)
        //{
        //    _vertices = new float[1080];
        //    for (int i = 0; i < 360; i++)
        //    {
        //        double degInRad = i * Math.PI / 180;
        //        //x
        //        _vertices[i * 3] = radius * (float)Math.Cos(degInRad) + center_x;
        //        //y
        //        _vertices[i * 3 + 1] = radius * (float)Math.Sin(degInRad) + center_y;
        //        //z
        //        _vertices[i * 3 + 2] = 0; 
        //    }
        //} public void createElipse(float center_x, float center_y, float radius_x,float radius_y)
        //{
        //    _vertices = new float[1080];
        //    for (int i = 0; i < 360; i++)
        //    {
        //        double degInRad = i * Math.PI / 180;
        //        //x
        //        _vertices[i * 3] = radius_x * (float)Math.Cos(degInRad) + center_x;
        //        //y
        //        _vertices[i * 3 + 1] = radius_y * (float)Math.Sin(degInRad) + center_y;
        //        //z
        //        _vertices[i * 3 + 2] = 0; 
        //    }
        //}
        //}
        //public void createElipseoid(float radius_x, float radius_y, float radius_z, float _x, 
        //float _y, float _z)
        //{
        //    float pi = (float)Math.PI;
        //    Vector3 temp_vector;
        //    for (float u = -pi; u <= pi / 2; u+= pi / 300)
        //    {
        //        for(float v = -pi / 2; v <= pi / 2;  v += pi / 300)
        //        {
        //            temp_vector.X = _x + (float)Math.Cos(v) * (float)Math.Cos(u) * radius_x;
        //            temp_vector.Y = _y + (float)Math.Cos(v) * (float)Math.Sin(u) * radius_y;  
        //            temp_vector.Z = _z + (float)Math.Sin(v) * radius_z;
        //            _vertices.Add(temp_vector);
        //        }
        //    }
        //}

        public void createHypbolo(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 300)
            {
                for (float v = -pi / 2; v <= pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x + (float)Sec(Math.Cos(v)) * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)Sec(Math.Cos(v)) * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)Math.Tan(v) * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }
        public void createHypbolo2(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi / 2; u <= pi / 2; u += pi / 300)
            {
                for (float v = -pi / 2; v <= pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x + (float)Math.Tan(v) * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)Math.Tan(v) * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)Sec(Math.Cos(v)) * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void EllipCone(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 300)
            {
                for (float v = 0; v <= pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x + (float)v * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)v * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)v * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }
        public void EllipCone2(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 720)
            {
                for (float v = -pi / 2; v <= pi / 2; v += pi / 720)
                {
                    temp_vector.X = _x + (float)v * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)v * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)v * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void EllipPara(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 600)
            {
                for (float v = 0; v <= 10; v += pi / 600)
                {
                    temp_vector.X = _x + (float)v * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)v * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)Math.Pow(v, 2) * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void HyperPara(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi; u += pi / 300)
            {
                for (float v = 0; v <= pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x + (float)v * (float)Math.Tan(u) * radius_x;
                    temp_vector.Y = _y + (float)v * 1 / (float)Math.Cos(u) * radius_y;
                    temp_vector.Z = _z + (float)Math.Pow(v, 2) * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void translateObject2(float x, float y, float z)
        {

            _model *= Matrix4.CreateTranslation(x, y, z);
            foreach (var i in Child)
            {
                i._model *= Matrix4.CreateTranslation(x, y, z);
            }
        }

        public void createElipseoid(float radius_x, float radius_y, float radius_z, float _x,
        float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi; u <= pi / 2; u += pi / 300)
            {
                for (float v = -pi / 2; v <= pi / 2; v += pi / 300)
                {
                    temp_vector.X = _x + (float)Math.Cos(v) * (float)Math.Cos(u) * radius_x;
                    temp_vector.Y = _y + (float)Math.Cos(v) * (float)Math.Sin(u) * radius_y;
                    temp_vector.Z = _z + (float)Math.Sin(v) * radius_z;
                    _vertices.Add(temp_vector);
                }
            }
        }

        public void createCylinder(float center_x, float center_y, float center_z, float radius, float height)
        {
            _center.X = center_x;
            _center.Y = center_y;
            _center.Z = center_z;
            Vector3 temp_vector;

            for (float deg = 0; deg <= 360; deg+= 0.1f)
            {
                for (float t = 0; t <= height; t += 0.5f)
                {
                    temp_vector.X = center_x + radius * (float)Math.Cos(deg);
                    temp_vector.Y = center_y + t;
                    temp_vector.Z = center_z + radius * (float)Math.Sin(deg);
                    _vertices.Add(temp_vector);
                }
            }

        }

        public void createEllipsoid2(float radiusX, float radiusY, float radiusZ,
            float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;



            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x * (float)Math.Cos(sectorAngle) + _x;
                    temp_vector.Y = y * (float)Math.Sin(sectorAngle) + _y;
                    temp_vector.Z = z + _z;
                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        public void translateObject(float y)
        {
            _model *= Matrix4.CreateTranslation(0, y, 0);
            foreach (var i in Child)
            {
                i._model *= Matrix4.CreateTranslation(0, y, 0);
            }
        }

        public void createHalfBall(float radiusX, float radiusY, float radiusZ,
            float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;



            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount / 2; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x * (float)Math.Cos(sectorAngle) + _x;
                    temp_vector.Y = y * (float)Math.Sin(sectorAngle) + _y;
                    temp_vector.Z = z + _z;
                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount / 2; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }

        public double Sec(double cos)
        {
            return 1 / cos;
        }

        ////public void updateMousePosition(float x, float y, float z)
        ////{
        ////    _vertices[index * 3] = x;
        ////   _vertices[index * 3 + 1] = y;
        ////   _vertices[index * 3 + 2] = z;
        ////    index++;

        ////    GL.BufferData(BufferTarget.ArrayBuffer, index * 3 * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        ////    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        ////}
        //public void updateMousePosition(float x, float y, float z)
        //{
        //    _vertices[index * 3] = x;
        //   _vertices[index * 3 + 1] = y;
        //   _vertices[index * 3 + 2] = z;
        //    index++;

        //    GL.BufferData(BufferTarget.ArrayBuffer, index * 3 * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        //    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        //    GL.EnableVertexAttribArray(0);
        //}
        //public List<int> getRow(int row_index)
        //{
        //    List<int> current_row = new List<int>();
        //    current_row.Add(1);
        //    if(row_index == 0)
        //    {
        //        return current_row;
        //    }
        //    List<int> prev = getRow(row_index - 1);
        //    for(int i = 1;i<prev.Count;i++)
        //    {
        //        int curr = prev[i - 1] + prev[i];
        //        current_row.Add(curr);
        //    }
        //    current_row.Add(1);
        //    return current_row;
        //}

        //public List<float> CreateCurveBezier()
        //{
        //    List<float> _vertices_bezier = new List<float>();
        //    List<int> pascal = getRow(index - 1);
        //    _pascal = pascal.ToArray();
        //    for (float t = 0; t <= 1.0f; t += 0.01f)
        //    {
        //        Vector2 p = getP(index, t);
        //        _vertices_bezier.Add(p.X);
        //        _vertices_bezier.Add(p.Y);
        //        _vertices_bezier.Add(0);
        //    }
        //    return _vertices_bezier;
        //}
        //public Vector2 getP (int n, float t)
        //{
        //    Vector2 p = new Vector2(0, 0);
        //    float [] k = new float[n];
        //    for (int i = 0; i < n; i++)
        //    {
        //        k[i] = (float)Math.Pow((1 - t), n - 1 - i) * (float)Math.Pow(t,i) * _pascal[i];
        //        p.X += k[i] * _vertices[i * 3];
        //        p.Y += k[i] * _vertices[i * 3 + 1];
        //    }
        //    return p;
        //}

        //public bool getVerticesLength()
        //{
        //    if (_vertices[0] == 0)
        //    {
        //        return false;
        //    } 
        //    if ((_vertices.Length + 1 / 3) > 0)
        //    {
        //        return true;
        //    } else
        //    {
        //        return false;
        //    }
        //}

        //public void setVertices(float[] vertices)
        //{
        //    _vertices = vertices;
        //}
    }
}