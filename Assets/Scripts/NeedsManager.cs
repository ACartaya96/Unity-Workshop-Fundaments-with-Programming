using System;
using UnityEngine;
using UnityEngine.Rendering;

public class NeedsManager : MonoBehaviour
{
    public static NeedsManager Instance { get; private set; }
    [SerializeField] private float tickRate = 0.5f;
    [Header ("Need Values")]
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
        InvokeRepeating(nameof(DepleteHunger), 1.0f, tickRate);
        InvokeRepeating(nameof(DepleteBoredom), 1.0f, tickRate);
        InvokeRepeating(nameof(DepleteSleep), 1.0f, tickRate);
    }

    private void DepleteHunger()
    {
        Mathf.Clamp(hungerValue -= 1 * hungerRate, 0, 1);
        hungerUpdated.Invoke(hungerValue);
       // Debug.Log("Hunger Value: " + hungerValue);
    }

    private void DepleteBoredom()
    {
        Mathf.Clamp(boredomValue -= 1 * boredomRate, 0, 1);
        boredomUpdated.Invoke(boredomValue);
       // Debug.Log("Boredom Value: " + boredomValue);
    }

    private void DepleteSleep()
    {
        Mathf.Clamp(sleepValue -= 1 * sleepRate, 0, 1);
        sleepUpdated.Invoke(sleepValue); 
        //Debug.Log("Sleep Value: " + sleepValue);
    }
    // Get/Set Hunger Value
    public void SetHungerValue(float value)
    {
        hungerValue = value;
        hungerUpdated.Invoke(hungerValue);
    }

    public float GetHungerValue()
    {
        return hungerValue;
    }
    // Get/Set Boredom Value
    public void SetBoredomValue(float value)
    {
        boredomValue = value;
        boredomUpdated.Invoke(boredomValue);
    }

    public float GetBoredomValue()
    {
        return boredomValue;
    }

    // Get/Set Sleep Value
    public void SetSleepValue(float value)
    {
        sleepValue = value;
        sleepUpdated.Invoke(sleepValue);
    }

    public float GetSleepValue()
    {
        return sleepValue;
    }
}
