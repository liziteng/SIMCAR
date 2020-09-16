using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //这个脚本贴在XR Rig上, 游戏运行以后MovementFunction会在LoadController里通过GameManager被引用
    public Vector3 driction;

    public void MovementFunction(float x, float y)
    {
        driction = new Vector3(x, 0, y);
        transform.Translate(driction * Time.deltaTime, Space.Self);
    }
}
