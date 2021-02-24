using UnityEngine;
public class CarMovementControl : MonoBehaviour
{
     //这个脚本在Car Collider物体上，控制汽车轮子的碰撞核
    public float horizontalInput;
    public float forwardInput, breakInput;
    public float steerAngle;
    public WheelCollider fr_wheelColider, fl_wheelColider, br_wheelColider, bl_wheelColider;
    public Transform fr_wheelTransform, fl_wheelTransform, br_wheelTransform, bl_wheelTransform;
    public float maxSteerAngle = 30; //左右转弯
    public float motoforce = 50; //前进后退
    public float breakforce = 300;

    private void FixedUpdate()
    {
        SteerMethod();
        AccelerateMethod();
        UpdateWheelsPoses();
        BreakMethod();
    }
    private void SteerMethod()
    {
        steerAngle = maxSteerAngle * 1;
        fl_wheelColider.steerAngle = steerAngle;
        fr_wheelColider.steerAngle = steerAngle;
    }
    private void AccelerateMethod()
    {
        fl_wheelColider.motorTorque = forwardInput * motoforce;
        fr_wheelColider.motorTorque = forwardInput * motoforce;
    }
    private void BreakMethod()
    {
        fl_wheelColider.brakeTorque = breakInput * breakforce;
        fr_wheelColider.brakeTorque = breakInput * breakforce;
        br_wheelColider.brakeTorque = breakInput * breakforce;
        bl_wheelColider.brakeTorque = breakInput * breakforce;
    }
    private void UpdateWheelsPoses()
    {
        UpdateWheelPose(fr_wheelColider, fr_wheelTransform);
        UpdateWheelPose(fl_wheelColider, fl_wheelTransform);
        UpdateWheelPose(br_wheelColider, br_wheelTransform);
        UpdateWheelPose(bl_wheelColider, bl_wheelTransform);
    }
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }
}
