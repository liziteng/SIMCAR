using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    public GameObject rightHand;
    private Transform rightHandOrigineParent;
    private bool rightHandOnWheel = false;
    public GameObject leftHand;
    private Transform leftHandOrigineParent;
    private bool leftHandOnWheel = false;
    public Transform[] snappPoints;
    public int numberOfHandsOnWheel = 0;
    public GameObject carBody;
    private Rigidbody carRigidbody;
    public float currentWheelRotation = 0;
    private float turnDampening = 250;
    public Transform directionalObject;

    private void Start()
    {
    }
    private void Update()
    {
        TurnVechicle();
        ReleasehandsFromWheel();
        ConvertHandRotationToSteeringWheelRotation();

        currentWheelRotation = -transform.rotation.eulerAngles.z;
    }

    void TurnVechicle()
    {
        var turn = -transform.rotation.eulerAngles.z;
        if (turn < -350)
        {
            turn += 360;
        }
        //get turn angle
    }
    void ReleasehandsFromWheel()
    {
        if (rightHandOnWheel == true) //&& grip pressed
        {
            rightHand.transform.parent = rightHandOrigineParent;
            rightHand.transform.position = rightHandOrigineParent.position;
            rightHand.transform.rotation = rightHandOrigineParent.rotation;
            rightHandOnWheel = false;
            numberOfHandsOnWheel--;
        }
        if (leftHandOnWheel == true)//&& grip pressed
        {
            leftHand.transform.parent = leftHandOrigineParent;
            leftHand.transform.position = leftHandOrigineParent.position;
            leftHand.transform.rotation = leftHandOrigineParent.rotation;
            leftHandOnWheel = false;
            numberOfHandsOnWheel--;
        }
        if (leftHandOnWheel == false && rightHandOnWheel == false)//&& grip pressed
        {
            transform.parent = null;
        }
    }
    void ConvertHandRotationToSteeringWheelRotation()
    {
        if (rightHandOnWheel == true && leftHandOnWheel == false)
        {
            Quaternion newRot = Quaternion.Euler(0, 0, rightHandOrigineParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }
        else if (rightHandOnWheel == false && leftHandOnWheel == true)
        {
            Quaternion newRot = Quaternion.Euler(0, 0, leftHandOrigineParent.transform.rotation.eulerAngles.z);
            directionalObject.rotation = newRot;
            transform.parent = directionalObject;
        }
        else if (rightHandOnWheel == true && leftHandOnWheel == true)
        {
            Quaternion newRotLeft = Quaternion.Euler(0, 0, leftHandOrigineParent.transform.rotation.eulerAngles.z);
            Quaternion newRotRight = Quaternion.Euler(0, 0, rightHandOrigineParent.transform.rotation.eulerAngles.z);
            Quaternion finalRot = Quaternion.Slerp(newRotLeft, newRotRight, 1.0f / 2.0f);
            directionalObject.rotation = finalRot;
            transform.parent = directionalObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (rightHandOnWheel == false) //&& grip pressed
            {
                PlaceHandOnWheel(ref rightHand, ref rightHandOrigineParent, ref rightHandOnWheel);
            }

            if (leftHandOnWheel == false) //&& grip pressed
            {
                PlaceHandOnWheel(ref leftHand, ref leftHandOrigineParent, ref leftHandOnWheel);
            }
        }
    }
    void PlaceHandOnWheel(ref GameObject hand, ref Transform originalParent, ref bool handOnWheel)
    {
        var shortestDistance = Vector3.Distance(snappPoints[0].position, hand.transform.position);
        var bestSnapp = snappPoints[0];
        foreach (var snappPosition in snappPoints)
        {
            if (snappPosition.childCount == 0)
            {
                var distance = Vector3.Distance(snappPosition.position, hand.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    bestSnapp = snappPosition;
                }
            }
        }

        originalParent = hand.transform.parent;

        hand.transform.parent = bestSnapp.transform;
        hand.transform.position = bestSnapp.transform.position;

        handOnWheel = true;
        numberOfHandsOnWheel++;
    }
}
