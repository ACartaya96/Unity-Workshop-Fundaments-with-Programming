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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckHungerStatus(float value)
    {
        if (value <= hungerThreshold)
        {
            mHungry = true;
            return;
        }

        mHungry = false;
    }

    private void CheckBoredomStatus(float value)
    {
        if (value <= boredomThreshold)
        {
            mBored = true;
            return;
        }

        mBored = false;
    }

    private void CheckSleepStatus(float value)
    {
        if (value  <= sleepThreshold)
        {
            mSleepy = true;
            return;
        }

        mSleepy = false;
    }

    public void PlayWithMocha()
    {
        float newValue = NeedsManager.Instance.GetBoredomValue() + 0.3f;
        NeedsManager.Instance.SetBoredomValue(newValue);

        Debug.Log("You played with Mocha");
    }
}
