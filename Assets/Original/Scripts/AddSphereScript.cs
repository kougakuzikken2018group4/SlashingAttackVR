using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSphereScript : MonoBehaviour {

    public Transform playerTransform;
    public UnityEngine.Object enemy;
    public float timeOut;
    private float timeElapsed;
    private float x, y, z, a, r, angle;
    public int aMin, aMax;
    public int rMin, rMax;
    public int yMin, yMax;
    Vector3 localPos;
    System.Random random = new System.Random();


    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            //乱数作成
            a = random.Next(aMin, aMax); //0~360
            r = random.Next(rMin, rMax); //半径
            y = random.Next(yMin, yMax); //高さ

            //座標計算
            angle = (float)Math.PI * a / 180.0f;
            x = r * (float)Math.Cos(angle);
            z = r * (float)Math.Sin(angle);


            //プレイヤーの位置に加算
            localPos = playerTransform.localPosition;
            localPos.x += x;
            localPos.z += z;
            localPos.y = y;

            Instantiate(enemy, localPos, transform.rotation);

            timeElapsed = 0.0f;
        }
    }
}
