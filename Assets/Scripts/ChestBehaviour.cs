using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ChestBehaviour : MonoBehaviour
{
    public HingeJoint hingeJoint;
    public float minTurnAngle;
    private XRSocketInteractor chestSocket;

    private void Awake()
    {
        chestSocket = GetComponent<XRSocketInteractor>();
    }
    
    void OnEnable()
    {
        chestSocket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        chestSocket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        ChestUnlock();
    }

    private void ChestUnlock()
    {
        JointLimits limit = hingeJoint.limits;
        limit.min = minTurnAngle;
        hingeJoint.limits = limit;
        
        Debug.Log("Limit removed");
    }
}
