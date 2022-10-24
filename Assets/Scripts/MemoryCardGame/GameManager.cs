using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Logger _debugLogger;
    [SerializeField] private List<Texture> _cardImageTextures = new List<Texture>();
    [SerializeField] private List<Texture> _selectedCardImageTextures = new List<Texture>();
    [SerializeField] private MemoryCard[] _memoryCards;

    [SerializeField] private TMP_Text _tapsText;
    [SerializeField] private TMP_Text _cardsText;
    private MemoryCard _openCard1;
    private MemoryCard _openCard2;
    private int _tapsLeft;
    private int _cardsLeft;
    private System.Random _random = new System.Random();  

    private void Awake()
    {
        Instance = this;
        _memoryCards = FindObjectsOfType<MemoryCard>();
    }

    void Start()
    {
        Assert.IsTrue(_memoryCards.Length <= _cardImageTextures.Count * 2, "Error: You don't have enough textures");
        Assert.IsTrue(_memoryCards.Length % 2 == 0, "Error: You need an even amount of memory cards");
        
        ShuffleCards(_cardImageTextures);
        SelectCardImageTextures();
        ShuffleCards(_selectedCardImageTextures);
        ApplyTexturesToCards();

        _tapsLeft = _memoryCards.Length * 4;
        _cardsLeft = _memoryCards.Length;
        UpdateTapsText();
        UpdateCardsText();

    }

    private void ShuffleCards(List<Texture> list)  
    {  
        // Fisher-Yates shuffle
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = _random.Next(n + 1);  
            Texture value = list[k];
            list[k] = list[n];  
            list[n] = value;  
        }  
    }
    
    private void SelectCardImageTextures()
    {
        for (int i = 0; i < _memoryCards.Length / 2; i++)
        {
            _selectedCardImageTextures.Add(_cardImageTextures[i]);
            _selectedCardImageTextures.Add(_cardImageTextures[i]);
        }
    }

    private void ApplyTexturesToCards()
    {
        for (int i = 0; i < _memoryCards.Length; i++)
        {
            _memoryCards[i].revealImage.texture = _selectedCardImageTextures[i];
            _memoryCards[i].cardTitle.text = _memoryCards[i].revealImage.texture.name;
            _memoryCards[i].cardTitle.gameObject.SetActive(false);
        }
    }
    

    public void OpenCard(MemoryCard card)
    {
        if (_openCard1 != null && _openCard2 != null) return;
        
        if (_openCard1 == null)
        {
            _openCard1 = card;
            _debugLogger.LogInfo("openCard1 taken");
        }

        else
        {
            _openCard2 = card;
            _debugLogger.LogInfo("openCard2 taken");
            CheckCards();
        }

        _tapsLeft--;
        UpdateTapsText();

    }

    private void CheckCards()
    {
        _debugLogger.LogInfo("checking cards...");
        
        if (_openCard1.revealImage.texture == _openCard2.revealImage.texture)
        {
            _debugLogger.LogInfo("Cards match!");
            _openCard1.RemoveCard();
            _openCard2.RemoveCard();
            _cardsLeft = _cardsLeft - 2;
            UpdateCardsText();
        }

        else
        {
            _debugLogger.LogInfo("Cards don't match!"); 
            _openCard1.CoverCard();
            _openCard2.CoverCard();
        }

        _openCard1 = null;
        _openCard2 = null;
        _debugLogger.LogInfo("Cards reset");
        

    }

    private void UpdateCardsText()
    {
        _cardsText.text = "Cards: " + _cardsLeft.ToString();
    }
    private void UpdateTapsText()
    {
        _tapsText.text = "Taps: " + _tapsLeft.ToString();
    }
    
    

}
