using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastAttackerMediator : MonoBehaviour
{
    private LastAttacker lastAttacker;

    void Awake()
    {
        if ((LastAttacker = GetComponent<LastAttacker>()) == null)
        {
            LastAttacker = this.gameObject.AddComponent<LastAttacker>();
        }
    }

    void Reset()
    {
        if ((LastAttacker = GetComponent<LastAttacker>()) == null)
        {
            LastAttacker = this.gameObject.AddComponent<LastAttacker>();
        }
    }

    public void SetLasAttacker(GameObject value)
    {
        LastAttacker.Attribute = value;
    }

    public void SubcribeToLastAttacker(GenericGameObjectObserverMethod newObserver)
    {
        LastAttacker.Subcribe(newObserver);
    }

    public void UnsubcribeToLastAttacker(GenericGameObjectObserverMethod newObserver)
    {
        LastAttacker.Unsubcribe(newObserver);
    }

    public LastAttacker LastAttacker { get => lastAttacker; set => lastAttacker = value; }
}
