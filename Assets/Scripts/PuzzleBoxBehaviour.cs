using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBoxBehaviour : MonoBehaviour
{
    private int _count, _actualCharge;//510
    private bool _isActive;
    private SpriteRenderer _sr;
    private GameManager _gm;
    [SerializeField]
    private GameObject _child;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _gm = FindObjectOfType<GameManager>();
        _isActive = true;
        _sr.color = new Color32(255,255,255,255);
        _count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isActive == true)
        {
            if (collision.CompareTag("PuzzleTorch"))
            {
                if (_count < 255)
                {
                    _count++;
                    Debug.Log(_count);
                    _sr.color = _sr.color - new Color32(0, 1, 1, 0);
                    //grow spritemask (x 7.3 ; y 3.2 ;)
                    
                }
                else
                {
                    //terminó
                    _isActive = false;
                    _gm.SendMessage("ClosePuzzle", 1);
                    //instantiate particle

                }
            }
        }
    }
}
