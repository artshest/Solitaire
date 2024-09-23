using System.Collections.Generic;

public class Controller 
{
    protected Model _model;
    protected View _view;

    public Controller(Model model, View view)
    {
        _model = model;
        _view = view;
    }

    public void GenerateCardField(List<Card> topCards)
    {
        Card bankCard = new Card();
        CardFieldGenerator.GenerateCardField(topCards, bankCard);
        _model.InitializeCards(topCards, bankCard);
    }

    public void CheckForCombination(int cardID)
    {
        var aboba = _model.CurrentComboCard.Value - _model.TopCards[cardID].Value;

        if (aboba == 1 || aboba == 12)
        {
            _model.CurrentComboCard = _model.TopCards[cardID];
            _model.NextCard(cardID);
        }
    }

}
