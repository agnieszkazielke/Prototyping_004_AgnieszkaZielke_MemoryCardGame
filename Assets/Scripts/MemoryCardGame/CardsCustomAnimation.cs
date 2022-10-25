using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CardsCustomAnimation : MonoBehaviour
{
    public enum CardsState
    {
        MovingDown = 0,
        Down = 1,
        MovingUp = 2,
        Up = 3
    }
    
    
    public UnityEvent onCardsDescended;
    public UnityEvent onCardsAscending;
    public CardsState cardsState;
    [SerializeField] private float _travelDist = 3.0f;
    [SerializeField] private GameObject _rotationRef;
    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private Quaternion _targetRotation;
    private Quaternion _startRotation;
    private float t = 0f;
    private bool _down = false;
    

    private void Start()
    {
        _targetPosition = transform.position;
        _startPosition = _targetPosition + new Vector3(0, _travelDist, 0);
        _targetRotation = transform.rotation;
        _startRotation = _rotationRef.transform.localRotation;
    }

    public void MoveCards()
    {
        if (cardsState == CardsState.Down)
        {
            cardsState = CardsState.MovingUp;
        }
        
        else if (cardsState == CardsState.Up)
        {
            cardsState = CardsState.MovingDown;
        }

        else
        {
            return;
        }
        
    }

    private void SpinAndDescend()
    {
        if (!_down)
        {
            if (t <= 1)
            {
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(_startPosition, _targetPosition, t);
                transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, t);
            }

            else
            {
                _down = true;
                t = 0;
                onCardsDescended.Invoke();
                cardsState = CardsState.Down;

            }
        }
        
    }

    private void SpinAndAscend()
    {
        if (_down)
        {
            if (t <= 1)
            {
                if (t == 0) onCardsAscending.Invoke();
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(_targetPosition, _startPosition, t);
                transform.rotation = Quaternion.Lerp(_targetRotation, _startRotation, t);
            }

            else
            {
                _down = false;
                t = 0;
                cardsState = CardsState.Up;

            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (cardsState == CardsState.MovingDown)
        {
            SpinAndDescend();
        }

        else if (cardsState == CardsState.MovingUp)
        {
            SpinAndAscend();
        }

        
    }
}
