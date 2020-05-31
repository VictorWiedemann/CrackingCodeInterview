using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Merge_sort
{
    public enum Suit
    {
        Diamond,
        Heart,
        Club,
        Spade
    }


    public interface IHandCalculator
    {
        int CalculateHand(List<Card> cards);
    }

    public class CalculateBlackjackHand : IHandCalculator
    {
        private const int faceCard = 11;
        private const int Ace = 1;
        public int CalculateHand(List<Card> cards)
        {
            var totalValue = 0;
            var numOfAces = 0;
            foreach (var card in cards)
            {
                if (card.Face >= faceCard)
                {
                    totalValue += 10;
                }
                else if(card.Face == Ace)
                {
                    totalValue += 11;
                    numOfAces++;
                }
                else
                {
                    totalValue += card.Face;
                }
            }

            while ((numOfAces > 0) & (totalValue > 21))
            {
                totalValue -= 10;
                numOfAces--;
            }

            return totalValue;
        }
    }

    public class Hand
    {
        public List<Card> HeldHand { get; } = new List<Card>();
        public IHandCalculator HandCalculator;

        public Hand(IHandCalculator Calculator)
        {
            HandCalculator = Calculator;
        }

        public void AddCard(Card card)
        {
            HeldHand.Add(card);
        }

        public int getTotal()
        {
            return HandCalculator.CalculateHand(HeldHand);
        }

    }

    public class Card
    {
        public Suit Suit { get; }
        public int Face { get; }

        public Card(Suit suit, int face)
        {
            Suit = suit;
            Face = face;
        }    
    }

    public class Deck
    {
        public Stack<Card> Stack { get; } = new Stack<Card>();

        public void Shuffle()
        {
            //TODO: add shuffle
        }

        public Deck(List<Card> pileOfCards)
        {
            //"shuffled"
            foreach (var card in pileOfCards)
                Stack.Push(card);
        }

        public Card DrawCard()
        {
            //draw card info
            return Stack.Pop();
        }

    }


}