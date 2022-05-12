using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Events/Event Channel")] 
public class EventChannelObject : ScriptableObject
{
    public UnityAction onEventRaised;

    //Invoke events linked to this channel
    public void RaiseEvent()
    {
        onEventRaised.Invoke();
    }


}
