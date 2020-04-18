using UnityEngine;
using UnityEngine.Events;

public abstract class Lever : MonoBehaviour
{
    public UnityEvent OnLeverTurnOn = new UnityEvent();


    public abstract float Value { get; }


}
