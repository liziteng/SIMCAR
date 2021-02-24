using UnityEngine;

public class GameManager : MonoBehaviour
{
    //这个脚本在GameManager上
    public static GameManager instance;
    public CharacterMovement characterMovement;
    public VRControllerInput[] vrInputs;
    public CarDrictionInput carSpeed;
    public LoadController controllerLoader;
    public CharacterController characterCollision;
    public bool handOnWheel;
    public AngleDetector steerWheelAngle;

    private void Awake()
    {
        instance = this;
        characterMovement = FindObjectOfType<CharacterMovement>();
        vrInputs = FindObjectsOfType<VRControllerInput>();
        controllerLoader = FindObjectOfType<LoadController>();
        characterCollision = FindObjectOfType<CharacterController>();
        steerWheelAngle = FindObjectOfType<AngleDetector>();
    }
    public void CarLoaded()
    {
        carSpeed = FindObjectOfType<CarDrictionInput>();
    }
}
