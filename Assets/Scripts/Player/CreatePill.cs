using System.Collections;
using UnityEngine;
using VRTK;

public class CreatePill : MonoBehaviour
{
    [SerializeField] private VRTK_ControllerEvents leftHand;
    [SerializeField] private VRTK_ControllerEvents rightHand;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform leftGrabPoint;
    [SerializeField] private Transform rightGrabPoint;

    protected virtual void OnEnable()
    {
        if (leftHand != null)
        {
            leftHand.GripPressed += generateLeftProjectile;
        }
        if (rightHand != null)
        {
            rightHand.GripPressed += generateRightProjectile;
        }
    }

    public void generateLeftProjectile(object sender, ControllerInteractionEventArgs e)
    {
        GameObject pill = Instantiate(projectile, leftGrabPoint.position, Quaternion.identity);
        pill.GetComponent<Rigidbody>().AddForce(-leftGrabPoint.up * 10, ForceMode.Impulse);

    }

    public void generateRightProjectile(object sender, ControllerInteractionEventArgs e)
    {
        GameObject pill = Instantiate(projectile, rightGrabPoint.position, Quaternion.identity);
        pill.GetComponent<Rigidbody>().AddForce(-rightGrabPoint.up * 10, ForceMode.Impulse);
    }
}
