using UnityEngine;

public class GameManger : MonoBehaviour
{
    //这个脚本在GameManager上
    public static GameManger instance;
    public CharacterMovement characterMovement;
    public VRControllerInput[] vrInputs;
    public CarDrictionInput carSpeed;
    public LoadController controllerLoader;
    public bool handOnWheel;

    private void Awake()
    {
        instance = this;
        characterMovement = FindObjectOfType<CharacterMovement>();
        vrInputs = FindObjectsOfType<VRControllerInput>();
        controllerLoader = FindObjectOfType<LoadController>();
    }
    public void CarLoaded()
    {
        carSpeed = FindObjectOfType<CarDrictionInput>();
    }
}
