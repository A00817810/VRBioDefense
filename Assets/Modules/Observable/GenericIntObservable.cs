using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericIntObservable : MonoBehaviour
{
    public delegate void GenericIntObserverMethod(int newValue);

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

    public void subcribe(GenericIntObserverMethod newObserver)
    {
        observers.Add(newObserver);
    }

    public void unsubcribe(GenericIntObserverMethod toRemoveObserver)
    {
        observers.Remove(toRemoveObserver);
    }
}
