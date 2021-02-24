using UnityEngine;

public class CarAngle : MonoBehaviour
{
    public GameObject shadowWheel;
    public float _turningForce;
    private void Update()
    {
        var force = - Vector3.Cross(transform.up, shadowWheel.transform.up);
        var z = force.z;
        if (Mathf.Abs(z) < 0.1f) z = 0;
        _turningForce = z;
    }
}
