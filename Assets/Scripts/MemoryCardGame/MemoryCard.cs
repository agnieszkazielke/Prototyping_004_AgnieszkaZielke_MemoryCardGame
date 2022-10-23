using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    public RawImage revealImage;

    [SerializeField] private MemoryCardSwipe _cardSwipe;

    public bool _cardOpen = false;
    

    private void Start()
    {
        GameManager.Instance.onCardsChecked.AddListener(CoverCard);
    }

    public void RevealCard()
    {
        if (_cardOpen) return;
        GameManager.Instance.OpenCard(this);
        _cardOpen = true;
    }

    public void CoverCard()
    {
        _cardOpen = false;
        _cardSwipe.ScrollBack();
        
    }

    private void OnDestroy()
    {
        GameManager.Instance.onCardsChecked.RemoveAllListeners();
    }
}
