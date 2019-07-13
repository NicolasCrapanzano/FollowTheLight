using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleBox : MonoBehaviour
{
    public int ID;
    private bool _alreadyActivatedText;
    [SerializeField]
    private GameObject _child,_child2;
    private GameManager _gm;
    [SerializeField]
    private Sprite[] _sprites;
    private SpriteRenderer _sr,_sr2;
    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _sr = _child.GetComponent<SpriteRenderer>();
        _sr2 = _child2.GetComponent<SpriteRenderer>();
        _sr.sprite = _sprites[ID];
        _sr2.sprite = _sprites[ID];
        _alreadyActivatedText = false;
    }
    private void CorrectPiece()
    {
        _child.SetActive(true);

        _gm.SendMessage("ClosePuzzle",1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_alreadyActivatedText == false)
        {
            if (collision.CompareTag("Player") && ID == 0)//when the player collide with the first box a message should apear
            {
                _alreadyActivatedText = true;
                _gm.ChangeText("This mark look familiar . . .", 3);
            }
        }
    }
}
