using UnityEngine;

public class Checker_Still : MonoBehaviour
{
    //这个脚本放在still检测物体上
    //当方向盘转到左边时, 方向盘回转180度后撒手则圈数减少; 相反则圈数增加.
    private SteerWheelAngelReset wheel;

    void Start()
    {
        wheel = FindObjectOfType<SteerWheelAngelReset>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SteerWheel")
        {
            // if (wheel.turns > 0)
            //     wheel.turns--;
            // else if (wheel.turns < 0)
            //     wheel.turns++;
        }
    }
}
