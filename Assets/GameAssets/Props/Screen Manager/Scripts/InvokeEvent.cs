using UltEvents;
using UnityEngine;

public class InvokeEvent : MonoBehaviour
{
    public UltEvent Event;

    public void Invoke()
    {
        Event?.Invoke();
    }
}
