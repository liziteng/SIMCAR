using UnityEngine;
public class CarDrictionInput : MonoBehaviour
{
    //这个脚本在Car Collider物体上
    private CarMovementControl driction;
    private SteerWheelRotation steerWheel;
    private Rigidbody rgbd;
    public float level = 1; //这个是控制档位的系数，通过调整档位修改
    private float angle = 10; //这个是控制车轮旋转的一个角度，这个数自己看情况定义一个
    private void Awake()
    {
        driction = GetComponent<CarMovementControl>();
        rgbd = GetComponent<Rigidbody>();
        steerWheel = FindObjectOfType<SteerWheelRotation>();
    }
    public void GoForward(float value) //控制车往前往后走
    {
        driction.forwardInput = -value * level;
    }
    public void GetBreak(float value) //控制刹车
    {
        driction.breakInput = value;
    }
}
