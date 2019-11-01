using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AttackerDamage : MonoBehaviour
{
    private HealthMediator healthMediator;
    private LastAttackerMediator lastAttackerMediator;

    void Awake()
    {
        if ((healthMediator = GetComponent<HealthMediator>()) == null)
        {
            healthMediator = this.gameObject.AddComponent<HealthMediator>();
        }
        if ((lastAttackerMediator = GetComponent<LastAttackerMediator>()) == null)
        {
            lastAttackerMediator = this.gameObject.AddComponent<LastAttackerMediator>();
        }
    }

    void Rest()
    {
        if ((healthMediator = GetComponent<HealthMediator>()) == null)
        {
            healthMediator = this.gameObject.AddComponent<HealthMediator>();
        }
        if ((lastAttackerMediator = GetComponent<LastAttackerMediator>()) == null)
        {
            lastAttackerMediator = this.gameObject.AddComponent<LastAttackerMediator>();
        }
    }

    public void CalculateDamage(object sender, BodyPhysicsEventArgs e)
    {
        Attack attack = e.target.GetComponent<Attack>();
        if (attack != null)
        {
            lastAttackerMediator.SetLasAttacker(e.target);
            healthMediator.DecreaseCurrentHealth(attack.Damage);
        }
    }
}
