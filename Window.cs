﻿//using LearnOpenTK.Common;
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
        Asset3d[] envTool = new Asset3d[10];
        Asset3d _environment;
        Asset3d cam = new Asset3d();
        Asset3d doraemon = new Asset3d();
        Camera _camera;
        Asset3d eyes2 = new Asset3d();
        Asset3d eyes3 = new Asset3d();
        Asset3d tong = new Asset3d();





        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0.0f, 0.0f, 0.0f);
        float _rotationSpeed = 1f;

        float degree = 0;
        double _time = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

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


        public void makeEnvironment()
        {
            envTool[0] = new Asset3d();
            _environment = new Asset3d();
            tong = new Asset3d();

            //Base
            envTool[0] = new Asset3d();
            envTool[0].createEllipsoid2(10.0f, 0.0f, 10.0f, 0.0f, -0.95f, 0.0f, 300, 100);
            envTool[0].setColor(new Vector3(11, 102, 35));
            _environment.addChildClass(envTool[0]);

            //Base2
            envTool[1] = new Asset3d();
            envTool[1].createEllipsoid2(2.0f, 0.0f, 2.0f, 1.0f, -0.94f, -3.0f, 300, 100);
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
            makeEnvironment();

            doraemon.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            _environment.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);

            cam.addChildClass(doraemon);
            cam.addChildClass(_environment);


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
            _environment.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            animateDoraemon();
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