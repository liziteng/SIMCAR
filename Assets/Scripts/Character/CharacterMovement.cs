using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //这个脚本贴在XR Rig上, 游戏运行以后MovementFunction会在LoadController里通过GameManager被引用。
    //最后运行是在VRControllerInput 里方向键那.
    private float speed = 0.6f;
    private GameObject cam;
    private void Start()
    {
        cam = FindObjectOfType<AudioListener>().gameObject;
    }
    public void MovementFunction(float x, float y)
    {
        var camDir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        transform.localPosition += camDir * y * Time.deltaTime * speed;
        transform.localPosition += cam.transform.right * x * Time.deltaTime * speed;
    }
}
