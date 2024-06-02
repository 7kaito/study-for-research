using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera; //カメラの座標を変える
    public float PlayerSpeed; //進むスピードを変える
    public float RotationSpeed; //回転スピードを変える

    Vector3 speed = Vector3.zero; //3次元の値を一回作った
    Vector3 rotation = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        Move(); //Updateでこれが呼ばれる
        Rotation();
        Camera.transform.position = transform.position; //カメラが自分を追跡
    }

    void Move()
    {
        speed = Vector3.zero;
        rotation = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            rotation.y = 0;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotation.y = 180;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation.y = 90;
            MoveSet();
        }
        transform.Translate(speed); //自分の向いている方向に進む
    }

    void MoveSet()
    {
        speed.z = PlayerSpeed; //z軸にスピードをつける(最初は0,0,0の値が設定されている)
        transform.eulerAngles = Camera.transform.eulerAngles + rotation; //カメラの向いている方向と設定した値の方向を向く
    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow)) //矢印キーを押すと{}内の処理が実行される
        {
            speed.y = -RotationSpeed; 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = RotationSpeed;
        }
        Camera.transform.eulerAngles += speed; //自分の回転に加算
    }
}
