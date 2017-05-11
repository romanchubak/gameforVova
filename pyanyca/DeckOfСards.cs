using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    class DeckOfСards
    {
        public LinkedList<PlayingCard> Cards { get; private set; }
        
        public DeckOfСards(bool empty)
        {
            if (!empty)
                Cards = new LinkedList<PlayingCard>(getDeck());
            else 
                Cards = new LinkedList<PlayingCard>();
        }

        public DeckOfСards(LinkedList<PlayingCard> deck)
        {
            Cards = new LinkedList<PlayingCard>(deck);
        }
        
        private static List<PlayingCard> getDeck()
        {
            List<PlayingCard> deck = new List<PlayingCard>();
            foreach (var suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (var value in Enum.GetValues(typeof(Values)))
                {
                    deck.Add(new PlayingCard((Suits)suit, (Values)value));
                }
            }
            return deck;
        }
        
        public void Stir()
        {
            List<PlayingCard> deck = new List<PlayingCard>(Cards);
            Cards = new LinkedList<PlayingCard>();
            Random r = new Random();
            while (Cards.Count < 52)
            {
                int index = r.Next(deck.Count);
                if (!Cards.Contains(deck[index]))
                    Cards.AddFirst(deck[index]);
            }
        }

        public LinkedList<PlayingCard> GetSubDeck(int number)
        {
            LinkedList<PlayingCard> rez = Cards.subList<PlayingCard>(number);
            foreach (var card in rez)
            {
                Cards.Remove(card);
            }
            return rez;
        }

        public PlayingCard GetTopCard()
        {
            PlayingCard rez = Cards.First.Value;
            Cards.RemoveFirst();
            return rez;
        }
        public void AddCardToBotom(PlayingCard card)
        {
            Cards.AddLast(card);
        }

        public override string ToString()
        {
            string rez = "";
            foreach (var card in Cards)
            {
                rez += card.ToString() + ", ";
            }
            return rez;
        }
    }
}
