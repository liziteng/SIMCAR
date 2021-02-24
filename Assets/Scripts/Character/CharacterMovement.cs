using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CharacterMovement : MonoBehaviour
{
    //这个脚本贴在XR Rig上, 游戏运行以后MovementFunction会在LoadController里通过GameManager被引用。
    //最后运行是在VRControllerInput 里方向键那.
    public float speed = 1;
    private XRRig rig;
    private CharacterController character;
    private void Start()
    {
        rig = GetComponent<XRRig>();
        character = GetComponent<CharacterController>();
    }

    public void MovementFunction(float x, float y)
    {
        var headDri = Quaternion.Euler(0, rig.cameraGameObject.transform.localEulerAngles.y, 0);
        var movingDriection = headDri * new Vector3(x, 0, y);
        character.Move(movingDriection * Time.deltaTime * speed);
    }

    #region Old Character Move Method 
    // private float speed = 0.6f;
    // private GameObject cam;
    // private void Start()
    // {
    //     cam = FindObjectOfType<AudioListener>().gameObject;
    // }
    // public void MovementFunction(float x, float y)
    // {
    //     var camDir = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
    //     transform.localPosition += camDir * y * Time.deltaTime * speed;
    //     transform.localPosition += cam.transform.right * x * Time.deltaTime * speed;
    // }
    #endregion
}
