using UnityEngine;

public class SteerWheelAngelReset : MonoBehaviour
{
    //这个脚本控制方向盘回转，放在“方向盘”物体上
    public Quaternion orginalAngle;
    public int turns = 0;
    public GameObject right, left, still;
    // public Transform On, Off;
    public int driection;
    private int speed = 700;
    private void Start()
    {
        orginalAngle = transform.localRotation;
    }

    private void Update()
    {
        SetCheckerPosition();
    }

    private void SetCheckerPosition()
    {
        if (driection == 1)
        {
            right.SetActive(true);
            still.SetActive(false);
            left.SetActive(false);
        }
        else if (driection == -1)
        {
            left.SetActive(true);
            still.SetActive(false);
            right.SetActive(false);
        }

        if (driection == 0)
        {
            still.SetActive(true);
            left.SetActive(false);
            right.SetActive(false);
        }
        if (!GameManger.instance.handOnWheel)
        {
            RotationReset();
            if (turns == 0) transform.localRotation = Quaternion.RotateTowards(transform.localRotation, orginalAngle, speed * Time.deltaTime);
        }
    }

    private void RotationReset()
    {
        if (turns > 0) transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime), Space.Self);
        else if (turns < 0) transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime), Space.Self);
    }
}
