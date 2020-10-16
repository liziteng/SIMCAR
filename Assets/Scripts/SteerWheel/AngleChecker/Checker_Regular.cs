using UnityEngine;

public class Checker_Regular : MonoBehaviour
{
    //这个脚本在方向盘的左右判别器上.
    //当"左"或者"右"被触发时, 方向盘复位脚本里的圈数加上或者减去相应的number
    private SteerWheelAngelReset wheel;
    public int number;
    private void Start()
    {
        wheel = FindObjectOfType<SteerWheelAngelReset>();
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SteerWheel")
        wheel.turns += number;
    }
}

