using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWallsBehaviour : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Color _original;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _original = _sr.color;
        Physics2D.IgnoreLayerCollision(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sr.color = new Color(1, 1, 1, 0.3f);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        _sr.color = _original;
    }
}
