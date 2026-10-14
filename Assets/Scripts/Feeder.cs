using UnityEngine;

public class Feeder : MonoBehaviour
{
    public bool full = false;
    private SpriteRenderer renderer;
    [SerializeField] Sprite emptybowl;
    [SerializeField] Sprite fullbowl;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    public void FillFeeder()
    {
        if (!full)
        {
            full = true;
            renderer.sprite = fullbowl;
        }
        
    }

    public void EmptyFeeder()
    {
        full = false;
        renderer.sprite = emptybowl;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Mocha" && full)
        {
            NavMeshMovement movement = other.GetComponent<NavMeshMovement>();
            Animator animator = other.GetComponentInChildren<Animator>();

            movement.StopAgent();
            animator.Play("Eat");

            float newValue = NeedsManager.Instance.GetHungerValue() + 0.9f;
            NeedsManager.Instance.SetHungerValue(newValue);

            EmptyFeeder();
        }
    }
}
