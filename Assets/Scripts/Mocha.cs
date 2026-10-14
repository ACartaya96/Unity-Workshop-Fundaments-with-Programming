using UnityEngine;

public class Mocha : MonoBehaviour
{
    public bool mHungry = false;
    public bool mBored = false;
    public bool mSleepy = false;

    [SerializeField] private float hungerThreshold = 0.5f;
    [SerializeField] private float boredomThreshold = 0.5f;
    [SerializeField] private float sleepThreshold = 0.5f;

    private void OnEnable()
    {
        
        NeedsManager.hungerUpdated += CheckHungerStatus;
        NeedsManager.boredomUpdated += CheckBoredomStatus;
        NeedsManager.sleepUpdated += CheckSleepStatus;
    }

    private void OnDisable()
    {
       
        NeedsManager.hungerUpdated -= CheckHungerStatus;
        NeedsManager.boredomUpdated -= CheckBoredomStatus;
        NeedsManager.sleepUpdated -= CheckSleepStatus;
    }
    // TODO EXERCISE 6: CONDITIONALS
    private void CheckHungerStatus(float value)
    {
        
       
    }

    private void CheckBoredomStatus(float value)
    {
    }

    private void CheckSleepStatus(float value)
    {
     
        // TODO EXERCISE 7: CONDITIONALS CONT.
      
    }

    public void PlayWithMocha()
    {
        float newValue = NeedsManager.Instance.GetBoredomValue() + 0.3f;
        NeedsManager.Instance.SetBoredomValue(newValue);
        Debug.Log("You played with Mocha");
    }
}
