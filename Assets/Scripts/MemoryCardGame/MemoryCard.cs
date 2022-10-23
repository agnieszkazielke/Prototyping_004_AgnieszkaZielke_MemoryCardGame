using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    public RawImage revealImage;

    [SerializeField] private MemoryCardSwipe _cardSwipe;

    private bool _cardOpen = false;


    public void RevealCard()
    {
        if (_cardOpen) return;
        GameManager.Instance.OpenCard(this);
        _cardOpen = true;
    }

    public void CoverCard()
    {
        _cardSwipe.ScrollBack();
        _cardOpen = false;
    }

}
