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
    private int currentRow = 0;
    private int currentColumn = 0;

    void Start()
    {
        HighlightButton();
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
            currentRow = Mathf.Max(0, currentRow - 1);
            currentColumn = Mathf.Min(currentColumn, buttonGrid[currentRow].buttons.Count - 1);
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentRow = Mathf.Min(buttonGrid.Count - 1, currentRow + 1);
            currentColumn = Mathf.Min(currentColumn, buttonGrid[currentRow].buttons.Count - 1);
            HighlightButton();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            currentColumn = Mathf.Max(0, currentColumn - 1);
            HighlightButton();;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentColumn = Mathf.Min(buttonGrid[currentRow].buttons.Count - 1, currentColumn + 1);
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
        buttonGrid[currentRow].buttons[currentColumn].GetComponent<Image>().color = Color.white;
    }
    
}
