using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    // TM textfields;
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public TMP_Text validationText;
    
    private string usernameInput = "admintest";
    private string passwordInput = "admintest";

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(4);
    }

    public void loginUser()
    {
       if (EmailInput.text == usernameInput && PasswordInput.text == passwordInput)
        {
            validationText.text = "Login Successful!";
            
            StartCoroutine(loadScene());

        }
        else
        {
            validationText.text = "Login Failed. Please try again.";

            // StartCoroutine(delay());

            // validationText.text = "";

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
}
