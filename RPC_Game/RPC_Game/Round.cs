using System;
using System.Collections.Generic;
using System.Text;

namespace RPC_Game
{
    public class Round
    {
        //Two players (p1,p2) player Choices: 0=rock|1=paper|2=scissor
        public readonly int p1Choice;
        public readonly int p2Choice;
        
        public readonly int roundCount; //Keeps track of each round played one-at-a-time
       
        public readonly int result;  //result of each round: (-1)p1 wins | (1)p2 wins | (0)tie 

        public Round(int n)
        {
            this.p1Choice = GenerateRPS();   //Randomly picks one:  0=rock|1=paper|2=scissor 
            this.p2Choice = GenerateRPS();
            this.roundCount = n;
            this.result = decideRoundOutcome(); //Holds result of who won the game
        }

        static int GenerateRPS()    //Used to randomly generates what each player will pick
        {
            Random rand = new Random();
            return rand.Next(3);    // 0= rock, 1=paper, 2=scissor
        }

        public int decideRoundOutcome() // Logic (game rules) that defines who wins/looses
        {
            if (p1Choice != p2Choice)
            {
                if (p1Choice + 1 == p2Choice || p2Choice + 2 == p1Choice)
                    
                    return -1;  //Player 2 wins

                else return 1;  //Player 1 wins
            }
            else 
            {
               return 0;        //Tie
            }
        }
    }
}
