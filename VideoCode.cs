using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class VideoCode
{
    private const string Table = "fZodR9XQDSUm21yCkr6zBqiveYah8bt4xsWpHnJE7jL5VG3guMTKNPAwcF";
    private const int Xor = 177451812;
    private const long Add = 100618342136696320L;
    private static readonly int[] S = {11, 10, 3, 8, 4, 6, 2, 9, 5, 7};
    private static readonly Dictionary<char, int> Tr;
        
    static VideoCode()
    {
        Tr = new Dictionary<char, int>();
        for (var i = 0; i < 58; i++)
        {
            Tr.Add(Table[i], i);
        }
    }

    public static long Dec(string x)
    {
        long r = 0;
        for (var i = 0; i < 10; i++)
        {
            r += Tr[x[S[i]]] * (long) Math.Pow(58, i);
        }

        return (r - Add) ^ Xor;
    }

    public static string Enc(int x)
    {
        long x1 = (x ^ Xor) + Add;
        char[] r = "BV          ".ToCharArray();
        for (var i = 0; i < 10; i++)
        {
            r[S[i]] = Table[(int) (x1 / (long) Math.Pow(58, i) % 58)];
        }

        return Regex.Replace(new string(r), "[\\[\\]\\s,]", string.Empty);
    }
}