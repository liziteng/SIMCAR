using UnityEngine;

public class SteerWheelRotation : MonoBehaviour
{
    //这个脚本放在SteerWheel上，控制方向盘角度. 

    public GameObject handLocator;
    
    private void Update()
    {
        GetControllerAngle();
    }

    private void GetControllerAngle() //得到手的相对位置 ( transform.localrotation )
    {
        var handAngle = Mathf.Atan2(handLocator.transform.position.y, handLocator.transform.position.x) * Mathf.Rad2Deg;
        var wheelAngle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(handAngle * 10, Vector3.forward);
        print(wheelAngle);
    }
}
