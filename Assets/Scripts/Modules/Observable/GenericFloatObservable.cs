using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GenericFloatObserverMethod(float newValue);

public class GenericFloatObservable : MonoBehaviour
{
    private List<GenericFloatObserverMethod> observers = new List<GenericFloatObserverMethod>();
    [SerializeField] private float attribute;

    public float Attribute
    {
        get => attribute;
        set
        {
            attribute = value;
            foreach (GenericFloatObserverMethod observer in observers)
            {
                observer(this.attribute);
            }
        }
    }

    public List<GenericFloatObserverMethod> Observers { get => observers; set => observers = value; }

    public void Subcribe(GenericFloatObserverMethod newObserver)
    {
        observers.Add(newObserver);
    }

    public void Unsubcribe(GenericFloatObserverMethod toRemoveObserver)
    {
        observers.Remove(toRemoveObserver);
    }
}
