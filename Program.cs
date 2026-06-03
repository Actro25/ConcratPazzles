using ConcratPazzles;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        var puzzles = File.ReadAllLines("source.txt").ToList();
        var maxLenghtPazzle = PuzzleSubstruct.FindNumber(puzzles);
        Console.WriteLine(maxLenghtPazzle);
    }
}