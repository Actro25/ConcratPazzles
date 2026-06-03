using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcratPazzles
{
    class PuzzleSubstruct
    {
        static private string ConcatPuzzles(int currentIndex, List<string> puzzles, Dictionary<string, List<int>> note, bool[] visited)
        {
            visited[currentIndex] = true;

            string currentPuzzle = puzzles[currentIndex];
            string nextKey = currentPuzzle[4..6];

            string maxResult = "";

            if (note.ContainsKey(nextKey))
            {
                foreach (int index in note[nextKey])
                {
                    if (!visited[index])
                    {
                        string currentResult = ConcatPuzzles(index, puzzles, note, visited);

                        if (currentResult.Length > maxResult.Length)
                            maxResult = currentResult;
                    }
                }
            }
            visited[currentIndex] = false;

            if (string.IsNullOrEmpty(maxResult))
                return currentPuzzle;
            else
                return currentPuzzle + maxResult[2..];
        }
        static public string FindNumber(List<string> puzzles)
        {
            Dictionary<string, List<int>> note = new Dictionary<string, List<int>>();
            for (int i = 0; i < puzzles.Count; i++)
            {
                if (!note.ContainsKey(puzzles[i][0..2]))
                {
                    note.Add(puzzles[i][0..2], new List<int>());
                }
                note[puzzles[i][0..2]].Add(i);
            }
            string maxLenghtPazzle = "";
            bool[] visited = new bool[puzzles.Count];

            for (int i = 0; i < puzzles.Count; i++)
            {
                string currentLenghtPazzle = ConcatPuzzles(i, puzzles, note, visited);
                if (currentLenghtPazzle.Length > maxLenghtPazzle.Length)
                    maxLenghtPazzle = currentLenghtPazzle;
            }
            return maxLenghtPazzle;
        }
    }
}
