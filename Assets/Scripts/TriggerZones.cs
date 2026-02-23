using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Tutorials.Core.Editor;

public class TriggerZones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (gameObject.CompareTag("TriggerZone"))
        {
            // Call the manager script to enable the correct trigger zone
            TutorialScript.Instance.TriggerZoneEntered();
        }
        else if (gameObject.CompareTag("TeleportZone"))
        {
            TutorialScript.Instance.TeleportZoneEntered();
        }
    }
}
