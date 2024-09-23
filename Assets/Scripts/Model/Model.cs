using System;
using System.Collections.Generic;

public class Model
{
    protected View _view;
    protected List<Card> _topCards;

    protected Card _bankCard;
    protected Card _currnetComboCard;

    public Card CurrentComboCard { get => _currnetComboCard; set => _currnetComboCard = value; }
    public List<Card> TopCards { get => _topCards; set => _topCards = value; }

    public event Action<int, Card> OnTopCardInitialized;
    public event Action<Card> OnBankCardInitialized;
    public event Action<int, Card> OnTopCardChanged;
    public event Action<Card> OnBankCardChanged;

    public Model()
    {
    }

    public Model(View view)
    {
        _view = view;
    }

    public void InitializeCards(List<Card> topCards, Card bankCard)
    {
        _topCards = topCards;
        _bankCard = bankCard;

        OnBankCardInitialized?.Invoke(_bankCard);

        for (int i = 0; i < topCards.Count; i++)
        {
            OnTopCardInitialized?.Invoke(i, topCards[i]);
        }

        foreach (var card in _topCards)
        {
            UnityEngine.Debug.Log("NEW GROUP");

            var currentCard = card;

            while (currentCard.IsParent()) 
            {
                UnityEngine.Debug.Log(currentCard);
                currentCard = currentCard.ChildCard;
            }
        }
    }

    public void NextCard(int cardID)
    {
        if (_topCards[cardID].IsParent())
        {
            _topCards[cardID] = _topCards[cardID].ChildCard;
            OnTopCardChanged?.Invoke(cardID, _topCards[cardID]);
        }
    }


}
