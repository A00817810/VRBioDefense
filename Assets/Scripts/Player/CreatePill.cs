using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CreatePill : MonoBehaviour
{
    [SerializeField] private VRTK_ControllerEvents leftHand;
    [SerializeField] private VRTK_ControllerEvents rightHand;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform leftGrabPoint;
    [SerializeField] private Transform rightGrabPoint;
    [SerializeField] private int overheatAmount;
    [SerializeField] private int damage;

    private OverheatMediator overheatMediator;

    void Awake()
    {
        if ((overheatMediator = GetComponent<OverheatMediator>()) == null)
        {
            overheatMediator = this.gameObject.AddComponent<OverheatMediator>();
        }
    }

    void Reset()
    {
        if ((overheatMediator = GetComponent<OverheatMediator>()) == null)
        {
            overheatMediator = this.gameObject.AddComponent<OverheatMediator>();
        }
    }

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
        Attack attack = pill.AddComponent<Attack>();
        attack.Damage = damage;
        attack.Attacker = this.gameObject;
        pill.GetComponent<Rigidbody>().AddForce(-leftGrabPoint.up * 10, ForceMode.Impulse);
        overheatMediator.IncreaseCurrentOverheat(overheatAmount);
    }

    public void generateRightProjectile(object sender, ControllerInteractionEventArgs e)
    {
        GameObject pill = Instantiate(projectile, rightGrabPoint.position, Quaternion.identity);
        Attack attack = pill.AddComponent<Attack>();
        attack.Damage = damage;
        attack.Attacker = this.gameObject;
        pill.GetComponent<Rigidbody>().AddForce(-leftGrabPoint.up * 10, ForceMode.Impulse);
        overheatMediator.IncreaseCurrentOverheat(overheatAmount);
    }
}
