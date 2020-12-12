using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //这个脚本贴在XR Rig上, 游戏运行以后MovementFunction会在LoadController里通过GameManager被引用。
    //最后运行是在VRControllerInput 里方向键那.
    private float speed = -0.6f;
    public void MovementFunction(float x, float y)
    {
        transform.localPosition += transform.forward * y * Time.deltaTime * speed;
        transform.localPosition += transform.right * x * Time.deltaTime * speed;
    }
}
