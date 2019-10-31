using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatMediator : MonoBehaviour
{
    [SerializeField] private int maxOverheatValue;
    [SerializeField] private int currentOverheatValue;
    [SerializeField] private int thresholdOverheatValue;
    [SerializeField] private float overheatReduceAmount;
    [SerializeField] private float overheatReduceTime;

    private CurrentOverheat currentOverheat;
    private MaxOverheat maxOverheat;
    private ThresholdOverheat thresholdOverheat;

    private float reductionTime;
    
    void Awake()
    {
        if ((CurrentOverheat = GetComponent<CurrentOverheat>()) == null)
        {
            CurrentOverheat = this.gameObject.AddComponent<CurrentOverheat>();
        }
        if ((MaxOverheat = GetComponent<MaxOverheat>()) == null)
        {
            MaxOverheat = this.gameObject.AddComponent<MaxOverheat>(); 
        }
        if ((ThresholdOverheat = GetComponent<ThresholdOverheat>()) == null)
        {
            ThresholdOverheat = this.gameObject.AddComponent<ThresholdOverheat>();
        }

        CurrentOverheat.Attribute = CurrentOverheatValue;
        MaxOverheat.Attribute = MaxOverheatValue;
        ThresholdOverheat.Attribute = ThresholdOverheatValue;
    }
    
    void Reset()
    {
        if ((CurrentOverheat = GetComponent<CurrentOverheat>()) == null)
        {
            CurrentOverheat = this.gameObject.AddComponent<CurrentOverheat>();
        }
        if ((MaxOverheat = GetComponent<MaxOverheat>()) == null)
        {
            MaxOverheat = this.gameObject.AddComponent<MaxOverheat>();
        }

        CurrentOverheat.Attribute = CurrentOverheatValue;
        MaxOverheat.Attribute = MaxOverheatValue;
    }

    void Update()
    {
        reductionTime += Time.deltaTime;

        if (reductionTime >= overheatReduceTime)
        {
            DecreaseCurrentOverheat((int) (Time.deltaTime * overheatReduceAmount));
        }
    }

    public void IncreaseCurrentOverheat(int value)
    {
        if ((CurrentOverheat.Attribute + value) >= MaxOverheat.Attribute)
        {
            CurrentOverheat.Attribute = MaxOverheat.Attribute;
        }
        else
        {
            CurrentOverheat.Attribute += MaxOverheat.Attribute;
        }

        overheatReduceTime = 0;
    }

    public void DecreaseCurrentOverheat(int value)
    {
        if ((CurrentOverheat.Attribute - value) <= 0)
        {
            CurrentOverheat.Attribute = 0;
        }
        else
        {
            CurrentOverheat.Attribute -= value;
        }
    }

    public void IncreaseMaxOverheat(int value)
    {
        MaxOverheat.Attribute += value;
    }

    public void DecreaseMaxOverheat(int value)
    {
        if ((MaxOverheat.Attribute - value) <= 0)
        {
            MaxOverheat.Attribute = 0;
        }
        else
        {
            MaxOverheat.Attribute -= value;
        }
    }

    public void SetThresholdOverheat(int value)
    {
        if (value < 0)
        {
            ThresholdOverheat.Attribute = 0;
        }
        else if (value > MaxOverheat.Attribute)
        {
            ThresholdOverheat.Attribute = MaxOverheat.Attribute;
        }
        else
        {
            ThresholdOverheat.Attribute = value;
        }
    }

    public void SubcribeToCurrentOverheat(GenericIntObserverMethod newObserser)
    {
        CurrentOverheat.Subcribe(newObserser);
    }

    public void UnsubcribeToCurrentOverheat(GenericIntObserverMethod newObserser)
    {
        CurrentOverheat.Unsubcribe(newObserser);
    }

    public void SubcribeToMaxOverheat(GenericIntObserverMethod newObserser)
    {
        MaxOverheat.Subcribe(newObserser);
    }

    public void UnsubcribeToMaxOverheat(GenericIntObserverMethod newObserser)
    {
        MaxOverheat.Unsubcribe(newObserser);
    }

    public void SubcribeToThresholdOverheat(GenericIntObserverMethod newObserser)
    {
        ThresholdOverheat.Subcribe(newObserser);
    }

    public void UnsubcribeToThresholdOverheat(GenericIntObserverMethod newObserser)
    {
        ThresholdOverheat.Unsubcribe(newObserser);
    }

    public CurrentOverheat CurrentOverheat { get => currentOverheat; set => currentOverheat = value; }
    public MaxOverheat MaxOverheat { get => maxOverheat; set => maxOverheat = value; }
    public int MaxOverheatValue { get => maxOverheatValue; set => maxOverheatValue = value; }
    public int CurrentOverheatValue { get => currentOverheatValue; set => currentOverheatValue = value; }
    public int ThresholdOverheatValue { get => thresholdOverheatValue; set => thresholdOverheatValue = value; }
    public ThresholdOverheat ThresholdOverheat { get => thresholdOverheat; set => thresholdOverheat = value; }
}
