using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SteerWheerLocatorPosition : MonoBehaviour
{
    //这个脚本在steerWheelLocator上。 最后在steerWheelLocator的interactable Event里的Select Enter和Select Exit要添加上HandOnWheel和HandAway。
    public GameObject handLocator; //这个是抓住方向盘以后手的位置, 用于判定手的位置.
    public GameObject steerWheel; //这个是方形盘物体
    public bool handOnWheel;
    private XRDirectInteractor[] hands;
    public GameObject hand;
    private Quaternion baseAngle;

    private void Start()
    {
        baseAngle = transform.localRotation;
        hands = FindObjectsOfType<XRDirectInteractor>();
    }

    public void HandOnWheel()  //在steerWheelLocator的interactable Event里的Select Enter里
    {
        GetHand();
        handLocator.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, transform.position.z);
        handOnWheel = true;
        GameManager.instance.handOnWheel = true;
    }

    public void HandAway()  //在steerWheelLocator的interactable Event里的Select Exit里
    {
        transform.localPosition = steerWheel.transform.position;
        transform.localRotation = baseAngle;
        handOnWheel = false;
        GameManager.instance.handOnWheel = false;
    }
    private void GetHand()
    {
        foreach (XRDirectInteractor h in hands)
        {
            if(h.isSelectActive) hand = h.gameObject;
        }
    }

    private void Update()
    {
        handLocator.transform.localPosition = handOnWheel ?
        new Vector3(hand.transform.position.x, hand.transform.position.y, transform.localPosition.z)
        : handLocator.transform.localPosition = steerWheel.transform.localPosition;
    }
}
