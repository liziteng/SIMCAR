using UnityEngine;

public class AngleDetector : MonoBehaviour
{
    public GameObject orginal;
    public float horizontalForce;

    private void Update()
    {
        AngleDetection();
    }
    private void AngleDetection()
    {
        var force = Vector3.Cross(transform.up, orginal.transform.up);
        horizontalForce = force.z;
        if (Mathf.Abs(horizontalForce) < 0.1f)
        {
            horizontalForce = 0;
        }
    }
}
