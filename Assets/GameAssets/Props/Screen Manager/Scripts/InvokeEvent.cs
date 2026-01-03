using UnityEngine;
using UnityEngine.Events;

public class InvokeEvent : MonoBehaviour
{
    public UnityEvent Event;

    public void Invoke()
    {
        Event?.Invoke();
    }
}
