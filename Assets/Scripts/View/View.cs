using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    private Model _model;
    private List<CardView> _cardViews;
    private CardView _bankView;

    public List<CardView> CardViews { get => _cardViews; set => _cardViews = value; }
    public CardView BankView { get => _bankView; set => _bankView = value;}

    public void SetModel(Model model)
    {
        _model = model;
        _model.OnTopCardInitialized += _model_OnTopCardInitialized;
        _model.OnBankCardInitialized += _model_OnBankCardInitialized;
    }

    private void _model_OnBankCardInitialized(Card card)
    {
        _bankView.DisplayCard(card);
    }

    private void _model_OnTopCardInitialized(int i, Card card)
    {
        _cardViews[i].DisplayCard(card);
    }

    public void DisplayNextCard(int groupID, Card card)
    {
        GameObject nextCardObject = _cardViews[groupID].transform.parent.GetChild(_cardViews[groupID].transform.GetSiblingIndex() - 1).gameObject;
    }
}
