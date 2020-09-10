using UnityEngine;
public class LocatorPosition : MonoBehaviour
{
    //这个脚本在steerWheelLocator上。 最后在steerWheelLocator的interactable Event里的Select Enter和Select Exit要添加上HandOnWheel和HandAway。
    public GameObject handLocator,steerWheelLocator, steerWheel;
    public VRControllerInput[] hands;
    public bool handOnWheel;

    private void Start()
    {
        hands = FindObjectsOfType<VRControllerInput>();
    }

    public void HandOnWheel()
    {
        handLocator.transform.position = hands[0].transform.position;//这个hands.transform之后要改掉, 最后还是创建一圈空白物体，然后位置=最近的空白物体的位置
        handOnWheel = true;
    }

    public void HandAway()
    {
        handLocator.transform.localPosition = steerWheel.transform.position;
        steerWheelLocator.transform.localPosition = steerWheel.transform.position;
        steerWheelLocator.transform.localRotation = steerWheel.transform.rotation;
        handOnWheel = false;
    }

    private void Update()
    {
        if (handOnWheel)
        {
            print("Hand on wheel!!!");
            handLocator.transform.localPosition = new Vector3(hands[0].transform.position.x, hands[0].transform.position.y, handLocator.transform.position.z);
        }
        else
        {
            print("Hands away");
            handLocator.transform.localPosition = new Vector3(0,-10,0);
        }
    }
}
