using UnityEngine;

public class SecendryWheel : MonoBehaviour
{
    private SteerWheelAngelReset swR;
    private SteerWheelRotation SW;
    private GameObject steerWheel;
    public Quaternion currentAngle;

    private void Start()
    {
        swR = FindObjectOfType<SteerWheelAngelReset>();
        SW = FindObjectOfType<SteerWheelRotation>();
        steerWheel = swR.gameObject;
    }
    private void Update()
    {
        GetAngle();
        AngleComparation();
    }

    private void GetAngle()
    {
        currentAngle = steerWheel.transform.localRotation;
        var difference = Mathf.Abs(steerWheel.transform.localEulerAngles.z - transform.localEulerAngles.z);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, currentAngle, 12 * difference * Time.deltaTime);
    }

    private void AngleComparation()
    {
        Vector3 direction = Vector3.Cross(transform.localEulerAngles, steerWheel.transform.localEulerAngles);

        if (direction.y < 0)
        {
            swR.driection = 1;
        }
        else if (direction.y > 0)
        {
            swR.driection = -1;
        }
        else
        {
            swR.driection = 0;
        }
    }
}
