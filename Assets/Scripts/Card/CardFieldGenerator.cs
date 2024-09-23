using System;
using System.Collections.Generic;

public static class CardFieldGenerator
{
    private const int MIN_COMBINATION_SIZE = 2;
    private const int MAX_COMBINATION_SIZE = 7;

    public static void GenerateCardField(List<Card> groups, Card bankCard)
    {
        bool isHaveEmptyCards = true;

        Card currentBankCard = bankCard;
        List<Card> currentCards = new List<Card>(groups);

        while (isHaveEmptyCards) 
        {
            isHaveEmptyCards = CreateCardCombination(currentCards, currentBankCard);
        }
    }

    public static bool CreateCardCombination(List<Card> cards, Card bankCard)
    {
        Random random = new Random();

        int step = SetStepDirection(random);
        int currentValue = SetStartValue(random);

        int combinationCount = random.Next(MIN_COMBINATION_SIZE, MAX_COMBINATION_SIZE);

        int reverseDirectionStep = SetReverseStep(random, combinationCount);

        if (bankCard.Value != 0)
        {
            bankCard.ChildCard = new Card();
            bankCard = bankCard.ChildCard;
        }

        bankCard.Value = currentValue;
        currentValue += step;



        for (int i = 1; i < combinationCount; i++) 
        {
            int groupID = random.Next(0, cards.Count - 1);

            cards[groupID].Value = currentValue;
            currentValue += step;

            if (i == reverseDirectionStep)
            {
                step *= -1;
            }

            if (cards[groupID].IsParent())
            {
                cards[groupID] = cards[groupID].ChildCard;
            }
            else
            {
                cards.RemoveAt(groupID);
                if (cards.Count == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static int SetReverseStep(Random random, int combinationCount)
    {
        if (random.Next(0, 100) < 15)
        {
            return random.Next(2, combinationCount);
        }
        else 
        {
            return -1;
        }
    }

    private static int SetStepDirection(Random random)
    {
        if (random.Next(0, 100) > 65)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private static int SetStartValue(Random random)
    {
        return (random.Next(1, 13));
    }

}
