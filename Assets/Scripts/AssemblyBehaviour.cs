using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class AssemblyBehaviour : MonoBehaviour
{
    
    [Header("Sockets")]
    public XRSocketInteractor socketA;
    public XRSocketInteractor socketB;
    public XRSocketInteractor socketC;

    [Header("Final Item")]
    public Transform finalItemLocation;
    public GameObject finalItemPrefab;

    [Header("TP Mat")] 
    public TeleportationArea teleportMat;
    
    private bool completed = false;

    void Update()
    {
        if (completed) return;

        // Check if all sockets have something
        if (socketA.hasSelection &&
            socketB.hasSelection &&
            socketC.hasSelection)
        {
            CompleteAssembly();
        }
    }

    void CompleteAssembly()
    {
        completed = true;

        // Hide inserted parts
        socketA.interactablesSelected[0].transform.gameObject.SetActive(false);
        socketB.interactablesSelected[0].transform.gameObject.SetActive(false);
        socketC.interactablesSelected[0].transform.gameObject.SetActive(false);

        // Spawn final item
        Instantiate(finalItemPrefab, finalItemLocation.position, finalItemLocation.rotation);
        
        // Enable the teleport mat
        teleportMat.enabled = true;
    }
}