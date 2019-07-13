using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelFire : MonoBehaviour
{
    public GameObject _glow;
    private WoodFire _wf;
    private MouseBehaviour _mouse;
    void Start()
    {
        _mouse = FindObjectOfType<MouseBehaviour>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("WoodFire"))
        {
            _wf = collision.GetComponent<WoodFire>();
            Debug.Log("Light this!");
            _wf.SendMessage("SetON");
            _mouse.SendMessage("ChildrenState",false);
            Destroy(this.gameObject);
        }
    }
}
