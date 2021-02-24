using UnityEngine;

public class Test1000 : MonoBehaviour
{
    private GameObject obj;
    private MeshRenderer mesh;
    public float distance;
    private void Start()
    {
        obj = FindObjectOfType<ConfigurableJoint>().gameObject;
        mesh = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        DistanceChecker();
    }
    private void DistanceChecker()
    {
        var dis = transform.position - obj.transform.position;
        if (dis.sqrMagnitude < distance * distance)
        {
            mesh.enabled = true;
        }
        else
            mesh.enabled = false;
    }
}


