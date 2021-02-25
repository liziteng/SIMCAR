using UnityEngine;
public class DoorRemainClose : MonoBehaviour
{
    //这个脚本在车门上，可以让车门关闭以后不会因为惯性被弹开。
    protected GameObject car;
    protected HingeJoint joint;
    protected JointLimits limit;
    public enum DoorState { close, open, pending }
    public DoorState drState;
    protected virtual void Start()
    {
        car = FindObjectOfType<CarMovementControl>().gameObject;
        joint = GetComponent<HingeJoint>();
        limit = joint.limits;
    }
    protected virtual void Update()
    {
        if (drState == DoorState.close)
        {
            limit.max = 0;
            joint.limits = limit;
        }
        else
        {
            limit.max = 80;
            joint.limits = limit;
        }
    }
    public void HoldingDoor()
    {
        drState = DoorState.pending;
    }
    public void RegularDoorFunction()
    {
        var doorOpenAngle = Vector3.Cross(-transform.up, car.transform.forward).y;
        if (doorOpenAngle > -0.1f)
        {
            drState = DoorState.close;
        }
    }
}
