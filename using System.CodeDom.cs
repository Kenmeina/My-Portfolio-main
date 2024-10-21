using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'entryTime' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING keypad
     */

    public static int entryTime(string s, string keypad)
{
    char[,] grid = new char[3,3];
    int index = 0;
    for (int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            grid[i,j] = keypad[index];
            index++;
        }
    }
    
    int totalTime = 0;
    int currentRow = 0;
    int currentCol = 0;
    
    foreach(char digit in s)
    {
        int targetRow = 0;
        int targetCol = 0;    
    
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(grid[i,j] == digit)
                {
                    targetRow = i;
                    targetCol = j;
                    break;
                }
            }
        }
    
        totalTime += Math.Abs(targetRow - currentRow) + Math.Abs(targetCol - currentCol);
    
        currentRow = targetRow;
        currentCol = targetCol;
    }
    
    return totalTime;
}
public static void Main(string[] args)
{
    string s = "423692";
    string keypad = "923857614";

    int result = entryTime(s, keypad);

    Console.WriteLine(result); // Output: 8
}


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string keypad = Console.ReadLine();

        int result = Result.entryTime(s, keypad);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
