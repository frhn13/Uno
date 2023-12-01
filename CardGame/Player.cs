using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class Player
    {
        private string username;
        private int playerNumber;
        private List<Card> cardHand = new List<Card>();

        public Player(string username, int playerNumber, List<Card> cardHand)
        {
            this.Username = username;
            this.PlayerNumber = playerNumber;
            this.CardHand = cardHand;
        }
        public string Username { get; set; }
        public int PlayerNumber { get; set; }
        public List<Card> CardHand { get; set; }

        public void AddCard(Card newCard)
        {
            this.CardHand.Add(newCard);
        }
        public void RemoveCard(int position)
        {
            this.CardHand.RemoveAt(position);
        }
    }
}
