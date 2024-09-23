using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Image _image;

    private Dictionary<int, string> _valueToText = new Dictionary<int, string>()
    {
        [1] = "1",
        [2] = "2",
        [3] = "3",
        [4] = "4",
        [5] = "5",
        [6] = "6",
        [7] = "7",
        [8] = "8",
        [9] = "9",
        [10] = "10",
        [11] = "J",
        [12] = "Q",
        [13] = "K"
    };

    private Dictionary<Card.Suits, Color> _suitToColor = new Dictionary<Card.Suits, Color>()
    {
        [Card.Suits.spades] = Color.black,
        [Card.Suits.clubs] = Color.black,
        [Card.Suits.diamonds] = Color.red,
        [Card.Suits.hearts] = Color.red,
    };

    private void Awake()
    {
        _image.color = Color.black;
        _textMeshPro.gameObject.SetActive(false);
    }

    public void DisplayCard(Card card)
    {
        _textMeshPro.gameObject.SetActive(true);

        _textMeshPro.text = _valueToText[card.Value];
        _textMeshPro.color = _suitToColor[card.Suit];

        _image.color = Color.white;
    }
}
