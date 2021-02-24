using UnityEngine;
public class DoorRemainClose : MonoBehaviour
{
    //这个脚本在车门上，可以让车门关闭以后不会因为惯性被弹开。HoldingDoor在Interactable Events里面加在OnSelectEnter里
    //RegularDoorFunction在Interactable Events里面加在OnselectExit里
    protected GameObject car;
    public enum DoorState { close, open, pending }
    public DoorState drState;
    protected Quaternion doorInitailAngle;
    protected virtual void Start()
    {
        doorInitailAngle = transform.localRotation;
        car = FindObjectOfType<CarMovementControl>().gameObject;
    }
    protected void Update()
    {
        if (drState == DoorState.close)
        {
            transform.localRotation = doorInitailAngle;
        }
    }
    public void HoldingDoor() 
    {
        drState = DoorState.pending;
    }
    public void RegularDoorFunction()
    {
        var doorOpenAngle = Vector3.Cross(-transform.up, car.transform.forward).y;

        if(doorOpenAngle > -0.1f)
        {
            drState = DoorState.close;
        }
    }
}
