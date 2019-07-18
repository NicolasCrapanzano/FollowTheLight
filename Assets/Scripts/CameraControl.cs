using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private Vector3 _offset;
    private bool _start;
    void Start()
    {
        
        _offset = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (_start == true)
        {
            if (_player.transform.position.x > 0.614f)
            {
                transform.position = _player.transform.position + _offset;
            }
        }else
        {
            _start = _player.GetComponent<PlayerBehaviour>().animEnd;
            //Debug.Log(_start);
        }
    }
}
