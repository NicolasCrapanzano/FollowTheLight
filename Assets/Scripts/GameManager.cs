using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera _puzzleCamera;
    [SerializeField]
    private DoorBehavoiur _door,_finalDoor;
    [SerializeField]
    private Text _character,puzzle;
    [SerializeField]
    private GameObject _puzzle;
    private PlayerBehaviour _pl;
    private Animator _plAnimator;
    private MouseBehaviour _mouse;
    private bool _textVanish,_diplayTextAgain,_debugHK,_firstPuzzleEnded,_gameStarted; 
    [SerializeField]
    private string[] _words,_words2;
    private int _count, _puzzleSolved,_secondPuzzle,contadorsito,_idTxtProg;
    private float _timer, _vanishSpd;
    void Start()
    {
        _gameStarted = false;
        contadorsito = 0;
        _puzzleCamera.depth = -2;
        _words = new string[] {"Where i am? . . . ", "I cant see a thing, i should get some fire... ", "(Do it by moving the cursor over the glowing flint&steel an press the left button)", "(Press E near the WoodFire to take a torch)" };
        _textVanish = false;
        _diplayTextAgain = true;
        _count = 0;
        //ChangeText(_words[_count],0);
        _mouse = FindObjectOfType<MouseBehaviour>();
        _pl = FindObjectOfType<PlayerBehaviour>();
        _plAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void StartGame()
    {
        _gameStarted = true;
        _mouse.SendMessage("ChangeLayer", 1);
        _plAnimator.SetBool("GameStarted", _gameStarted);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        if (_gameStarted == true)
        {
            
            if (_textVanish == true)
            {
                TextVanish();
            } else if (_textVanish == false && _timer >= Time.time)
            {
                if (_count < _words.Length && _diplayTextAgain == true)
                {
                    ChangeText(_words[_count], 0);
                    _diplayTextAgain = false;
                }
            }

        } else
        {
            _timer = Time.time + 1;
        }
        DebugHotKeys();
    }
    public void ChangeText(string word , int id)//paso de parametro 1 la palabra 2 la seccion de palabras 0=primer puzzle (fogata) 1=  
    {
        float temp = word.Length * word.Length;
        _vanishSpd = 0.07f + word.Length / temp;
        _character.color = new Color32(255, 255, 255, 255);
        if (id == 0 && _count <= _words.Length)
        {
            _character.text = _words[_count];
            _textVanish = true;
        }else if(id > 0)
        {
            _character.text = word;
            _textVanish = true;
            if(id == 1)
            {
                _idTxtProg = id;
            }
        }
    }
    private void OpenPuzzle()//se inicia el puzzle muestra la camara secundaria por delante y activa la antorcha del puzzle
    {
        _puzzle.SetActive(true);
        _puzzleCamera.depth = 1;
    }
    private void ClosePuzzle(int c)//this function works for the first puzzle and the last one
    {
        if (_firstPuzzleEnded == false) // first puzzle
        {
            _puzzleSolved = _puzzleSolved + c;
            puzzle.text = _puzzleSolved + " / 3";
            if (_puzzleSolved >= 3)
            {
                _firstPuzzleEnded = true;
                _mouse.SendMessage("EnableFinalPuzzle");
                _puzzleCamera.depth = -2;
                _puzzle.SetActive(false);
                _door.SendMessage("OpenDoor");

            }
        }else //last puzzle
        {
            _secondPuzzle = _secondPuzzle + c;
            if (_secondPuzzle >= 3)
            {
                _finalDoor.SendMessage("OpenDoor");
                _pl.SendMessage("FinalPuzzleEnded");
            }
        }
    }
    
    private void TextVanish()
    {
        if (_character.color.a > 0)
        {
            _character.color = _character.color - new Color(0, 0, 0, _vanishSpd)*Time.deltaTime;
        } else
        {
            _character.text = " ";
            _character.color = new Color32(255, 255, 255, 255);
            _textVanish = false;
            if (_count < 2)
            { 
                _count = _count + 1;
                _diplayTextAgain = true;
            }else if(_idTxtProg == 1)
            {
                _count++;
                _diplayTextAgain = true;
            }
            _timer = Time.time + 1;
        }
    }
    private void DebugHotKeys() 
    {
        
        if (Input.GetKey(KeyCode.F9))
        {

            contadorsito = contadorsito +1;
            

            if(contadorsito >= 200)
            {
                _debugHK = true;
                Debug.Log("modo de prueba activado");
            }

        }

        if (_debugHK == true)
        {
            if (Input.GetKeyDown(KeyCode.F10))//open door
            {
                Debug.Log("puerta forzada");
                _door.SendMessage("OpenDoor");
                _mouse.SendMessage("EnableFinalPuzzle");
                _firstPuzzleEnded = true;
            }

            if(Input.GetKeyDown(KeyCode.F11))
            {
                Debug.Log("puerta final forzada");
                _finalDoor.SendMessage("OpenDoor");
                _pl.SendMessage("FinalPuzzleEnded");
            }

        }

    }

}
