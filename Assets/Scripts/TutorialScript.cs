using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
   // Triggers + AudioSource
   [SerializeField] private GameObject[] triggerZones;
   [SerializeField] private GameObject[] teleportZones;
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private GameObject door;
   
   // Variables
   [SerializeField] private int currentTriggerIndex;
   [SerializeField] private int currentTeleportIndex;
   private bool triggersComplete;
   private bool teleportComplete;
   private bool tutorialComplete;
   
   public static TutorialScript Instance;

   void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

   void Start()
   {
      // Only enables the first trigger zone to be enabled
      if (triggerZones != null)
      {
         for (int i = 0; i < triggerZones.Length; i++)
         {
            triggerZones[i].SetActive(i == 0);
         }
      }
      
      // Disable all the teleport areas
      foreach (var teleport in teleportZones)
      {
         teleport.SetActive(false);
      }
   }
   
   /// <summary>
   /// This function helps settle the triggers being enabled or not
   /// </summary>
   public void TriggerZoneEntered()
   {
      // Null check
      if (triggerZones == null) return;
      
      audioSource.PlayOneShot(audioSource.clip);
      triggerZones[currentTriggerIndex].SetActive(false);
      currentTriggerIndex++;

      if (currentTriggerIndex < triggerZones.Length)
      {
         // Unlock the next trigger zone
         triggerZones[currentTriggerIndex].SetActive(true);
      }
      else
      {
         // Finishes the trigger zones and enables the first teleport zone
         triggersComplete = true;
         door.SetActive(false);
         UIManager.Instance.EnableLevel2UI();
         teleportZones[currentTeleportIndex].SetActive(true);
      }
   }
   
   /// <summary>
   /// This function settles the teleporters being enabled
   /// </summary>
   public void TeleportZoneEntered()
   {
      // Null checks
      if (!triggersComplete) return;
      if (teleportZones == null) return;
      
      currentTeleportIndex++;

      if (currentTeleportIndex < teleportZones.Length)
      {
         teleportZones[currentTeleportIndex].SetActive(true);
      }
      else
      {
         // Enable the tutorial end UI
         teleportComplete = true;
         TutorialComplete();
         Debug.Log("Tutorial completed!");
      }
   }

   private IEnumerator Delay()
   {
      yield return new WaitForSeconds(5.67f);
   }
   
   /// <summary>
   /// This will enable the end of the tutorial UI
   /// </summary>
   public void TutorialComplete()
   {
      if (!triggersComplete) return;
      if (!teleportComplete) return;
   
      tutorialComplete = true;
      UIManager.Instance.EnableCompleteUI();
      
      // load into the next scene
      StartCoroutine(Delay());
      SceneManager.LoadScene("CA5");
   }
}
