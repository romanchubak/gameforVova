using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyanyca
{
    class Сroupier : IPeople
    {
        public string NickName { get; set; }
        public int Age { get; set; }
        private DeckOfСards Bank { get; set; }
        private DeckOfСards Deck { get; set; }

        public Сroupier(string nickname, int age)
        {
            NickName = nickname;
            Age = age;
            Bank = new DeckOfСards(true);
            Deck = new DeckOfСards(false);
        }


        private string OnMove(Player player)
        {
            string rez = "";
            PlayingCard players_card = player.MakeMove();
            rez += player + " поклав у банк " + players_card;
            if (Bank.Cards.Count > 0 && Bank.Cards.Last.Value < players_card)
            {
                Bank.AddCardToBotom(players_card);
                rez += "\n" + player + " виграв банк: " + Bank;
                player.WinBank(Bank);
                rez += "\nу " + player+ " " + player.CardsOnHand.Cards.Count + " карт";
                Bank = new DeckOfСards(true);
            }   
            else
                Bank.AddCardToBotom(players_card);
            return rez;
        }


        public void StartGame(Player[] Players)
        {
            Deck.Stir();
            int number = Deck.Cards.Count / Players.Length;
            foreach ( var player in Players)
                player.TekeCards(new DeckOfСards(Deck.GetSubDeck(number)));
            bool flag = true;
            while(EndOfGame(Players)==null && flag)
            {
                foreach (var player in Players)
                {
                    if(!player.Lose())
                    {
                        Console.WriteLine(OnMove(player));
                        Console.ReadKey();
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
            }
            Console.WriteLine("виграв " + EndOfGame(Players));

        }

        private Player EndOfGame(Player[] Players)
        {
            foreach (var player in Players)
                if (player.Win()) return player;
            return null;
        }
    }
}
