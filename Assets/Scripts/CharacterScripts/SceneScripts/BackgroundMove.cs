using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{
    public Button StartButton, OptionButton,QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.GetComponent<Button>().onClick.AddListener(onStartClick);
        OptionButton.GetComponent<Button>().onClick.AddListener(onOptionClick);
        QuitButton.GetComponent<Button>().onClick.AddListener(onQuitClick);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onStartClick()
    {
        SceneManager.LoadScene("PlazaScene");
    }

    void onOptionClick()
    {
        SceneManager.LoadScene("CharacterScene");
    }

    void onQuitClick()
    {
        Application.Quit();
    }
}
