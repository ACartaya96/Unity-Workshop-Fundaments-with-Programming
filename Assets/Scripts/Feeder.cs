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
}
