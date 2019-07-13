using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private PlayerBehaviour _pl;
    private GameManager _gm;
    void Start()
    {
        _pl = FindObjectOfType<PlayerBehaviour>();
        _gm = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("ganaste bro");
            _gm.ChangeText("Finally free. . .",3);
        }
    }
}
