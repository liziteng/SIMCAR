﻿using UnityEngine;

public class SteerWheelAngelReset : MonoBehaviour
{
    //这个脚本控制方向盘回转，放在“方向盘”物体上
<<<<<<< HEAD
    public float steerTurnedAngele;
    private int speed = 200;
=======
    // public float steerTurnedAngele;
    private int speed = 300;
>>>>>>> qwe
    private SteerWheelRotation steer;
    // private Vector3 startAngel;//待定用不用
    private Quaternion startQua;//待定用不用

    private void Start()
    {
        steer = GetComponent<SteerWheelRotation>();
        // startAngel = transform.localEulerAngles;
        startQua = transform.rotation;
    }
    private void Update()
    {
        RotationReset();
    }
    private void RotationReset()
    {
<<<<<<< HEAD
        if(!GameManager.instance.handOnWheel)
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, startQua, speed * Time.deltaTime);
=======
        if (!GameManager.instance.handOnWheel)
        {
            transform.rotation = Quaternion.RotateTowards(transform.localRotation, startQua, speed * Time.deltaTime);
        }
        // if (steer._direction == SteerWheelRotation.Dir.right)
        // {
        //     steerTurnedAngele += 0.1f;
        // }
        // else if (steer._direction == SteerWheelRotation.Dir.left)
        // {
        //     steerTurnedAngele -= 0.1f;
        // }
>>>>>>> qwe
    }
    // private void RotationReset()
    // {
    //     if (steer._direction == SteerWheelRotation.Dir.right)
    //     {
    //         steerTurnedAngele += 0.1f;
    //     }
    //     else if (steer._direction == SteerWheelRotation.Dir.left)
    //     {
    //         steerTurnedAngele -= 0.1f;
    //     }
    // }
}
