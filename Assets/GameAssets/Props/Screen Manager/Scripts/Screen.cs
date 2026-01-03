using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    public abstract bool ShouldPreload();
    public abstract void Preload();
    public abstract void Show();
    public abstract void Hide();
    public bool activeSelf { get => activeSelf; }
}
