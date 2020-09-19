using UnityEngine;
using UnityEngine.XR;
public class LoadController : MonoBehaviour
{
    //这个脚本在GameManager上
    private void Start()
    {
        CharacterMovementRegisteration();
    }
    public void CarRegisteration() //上车以后执行这个
    {
        CharacterMovementDeregisteration();
        CarMovementRegisteration();
    }

    public void CharacterRegisteration() // 下车执行这个
    {
        CarMovementDeregisteration();
         CharacterMovementRegisteration();
    }

    private void CharacterMovementRegisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            vrcontroller.CharacterMovement += GameManger.instance.characterMovement.MovementFunction;
        }
    }

    private void CharacterMovementDeregisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            vrcontroller.CharacterMovement -= GameManger.instance.characterMovement.MovementFunction;
        }
    }

    private void CarMovementRegisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            if (vrcontroller.controlNode == InputDeviceCharacteristics.Right)
                vrcontroller.CarMovement += GameManger.instance.carSpeed.GoForward;
            else
                vrcontroller.CarMovement += GameManger.instance.carSpeed.GetBreak;
        }
    }
    private void CarMovementDeregisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            if (vrcontroller.controlNode == InputDeviceCharacteristics.Right)
                vrcontroller.CarMovement -= GameManger.instance.carSpeed.GoForward;
            else
                vrcontroller.CarMovement -= GameManger.instance.carSpeed.GetBreak;
        }
    }
}
