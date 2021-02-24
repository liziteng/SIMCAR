using UnityEngine;
public class SteerWheelRotation : MonoBehaviour
{
    //这个脚本放在“方向盘物体”上，控制方向盘角度. 🚗

    public GameObject handLocator;
    public float outPutAngle;

    private GameObject steerWheelLocator;
    private float baseAngle;
<<<<<<< HEAD
    private SecendryWheel secendryWheel;
=======
    // private SecendryWheel secendryWheel;
    // private GameObject shadowWheel;
>>>>>>> qwe
    private Vector3 startAngel;

    // public enum Dir
    // {
    //     right,
    //     left,
    //     still
    // }
    // public Dir _direction = Dir.still;

    private void Start()
    {
        steerWheelLocator = FindObjectOfType<SteerWheerLocatorPosition>().gameObject;
<<<<<<< HEAD
        secendryWheel = FindObjectOfType<SecendryWheel>();
=======
        // secendryWheel = FindObjectOfType<SecendryWheel>();
        // shadowWheel = secendryWheel.gameObject;
>>>>>>> qwe
        startAngel = transform.up;
    }
    private void Update()
    {
        if (GameManager.instance.handOnWheel) GetControllerAngle();

        // _direction = DirectionDetector();
    }

    public void StartingAngle() //这个方法要在刚开始握方向盘时运行一次, 在SteerWheelLocator的Interactable Event的Select Enter里
    {
        var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
        var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
        baseAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        var steerWheelAngle = Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg; //这个是方向盘本身的方向
        baseAngle -= steerWheelAngle;
    }

    private void GetControllerAngle() //让方向盘跟随手旋转
    {
        var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
        var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
        var floatAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg - baseAngle;
        //减去了一个初始角度，也就是手刚开始抓方向盘的角度，这样才不至于住方向盘时方向盘突然转向手.
        outPutAngle = floatAngle;
        var quatAngle = Quaternion.AngleAxis(floatAngle, Vector3.forward); //算出方向盘应该使用的四元数角度
        var v3angle = quatAngle.eulerAngles; //将四元数角度转换为三项数角度
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, v3angle.z); //保持x轴角度的前提下,只选转z轴
    }

    // private Dir DirectionDetector()
    // {
    //     var direction = Vector3.Cross(transform.up, shadowWheel.transform.up);
    //     if (direction.y > 0)
    //     {
    //         return Dir.left;
    //     }
    //     else if (direction.y < 0)
    //     {
    //         return Dir.right;
    //     }
    //     else
    //     {
    //         return Dir.still;
    //     }
    // }

    // private void GetControllerAngle() //让方向盘跟随手旋转
    // {
    //     var x = handLocator.transform.position.x - transform.position.x; //算出手柄相对于方向盘的X
    //     var y = handLocator.transform.position.y - transform.position.y; //算出手柄相对于方向盘的Y
    //     var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
    //     transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    // }
}
