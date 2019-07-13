using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavoiur : MonoBehaviour
{
    private bool _open;
    private float _timer;
    private Animator _anim;
    [SerializeField]
    private GameObject[] _particles; //child dust particles
    void Start()
    {
        _timer = 0;
        _open = false;
        _anim = GetComponentInChildren<Animator>();
        _particles[0].SetActive(false);
        _particles[1].SetActive(false);
    }

    
    void Update()
    {
        if(_open == true && transform.position.y < 17.34)
        {
            this.transform.position = this.transform.position + new Vector3(0,0.05f,0);//moves the door up

            //start animation like dust
            
            _particles[0].SetActive(true);
            _particles[1].SetActive(true);

            _anim.SetBool("Tremble",true);
        }else if(_open == true && transform.position.y >= 17.34)
        {


            _anim.SetBool("Tremble", false);
            
            //call the end of the dust particle
            EndDustParticle();
            
        }
    }
    private void EndDustParticle()//a little timer that extend the duration of the dust particles after the door stoped moving
    {
        if(_timer == 0)
        {
            _timer = Time.time + 3;
        }
        if(_timer <= Time.time)
        {
            
            _particles[0].SetActive(false);
            _particles[1].SetActive(false);
            _open = false;
        }
        
    }
    private void OpenDoor()
    {
        _open = true;
    }
}
