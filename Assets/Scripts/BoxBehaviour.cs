using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BoxBehaviour : MonoBehaviour
{
    public HingeJoint leftJoint;
    public HingeJoint rightJoint;
    public float hingeLimit;
    
    private XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        UnlockBox();
    }

    private void UnlockBox()
    {
        // Left side
        JointLimits leftLimit = leftJoint.limits;
        leftLimit.max = hingeLimit;
        leftJoint.limits = leftLimit;
        
        // Right side
        JointLimits rightLimit = rightJoint.limits;
        rightLimit.max = hingeLimit;
        rightJoint.limits = rightLimit;
        
        Debug.Log("Box unlocked!");
    }
}
