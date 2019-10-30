using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFloatObservable : MonoBehaviour
{
    public delegate void GenericFloatObserverMethod(float newValue);

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

    public void subcribe(GenericFloatObserverMethod newObserver)
    {
        observers.Add(newObserver);
    }

    public void unsubcribe(GenericFloatObserverMethod toRemoveObserver)
    {
        observers.Remove(toRemoveObserver);
    }
}
