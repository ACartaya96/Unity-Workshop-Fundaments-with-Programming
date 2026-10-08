using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceUpdater : MonoBehaviour
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private Slider boredomBar;
    [SerializeField] private Slider sleepBar;
    private void OnEnable()
    {
        NeedsManager.hungerUpdated += UpdateHungerBar;
        NeedsManager.boredomUpdated += UpdateBoredomeBar;
        NeedsManager.sleepUpdated += UpdateSleepBar;
    }

    private void OnDisable()
    {
        NeedsManager.hungerUpdated -= UpdateHungerBar;
        NeedsManager.boredomUpdated -= UpdateBoredomeBar;
        NeedsManager.sleepUpdated -= UpdateSleepBar;
    }

    private void UpdateHungerBar(float value)
    {
        hungerBar.value = value; 
    }

    private void UpdateBoredomeBar(float value)
    {
        boredomBar.value = value;
    }

    private void UpdateSleepBar(float value)
    {
        sleepBar.value = value;
    }
}
