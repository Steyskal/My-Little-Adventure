using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour
{
    public static DialoguePanel Instance;

    public float CharacterDisplayInterval = 0.25f;

    [Header("Component References")]
    [SerializeField] private Text _nameText;
    [SerializeField] private Image _portraitImage;
    [SerializeField] private Text _contentText;
    [SerializeField] private Text _keyCodeText;

    private string _completeContent;
    private string _currentContent;

    private int _contentCharacterIndex = 0;

    private float _stopwatch = 0.0f;

    private Dialogue _currentDialogue;
    private int _statementIndex = 0;

    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_contentCharacterIndex < _completeContent.Length)
        {
            _stopwatch += Time.deltaTime;

            if(_stopwatch >= CharacterDisplayInterval)
            {
                _stopwatch = 0.0f;

                _currentContent += _completeContent[_contentCharacterIndex];
                _contentText.text = _currentContent;

                _contentCharacterIndex++;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _stopwatch = 0.0f;
                _currentContent = _completeContent;
                _contentText.text = _completeContent;
                _contentCharacterIndex = _completeContent.Length;
            }
        }
        else
        {
            if (_statementIndex < _currentDialogue.Statements.Count)
                _keyCodeText.text = "Press Space for next";
            else
                _keyCodeText.text = "Press Space to close";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_statementIndex < _currentDialogue.Statements.Count)
                {
                    ShowStatement(_currentDialogue.Statements[_statementIndex]);

                    _statementIndex++;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void ShowStatement(string name, Sprite portraitSprite, string content)
    {
        _nameText.text = name;
        _portraitImage.sprite = portraitSprite;
        _contentText.text = "";

        _completeContent = content;
        _currentContent = "";

        _contentCharacterIndex = 0;
        _stopwatch = 0.0f;

        _keyCodeText.text = "Press Space to skip";
    }

    private void ShowStatement(Statement statement)
    {
        ShowStatement(statement.Character.name, statement.Character.Portrait, statement.Content);
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        _currentDialogue = dialogue;
        _statementIndex = 0;

        ShowStatement(_currentDialogue.Statements[_statementIndex]);

        _statementIndex++;

        gameObject.SetActive(true);
    }
}
