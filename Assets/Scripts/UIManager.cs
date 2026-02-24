using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject Level2UI;
    [SerializeField] private GameObject tutorialCompleteUI;
    
    
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

    public void EnableCompleteUI()
    {
        tutorialCompleteUI.SetActive(!tutorialCompleteUI.activeSelf);
    }

    public void EnableLevel2UI()
    {
        tutorialCompleteUI.SetActive(!Level2UI.activeSelf);
    }
}
