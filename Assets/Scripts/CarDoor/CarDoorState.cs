using UnityEngine;
public class CarDoorState : DoorRemainClose
{
    //这个脚本在汽车的车门检测，检测车门的角度。在汽车门的interactable event里要把GetTheCar指定一下
    private GameObject character;
    public Transform whereGetOn;
    public Transform seatPos;
    public enum CharacterState { OnCar, OffCar, }
    public CharacterState charState;

    protected override void Start()
    {
        base.Start();
        character = FindObjectOfType<CharacterMovement>().gameObject;
        charState = CharacterState.OffCar;
    }
    public void GetTheCar()
    {
        if (RunOperation())
        {
            if (charState == CharacterState.OnCar) GetOff();
            else if (charState == CharacterState.OffCar) GetOn();
        }
    }
    private bool RunOperation()
    {
        var doorOpenAngle = Vector3.Cross(-transform.up, car.transform.forward).y;

        if (doorOpenAngle > -0.1f)
        {
            drState = DoorState.close;
            return false;
        }
        else if (doorOpenAngle < -0.6f)
        {
            drState = DoorState.open;
            return true;
        }
        else
        {
            drState = DoorState.open;
            return false;
        }
    }
    private void GetOn()
    {
        whereGetOn.position = character.transform.position;
        character.transform.position = seatPos.position;
        character.transform.parent = car.transform;
        GameManger.instance.controllerLoader.CarRegisteration();
        charState = CharacterState.OnCar;
    }
    private void GetOff()
    {
        character.transform.parent = null;
        character.transform.position = whereGetOn.position;
        GameManger.instance.controllerLoader.CharacterRegisteration();
        charState = CharacterState.OffCar;
    }
}
