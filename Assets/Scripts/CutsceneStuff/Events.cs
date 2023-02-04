using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events 
{
    static List<(int, string)> c1;
    static List<(int, string)> c2;
    static List<(int, string)> c3;

    public static List<(int,string)> getCutscene(int n)
    {
        switch (n)
        {
            case 1:
                return c1;
            case 2:
                return c2;
            case 3:
                return c3;
            default:
                return new List<(int, string)>();
        }
    }

    public static void Initialise()
    {

    }
    public static void writeC1()
    {
        c1 = new List<(int, string)>();
        c1.Add((1, "This is a test diaglouge."));
        c1.Add((2, "Wow, that's so cool!"));
        c1.Add((1, "Shut up, nobody cares what you think."));
    }
    public static void writeC2()
    {
        c2 = new List<(int, string)>();
    }
    public static void writeC3()
    {
        c3 = new List<(int, string)>();
    }
}
