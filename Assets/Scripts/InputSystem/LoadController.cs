using UnityEngine;
using UnityEngine.XR;
public class LoadController : MonoBehaviour
{
    //这个脚本在GameManager上
    private void Start()
    {
        CharacterMovementRegisteration();
        GameManager.instance.CarLoaded(); //加载汽车或者上车以后要运行GM里的CarLoaded()命令。要不然后面的CarRegisteration会报错。
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
        foreach (VRControllerInput vrcontroller in GameManager.instance.vrInputs)
        {
            vrcontroller.CharacterMovement += GameManager.instance.characterMovement.MovementFunction;
        }
    }

    private void CharacterMovementDeregisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManager.instance.vrInputs)
        {
            vrcontroller.CharacterMovement -= GameManager.instance.characterMovement.MovementFunction;
        }
    }

    private void CarMovementRegisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManager.instance.vrInputs)
        {
            if (vrcontroller.controlNode == InputDeviceCharacteristics.Right)
            {
                vrcontroller.CarMovement += GameManager.instance.carSpeed.GoForward;
            }
            else if (vrcontroller.controlNode == InputDeviceCharacteristics.Left)
            {
                vrcontroller.CarMovement += GameManager.instance.carSpeed.GetBreak;
            }

        }
    }
    private void CarMovementDeregisteration()
    {
        foreach (VRControllerInput vrcontroller in GameManager.instance.vrInputs)
        {
            if (vrcontroller.controlNode == InputDeviceCharacteristics.Right)
                vrcontroller.CarMovement -= GameManager.instance.carSpeed.GoForward;
            else
                vrcontroller.CarMovement -= GameManager.instance.carSpeed.GetBreak;
        }
    }
}
