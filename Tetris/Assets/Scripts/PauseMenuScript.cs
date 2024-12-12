using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum ButtonAction
{
    Reset,  
    StartMenu, 
    Quit     
}
public class PauseMenuScript : MonoBehaviour
{
     [System.Serializable]
    public class ButtonRow
    {
        public List<Button> buttons;  
        public List<ButtonAction> buttonActions; 
    }
    [SerializeField] private ButtonRow buttonRow;  
    private int _currentIndex = 0; 
    private static bool _gameIsPaused = false;
    public GameObject pauseMenuUI;
  
    void Start()
    {
        HighlightButton();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                pauseMenuUI.SetActive(false);
                _gameIsPaused = false;
            }
            else
            {
                pauseMenuUI.SetActive(true);
                _gameIsPaused = true;
            }
        }
        HandleNavigation();
    }
    void HandleNavigation()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentIndex = Mathf.Max(0, _currentIndex - 1);  
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentIndex = Mathf.Min(buttonRow.buttons.Count - 1, _currentIndex + 1);  
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            PerformAction(); 
        }
    }
    void HighlightButton()
    {
        foreach (var button in buttonRow.buttons)
        {
            button.GetComponent<Image>().color = Color.black;
        }
        buttonRow.buttons[_currentIndex].GetComponent<Image>().color = Color.white;
    }

    void PerformAction()
    {
        ButtonAction selectedAction = buttonRow.buttonActions[_currentIndex];

        switch (selectedAction)
        {
            case ButtonAction.Reset:
                Reset();
                break;
            case ButtonAction.StartMenu:
                StartMenu();
                break;
            case ButtonAction.Quit:
                QuitGame();
                break;
            default:
                break;
        }
    }
    void Reset()
    {
        pauseMenuUI.SetActive(false);
        _gameIsPaused = false;
    }
    void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
