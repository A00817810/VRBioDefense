using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GenericIntObserverMethod(int newValue);

public class GenericIntObservable : MonoBehaviour
{
    private List<GenericIntObserverMethod> observers = new List<GenericIntObserverMethod>();
    [SerializeField] private int attribute;

    public int Attribute
    {
        get => attribute;
        set
        {
            attribute = value;
            foreach(GenericIntObserverMethod observer in observers)
            {
                observer(this.attribute);
            }
        }
    }

    public List<GenericIntObserverMethod> Observers { get => observers; set => observers = value; }

    public void Subcribe(GenericIntObserverMethod newObserver)
    {
        observers.Add(newObserver);
    }

    public void Unsubcribe(GenericIntObserverMethod toRemoveObserver)
    {
        observers.Remove(toRemoveObserver);
    }
}
