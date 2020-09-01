using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //这个脚本在XR Rig上
    public Vector3 driction;

    public void MovementFunction(float x, float y)
    {
        driction = new Vector3(x, 0, y);
        transform.Translate(driction * Time.deltaTime, Space.Self);
    }
}
