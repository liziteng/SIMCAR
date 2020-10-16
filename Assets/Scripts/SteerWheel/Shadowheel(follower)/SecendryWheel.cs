using UnityEngine;

public class SecendryWheel : MonoBehaviour
{
    private SteerWheelAngelReset SR;
    private GameObject steerWheel;
    public Quaternion currentAngle;

    private void Start()
    {
        SR = FindObjectOfType<SteerWheelAngelReset>();
        steerWheel = SR.gameObject;
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
        if (transform.localEulerAngles.z < steerWheel.transform.localEulerAngles.z)
        {
            SR.driection = 1;
        }
        else if (transform.localEulerAngles.z > steerWheel.transform.localEulerAngles.z)
        {
            SR.driection = -1;
        }
        else
        {
            SR.driection = 0;
        }
    }
}
