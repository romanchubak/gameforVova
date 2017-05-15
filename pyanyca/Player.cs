using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    class Player : IPeople
    {
        public string NickName { get; set; }
        public int Age { get; set; }
        public DeckOfСards CardsOnHand { get; private set; }

        public Player(string nickname, int age)
        {
            NickName = nickname;
            Age = age;
        }
        public void TekeCards(DeckOfСards cards)
        {
            CardsOnHand = cards;
        }
        public PlayingCard MakeMove()
        {
            return CardsOnHand.GetTopCard();
        }
        public void WinBank(DeckOfСards bank)
        {
            foreach (var card in bank.Cards)
                CardsOnHand.AddCardToBotom(card);
        }
        
        

        public override string ToString()
        {
            return NickName;
        }
    }
}
