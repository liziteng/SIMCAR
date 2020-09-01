﻿using UnityEngine;

public class GameManger : MonoBehaviour
{
    //这个脚本在GameManager上
    public static GameManger instance;
    public CharacterMovement characterMovement;
    public VRControllerInput[] vrInputs;
    public CarDrictionInput carSpeed;
    public LoadController controllerLoader;
    
    private void Awake()
    {
        instance = this;
        characterMovement = FindObjectOfType<CharacterMovement>();
        vrInputs = FindObjectsOfType<VRControllerInput>();
        carSpeed = FindObjectOfType<CarDrictionInput>();
        controllerLoader = FindObjectOfType<LoadController>();
    }
}
