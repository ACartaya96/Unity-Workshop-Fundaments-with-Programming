using System;
using System.Collections;
using UnityEngine;

public class NeedsManager : MonoBehaviour
{
    public static NeedsManager Instance { get; private set; }
    [SerializeField] private float tickRate = 0.5f;

    // TODO EXERCISE 1


    public static event Action<float> hungerUpdated;
    public static event Action<float> boredomUpdated;
    public static event Action<float> sleepUpdated;

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
    // TODO EXERCISE 2: VARIABLES AND ARITHMETIC
    private void DepleteHunger()
    {
      
    }

    private void DepleteBoredom()
    {
       
    }

    private void DepleteSleep()
    {
   
    }

    public void SetHungerValue(float value) { hungerValue = value; hungerUpdated.Invoke(hungerValue); }
    public float GetHungerValue() { return hungerValue; }
    public void SetBoredomValue(float value) { boredomValue = value; boredomUpdated.Invoke(boredomValue); }
    public float GetBoredomValue() { return boredomValue; }
    public void SetSleepValue(float value) { sleepValue = value; sleepUpdated.Invoke(sleepValue); }
    public float GetSleepValue() { return sleepValue; }

    public IEnumerator SleepRoutine()
    {
        CancelInvoke(nameof(DepleteSleep));

        // TODO EXERCISE 3: LOOPS
            // UNITY LIBRARY: This pauses the execution for a brief moment so the game doesn't crash
            yield return new WaitForSeconds(1.0f);
       

        InvokeRepeating(nameof(DepleteSleep), 1.0f, tickRate);
    }
}
