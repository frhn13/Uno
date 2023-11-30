using System;
using System.Collections.Generic;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int noPlayers;
            Stack<Card> cardDeckStack = new Stack<Card>();
            List<Card> cardDeck = new List<Card>();
            Random rand = new Random();
            List<Player> playerList = new List<Player>();
            bool playersChosen = false;
            bool winner = false;
            bool gameOver = false;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    switch (x)
                    {
                        case 0:
                            cardDeck.Add(new Card(y, 'R', "number"));
                            break;
                        case 1:
                            if (y != 0)
                                cardDeck.Add(new Card(y, 'R', "number"));
                            break;
                        case 2:
                            cardDeck.Add(new Card(y, 'Y', "number"));
                            break;
                        case 3:
                            if (y != 0)
                                cardDeck.Add(new Card(y, 'Y', "number"));
                            break;
                        case 4:
                            cardDeck.Add(new Card(y, 'G', "number"));
                            break;
                        case 5:
                            if (y != 0)
                                cardDeck.Add(new Card(y, 'G', "number"));
                            break;
                        case 6:
                            cardDeck.Add(new Card(y, 'B', "number"));
                            break;
                        case 7:
                            if (y != 0)
                                cardDeck.Add(new Card(y, 'B', "number"));
                            break;
                    }
                }
            }
            // Randomises the cards
            for (int i = cardDeck.Count - 1; i > 0; i--)
            {
                int k = rand.Next(i + 1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[i];
                cardDeck[i] = value;
            }
            foreach (Card card in cardDeck)
            {
                cardDeckStack.Push(card);
            }

            do
            {
                Console.WriteLine("How many people are playing Uno?");
                try
                {
                    noPlayers = Convert.ToInt32(Console.ReadLine());
                    for (int x = 1; x <= noPlayers; x++)
                    {
                        Console.WriteLine($"Enter a name for Player {x}");
                        List<Card> hand = new List<Card>();
                        for (int y=0; y<7; x++)
                        {
                            hand.Add(cardDeckStack.Peek());
                            cardDeckStack.Pop();
                        }
                        playerList.Add(new Player(Console.ReadLine(), x, hand));
                    }
                    playersChosen = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number.");
                }
            } while (!playersChosen);

            do
            {

            } while (!winner || cardDeck.Count > 0);
            Console.ReadKey();
        }
    }
}
