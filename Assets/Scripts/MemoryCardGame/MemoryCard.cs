using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    
    public RawImage revealImage;
    
    [SerializeField] private MemoryCardSwipe _cardSwipe;
    [SerializeField] private Logger _debugLogger;

    private bool _cardOpen = false;
    

    public void RevealCard()
    {
        if (_cardOpen) return;
        GameManager.Instance.OpenCard(this);
        _cardOpen = true;
    }

    public void CoverCard()
    {
        _debugLogger.LogInfo("CoverCard() executed on " + gameObject.name);
        _cardOpen = false;
        _cardSwipe.ScrollBack();
        StartCoroutine(SetFalse());

    }
    
    // no idea why this is needed but it is needed to make sure all cards get set to false for some reason
    private IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(2f);
        _cardOpen = false;

    }

    public void RemoveCard()
    {
        StartCoroutine(DestroyCard());
    }
    
    private IEnumerator DestroyCard()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }


    private void OnDestroy()
    {
        
    }
}
