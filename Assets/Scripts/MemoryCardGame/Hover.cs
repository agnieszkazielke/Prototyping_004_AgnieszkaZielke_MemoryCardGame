using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    
    public enum HoverType
    {
        UpAndDown = 0,
        BackAndForwards = 1
    }
    
    [SerializeField] private HoverType _state = HoverType.UpAndDown;
    [SerializeField] private float _hoverMagnitude = 0.1f;
    private bool _up = true;
    private float t;
    
    private Vector3 _initialPosition;
    private Vector3 _upperHover;
    private Vector3 _forwardHover;
    


    void Start()
    {
        t = 0;
        _initialPosition = transform.position;
        _upperHover = _initialPosition + (transform.up * _hoverMagnitude);
        _forwardHover = _initialPosition + (transform.forward * _hoverMagnitude);
        
    }

   
    void Update()
    {
        if (_state == HoverType.UpAndDown)
        {
            if (_up)
            {
                if (t <= 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(_initialPosition, _upperHover, t);
                }

                else
                {
                    _up = false;
                    t = 0;
                }
            
            }

            else
            {
                if (t <= 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(_upperHover, _initialPosition, t);
                }

                else
                {
                    _up = true;
                    t = 0;
                }
            }
        }
        
        else if (_state == HoverType.BackAndForwards)

        {
            if (_up)
            {
                if (t <= 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(_initialPosition, _forwardHover, t);
                }

                else
                {
                    _up = false;
                    t = 0;
                }
            
            }

            else
            {
                if (t <= 1)
                {
                    t += Time.deltaTime;
                    transform.position = Vector3.Lerp(_forwardHover, _initialPosition, t);
                }

                else
                {
                    _up = true;
                    t = 0;
                }
            }
        }
        
        
       
    }
}
