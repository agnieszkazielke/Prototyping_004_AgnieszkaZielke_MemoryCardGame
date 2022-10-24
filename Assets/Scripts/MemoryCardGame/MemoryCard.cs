using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    
    public RawImage revealImage;
    public TMP_Text cardTitle;
    [SerializeField] private MemoryCardSwipe _cardSwipe;
    [SerializeField] private GameObject _cardEnsemble;
    [SerializeField] private ParticleSystem _fireworkEffect;
    [SerializeField] private Logger _debugLogger;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    private bool _cardOpen = false;
    

    public void RevealCard()
    {
        if (_cardOpen) return;
        GameManager.Instance.OpenCard(this);
        cardTitle.gameObject.SetActive(true);
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
        cardTitle.gameObject.SetActive(false);
        _cardOpen = false;

    }

    public void RemoveCard()
    {
        StartCoroutine(DestroyCard());
    }
    
    private IEnumerator DestroyCard()
    {
        yield return new WaitForSeconds(1f);
        PlayMatchCardSound();
        _fireworkEffect.gameObject.SetActive(true);
        _cardEnsemble.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

    private void PlayMatchCardSound()
    {
        _source.clip = _clip;
        _source.Play();
    }


    private void OnDestroy()
    {
        
    }
}
