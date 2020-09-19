using UnityEngine;

public class SteerWheelRotation : MonoBehaviour
{
    //这个脚本放在SteerWheel上，控制方向盘角度. 

    public GameObject handLocator;
    public float outPutAngle;

    private float baseAngle;

    private void Update()
    {
        GetControllerAngle();
    }

    public void StartingAngle() //这个方法要在刚开始握方向盘时运行一次, 在SteerWheelLocator的Interactable Event的Select Enter里
    {
        var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
        var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
        baseAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        var steerWheelAngle = Mathf.Atan2(transform.right.y, transform.right.x)*Mathf.Rad2Deg; //这个是方向盘本身的方向
        baseAngle -= steerWheelAngle;
    }
    
    private void GetControllerAngle() //让方向盘跟随手旋转
    {
        var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
        var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
        var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg - baseAngle; 
        //减去了一个初始角度，也就是手刚开始抓方向盘的角度，这样才不至于住方向盘时方向盘突然转向手.
        outPutAngle = angle;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // private void GetControllerAngle() //让方向盘跟随手旋转
    // {
    //     var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
    //     var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
    //     var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    //     transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    // }
}
