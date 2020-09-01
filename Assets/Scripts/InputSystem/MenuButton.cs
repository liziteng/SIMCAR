﻿using UnityEngine;

public class MenuButton : MonoBehaviour
{
    //这个脚本在InputManager上
    public GameObject control_L, control_R, Ray_R, Ray_L, menuObj;

    public void SetControllerActivite(bool b)
    {
        control_L.SetActive(!b);
        control_R.SetActive(!b);
        menuObj.SetActive(b);
        Ray_R.SetActive(b);
        Ray_L.SetActive(b);
        print(b);
    }
}
