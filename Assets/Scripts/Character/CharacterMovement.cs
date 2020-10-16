using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //这个脚本贴在XR Rig上, 游戏运行以后MovementFunction会在LoadController里通过GameManager被引用。
    //最后运行是在VRControllerInput 里方向键那.
    public GameObject cameraObj;
    private float speed = 1.0f;
    public void MovementFunction(float x, float y)
    {
        var test = new Vector2(x,y);
        print(test);
        // var driection = new Vector3(-y, 0, x) * Time.deltaTime;
        // transform.localPosition += driection;
        if (x > 0)
        {
            transform.position += cameraObj.transform.right * Time.deltaTime * speed;
        }
        if (x < 0)
        {
            transform.position += -cameraObj.transform.right * Time.deltaTime * speed;
        }
        if (y > 0)
        {
            transform.position += cameraObj.transform.forward * Time.deltaTime * speed;
        }
        if (y < 0)
        {
            transform.position += -cameraObj.transform.forward * Time.deltaTime * speed;
        }
    }
}
