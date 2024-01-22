using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticManager : MonoBehaviour
{
    public static HapticManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public XRDirectInteractor leftDirectInteractor;
    public XRDirectInteractor rightDirectInteractor;

    [Range(0, 1)]
    public float hapticIntensity = 0.5f;
    public float hapticDuration = 0.50f;


    // Start a haptic impulse with the default intensity and duration
    public void LeftOrRightStandardHaptics()
    {
        if (leftDirectInteractor.hasSelection)
        {
            leftDirectInteractor.SendHapticImpulse(hapticIntensity, hapticDuration);

        }
        if (rightDirectInteractor.hasSelection)
        {
            rightDirectInteractor.SendHapticImpulse(hapticIntensity, hapticDuration);
        }
    }

    public void PlayLeftHaptic()
    {
        float randomHapticIntensity = Random.Range(.1f, .4f);
        float randomHapticDuratrion = Random.Range(.2f, .4f);
        leftDirectInteractor.SendHapticImpulse(randomHapticIntensity, randomHapticDuratrion);
    }

    public void PlayRightHaptic()
    {
        float randomHapticIntensity = Random.Range(.1f, .4f);
        float randomHapticDuratrion = Random.Range(.2f, .4f);
        rightDirectInteractor.SendHapticImpulse(randomHapticIntensity, randomHapticDuratrion);
    }

    // Change the haptic duration to the provided value
    public void ChangeHapticDuration(float modifiedDuration)
    {
        hapticDuration = modifiedDuration;
    }

    // Change the haptic intensity to the provided value
    public void ChangeHapticIntensity(float modifiedIntensity)
    {
        hapticIntensity = modifiedIntensity;
    }
}
