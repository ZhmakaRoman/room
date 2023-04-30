using System;
using UnityEditor;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;
    private Animator _animator;
    private bool _isOpen;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //  //Данный метод будет создает  луч из точки экрана где находится наша мышка  
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
      
        //узнаём попал ли наш луч
        if (Physics.Raycast(ray,1f,_layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E) )
            {
                SwitchDoorState();
            }
            
        }
       
        
    }
 

    public void SwitchDoorState()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("isOpen", _isOpen);
    }


}