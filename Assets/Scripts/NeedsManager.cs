using System;
using UnityEngine;
using UnityEngine.Rendering;

public class NeedsManager : MonoBehaviour
{
    public static NeedsManager Instance { get; private set; }

    [SerializeField] private float hungerValue = 1.0f;
    [SerializeField] private float hungerRate = 0.05f;
    [SerializeField] private float boredomValue = 1.0f;
    [SerializeField] private float boredomRate = 0.09f;
    [SerializeField] private float sleepValue = 1.0f;
    [SerializeField] private float sleepRate = 0.025f;


    public static event Action <float> hungerUpdated;
    public static event Action <float> boredomUpdated;
    public static event Action <float> sleepUpdated;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        InvokeRepeating(nameof(DepleteHunger), 1.0f, 0.5f);
        InvokeRepeating(nameof(DepleteBoredom), 1.0f, 0.5f);
        InvokeRepeating(nameof(DepleteSleep), 1.0f, 0.5f);
    }

    private void DepleteHunger()
    {
        hungerValue -= 1 * hungerRate;
        hungerUpdated.Invoke(hungerValue);
        Debug.Log("Hunger Value: " + hungerValue);
    }

    private void DepleteBoredom()
    {
        boredomValue -= 1 * boredomRate;
        boredomUpdated.Invoke(boredomValue);
        Debug.Log("Boredom Value: " + boredomValue);
    }

    private void DepleteSleep()
    {
        sleepValue -= 1 * sleepRate;
        sleepUpdated.Invoke(sleepValue); 
        Debug.Log("Sleep Value: " + sleepValue);
    }
    // Get/Set Hunger Value
    void SetHungerValue(float value)
    {
        hungerValue = value;
    }

    float GetHungerValue()
    {
        return hungerValue;
    }
    // Get/Set Boredom Value
    void SetBoredomValue(float value)
    {
        boredomValue = value;
    }

    float GetBoredomValue()
    {
        return boredomValue;
    }

    // Get/Set Sleep Value
    void SetSleepValue(float value)
    {
        sleepValue = value;
    }

    float GetSleepValue()
    {
        return sleepValue;
    }
}
