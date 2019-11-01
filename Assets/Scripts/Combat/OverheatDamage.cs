using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatDamage : MonoBehaviour
{
    [SerializeField] private float overheatDamage;
    [SerializeField] private float overheatTime;

    private int currentOverheat;
    private int maxOverheat;
    private int thresholdOverheat;

    private OverheatMediator overheatMediator;
    private HealthMediator healthMediator;

    private IEnumerator coroutine;

    void Awake()
    {
        if ((overheatMediator = GetComponent<OverheatMediator>()) == null)
        {
            overheatMediator = this.gameObject.AddComponent<OverheatMediator>();
        }
        if ((healthMediator = GetComponent<HealthMediator>()) == null)
        {
            healthMediator = this.gameObject.AddComponent<HealthMediator>();
        }

        overheatMediator.SubcribeToCurrentOverheat(UpdateCurrentOverheat);
        overheatMediator.SubcribeToMaxOverheat(UpdateMaxAmmo);
        overheatMediator.SubcribeToThresholdOverheat(UpdateMaxAmmo);
    }

    public void UpdateCurrentOverheat(int value)
    {
        currentOverheat = value;

        if (currentOverheat >= thresholdOverheat)
        {
            coroutine = DamagePerTime(overheatTime, overheatDamage);
            StartCoroutine(coroutine);
        }
    }

    public void UpdateMaxAmmo(int value)
    {
        maxOverheat = value;
    }

    public void UpdateThresholdOverheat(int value)
    {
        thresholdOverheat = value;
    }

    public IEnumerator DamagePerTime(float waitTime, float overheatDamage)
    {
        while (currentOverheat >= thresholdOverheat)
        {
            yield return new WaitForSeconds(waitTime);
            healthMediator.DecreaseCurrentHealth(overheatDamage);
        }
    }
}
