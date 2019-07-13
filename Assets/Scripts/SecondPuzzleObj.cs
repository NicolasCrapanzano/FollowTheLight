using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleObj : MonoBehaviour
{
    [SerializeField]
    private int _ID;
    private int _otherID;
    private SecondPuzzleBox _boxTemporal;
    private MouseBehaviour _mouse;
    private SpriteRenderer _Sr;
    [SerializeField]
    private Sprite[] _sprites;

    void Start()
    {
        _mouse = FindObjectOfType<MouseBehaviour>();
        _Sr = GetComponent<SpriteRenderer>();
        _Sr.sprite = _sprites[_ID];
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Puzzle2"))
        {
            _boxTemporal = other.gameObject.GetComponent<SecondPuzzleBox>();
            _otherID = _boxTemporal.ID;       
            if(_ID == _otherID) 
            {
                //if the piece is the correct one then
                _boxTemporal.SendMessage("CorrectPiece");
                _mouse.SendMessage("ChildrenState");
                Destroy(this.gameObject);
            }
            
        }
    }
}
