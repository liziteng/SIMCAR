using UnityEngine;
public class LocatorPosition : MonoBehaviour
{
    //这个脚本在steerWheelLocator上。 最后在steerWheelLocator的interactable Event里的Select Enter和Select Exit要添加上HandOnWheel和HandAway。
    public GameObject handLocator; //这个是抓住方向盘以后手的位置, 用于判定手的位置.
    public GameObject steerWheelLocator; //这个是方向盘的定位, 用于抓取
    public GameObject steerWheel; //这个是方形盘物体
    private VRControllerInput[] hands;
    public bool handOnWheel;

    private void Start()
    {
        hands = FindObjectsOfType<VRControllerInput>();
    }

    public void HandOnWheel()  //在steerWheelLocator的interactable Event里的Select Enter里
    {
        handLocator.transform.position = new Vector3(hands[0].transform.position.x, hands[0].transform.position.y, steerWheelLocator.transform.position.z);
        handOnWheel = true;
    }

    public void HandAway()  //在steerWheelLocator的interactable Event里的Select Exit里
    {
        handLocator.transform.localPosition = steerWheel.transform.position;
        steerWheelLocator.transform.localPosition = steerWheel.transform.position;
        steerWheelLocator.transform.localRotation = steerWheel.transform.rotation;
        handOnWheel = false;
    }

    private void Update()
    {
        handLocator.transform.localPosition = handOnWheel ?
        new Vector3(hands[0].transform.position.x, hands[0].transform.position.y, handLocator.transform.position.z)
        : handLocator.transform.localPosition = steerWheel.transform.position;
    }
}
