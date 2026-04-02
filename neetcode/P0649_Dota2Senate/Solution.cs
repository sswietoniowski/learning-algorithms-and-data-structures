namespace neetcode.P0649_Dota2Senate;

// https://leetcode.com/problems/dota2-senate/description/
// https://neetcode.io/problems/dota2-senate/question?list=neetcode250
public class Solution
{
    public string PredictPartyVictory(string senate)
    {
        int n = senate.Length;
        Queue<int> radiant = new Queue<int>();
        Queue<int> dire = new Queue<int>();

        // Step 1: Populate queues with the initial indices of each senator
        for (int i = 0; i < n; i++)
        {
            if (senate[i] == 'R')
            {
                radiant.Enqueue(i);
            }
            else
            {
                dire.Enqueue(i);
            }
        }

        // Step 2: Simulate the voting process
        while (radiant.Count > 0 && dire.Count > 0)
        {
            int rIndex = radiant.Dequeue();
            int dIndex = dire.Dequeue();

            // The senator with the smaller index acts first and bans the other
            if (rIndex < dIndex)
            {
                // Radiant bans Dire. Radiant moves to the next round.
                // We add 'n' to the index to place them at the end of the line for the next round.
                radiant.Enqueue(rIndex + n);
            }
            else
            {
                // Dire bans Radiant. Dire moves to the next round.
                dire.Enqueue(dIndex + n);
            }
        }

        // Step 3: The party that still has senators remaining wins
        return radiant.Count > 0 ? "Radiant" : "Dire";
    }
}
