using System;

public class Card
{
    private const int MAX_VALUE = 13;
    public enum Suits
    {
        spades,
        clubs,
        diamonds,
        hearts
    }

    private Suits _suit;
    private int _value;

    public Suits Suit { get => _suit; }
    public int Value { get => _value; set => _value = ValidateCardValue(value); }

    private Card _childCard;
    private Card _parentCard;

    public Card ChildCard
    {
        get
        {
            return _childCard;
        }
        set
        {
            _childCard = value;

            if (_childCard.ParentCard != this)
            {
                _childCard.ParentCard = this;
            }
        }
    }

    public Card ParentCard
    {
        get
        {
            return _parentCard;
        }
        set
        {
            _parentCard = value;

            if (_parentCard.ChildCard != this)
            {
                _parentCard.ChildCard = this;
            }
        }
    }

    public bool IsChild() => ParentCard != null;
    public bool IsParent() => ChildCard != null;

    public Card()
    {
    }

    public Card(int value)
    {
        _value = ValidateCardValue(value);
    }

    public Card(int value, Suits suit)
    {
        _value = ValidateCardValue(value);
        _suit = suit;
    }

    private int ValidateCardValue(int value)
    {
        if (value < 1)
        {
            value = Math.Abs(MAX_VALUE + value);
        }

        if (value <= MAX_VALUE)
        {
            return value;
        }
        else
        {
            return value % MAX_VALUE;
        }

    }

    public override string ToString()
    {
        return _value.ToString() + _suit;
    }
}
