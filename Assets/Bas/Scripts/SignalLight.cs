using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(LensFlareComponentSRP))]
public class SignalLight : MonoBehaviour
{
    private enum State
    {
        Off,
        TurningOn,
        On,
        TurningOff
    }

    [SerializeField, Range(0,1f)] private float minIntensity = 0f;
    [SerializeField, Range(0, 10f)] private float maxIntensity = 5f;
    [SerializeField, Range(0,1f)] private float blinkSpeed = 1f;
    [SerializeField, Range(0, 10f)] private float onInterval = 1f;
    [SerializeField, Range(0, 10f)] private float offInterval = 3f;

    private LensFlareComponentSRP lensFlare;
    private float timeInState = 0;
    private State state;
    private void SetState(State newState)
    {
        state = newState;
        timeInState = 0f;
    }


    private void Awake()
    {        
        lensFlare = GetComponent<LensFlareComponentSRP>();
        lensFlare.intensity = minIntensity;
        SetState(State.Off);
    }
    
    private void Update()
    {
        switch (state)
        {
            case State.Off:
                if (timeInState >= offInterval)
                {
                    SetState(State.TurningOn);
                }
                break;
            case State.TurningOn:
                lensFlare.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.InverseLerp(0, blinkSpeed, timeInState));
                if (lensFlare.intensity >= maxIntensity)
                {
                    SetState(State.On);
                }
                break;
            case State.On:
                if (timeInState >= onInterval)
                {
                    SetState(State.TurningOff);
                }
                break;
            case State.TurningOff:
                lensFlare.intensity = Mathf.Lerp(maxIntensity, minIntensity, Mathf.InverseLerp(0, blinkSpeed, timeInState));
                if (lensFlare.intensity <= minIntensity)
                {
                    SetState(State.Off);
                }
                break;
        }

        timeInState += Time.deltaTime;
    }

}
