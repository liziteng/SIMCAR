using UnityEngine;
using UnityEngine.XR;
public class LoadController : MonoBehaviour
{
    private void Start()
    {
        CharacterMovementRegisteration();
        CarMovementRegisteration();
    }

    public void CharacterMovementRegisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            vrcontroller.CharacterMovement += GameManger.instance.characterMovement.MovementFunction;
        }
    }

    public void CarMovementRegisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManger.instance.vrInputs)
        {
            if(vrcontroller.controlNode == InputDeviceCharacteristics.Right)
            vrcontroller.CarMovement += GameManger.instance.carSpeed.GoForward;
            else
            vrcontroller.CarMovement += GameManger.instance.carSpeed.GetBreak;
        }
    }
}
