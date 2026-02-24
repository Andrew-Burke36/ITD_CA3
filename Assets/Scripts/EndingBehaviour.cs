using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class EndingBehaviour : MonoBehaviour
{
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        CompleteGame();
    }
    
    // Shows the end game UI
    private void CompleteGame()
    {
       UIManager.Instance.EnableCompleteUI();
    }
}
