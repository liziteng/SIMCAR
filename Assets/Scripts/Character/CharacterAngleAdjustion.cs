
using UnityEngine;
public class CharacterAngleAdjustion : MonoBehaviour
{
    private GameObject cam;
    private void Start()
    {
        cam = FindObjectOfType<AudioListener>().gameObject;
        transform.forward = cam.transform.forward;
    }
}

