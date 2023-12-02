﻿using System;
using System.Collections.Generic;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = false;
            do
            {
                int noPlayers = 0;
                string cardChoice;
                int cardPosition;
                string winner = "";
                Stack<Card> cardDeckStack = new Stack<Card>();
                List<Card> cardDeck = new List<Card>();
                Stack<Card> cardPile = new Stack<Card>();
                Random rand = new Random();
                List<Player> playerList = new List<Player>();
                bool playersChosen = false;
                bool winnerFound = false;
                bool cardPlaced = false;

                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        switch (x)
                        {
                            case 0:
                                cardDeck.Add(new Card(y, "Red", "number"));
                                break;
                            case 1:
                                if (y != 0)
                                    cardDeck.Add(new Card(y, "Red", "number"));
                                break;
                            case 2:
                                cardDeck.Add(new Card(y, "Yellow", "number"));
                                break;
                            case 3:
                                if (y != 0)
                                    cardDeck.Add(new Card(y, "Yellow", "number"));
                                break;
                            case 4:
                                cardDeck.Add(new Card(y, "Green", "number"));
                                break;
                            case 5:
                                if (y != 0)
                                    cardDeck.Add(new Card(y, "Green", "number"));
                                break;
                            case 6:
                                cardDeck.Add(new Card(y, "Blue", "number"));
                                break;
                            case 7:
                                if (y != 0)
                                    cardDeck.Add(new Card(y, "Blue", "number"));
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
                            for (int y = 0; y < 7; y++)
                            {
                                hand.Add(cardDeckStack.Pop());
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

                // Starting card
                cardPile.Push(cardDeckStack.Pop());
                do
                {
                    for (int x = 0; x < noPlayers; x++)
                    {
                        do
                        {
                            cardPlaced = false;
                            Console.WriteLine($"Current Card on Pile: {cardPile.Peek().CardColour} {cardPile.Peek().CardVal}");
                            Console.WriteLine($"Cards left in Draw Deck: {cardDeckStack.Count}");
                            Console.WriteLine($"{playerList[x].Username}'s Turn");

                            for (int y = 0; y < playerList[x].CardHand.Count; y++)
                            {
                                Console.WriteLine($"Card {y + 1}: {playerList[x].CardHand[y].CardColour} {playerList[x].CardHand[y].CardVal},");
                            }
                            Console.WriteLine("\nSelect a card by its number position in your hand to place on the pile, or type 'draw' to draw a card and move on.");
                            cardChoice = Console.ReadLine();
                            if (cardChoice.ToUpper() == "DRAW")
                            {
                                playerList[x].AddCard(cardDeckStack.Pop());
                                cardPlaced = true;

                                Console.WriteLine("New Hand:");
                                for (int y = 0; y < playerList[x].CardHand.Count; y++)
                                {
                                    Console.WriteLine($"Card {y + 1}: {playerList[x].CardHand[y].CardColour} {playerList[x].CardHand[y].CardVal},");
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                try
                                {
                                    cardPosition = Convert.ToInt32(cardChoice);
                                    if (playerList[x].CardHand[cardPosition - 1].CardColour == cardPile.Peek().CardColour || playerList[x].CardHand[cardPosition - 1].CardVal == cardPile.Peek().CardVal)
                                    {
                                        cardPlaced = true;
                                        cardPile.Push(playerList[x].CardHand[cardPosition - 1]);
                                        playerList[x].RemoveCard(cardPosition - 1);
                                        Console.WriteLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("That card can't go on the pile.\n");
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("You didn't enter the number position of the card in your hand.\n");
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Position entered is out of the range of your hand.\n");
                                }
                            }
                            if (playerList[x].CardHand.Count <= 0)
                            {
                                winnerFound = true;
                                winner = playerList[x].Username;
                                break;
                            }
                            else
                            {
                                winnerFound = false;
                                break;
                            }
                        } while (!cardPlaced);
                        if (winnerFound || cardDeck.Count <= 0)
                            break;
                    }
                } while (!winnerFound && cardDeck.Count > 0);
                if (winnerFound)
                    Console.WriteLine($"Winner is : {winner}!");
                else
                    Console.WriteLine("Ran out of cards from the draw deck, no one wins!");

                Console.WriteLine("Would you like to play again?");
                if (Console.ReadLine().ToUpper() == "YES" || Console.ReadLine().ToUpper() == "Y")
                    playAgain = true;
                else playAgain = false;       
            } while (playAgain);

            Console.WriteLine("Thanks for playing Uno, bye!");
            Console.ReadKey();
        }
    }
}
