using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.EventSystems;


/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{
    [Tooltip("Switch even if an object is selected")]
    public bool forceToggle = false;

    [Tooltip("The direct interactor that's switched to")]
    public XRDirectInteractor directInteractor = null;

    private XRRayInteractor rayInteractor = null;
    private bool isSwitched = false;

    private EventSystem eventSystem;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        SwitchInteractors(false); // moved to here
    }

    private void Start()
    {
        //SwitchInteractors(false);
        rayInteractor.enabled = false;
        eventSystem = EventSystem.current;
    }

    public void ActivateRay()
    {
        if (!TouchingObject() || forceToggle)
            SwitchInteractors(true);
    }

    public void DeactivateRay()
    {
        if (isSwitched)
            SwitchInteractors(false);
    }

    private bool TouchingObject()
    {
        //List<XRBaseInteractable> targets = new List<XRBaseInteractable>();
        List<IXRInteractable> targets = new List<IXRInteractable>();
        directInteractor.GetValidTargets(targets);
        return (targets.Count > 0);
    }

    /*
    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        rayInteractor.enabled = value;
        directInteractor.enabled = !value;
    }
    */
    private void SwitchInteractors(bool value)
    {
        if (rayInteractor != null && directInteractor != null)
        {
            if (value && !isSwitched) // Check if ray interaction is not already enabled
            {
                DisableSelectedGameObject();
                rayInteractor.enabled = true;
                directInteractor.enabled = false;
                isSwitched = true;
            }
            else if (!value && isSwitched) // Check if direct interaction is not already enabled
            {
                rayInteractor.enabled = false;
                directInteractor.enabled = true;
                isSwitched = false;
            }
        }
    }

    private void DisableSelectedGameObject()
    {
        if (eventSystem != null)
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
}
