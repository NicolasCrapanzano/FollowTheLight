using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTorchBehaviour : MonoBehaviour
{
    private Vector2 _mousePos;
    private Camera _pCamera;
    void Start()
    {
        _pCamera = GameObject.FindGameObjectWithTag("PuzzleCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        _mousePos = _pCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = _mousePos;
    }
}
