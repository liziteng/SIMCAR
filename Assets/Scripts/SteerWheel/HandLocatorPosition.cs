using UnityEngine;

public class HandLocatorPosition : MonoBehaviour
{
    public GameObject SWlocator;
    public GameObject SWobj;
    void Update()
    {
        transform.localPosition = GameManager.instance.handOnWheel
        ? new Vector3(SWlocator.transform.position.x, SWlocator.transform.position.y, transform.localPosition.z)
        : transform.localPosition = SWobj.transform.localPosition;
    }
}
