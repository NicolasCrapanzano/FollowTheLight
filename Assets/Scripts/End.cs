using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private PlayerBehaviour _pl;
    private GameManager _gm;
    [SerializeField]
    private GameObject _endScreen;
    private bool _isEndScreenOn;
    private float _timer;
    void Start()
    {
        _isEndScreenOn = false;
        _pl = FindObjectOfType<PlayerBehaviour>();
        _gm = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        if(_isEndScreenOn)
        {
            if (_timer <= Time.time)
            {
                _endScreen.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ganaste bro");
            _isEndScreenOn = true;
            _timer = Time.time + 3;
        }
    }
}
