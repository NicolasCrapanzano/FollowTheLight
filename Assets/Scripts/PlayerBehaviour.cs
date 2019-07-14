using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool enableAnimRoot;
    private GameManager _gm;
    private Animator _anim;
    private SpriteRenderer _sr;
    private TorchStand _torchStand;
    [SerializeField]
    private GameObject _armEmpty, _armWTorch;
    [SerializeField]
    private int ChangeGO,_stopWalk;
    private bool _canGetTorch,_torchActive,_fireOn, _CanPlay,_puzzleEnded,_secondPuzzleEnded,_torchLeft;
    public bool animEnd;
    
    void Start()
    {
        animEnd = false;
        _torchActive = false;
        _canGetTorch = false;
        _puzzleEnded = false;
        _secondPuzzleEnded = false;
        _speed = 4.5f;
        _anim = GetComponent<Animator>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _gm = FindObjectOfType<GameManager>();
        
    }

    
    void Update()
    {
        if(enableAnimRoot == true)
        {

            _anim.applyRootMotion = true;
            animEnd = enableAnimRoot;
        }
        if(Input.GetKey(KeyCode.D)&&_stopWalk != 1)
        {

            transform.rotation = new Quaternion(0,0,0,0);
            transform.Translate(new Vector3(_speed, 0, 0) * Time.deltaTime);
            _anim.SetBool("IsRunning", true);
            _anim.SetFloat("X", 1);

        }else
        {

            _anim.SetBool("IsRunning", false);

        }

        if(Input.GetKey(KeyCode.A) && _stopWalk != 1)
        {

            transform.rotation = new Quaternion(0, -180, 0, 0);
            transform.Translate( new Vector3(_speed, 0, 0) * Time.deltaTime);
            _anim.SetBool("IsRunning", true);
            _anim.SetFloat("X", 0);

        }

        if (_CanPlay==true && Input.GetKeyDown(KeyCode.Space) && _puzzleEnded == false && _torchActive == true)
        {

            _gm.SendMessage("OpenPuzzle");
            _puzzleEnded = true;
            

        }else if(Input.GetKeyDown(KeyCode.Space) && _torchActive == false)
        {

            _gm.ChangeText("I need some kind of portable light to do this. . .",3);

        }

        if (_torchActive == false &&_fireOn == true && _canGetTorch == true && Input.GetKeyDown(KeyCode.E))
        {

            _torchActive = true;
            _armEmpty.SetActive(false);
            _armWTorch.SetActive(true);
            _gm.ChangeText("Now i can continue",1);

        }
        if (ChangeGO == 1)//this changes when the animation leaving the torch reach the middle
        {
            LeaveTorch();
        }
    }
    private void FireOn(bool on)
    {

        _fireOn = on;

    }
    private void LeaveTorch()//leave the torch when leaving the cave
    {
        _gm.ChangeText("Finally free . . .",3);
        _armEmpty.SetActive(true);
        _armWTorch.SetActive(false);
        _anim.SetInteger("LeaveTorch", 0);
        _torchStand.SendMessage("ActiveTorch");
    }
    private void FinalPuzzleEnded()
    {
        _secondPuzzleEnded = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    
        if(collision.CompareTag("Sticks"))
        {

            _canGetTorch = true;

        }

        if (_puzzleEnded == false)
        {

            if (collision.CompareTag("Pedestal"))//al entrar en rango con el pedestal (segundo puzzle)
            {

 
                _CanPlay = true;
                _gm.ChangeText("(Press 'Space' to open the puzzle)",2); //cambio de texto en el gamemanager

            }

        }
        if (collision.CompareTag("TorchStand"))//start leaveTorch animation 
        {
            if (_secondPuzzleEnded == true && _torchLeft == false)//only if  the last puzzle is completed
            {
                _torchStand = collision.GetComponent<TorchStand>();
                _anim.SetInteger("LeaveTorch", 1);
                _torchLeft = true;
            }
            else
            {
                _gm.ChangeText("This looks like the exit, so close . . .", 3);
            }
        }
        
        
            
            
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        _canGetTorch = false;
        if (collision.CompareTag("Pedestal"))
        {

            _CanPlay = false;

        }

    }
}
