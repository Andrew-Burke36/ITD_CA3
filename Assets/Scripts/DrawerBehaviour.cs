using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DrawerBehaviour : MonoBehaviour
{
    // variables
    public ConfigurableJoint drawerJoint;
    public float maxZLimit;
    private XRSocketInteractor drawerSocket;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        drawerSocket =  GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        drawerSocket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        drawerSocket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        DrawerUnlock();
    }
    
    /// <summary>
    /// set the new z limit for the drawer
    /// </summary>
    private void DrawerUnlock()
    {
        // set new limit
        SoftJointLimit limit = drawerJoint.linearLimit;
        limit.limit = maxZLimit;
        drawerJoint.linearLimit = limit;
        Debug.Log("Drawer unlocked");
    }
}
