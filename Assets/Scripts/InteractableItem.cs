using System;
using System.Net.Http.Headers;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private int _highlightIntensity = 4;    
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Rigidbody _rigidbody;
     [SerializeField]
    private float _sideForceValue = 300f;
    
    private Outline _outline;
    private Rigidbody _rig;
   

    
    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _rig = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        PlayrAction();
        
    }


    public void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }
    
    public void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }

   private void PlayrAction()
   {
       //  //Данный метод будет создает  луч из точки экрана где находится наша мышка  
       var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

       //узнаём попал ли наш луч
       if (Physics.Raycast(ray,5f,_layerMask))
       {
           
           SetFocus();
           if (Input.GetKeyDown(KeyCode.E) )
           {
              
               _rig.isKinematic = true;
               _rig.MovePosition(_transform.position);
           }
       }
       else
       {
           RemoveFocus();
       }
   }
   

   private void FixedUpdate()
   {
       if (_rig.isKinematic == true)
       {
           transform.position = _transform.position;
           if (Input.GetMouseButtonDown(0))
           {
             
               _rigidbody.useGravity = true;
               _rigidbody.isKinematic = false;
               _rigidbody.AddForce(Camera .main.transform.forward * _sideForceValue);
           }

       }
   }
}