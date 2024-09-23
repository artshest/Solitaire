using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private List<Transform> _cardGroups;
    [SerializeField] private CardView _bankView;
    [SerializeField] private View _view;

    private List<Card> _topCards = new List<Card>();
    private List<CardView> _cardViews = new List<CardView>();

    private void Awake()
    {
        InitializeCardGroups();
        InitializeMVC();
    }

    private void InitializeMVC()
    {
        var model = new Model();

        _view.SetModel(model);
        _view.CardViews = _cardViews;
        _view.BankView = _bankView;

        var controller = new Controller(model, _view);
        controller.GenerateCardField(_topCards);
    }


    private void InitializeCardGroups()
    {
        foreach (Transform groupTransform in _cardGroups)
        {
            var parentCard = new Card();
            Card currentCard = parentCard;

            for (int i = groupTransform.childCount - 1; i >= 0; i--)
            {
                currentCard.ChildCard = new Card();

                currentCard = currentCard.ChildCard;
            }

            _topCards.Add(parentCard);
            _cardViews.Add(groupTransform.GetChild(groupTransform.childCount - 1).GetComponent<CardView>());
        }
    }

    
}
