using UnityEngine;

public class GameManager : MonoBehaviour
{
    //这个脚本在GameManager上
    public static GameManager instance;
    public CharacterMovement characterMovement;
    public VRControllerInput[] vrInputs;
    public CarDrictionInput carSpeed;
    public LoadController controllerLoader;
    public bool handOnWheel;
    public CarAngle turningForce;
    public GameObject hand;

    private void Awake()
    {
        instance = this;
        characterMovement = FindObjectOfType<CharacterMovement>();
        vrInputs = FindObjectsOfType<VRControllerInput>();
        controllerLoader = FindObjectOfType<LoadController>();
        turningForce = FindObjectOfType<CarAngle>();
    }
    public void CarLoaded()
    {
        carSpeed = FindObjectOfType<CarDrictionInput>();
    }
}
