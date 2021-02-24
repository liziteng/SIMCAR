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
<<<<<<< HEAD:Assets/Scripts/GameManager/GameManager.cs
    public CarAngle turningForce;
=======
    public AngleDetector steerWheelAngle;
>>>>>>> qwe:Assets/Scripts/GameManager/GameManger.cs

    private void Awake()
    {
        instance = this;
        characterMovement = FindObjectOfType<CharacterMovement>();
        vrInputs = FindObjectsOfType<VRControllerInput>();
        controllerLoader = FindObjectOfType<LoadController>();
<<<<<<< HEAD:Assets/Scripts/GameManager/GameManager.cs
        turningForce = FindObjectOfType<CarAngle>();
=======
        characterCollision = FindObjectOfType<CharacterController>();
        steerWheelAngle = FindObjectOfType<AngleDetector>();
>>>>>>> qwe:Assets/Scripts/GameManager/GameManger.cs
    }
    public void CarLoaded()
    {
        carSpeed = FindObjectOfType<CarDrictionInput>();
    }
}
