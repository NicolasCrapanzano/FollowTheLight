using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchStand : MonoBehaviour
{
    [SerializeField]
    private GameObject _childTorch;

    private void ActiveTorch()
    {
        _childTorch.SetActive(true);
    }
    
}
