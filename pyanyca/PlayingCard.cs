using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    enum Suits { Clubs, Diamonds, Hearts, Spades };
    enum Values { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };

    class PlayingCard
    {
        public Suits Suit { get; private set; }
        public Values Value { get; private set; }

        public PlayingCard(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public static bool operator < (PlayingCard a, PlayingCard b)
        {
            if (a.Suit == b.Suit)
                return a.Value < b.Value;
            else return false;
        }

        public static bool operator >(PlayingCard a, PlayingCard b)
        {
            if (a.Suit == b.Suit)
                return a.Value > b.Value;
            else return false;
        }

        public override string ToString()
        {
            return Suit.ToString() + " " + Value.ToString();
        }
    }
}
