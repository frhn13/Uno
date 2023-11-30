using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    class Card
    {
        private int cardVal;
        private char cardColour;
        private string cardType;

        public Card(int cardVal, char cardColour, string cardType)
        {
            this.CardVal = cardVal;
            this.CardColour = cardColour;
            this.CardType = cardType;
        }
        public Card(char cardColour, string cardType)
        {
            this.CardColour = cardColour;
            this.CardType = cardType;
        }

        public int CardVal { get; set; }
        public char CardColour { get; set; }
        public string CardType { get; set; }
    }
}
