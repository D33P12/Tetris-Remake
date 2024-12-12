using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectGameNavScript : MonoBehaviour
{
  [System.Serializable]
    public class ButtonRow
    {
        public List<Button> buttons;
    }
    [SerializeField] private List<ButtonRow> buttonGrid;
    private int _currentRow = 0;
    private int _currentColumn = 0;

    void Start()
    {
        HighlightButton();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        HandleNavigation();
      
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    void HandleNavigation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentRow = Mathf.Max(0, _currentRow - 1);
            _currentColumn = Mathf.Min(_currentColumn, buttonGrid[_currentRow].buttons.Count - 1);
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _currentRow = Mathf.Min(buttonGrid.Count - 1, _currentRow + 1);
            _currentColumn = Mathf.Min(_currentColumn, buttonGrid[_currentRow].buttons.Count - 1);
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _currentColumn = Mathf.Max(0, _currentColumn - 1);
            HighlightButton();;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _currentColumn = Mathf.Min(buttonGrid[_currentRow].buttons.Count - 1, _currentColumn + 1);
            HighlightButton();
        }
    }
    void HighlightButton()
    {
        foreach (var row in buttonGrid)
        {
            foreach (var button in row.buttons)
            {
                button.GetComponent<Image>().color = Color.black;
            }
        }
        buttonGrid[_currentRow].buttons[_currentColumn].GetComponent<Image>().color = Color.white;
    }
    
}
