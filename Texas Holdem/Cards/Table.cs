using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Table
    {        
        private Deck _deck;
        private List<Player> _players;
        private List<Card> _communityCards;
        private Dictionary<string, int> _winningHands;
        private Dictionary<string, int> _winningPockets;
        private int _handCount;

        public Table()
        {
            _handCount = 0;
            _players = new List<Player>();
            _communityCards = new List<Card>();
            _winningHands = new Dictionary<string, int>();
            _winningPockets = new Dictionary<string, int>();

            foreach (Card.FaceValue face1 in Card.FaceValuesDesceding)
            {
                foreach (Card.FaceValue face2 in Card.FaceValuesDesceding)
                {
                    if (face1 >= face2)
                    {
                        string key = face1.ToString() + "-" + face2.ToString();

                        if (!_winningPockets.ContainsKey(key))
                        {
                            _winningPockets.Add(key, 0);
                        }
                    }
                }
            }

            foreach (Player.HandValue handValue in Player.HandValuesAscending)
            {
                string key = handValue.ToString();

                if (!_winningHands.ContainsKey(key))
                {
                    _winningHands.Add(key, 0);
                }
            }
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void ShowPlayerScores()
        {
            foreach (Player player in _players)
            {
                player.PrintScore();
            }
        }

        public void Deal()
        {
            _deck = new Deck();
            _communityCards.Clear();

            foreach (Player player in _players)
            {
                player.Clear();
            }

            dealPocketCards();
            dealBurnCard();
            dealCommunityCard(3);
            dealBurnCard();     
            dealCommunityCard(1);
            dealBurnCard();
            dealCommunityCard(1);
        }

        public Player GetWinner()
        {
            Player winner = null;
            Player.HandValue winningHand = Player.HandValue.Nothing;

            foreach (Player player in _players)
            {
                if (player.GetHandValue() >= winningHand)
                {
                    winner = player;
                    winningHand = player.GetHandValue();
                }
            }

            if (isTie(winner)) return null;

            _handCount++;
            _winningHands[winner.GetHandValue().ToString()]++;
            _winningPockets[winner.GetPocketName()]++;

            return winner;
        }

        private bool isTie(Player winner)
        {
            foreach (Player player in _players)
            {
                if (player != winner)
                {
                    if (player.GetHandValue() == winner.GetHandValue())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void RecordHands()
        {
            foreach (Player player in _players)
            {
                player.RecordHand();
            }
        }

        public void PrintWinningHandData()
        {
            Console.WriteLine(" +----------------------------+");

            foreach (string s in _winningHands.Keys)
            {
                StringBuilder output = new StringBuilder("");
                output.Append(" | ");
                output.Append(s.PadRight(10));
                output.Append(" : ");
                output.Append(_winningHands[s].ToString("0,000"));
                output.Append(" (" + ((double)_winningHands[s] / (double)_handCount).ToString("0.000") + ")");
                output.Append(" | ");
                Console.WriteLine(output.ToString());
            }

            Console.WriteLine(" +----------------------------+");
        }

        public void PrintWinningPocketData()
        {
            List<string> output = new List<string>();

            foreach (string pocketName in _winningPockets.Keys)
            {
                output.Add("[" + _winningPockets[pocketName].ToString("0000") + "]" + " " + pocketName);
            }

            output.Sort();
            output.Reverse();

            foreach (string s in output)
            {
                Console.WriteLine(s);
            }
        }

        private void dealPocketCards()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in _players)
                {
                    player.AddCard(_deck.GetCard());
                }
            }
        }

        private void dealCommunityCard(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Card communityCard = _deck.GetCard();

                foreach (Player player in _players)
                {
                    player.AddCard(communityCard);
                }

                _communityCards.Add(communityCard);
            }
        }

        private void dealBurnCard()
        {
            _deck.GetCard();
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine(" +----------------------------------------------------+--------------+");
            Console.Write(" | COMMUNITY CARDS:     ");
            foreach (Card card in _communityCards)
            {
                Console.Write(card.ToString() + " ");
            }
            Console.WriteLine("|    POCKETS   |");            
            Console.WriteLine(" +----------------------------------------------------+--------------+");

            foreach (Player player in _players)
            {
                Console.Write(" | ");
                Console.Write(player.GetName().PadRight(10));
                Console.Write(player.GetHandValue().ToString().PadRight(11));
                Console.Write(player.GetUsedCards().PadRight(5));
                Console.Write("|  ");
                Console.Write(player.GetPocketName().PadRight(11));
                Console.Write(" | ");

                Console.WriteLine();
            }

            Console.WriteLine(" +----------------------------------------------------+--------------+");
            Console.WriteLine();
        }
    }
}