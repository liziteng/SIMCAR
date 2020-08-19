using UnityEngine;
public class CarDrictionInput : MonoBehaviour
{
    //这个脚本在Car Collider物体上
    private CarMovementControl driction;
    private Rigidbody rgbd;
    private float level = 1; //这个是控制档位的系数
    private void Awake()
    {
        driction = GetComponent<CarMovementControl>();
        rgbd = GetComponent<Rigidbody>();
    }

    private float GetDriction() //这个是左右的方向，里面方法之后改
    {
        var horizontal = Input.GetAxis("Horizontal"); ;
        return horizontal;
    }
    public void GoForward(float value) //控制车往前往后走
    {
        driction.forwardInput = -value * level;
    }
    public void GetBreak(float value) //控制刹车
    {
        driction.breakInput = value ;
    }
}
