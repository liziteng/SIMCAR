using UnityEngine;
public class SteerWheerLocatorPosition : MonoBehaviour
{
    //这个脚本在steerWheelLocator上。 最后在steerWheelLocator的interactable Event里的Select Enter和Select Exit要添加上HandOnWheel和HandAway。
    public GameObject handLocator; //这个是抓住方向盘以后手的位置, 用于判定手的位置.
    public GameObject steerWheel; //这个是方形盘物体
    public bool handOnWheel;
    private VRControllerInput[] hands;
    private Quaternion baseAngle;

    private void Start()
    {
        baseAngle = transform.localRotation;
        hands = FindObjectsOfType<VRControllerInput>();
    }

    public void HandOnWheel()  //在steerWheelLocator的interactable Event里的Select Enter里
    {
        handLocator.transform.position = new Vector3(hands[0].transform.position.x, hands[0].transform.position.y, transform.position.z);
        handOnWheel = true;
        GameManager.instance.handOnWheel = true;
    }

    public void HandAway()  //在steerWheelLocator的interactable Event里的Select Exit里
    {
        handLocator.transform.localPosition = steerWheel.transform.position;
        transform.localPosition = steerWheel.transform.position;
        transform.localRotation = baseAngle;
        handOnWheel = false;
        GameManager.instance.handOnWheel = false;
    }

    private void Update()
    {
        handLocator.transform.localPosition = handOnWheel ?
        new Vector3(hands[0].transform.position.x, hands[0].transform.position.y, transform.localPosition.z)
        : handLocator.transform.localPosition = steerWheel.transform.localPosition;
    }
}
