//using LearnOpenTK.Common;
//using OpenTK.Graphics.ES11;
//using OpenTK.Graphics.OpenGL4;
//using OpenTK.Windowing.Common;
//using OpenTK.Windowing.Desktop;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClearBufferMask = OpenTK.Graphics.OpenGL4.ClearBufferMask;
//using GetPName = OpenTK.Graphics.OpenGL4.GetPName;
//using GL = OpenTK.Graphics.OpenGL4.GL;
//using VertexAttribPointerType = OpenTK.Graphics.OpenGL4.VertexAttribPointerType;
using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Pertemuan1
{

    static class Constant
    {
        public const string PATH = "../../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        //Doraemon Stuff
        Asset3d[] _object3d = new Asset3d[20];
        Asset3d body;
        Asset3d main_head;
        Asset3d right_hand;
        Asset3d left_hand;
        Asset3d right_foot;
        Asset3d left_foot;
        Asset3d baling;
        Asset3d balingAtas;
        Asset3d[] envTool = new Asset3d[11];
        Asset3d _environment;
        Asset3d cam = new Asset3d();
        Asset3d doraemon = new Asset3d();
        Camera _camera;
        Asset3d eyes2 = new Asset3d();
        Asset3d eyes3 = new Asset3d();
        Asset3d tong = new Asset3d();


        //Pawaemon Stuff
        Asset3d[] _object3dPawaemon = new Asset3d[20];
        Asset3d bodyPawaemon;
        Asset3d main_head_pawaemon;
        Asset3d cone;
        Asset3d right_hand_pawaemon;
        Asset3d left_hand_pawaemon;
        Asset3d right_foot_pawaemon;
        Asset3d left_foot_pawaemon;
        Asset3d cape_pawaemon;
        Asset3d pawaemon = new Asset3d();

        //Dorami Stuff
        Asset3d[] _object3dDorami = new Asset3d[20];
        Asset3d bodyDorami;
        Asset3d main_headDorami;
        Asset3d right_handDorami;
        Asset3d left_handDorami;
        Asset3d right_footDorami;
        Asset3d left_footDorami;
        Asset3d dorami = new Asset3d();



        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0.0f, 0.0f, 0.0f);
        float _rotationSpeed = 1f;

        float degree = 0;
        double _time = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        Asset3d[] sakura = new Asset3d[10];
        public Asset3d makeSakura(float x = 0, float y = 0, float z = 0)
        {
            Asset3d sakura = new Asset3d();
            int scale = 5;
            Asset3d branch = new Asset3d();
            branch.EllipPara(0.001f * scale, 0.001f * scale, 0.007f * scale, 0, 0, 0);
            branch.setColor(new Vector3(70, 50, 15));
            branch.rotate(sakura._center, branch._euler[0], 90);
            sakura.addChildClass(branch);

            branch = new Asset3d();                               //y  //x  
            branch.EllipPara(0.0008f * scale, 0.0008f * scale, 0.007f / 3f * scale, 0f, -0.1f * scale, -0.12f * scale);
            branch.setColor(new Vector3(70, 50, 15));
            branch.rotate(sakura._center, branch._euler[0], 50);
            sakura.addChildClass(branch);

            branch = new Asset3d();
            branch.EllipPara(0.0008f * scale, 0.0008f * scale, 0.007f / 3f * scale, 0f, 0.17f * scale, -0.09f * scale);
            branch.setColor(new Vector3(70, 50, 15));
            branch.rotate(sakura._center, branch._euler[0], 140);
            sakura.addChildClass(branch);

            branch = new Asset3d();                               //y  //x  
            branch.EllipPara(0.0008f * scale, 0.0008f * scale, 0.007f / 3f * scale, 0f, -0.18f * scale, -0.03f * scale);
            branch.setColor(new Vector3(70, 50, 15));
            branch.rotate(sakura._center, branch._euler[0], 50);
            sakura.addChildClass(branch);

            branch = new Asset3d();
            branch.EllipPara(0.0008f * scale, 0.0008f * scale, 0.007f / 3f * scale, 0f * scale, 0.07f * scale, -0.18f * scale);
            branch.setColor(new Vector3(70, 50, 15));
            branch.rotate(sakura._center, branch._euler[0], 140);
            sakura.addChildClass(branch);

            //bunga kanan

            Asset3d flower;

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, 0.05f * scale, 0.18f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, 0.01f * scale, 0.13f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, -0.03f * scale, 0.08f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, -0.07f * scale, 0.03f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            //bunga kiri

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, 0.02f * scale, (-0.13f - 0.02f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.03f - 0.02f) * scale, (-0.08f - 0.01f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.07f - 0.04f) * scale, (-0.03f - 0.01f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            //bunga kanan bawah

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (0.05f - 0.12f) * scale, 0.18f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (0.01f - 0.12f) * scale, 0.13f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.03f - 0.12f) * scale, 0.08f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.07f - 0.12f) * scale, 0.03f * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);
            //bunga kiri bawah

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (0.02f - 0.12f) * scale, (-0.13f - 0.02f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.03f - 0.02f - 0.12f) * scale, (-0.08f - 0.01f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            flower = new Asset3d();
            flower.createEllipsoid2(0.1f / 6f * scale, 0.1f / 6f * scale, 0.1f / 6f * scale, 0, (-0.07f - 0.04f - 0.12f) * scale, (-0.03f - 0.01f) * scale, 300, 100);
            flower.setColor(new Vector3(255, 143, 244));
            sakura.addChildClass(flower);

            sakura.rotate(sakura._center, sakura._euler[1], 90);

            sakura.translateObject2(x, 0.67f + y, z);

            return sakura;
        }
        private void loadSakura()
        {
            for (int i = 0; i < sakura.Length; i++)
            {
                if (sakura[i] != null)
                {
                    sakura[i].load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
                    cam.addChildClass(sakura[i]);
                }
            }
        }
        private void renderSakura(Matrix4 temp)
        {
            for (int i = 0; i < sakura.Length; i++)
            {
                if (sakura[i] != null)
                {
                    sakura[i].render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                }
            }
        }
        public void makeBody()
        {
            //Ganti Background
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            _object3d[0] = new Asset3d();
            body = new Asset3d();

            //Badan
            _object3d[0] = new Asset3d();
            _object3d[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3d[0].setColor(new Vector3(0, 0, 255));
            body.addChildClass(_object3d[0]);

            //Outline bg kantong
            _object3d[1] = new Asset3d();
            _object3d[1].createEllipsoid2(0.43f, 0.41f, 0.30f, 0.0f, 0.0f, 0.2f, 300, 100);
            _object3d[1].setColor(new Vector3(0, 0, 0));
            body.addChildClass(_object3d[1]);

            //bg kantong
            _object3d[2] = new Asset3d();
            _object3d[2].createEllipsoid2(0.40f, 0.38f, 0.25f, 0.0f, 0.0f, 0.26f, 300, 100);
            _object3d[2].setColor(new Vector3(255, 255, 255));
            body.addChildClass(_object3d[2]);

            //Outline Kantong
            _object3d[3] = new Asset3d();
            _object3d[3].createHalfBall(0.3f, 0.3f, 0.0f, 0.0f, -0.05f, 0.51f, 800, 2000);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[0], 0);
            _object3d[3].setColor(new Vector3(0, 0, 0));
            body.addChildClass(_object3d[3]);

            //kantong
            _object3d[4] = new Asset3d();
            _object3d[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.04f, 0.52f, 800, 2000);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[0], 0);
            _object3d[4].setColor(new Vector3(255, 255, 255));
            body.addChildClass(_object3d[4]);

            //kalung lonceng
            _object3d[5] = new Asset3d();
            _object3d[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3d[5].setColor(new Vector3(255, 0, 0));
            body.addChildClass(_object3d[5]);


            //bg lonceng
            _object3d[6] = new Asset3d();
            _object3d[6].createEllipsoid2(0.11f, 0.01f, 0.11f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[6].setColor(new Vector3(255, 165, 0));
            body.addChildClass(_object3d[6]);

            //Lonceng
            _object3d[7] = new Asset3d();
            _object3d[7].createEllipsoid2(0.1f, 0.1f, 0.1f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3d[7].setColor(new Vector3(255, 255, 0));
            body.addChildClass(_object3d[7]);

            //Buntut
            _object3d[8] = new Asset3d();
            _object3d[8].EllipCone(0.02f, 0.02f, 0.1f, 0.0f, -0.2f, -0.55f);
            _object3d[8].setColor(new Vector3(0, 0, 0));
            body.addChildClass(_object3d[8]);

            //Bola Buntut
            _object3d[9] = new Asset3d();
            _object3d[9].createEllipsoid2(0.07f, 0.07f, 0.07f, 0.0f, -0.22f, -0.58f, 300, 100);
            _object3d[9].setColor(new Vector3(255, 0, 0));
            body.addChildClass(_object3d[9]);

        }

        public void makeHead()
        {
            main_head = new Asset3d();
            //main_head.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head.setColor(new Vector3(0.0f, 0.0f, 255.0f));

            Asset3d eyes = new Asset3d();
            eyes2 = new Asset3d();
            eyes3 = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, -0.1f, 0.15f, 0.45f, 300, 100);
            eyes.setColor(new Vector3(235.0f, 235.0f, 235.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, 0.1f, 0.15f, 0.45f, 300, 100);
            eyes.setColor(new Vector3(235.0f, 235.0f, 235.0f));
            main_head.addChildClass(eyes);

            eyes2 = new Asset3d();
            eyes2.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.05f, 0.15f, 0.55f, 300, 100);
            eyes2.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes2);

            eyes3 = new Asset3d();
            eyes3.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.05f, 0.15f, 0.55f, 300, 100);
            eyes2.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes3);

            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            Asset3d cheekOutline = new Asset3d();

            cheekOutline.createEllipsoid2(0.38f, 0.34f, 0.15f, 0.0f, 0.0f, 0.33f, 300, 100);
            cheekOutline.setColor(new Vector3(0f, 0f, 0f));
            cheekOutline.rotate(main_head._center, main_head._euler[0], 10);

            cheek.createEllipsoid2(0.35f, 0.30f, 0.15f, 0.0f, -0.05f, 0.4f, 300, 100);
            cheek.setColor(new Vector3(255f, 255f, 255f));



            nose.createEllipsoid2(0.075f, 0.075f, 0.075f, 0.0f, 0.0f, 0.63f, 300, 100);
            nose.setColor(new Vector3(255.0f, 0.0f, 0.0f));

            smile.createHalfBall(0.2f, 0.15f, 0f, 0.0f, -0.2f, 0.6f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_head._center, main_head._euler[2], 180);
            smile.rotate(main_head._center, main_head._euler[0], 35);
            main_head.addChildClass(cheekOutline);
            main_head.addChildClass(smile);
            main_head.addChildClass(cheek);
            main_head.addChildClass(nose);
            Asset3d mustache;
            //Right Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.52f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            mustache.rotate(main_head._center, mustache._euler[0], -15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.15f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            mustache.rotate(main_head._center, mustache._euler[0], 15);
            main_head.addChildClass(mustache);

            //Left Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.49f, -0.12f, 0.13f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            mustache.rotate(main_head._center, mustache._euler[0], 15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.52f, -0.12f, 0.08f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            mustache.rotate(main_head._center, mustache._euler[0], -15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 15f, 0.0014f, 0f, 0.6f, -0.16f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[0], 110);
            main_head.addChildClass(mustache);


        }

        public void makeHand()
        {
            //right hand
            right_hand = new Asset3d();
            right_hand.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, -0.3f, 0.0f, 300, 100);
            right_hand.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(50, 50, 255));
            arm.rotate(right_hand._center, arm._euler[0], 90);
            arm.rotate(right_hand._center, arm._euler[1], 15);
            right_hand.addChildClass(arm);

            //left hand
            left_hand = new Asset3d();
            left_hand.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, -0.3f, 0.0f, 300, 100);
            left_hand.setColor(new Vector3(211, 211, 211));
            //left arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(50, 50, 255));
            arm.rotate(right_hand._center, arm._euler[0], 90);
            arm.rotate(right_hand._center, arm._euler[1], -15);
            left_hand.addChildClass(arm);
        }

        public void makeFoot()
        {
            //right foot
            right_foot = new Asset3d();
            right_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_foot.setColor(new Vector3(211, 211, 211));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(50, 50, 255));
            right_foot.addChildClass(leg);

            //left foot
            left_foot = new Asset3d();
            left_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_foot.setColor(new Vector3(211, 211, 211));
            //left leg
            leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(50, 50, 255));
            right_foot.addChildClass(leg);
        }

        public void makeBodyPawaemon()
        {
            //Ganti Background
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            _object3dPawaemon[0] = new Asset3d();
            bodyPawaemon = new Asset3d();

            //cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.EllipCone2(0.1f, 0.15f, 0.28f, 0f, -0.4f, 0.0f);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            cape_pawaemon.rotate(cape_pawaemon._center, cape_pawaemon._euler[1], 90);
            bodyPawaemon.addChildClass(cape_pawaemon);

            //Circle for cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.createEllipsoid2(0, 0.21f, 0.14f, -0.4f, -0.4f, 0.0f, 300, 100);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(cape_pawaemon);

            //Circle for cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.createEllipsoid2(0, 0.21f, 0.14f, 0.4f, -0.4f, 0.0f, 300, 100);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(cape_pawaemon);


            //Badan
            _object3dPawaemon[0] = new Asset3d();
            _object3dPawaemon[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3dPawaemon[0].setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(_object3dPawaemon[0]);


            //Outline Kantong
            _object3dPawaemon[3] = new Asset3d();
            _object3dPawaemon[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3dPawaemon[3].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[2], 180);
            _object3dPawaemon[3].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], 10);
            _object3dPawaemon[3].setColor(new Vector3(0, 0, 0));
            bodyPawaemon.addChildClass(_object3dPawaemon[3]);

            //kantong
            _object3dPawaemon[4] = new Asset3d();
            _object3dPawaemon[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3dPawaemon[4].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[2], 180);
            _object3dPawaemon[4].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], 15);
            _object3dPawaemon[4].setColor(new Vector3(255, 255, 255));
            bodyPawaemon.addChildClass(_object3dPawaemon[4]);

            //kalung lonceng
            _object3dPawaemon[5] = new Asset3d();
            _object3dPawaemon[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3dPawaemon[5].setColor(new Vector3(240, 57, 96));
            bodyPawaemon.addChildClass(_object3dPawaemon[5]);

            //Hem baju
            _object3dPawaemon[1] = new Asset3d();
                                                    //x   //z   //y
            _object3dPawaemon[1].EllipCone(0.14f, 0.02f, 0.15f, 0f, -0.5f, -0.1f);
            _object3dPawaemon[1].setColor(new Vector3(0, 0, 0));
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], -105);
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 0);

            bodyPawaemon.addChildClass(_object3dPawaemon[1]);

            //Hem baju
            _object3dPawaemon[1] = new Asset3d();
                                                    //x   //z   //y
            _object3dPawaemon[1].EllipCone(0.1f, 0.01f, 0.145f, 0f, -0.51f, -0.05f);
            _object3dPawaemon[1].setColor(new Vector3(255, 255, 255));
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], -100);
            //_object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 25);

            bodyPawaemon.addChildClass(_object3dPawaemon[1]);
            
            //Lonceng
            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].createEllipsoid2(0.03f, 0.03f, 0.03f, 0.0f, 0.3f, 0.55f, 300, 100);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);

            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].EllipCone(0.03f, 0.05f, 0.1f, -0.55f, 0.30f, 0f);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            _object3dPawaemon[7].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 90);
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);

            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].EllipCone(0.03f, 0.05f, 0.1f, 0.55f, 0.30f, 0f);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            _object3dPawaemon[7].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], -90);
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);


        }

        public void makeHeadPawaemon()
        {
            main_head_pawaemon = new Asset3d();
            //main_head_pawaemon.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head_pawaemon.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head_pawaemon.setColor(new Vector3(227, 184, 93));

            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, -0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, 0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head_pawaemon.addChildClass(eyes);
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.23f, 0.05f, 0.0f, 0.05f, 0.44f, 300, 100);
            cheek.setColor(new Vector3(255f, 255f, 255f));
            cheek.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[0], 35);

            nose.createEllipsoid2(0.075f, 0.075f, 0.075f, 0.0f, 0.0f, 0.5f, 300, 100);
            nose.setColor(new Vector3(255.0f, 0.0f, 0.0f));

            smile.createHalfBall(0.2f, 0.15f, 0f, 0.0f, -0.1f, 0.5f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[2], 180);
            smile.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[0], 35);
            main_head_pawaemon.addChildClass(smile);
            main_head_pawaemon.addChildClass(cheek);
            main_head_pawaemon.addChildClass(nose);
            Asset3d mustache;
            //Right Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.52f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], -15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.15f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 15);
            main_head_pawaemon.addChildClass(mustache);

            //Left Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.49f, -0.12f, 0.13f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.52f, -0.12f, 0.08f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], -15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 15f, 0.0014f, 0f, 0.53f, -0.115f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 110);
            main_head_pawaemon.addChildClass(mustache);

            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 90);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], 15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head_pawaemon.addChildClass(ears);
            //left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 90);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], -15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head_pawaemon.addChildClass(ears);

            //inner left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, -0.1f, -0.58f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 70);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], -15);
            ears.rotate(main_head_pawaemon._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head_pawaemon.addChildClass(ears);
            //inner left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, 0.1f, -0.58f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 70);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], 15);
            ears.rotate(main_head_pawaemon._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head_pawaemon.addChildClass(ears);
        }

        public void makeHandPawaemon()
        {
            //right hand
            right_hand_pawaemon = new Asset3d();
            right_hand_pawaemon.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, 0, 0.3f, 300, 100);
            right_hand_pawaemon.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 0);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], 15);
            right_hand_pawaemon.addChildClass(arm);

            arm = new Asset3d();
            arm.EllipPara(0.013f, 0.013f, 0.0035f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(44, 74, 91));
            //arm.rotate(right_hand_pawaemon._center, arm._euler[0], 90);
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 0);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], 15);
            right_hand_pawaemon.addChildClass(arm);


            //left_pawaemon arm
            left_hand_pawaemon = new Asset3d();
            left_hand_pawaemon.EllipPara(0.011f, 0.011f, 0.0035f, -0.45f, 0f, 0f);
            left_hand_pawaemon.setColor(new Vector3(44, 74, 91));
            //left_hand_pawaemon.rotate(right_hand_pawaemon._center, left_hand_pawaemon._euler[0], 90);
            left_hand_pawaemon.rotate(left_hand_pawaemon._center, left_hand_pawaemon._euler[0], 270);
            left_hand_pawaemon.rotate(left_hand_pawaemon._center, left_hand_pawaemon._euler[1], -15);

            //left_pawaemon arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 270);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], -15);
            left_hand_pawaemon.addChildClass(arm);

            //left_pawaemon hand
            arm = new Asset3d();
            arm.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, 0.3f, 0.0f, 300, 100);
            arm.setColor(new Vector3(211, 211, 211));
            left_hand_pawaemon.addChildClass(arm);
        }

        public void makeFootPawaemon()
        {
            //right foot
            right_foot_pawaemon = new Asset3d();
            right_foot_pawaemon.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_foot_pawaemon.setColor(new Vector3(56, 60, 61));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            right_foot_pawaemon.addChildClass(leg);

            //left_pawaemon foot
            left_foot_pawaemon = new Asset3d();
            left_foot_pawaemon.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_foot_pawaemon.setColor(new Vector3(56, 60, 61));
            //left_pawaemon leg
            leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            left_foot_pawaemon.addChildClass(leg);
        }

        public void makePawaemon()
        {
            makeFootPawaemon();
            makeHeadPawaemon();
            makeBodyPawaemon();
            makeHandPawaemon();

            main_head_pawaemon.translateObject2(0, 0.7f, 0);
            bodyPawaemon.translateObject2(0, -0.15f, 0);
            main_head_pawaemon.translateObject2(2, -0.15f, 0);
            bodyPawaemon.translateObject2(2, 0, 0);
            right_hand_pawaemon.translateObject2(2, 0, 0);
            left_hand_pawaemon.translateObject2(2, 0, 0);
            right_foot_pawaemon.translateObject2(2, 0, 0);
            left_foot_pawaemon.translateObject2(2, 0, 0);

            pawaemon.addChildClass(main_head_pawaemon);
            pawaemon.addChildClass(bodyPawaemon);
            pawaemon.addChildClass(right_hand_pawaemon);
            pawaemon.addChildClass(left_hand_pawaemon);
            pawaemon.addChildClass(right_foot_pawaemon);
            pawaemon.addChildClass(left_foot_pawaemon);
        }

        public void makebodyDorami()
        {
            //Ganti Background
            GL.ClearColor(0f, 0f, 0f, 1.0f);
            _object3dDorami[0] = new Asset3d();
            bodyDorami = new Asset3d();

            //Badan
            _object3dDorami[0] = new Asset3d();
            _object3dDorami[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3dDorami[0].setColor(new Vector3(255, 228, 59));
            bodyDorami.addChildClass(_object3dDorami[0]);

            //Outline Kantong
            _object3dDorami[3] = new Asset3d();
            _object3dDorami[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3dDorami[3].rotate(_object3dDorami[0]._center, _object3dDorami[0]._euler[2], 180);
            _object3dDorami[3].rotate(_object3dDorami[0]._center, _object3dDorami[0]._euler[0], 10);
            _object3dDorami[3].setColor(new Vector3(0, 0, 0));
            bodyDorami.addChildClass(_object3dDorami[3]);

            //kantong
            _object3dDorami[4] = new Asset3d();
            _object3dDorami[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3dDorami[4].rotate(_object3dDorami[0]._center, _object3dDorami[0]._euler[2], 180);
            _object3dDorami[4].rotate(_object3dDorami[0]._center, _object3dDorami[0]._euler[0], 15);
            _object3dDorami[4].setColor(new Vector3(255, 255, 255));
            bodyDorami.addChildClass(_object3dDorami[4]);

            //kalung lonceng
            _object3dDorami[5] = new Asset3d();
            _object3dDorami[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3dDorami[5].setColor(new Vector3(2, 160, 231));
            bodyDorami.addChildClass(_object3dDorami[5]);


            //bg lonceng
            _object3dDorami[6] = new Asset3d();
            _object3dDorami[6].createEllipsoid2(0.11f, 0.01f, 0.11f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3dDorami[6].setColor(new Vector3(255, 165, 0));
            bodyDorami.addChildClass(_object3dDorami[6]);

            //Lonceng
            _object3dDorami[7] = new Asset3d();
            _object3dDorami[7].createEllipsoid2(0.1f, 0.1f, 0.1f, 0.0f, 0.19f, 0.55f, 300, 100);
            _object3dDorami[7].setColor(new Vector3(255, 255, 0));
            bodyDorami.addChildClass(_object3dDorami[7]);
        }

        public void makeHeadDorami()
        {
            main_headDorami = new Asset3d();
            //main_headDorami.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_headDorami.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_headDorami.setColor(new Vector3(253, 229, 63));

            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.12f, 0.1f, -0.15f, 0.02f, 0.43f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_headDorami.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.12f, 0.1f, 0.15f, 0.02f, 0.43f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_headDorami.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.15f, 0f, 0.53f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_headDorami.addChildClass(eyes);


            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.15f, 0f, 0.53f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_headDorami.addChildClass(eyes);
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.3f, 0.1f, 0.0f, -0.05f, 0.42f, 300, 100);
            cheek.setColor(new Vector3(240f, 240f, 240f));

            nose.createEllipsoid2(0.055f, 0.035f, 0.055f, 0.0f, -0.1f, 0.48f, 300, 100);
            nose.setColor(new Vector3(251, 207, 208));

            smile.createHalfBall(0.1f, 0.12f, 0f, 0.0f, 0.01f, 0.545f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_headDorami._center, main_headDorami._euler[2], 180);
            smile.rotate(main_headDorami._center, main_headDorami._euler[0], 15);
            main_headDorami.addChildClass(smile);
            main_headDorami.addChildClass(cheek);
            main_headDorami.addChildClass(nose);
            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_headDorami._center, ears._euler[0], 90);
            ears.rotate(main_headDorami._center, ears._euler[1], 15);
            ears.setColor(new Vector3(225, 0, 42));
            main_headDorami.addChildClass(ears);
            //left ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_headDorami._center, ears._euler[0], 90);
            ears.rotate(main_headDorami._center, ears._euler[1], -15);
            ears.setColor(new Vector3(225, 0, 42));
            main_headDorami.addChildClass(ears);
        }

        public void makeHandDorami()
        {
            //right hand
            right_handDorami = new Asset3d();
            right_handDorami.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, 0.3f, 0f, 300, 100);
            right_handDorami.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(right_handDorami._center, arm._euler[0], 270);
            arm.rotate(right_handDorami._center, arm._euler[1], 15);
            right_handDorami.addChildClass(arm);

            //left hand
            left_handDorami = new Asset3d();
            left_handDorami.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, 0.3f, 0.0f, 300, 100);
            left_handDorami.setColor(new Vector3(211, 211, 211));
            //left arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(255, 200, 59));
            arm.rotate(left_handDorami._center, arm._euler[0], 270);
            arm.rotate(left_handDorami._center, arm._euler[1], -15);
            left_handDorami.addChildClass(arm);
        }

        public void makeFootDorami()
        {
            //right foot
            right_footDorami = new Asset3d();
            right_footDorami.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_footDorami.setColor(new Vector3(211, 211, 211));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            right_footDorami.addChildClass(leg);

            //left foot
            left_footDorami = new Asset3d();
            left_footDorami.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_footDorami.setColor(new Vector3(211, 211, 211));
            //left leg
            leg = new Asset3d();
            leg.createHalfBall(0.15f, 0.4f, 0.15f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(255, 200, 59));
            left_footDorami.addChildClass(leg);
        }

        public void makeDorami()
        {
            makeHeadDorami();
            makebodyDorami();
            makeHandDorami();
            makeFootDorami();

            main_headDorami.translateObject2(-2f, 0.5f, 0);
            bodyDorami.translateObject2(-2f, -0.15f, 0);
            right_handDorami.translateObject2(-2f, 0, 0);
            left_handDorami.translateObject2(-2f, -0.1f, 0);
            right_footDorami.translateObject2(-2f, 0, 0);
            left_footDorami.translateObject2(-2f, 0, 0);

            dorami.addChildClass(main_headDorami);
            dorami.addChildClass(bodyDorami);
            dorami.addChildClass(right_handDorami);
            dorami.addChildClass(left_handDorami);
            dorami.addChildClass(right_footDorami);
            dorami.addChildClass(left_footDorami);

        }
        public void makeEnvironment()
        {
            envTool[0] = new Asset3d();
            _environment = new Asset3d();
            tong = new Asset3d();

            //Base
            envTool[0] = new Asset3d();
            envTool[0].createEllipsoid2(8.0f, 0.0f, 8.0f, 0.0f, -0.95f, -1.5f, 300, 100);
            envTool[0].setColor(new Vector3(0, 191, 6));
            _environment.addChildClass(envTool[0]);

            //Base2
            envTool[1] = new Asset3d();
            envTool[1].createEllipsoid2(2.0f, 0.0f, 2.0f, 1.3f, -0.94f, 3.0f, 300, 100);
            envTool[1].setColor(new Vector3(128, 97, 51));
            _environment.addChildClass(envTool[1]);

            //TONG
            envTool[2] = new Asset3d();
            envTool[2].createCylinder(0, -0.45f, -2.5f, 0.5f, 4);
            envTool[2].setColor(new Vector3(128, 128, 128));
            envTool[2].rotate(envTool[2]._center, envTool[2]._euler[0], 90);
            envTool[2].rotate(envTool[2]._center, envTool[2]._euler[2], 90);
            _environment.addChildClass(envTool[2]);
            tong.addChildClass(envTool[2]);

            //TONG2
            envTool[3] = new Asset3d();
            envTool[3].createCylinder(0, -0.45f, -3.5f, 0.5f, 4);
            envTool[3].setColor(new Vector3(211, 211, 211));
            envTool[3].rotate(envTool[3]._center, envTool[3]._euler[0], 90);
            envTool[3].rotate(envTool[3]._center, envTool[3]._euler[2], 90);
            _environment.addChildClass(envTool[3]);
            tong.addChildClass(envTool[3]);

            //TONG3
            envTool[4] = new Asset3d();
            envTool[4].createCylinder(0, 0.42f, -3.0f, 0.5f, 4);
            envTool[4].setColor(new Vector3(169, 169, 169));
            envTool[4].rotate(envTool[4]._center, envTool[4]._euler[0], 90);
            envTool[4].rotate(envTool[4]._center, envTool[4]._euler[2], 90);
            _environment.addChildClass(envTool[4]);
            tong.addChildClass(envTool[4]);

            tong.rotate(tong._center, tong._euler[1], 70);
            tong.translateObject2(-1, 0, 0);

            //Bulan
            envTool[5] = new Asset3d();
            envTool[5].createEllipsoid2(15.0f, 15.0f, 15.0f, 0.0f, 5.0f, -30.0f, 300, 100);
            envTool[5].setColor(new Vector3(255, 255, 0));
            _environment.addChildClass(envTool[5]);


            //Cone
            envTool[6] = new Asset3d();                     
            envTool[6].EllipCone(0.5f, 0.5f, 1.0f, 0, -5, -0.7f);//X//z//Y
            envTool[6].setColor(new Vector3(250, 0, 0));
            envTool[6].rotate(envTool[6]._center, envTool[6]._euler[0], 90);
            _environment.addChildClass(envTool[6]);


            //Cone
            envTool[7] = new Asset3d();
            envTool[7].EllipCone(0.5f, 0.5f, 1.0f, 5, 0, -0.7f);//X//z//Y
            envTool[7].setColor(new Vector3(250, 0, 0));
            envTool[7].rotate(envTool[7]._center, envTool[7]._euler[0], 90);
            _environment.addChildClass(envTool[7]);

            //Cone
            envTool[8] = new Asset3d();
            envTool[8].EllipPara(0.01f, 0.01f, 0.07f, 3.5f, 0.5f, -3.5f);
            envTool[8].setColor(new Vector3(0, 0, 0));
            envTool[8].rotate(envTool[8]._center, envTool[8]._euler[1], 45);
            _environment.addChildClass(envTool[8]);

            //Base
            envTool[9] = new Asset3d();
            envTool[9].createEllipsoid2(30.0f, 0.0f, 30.0f, 0.0f, -0.96f, -1.5f, 300, 100);
            envTool[9].setColor(new Vector3(43, 160, 255));
            _environment.addChildClass(envTool[9]);



            _environment.translateObject(0.1f);

        }

        public void makeBaling()
        {
            baling = new Asset3d();
            balingAtas = new Asset3d();
            balingAtas.EllipCone2(0.02f, 0.02f, 0.12f, 0, 1.11f, 0);
            balingAtas.setColor(new Vector3(254, 230, 168));
            baling.addChildClass(balingAtas);

            Asset3d balingBawah = new Asset3d();
            balingBawah.EllipCone(0.02f, 0.02f, 0.1f, 0, 0, -1.1f);
            balingBawah.setColor(new Vector3(254, 230, 168));
            balingBawah.rotate(main_head._center, main_head._euler[0], 90);
            baling.addChildClass(balingBawah);
        }

        bool inc = true;
        float translate = 0;
        float totalTrans = 1;
        float trans = 0.01f;

        bool plus = true;
        float rotate = 0;
        float totalRot = 30;
        float rotDeg = 0.3f;
        int left = 1;
        bool[] leftNoleh = { true, false };

        bool inc2 = true;
        float translate2 = 0;
        float totalTrans2 = 0.05f;
        float trans2 = 0.001f;

        //bool plus2 = true;
        //float rotate2 = 0;
        //float totalRot2 = 0.2f;
        //float rotDeg2 = 0.01f;
        //int left2 = 1;
        //bool[] leftNoleh2 = { true, false };

        public void animateDoraemon()
        {
        //TERBANG
            //condition of moving animation for positive degree
            if (translate >= 0 && translate < totalTrans)
            {
                inc = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate is equal to total rotation (totalRot)
                if (inc)
                {
                    translate = -0.01f;
                }

                if (translate > (-1 * totalTrans - 0.01))
                {
                    inc = false;
                }
                else
                {
                    translate = 0;
                    inc = true;
                }
            }
            if (inc)
            {
                main_head.translateObject(trans);
                body.translateObject(trans);
                right_hand.translateObject(trans);
                left_hand.translateObject(trans);
                right_foot.translateObject(trans);
                left_foot.translateObject(trans);
                baling.translateObject(trans);
                translate += trans;

            }
            else
            {
                main_head.translateObject(trans*-1);
                body.translateObject(trans * -1);
                right_hand.translateObject(trans * -1);
                left_hand.translateObject(trans * -1);
                right_foot.translateObject(trans * -1);
                left_foot.translateObject(trans * -1);
                baling.translateObject(trans * -1);
                translate -= trans;
            }

            //Baling
            balingAtas.rotate(balingAtas._center, balingAtas._euler[1], 50);

            //Kepala
            if (rotate >= 0 && rotate < totalRot)
            {
                plus = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate is equal to total rotation (totalRot)
                if (plus)
                {
                    rotate = -0.3f;
                }

                if (rotate > (-1 * totalRot - 0.3f))
                {
                    plus = false;
                }
                else
                {
                    rotate = 0;
                    plus = true;
                    if (left == 1)
                    {
                        left = 0;
                    }
                    else
                    {
                        left = 1;
                    }

                }
            }
            if (plus)
            {
                //doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg);
                if (leftNoleh[left])
                {
                    doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg * 1);
                }
                else
                {
                    doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg * -1);
                }
                rotate += rotDeg;

            }
            else
            {
                //doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg*-1);
                if (leftNoleh[left])
                {
                    doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg * -1);
                }
                else
                {
                    doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg * 1);
                }
                rotate -= rotDeg;
            }

            //MATA
            if (translate2 >= 0 && translate2 < totalTrans2)
            {
                inc2 = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate is equal to total rotation (totalRot)
                if (inc2)
                {
                    translate2 = -0.01f;
                }

                if (translate2 > (-1 * totalTrans2 - 0.01))
                {
                    inc2 = false;
                }
                else
                {
                    translate2 = 0;
                    inc2 = true;
                }
            }
            if (inc2)
            {
                eyes2.translateObject(trans2);
                eyes3.translateObject(trans2);
                translate2 += trans2;


            }
            else
            {
                eyes2.translateObject(trans2*-1);
                eyes3.translateObject(trans2*-1);
                translate2 -= trans2;
            }


        ////TANGAN
        //if (rotate2 >= 0 && rotate2 < totalRot2)
        //    {
        //        plus2 = true;
        //    }
        //    //condition of moving animation for negative degree
        //    else
        //    {
        //        //first checking after rotate is equal to total rotation (totalRot)
        //        if (plus2)
        //        {
        //            rotate2 = -0.1f;
        //        }

        //        if (rotate2 > (-1 * totalRot2 - 0.1f))
        //        {
        //            plus2 = false;
        //        }
        //        else
        //        {
        //            rotate2 = 0;
        //            plus2 = true;
        //            if (left2 == 1)
        //            {
        //                left2 = 0;
        //            }
        //            else
        //            {
        //                left2 = 1;
        //            }

        //        }
        //    }
        //    if (plus2)
        //    {
        //        //doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg);
        //        if (leftNoleh2[left])
        //        {
        //            right_hand.rotate(doraemon._center, doraemon._euler[2]*-1, rotDeg);
        //        }
        //        else
        //        {
        //            right_hand.rotate(doraemon._center, doraemon._euler[2] * -1, rotDeg*-1);
        //        }
        //        rotate2 += rotDeg2;

        //    }
        //    else
        //    {
        //        //doraemon.Child[0].rotate(doraemon.Child[0]._center, doraemon.Child[0]._euler[1], rotDeg*-1);
        //        if (leftNoleh2[left])
        //        {
        //            right_hand.rotate(doraemon._center, doraemon._euler[2] * -1, rotDeg * -1);
        //        }
        //        else
        //        {
        //            right_hand.rotate(doraemon._center, doraemon._euler[2] * -1, rotDeg);
        //        }
        //        rotate2 -= rotDeg2;
        //    }


        }
        bool plus_pawaemon = true;
        float rotate_pawaemon = 0;
        float totalRotPawaemon = 10;
        float rotDegPawaemon = 1;
        int left_pawaemon = 1;
        bool[] leftFootPawaemon = { true, false };

        private void animatePawaemon()
        {
            //condition of moving animation for positive degree
            if (rotate_pawaemon >= 0 && rotate_pawaemon < totalRotPawaemon)
            {
                plus_pawaemon = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate_pawaemon is equal to total rotation (totalRotPawaemon)
                if (plus_pawaemon)
                {
                    rotate_pawaemon = -1;
                }

                //-1 > -30 or -2 > -30 or -3 > -30 and until -30 == -30
                if (rotate_pawaemon > (-1 * totalRotPawaemon - 1))
                {
                    plus_pawaemon = false;
                }
                //switching movement back to positive degree condition
                else
                {
                    rotate_pawaemon = 0;
                    plus_pawaemon = true;
                    if (left_pawaemon == 1)
                    {
                        left_pawaemon = 0;
                    }
                    else
                    {
                        left_pawaemon = 1;
                    }
                }
            }
            if (plus_pawaemon)
            {

                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[1], rotDegPawaemon / 3 * -1);

                pawaemon.Child[2].rotate(pawaemon.Child[2]._center, pawaemon.Child[2]._euler[1], rotDegPawaemon / 3 * -1);
                if (leftFootPawaemon[left_pawaemon])
                {
                    pawaemon.Child[5].rotate(pawaemon.Child[5]._center, pawaemon.Child[5]._euler[0], rotDegPawaemon * -2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4);
                }
                else
                {
                    pawaemon.Child[4].rotate(pawaemon.Child[4]._center, pawaemon.Child[4]._euler[0], rotDegPawaemon * -2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4 * -1);
                }
                rotate_pawaemon += rotDegPawaemon;
            }
            else
            {
                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[1], rotDegPawaemon / 3 * 1);
                pawaemon.Child[2].rotate(pawaemon.Child[2]._center, pawaemon.Child[2]._euler[1], rotDegPawaemon / 3);
                if (leftFootPawaemon[left_pawaemon])
                {
                    pawaemon.Child[5].rotate(pawaemon.Child[5]._center, pawaemon.Child[5]._euler[0], rotDegPawaemon * 2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4 * -1);
                }
                else
                {
                    pawaemon.Child[4].rotate(pawaemon.Child[4]._center, pawaemon.Child[4]._euler[0], rotDegPawaemon * 2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4);
                }
                rotate_pawaemon -= rotDegPawaemon;
            }
        }
        bool plus_dorami = true;
        float rotate_dorami = 0;
        float rotdeg_dorami = 1;
        float totalRot_dorami = 10;

        public void animateDorami()
        {
            if (rotate_dorami >= 0 && rotate_dorami < totalRot_dorami)
            {
                plus_dorami = true;
            }
            else
            {
                //first checking after rotate_dorami is equal to total rotation (totalRot)
                if (plus_dorami)
                {
                    rotate_dorami = -1;
                }

                if (rotate_dorami > (-1 * totalRot_dorami - 1))
                {
                    plus_dorami = false;
                }
                else
                {
                    rotate_dorami = 0;
                    plus_dorami = true;
                }
            }
            if (plus_dorami)
            {
                dorami.Child[2].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami * -1);
                dorami.Child[3].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami * -1);
                rotate_dorami += rotdeg_dorami;
            }
            else
            {
                dorami.Child[2].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami);
                dorami.Child[3].rotate(dorami._center, dorami.Child[2]._euler[2], rotdeg_dorami);
                rotate_dorami -= rotdeg_dorami;
            }
        }


        public void makeDoraemon() 
        {
            makeHead();
            makeBody();
            makeHand();
            makeFoot();
            makeBaling();
            


            //cam.addChildClass(main_head);
            //cam.addChildClass(body);
            //cam.addChildClass(right_hand);
            //cam.addChildClass(left_hand);
            //cam.addChildClass(right_foot);
            //cam.addChildClass(left_foot);
            //cam.addChildClass(baling);

            main_head.translateObject(0.5f);
            body.translateObject(-0.15f);


            doraemon.addChildClass(main_head);
            doraemon.addChildClass(body);
            doraemon.addChildClass(right_hand);
            doraemon.addChildClass(left_hand);
            doraemon.addChildClass(right_foot);
            doraemon.addChildClass(left_foot);
            doraemon.addChildClass(baling);





        }


        protected override void OnLoad()
        {
            base.OnLoad();


           
            makeDoraemon();
            makePawaemon();
            makeDorami();
            makeEnvironment();
            sakura[0] = makeSakura(2,2,5);
            sakura[1] = makeSakura(-2, 2, -3);//Belakang
            sakura[2] = makeSakura(-3.5f, 2, 2.5f);//Depan sendiri


            doraemon.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            pawaemon.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            dorami.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            _environment.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);

            cam.addChildClass(doraemon);
            cam.addChildClass(pawaemon);
            cam.addChildClass(dorami);
            cam.addChildClass(_environment);

            loadSakura();

            GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
            Console.WriteLine($"Maximum number of vertex attributes supported : {maxAttributeCount}");
            _camera = new Camera(new Vector3(0, 0, 1), Size.X / Size.Y);
            //CursorGrabbed = true;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            //main_head.rotate(main_head._center, main_head._euler[1], 1);
            //smile.rotate(main_head._center, main_head._euler[2], 180);
            doraemon.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            pawaemon.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            dorami.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _environment.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            renderSakura(temp);



            animateDoraemon();
            animatePawaemon();
            animateDorami();
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }


        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyReleased(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
            {
                Console.Write("Hello \n");
            }
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                cam.rotate(cam._center, cam._euler[0], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                cam.rotate(cam._center, cam._euler[0], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                cam.rotate(cam._center, cam._euler[1], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                cam.rotate(cam._center, cam._euler[1], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Q))
            {
                cam.rotate(cam._center, cam._euler[2], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.E))
            {
                cam.rotate(cam._center, cam._euler[2], 5);
            }
            float cameraSpeed = 0.5f;
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }
            var mouse = MouseState;
            var sensitivity = 0.2f;
            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position
                    - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
        }


        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {

            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                float _x, _y;
                _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                _y = (MousePosition.Y - Size.Y / 2) / (Size.Y / 2) * -1;

                Console.WriteLine("x = " + _x + " y = " + _y + "\n");
                //_object[3].updateMousePosition(_x, _y, 0);
            }
        }
    }
}