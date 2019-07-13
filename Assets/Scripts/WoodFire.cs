using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFire : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _isactive;
    [SerializeField]
    private GameObject _glow, _particle;
    [SerializeField]
    private Sprite _fireOn;
    private SpriteRenderer _sr;
    private PlayerBehaviour _pl;
    private GameManager _gm;
    void Start()
    {

        _isactive = false;
        _pl = FindObjectOfType<PlayerBehaviour>();
        _sr = GameObject.FindGameObjectWithTag("Sticks").GetComponent<SpriteRenderer>();
        _gm = FindObjectOfType<GameManager>();

    }

    void Update()
    {

        //if is active is true tell game manager to change the text

    }
    public void SetON()
    {

        _isactive = true;
        _pl.SendMessage("FireOn",true);
        //_sr.sprite = _fireOn;
        _glow.SetActive(true);
        _particle.SetActive(true);
        _gm.ChangeText("I should take a torch to see the path ahead",1);

    }
}
