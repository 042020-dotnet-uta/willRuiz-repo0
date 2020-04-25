using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPC_Game
{
    public class Game
    {
        
        public readonly Player[] players;   //RPC is a 2-player game ... will only hold players (1,2)

        public List<Round> rounds;  //Keeps a record of rounds that have been played
        private int ties;

        private readonly ILogger _logger; //un-initialized instance of logger
        public Game(ILogger<Game> logger)   //the ILogger for this class "Game" is referenced by logger
        {
            this.players = new Player[2];
            rounds = new List<Round>();
            ties = 0;
            PromptPlayerNames();
            _logger = logger;           //initialize _logger with (the Ilogger for this instance ... logger)
        }

        private void PromptPlayerNames() //Get player names though Console inputs
        {   
            Console.WriteLine("Enter Player 1 Name:  ");
            players[0] = new Player(Console.ReadLine() );  //Player objects created with names via console inputs

            Console.WriteLine("Enter Player 2 Name:  ");
            players[1] = new Player(Console.ReadLine());
        }
        /* Starts Game 
         * Individual rounds are played 
         * Best of 3 (1st Player to win 2 games) = winner
         * Outputs Round details + Player choicer per-round (rock-paper-scissor)
        */
        public void start() 
        {            
            int n = 1;

            do
            {
                startRound(n);  
                n++;            //Round number is +1 ... Each round played

            
            } while (players[0].wins < 2 || players[1].wins < 2);

           // *****Logging*********************************************************
             if (rounds.Count > 3) { 
            _logger.LogInformation($"{players[0].name} has nice hair"); 
            _logger.LogDebug("Log Debug");//not printed to console
            _logger.LogError("LogError");
            _logger.LogTrace("Log Trace");//does not show up the console
            _logger.LogCritical("Game over ");
            };
           // ************************************************************************

        }
        private void startRound(int n) 
        {

            /*When a new Round is created  
             * Each indiv-round of play is simulated and 
             * Updates the Round (object) stored in a list
            */
            Round newRound = new Round(n);
            rounds.Add(newRound);

            Console.Write($"Round {newRound.roundCount}: {players[0].name} chose {newRound.p1Choice}, {players[1].name} chose {newRound.p2Choice}. - ");

            switch (newRound.result) // Updates Player object with wins + Game ties totals
            {
                case -1: //Player 2 wins.
                    players[1].wins++;
                    Console.WriteLine($"{players[1].name} Won");
                    break;
                case 0: //Tied round.
                    ties++;
                    Console.WriteLine($"It's a Tie");
                    break;
                case 1: //Player 1 wins.
                    players[0].wins++;
                    Console.WriteLine($"{players[0].name} Won");
                    break;                  
            }
        }
    }
}
