    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GenericGameObjectObserverMethod(GameObject newValue);

public class GenericGameObjectObservable : MonoBehaviour
{
    private List<GenericGameObjectObserverMethod> observers = new List<GenericGameObjectObserverMethod>();
    [SerializeField] private GameObject attribute;

    public GameObject Attribute
    {
        get => attribute;
        set
        {
            attribute = value;
            foreach (GenericGameObjectObserverMethod observer in observers)
            {
                observer(this.attribute);
            }
        }
    }

    public List<GenericGameObjectObserverMethod> Observers { get => observers; set => observers = value; }

    public void Subcribe(GenericGameObjectObserverMethod newObserver)
    {
        observers.Add(newObserver);
    }

    public void Unsubcribe(GenericGameObjectObserverMethod toRemoveObserver)
    {
        observers.Remove(toRemoveObserver);
    }
}
