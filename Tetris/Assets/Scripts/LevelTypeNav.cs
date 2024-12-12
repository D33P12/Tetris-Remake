using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelTypeNav : MonoBehaviour
{
    public List<Button> row1Buttons;
    public List<Button> row2Buttons;
    private int _currentRow = 0;
    private int _currentIndex = 0;
    private List<List<Button>> _rows;
    private Button[] _selectedButtons;
    private bool _firstSelectionMade = false; 
    void Start()
    {
        _rows = new List<List<Button>> { row1Buttons, row2Buttons };
        _selectedButtons = new Button[_rows.Count];
        HighlightButton();
    }
    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _currentIndex = (_currentIndex - 1 + _rows[_currentRow].Count) % _rows[_currentRow].Count;
            HighlightButton();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _currentIndex = (_currentIndex + 1) % _rows[_currentRow].Count;
            HighlightButton();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectButton();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UndoSelection();
        }
    }
    void HighlightButton()
    {
        for (int row = 0; row < _rows.Count; row++)
        {
            for (int i = 0; i < _rows[row].Count; i++)
            {
                if (_selectedButtons[row] != _rows[row][i])
                {
                    _rows[row][i].GetComponent<Image>().color = Color.black;
                }
            }
        }
        if (_selectedButtons[_currentRow] != _rows[_currentRow][_currentIndex])
        {
            _rows[_currentRow][_currentIndex].GetComponent<Image>().color = Color.gray;
        }
    }
    void SelectButton()
    {
        _rows[_currentRow][_currentIndex].GetComponent<Image>().color = Color.white;
        _selectedButtons[_currentRow] = _rows[_currentRow][_currentIndex];

        _firstSelectionMade = true;
        if (_currentRow == 0)
        {
            _currentRow = 1;
            _currentIndex = 0;
            HighlightButton();
        }
        else if (_currentRow == 1)
        {
            SceneManager.LoadScene(3);
        }
    }
    void UndoSelection()
    {
        if (!_firstSelectionMade)
        {
            SceneManager.LoadScene(1);
            return;
        }
        for (int row = 0; row < _rows.Count; row++)
        {
            for (int i = 0; i < _rows[row].Count; i++)
            {
                _rows[row][i].GetComponent<Image>().color = Color.white;
            }
            _selectedButtons[row] = null;
        }
        _currentRow = 0;
        _currentIndex = 0;
        _firstSelectionMade = false;
        HighlightButton();
    }
}
