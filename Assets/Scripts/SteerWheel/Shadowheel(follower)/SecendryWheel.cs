using UnityEngine;

public class SecendryWheel : MonoBehaviour
{
    //这个脚本在“影子方向盘”上，控制延时角度。
    private SteerWheelRotation SW;
    private GameObject steerWheel;
    public Quaternion currentAngle;

    private void Start()
    {
        SW = FindObjectOfType<SteerWheelRotation>();
        steerWheel = SW.gameObject;
    }
    private void Update()
    {
        GetAngle();
    }

    private void GetAngle()
    {
        currentAngle = steerWheel.transform.localRotation;
        var difference = Mathf.Abs(steerWheel.transform.localEulerAngles.z - transform.localEulerAngles.z);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, currentAngle, 12 * difference * Time.deltaTime);
    }
}
