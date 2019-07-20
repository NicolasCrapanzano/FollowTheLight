using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _mousePos;
    private SteelFire _sf;
    private GameManager _gm;
    private SpriteRenderer _sr;
    private bool _objInHand;
    private bool _finalPuzzle;
    void Start()
    {
        _finalPuzzle = false;
        _gm = FindObjectOfType<GameManager>();
        _sr = GetComponent<SpriteRenderer>();
        ChangeLayer(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.visible == true)
        {
            Cursor.visible = false;
        }
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _mousePos;
    }
    private void ChildrenState()
    {
        _objInHand = false;
    }
    private void ChangeLayer(int id)
    {
        Debug.Log(id);
        if (id == 1)
        {
            _sr.sortingLayerName = "FrontWalls";
            _sr.sortingOrder = 11;
        }else if (id == 2)
        {
            _sr.sortingLayerName = "Default";
            _sr.sortingOrder = 5;
        }
    }
    private void EnableFinalPuzzle()
    {
        _finalPuzzle = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("FlintSteel"))
        {
            _sf = collision.GetComponent<SteelFire>();
            
            if(Input.GetMouseButtonDown(0)&&_objInHand==false)
            {
                
                _sf._glow.SetActive(false);
                collision.gameObject.transform.SetParent(this.gameObject.transform);
                _objInHand = true;
            }
        }
        
            if (collision.CompareTag("PuzzleObj"))
            {
                if (_finalPuzzle == true && Input.GetMouseButtonDown(0) && _objInHand == false)
                {
                    collision.gameObject.transform.SetParent(this.gameObject.transform);
                    _objInHand = true;
                }else if(_finalPuzzle == false && Input.GetMouseButtonDown(0))
                {
                    _gm.ChangeText("I dont know how to use this for now . . .", 3);
                }
            }
        
    }
}
