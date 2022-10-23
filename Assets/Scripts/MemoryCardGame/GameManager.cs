using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Logger _debugLogger;
    
    private MemoryCard _openCard1;
    private MemoryCard _openCard2;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
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
        
       
    }

    private void CheckCards()
    {
        _debugLogger.LogInfo("checking cards...");
        
        if (_openCard1.revealImage.texture == _openCard2.revealImage.texture)
        {
            _debugLogger.LogInfo("Cards match!");  
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
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
