using UnityEngine;

public class CharacterDirection : MonoBehaviour
{
    public Transform cameraDri;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(0,cameraDri.localEulerAngles.y,0);
    }
}
