using UnityEngine;

public class CarDoorCollision : MonoBehaviour
{
    //这个脚本在汽车里的车门检测器上
    public Rigidbody rgbd;
    private void OnTriggerEnter(Collider other)
    {
        rgbd.isKinematic = true;
        print("door closed");
    }

    private void OnTriggerStay(Collider other)
    {
        rgbd.isKinematic = true;
        print("door closed");
    }

    private void OnTriggerExit(Collider other)
    {
        rgbd.isKinematic = false;
        print("door opened");
    }
}
