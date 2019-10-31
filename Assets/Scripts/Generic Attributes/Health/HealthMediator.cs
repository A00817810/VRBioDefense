using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMediator : MonoBehaviour
{
    [SerializeField] private float currentHealthValue;
    [SerializeField] private float maxHealthValue;

    private CurrentHealth currentHealth;
    private MaxHealth maxHealth;

    private IEnumerator coroutine;

    void Awake()
    {
        if ((CurrentHealth = GetComponent<CurrentHealth>()) == null)
        {
            CurrentHealth = this.gameObject.AddComponent<CurrentHealth>();
        }
        if ((MaxHealth = GetComponent<MaxHealth>()) == null)
        {
            MaxHealth = this.gameObject.AddComponent<MaxHealth>();
        }

        CurrentHealth.Attribute = CurrentHealthValue;
        MaxHealth.Attribute = MaxHealthValue;
    }

    void Reset()
    {
        if ((CurrentHealth = GetComponent<CurrentHealth>()) == null)
        {
            CurrentHealth = this.gameObject.AddComponent<CurrentHealth>();
        }
        if ((MaxHealth = GetComponent<MaxHealth>()) == null)
        {
            MaxHealth = this.gameObject.AddComponent<MaxHealth>();
        }

        CurrentHealth.Attribute = CurrentHealthValue;
        MaxHealth.Attribute = MaxHealthValue;
    }

    public void IncreaseCurrentHealth(float value)
    {
        if ((CurrentHealth.Attribute + value) >= MaxHealth.Attribute)
        {
            CurrentHealth.Attribute = MaxHealth.Attribute;
        }
        else
        {
            CurrentHealth.Attribute += value;
        }
    }

    public void DecreaseCurrentHealth(float value)
    {
        if ((CurrentHealth.Attribute - value) <= 0)
        {
            CurrentHealth.Attribute = 0;
        }
        else
        {
            CurrentHealth.Attribute -= value;
        }
        
    }

    public void IncreaseMaxHealth(float value)
    {
        MaxHealth.Attribute += value;
    }

    public void DecreaseMaxHealth(float value)
    {
        if ((MaxHealth.Attribute - value) <= 0)
        {
            MaxHealth.Attribute = 0;
        }
        else
        {
            MaxHealth.Attribute -= value;
        }
    }

    public void SubcribeToCurrentHealth(GenericFloatObserverMethod newObserver)
    {
        CurrentHealth.Subcribe(newObserver);
    }

    public void UnsubcribeToCurrentHealth(GenericFloatObserverMethod newObserver)
    {
        CurrentHealth.Unsubcribe(newObserver);
    }

    public void SubcribeToMaxHealth(GenericFloatObserverMethod newObserver)
    {
        MaxHealth.Subcribe(newObserver);
    }

    public void UnsubcribeToMaxHealth(GenericFloatObserverMethod newObserver)
    {
        MaxHealth.Unsubcribe(newObserver);
    }

    public float CurrentHealthValue { get => currentHealthValue; set => currentHealthValue = value; }
    public float MaxHealthValue { get => maxHealthValue; set => maxHealthValue = value; }
    public CurrentHealth CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public MaxHealth MaxHealth { get => maxHealth; set => maxHealth = value; }
}
