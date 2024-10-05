using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    
    public int sideCount = 0;
    public int numOfDice = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            RollDice(numOfDice, sideCount);
        }
        if (Input.GetKeyDown("a"))
        {
            RollAdvantage(sideCount);
        }
    }

    //Dice Roller
    public int RollDie(int sides)
    {
        int result;

        result = Random.Range(1, sides+1);

       // Debug.Log("" + result);
        return result;
    }

    //Dice Roller multi-dice
    public List<int> RollDice(int count, int sides) 
    {
        List<int> results = new List<int>();
        int roll = 0;
        for (int i = 0; i < count; i++)
        {
            roll = RollDie(sides);

            if (i == count-1)
            {
                results.Add(roll);
            }
            else
            {
                results.Add(roll);
            }
        }
        PrintList(results);
        return results;
    }

    //Rolls dice and returns only highest value
    public void RollAdvantage(int sides)
    {
        int roll1 = RollDie(sides);
        int roll2 = RollDie(sides);

        Debug.Log(roll1 + ", " + roll2);

        if (roll1 > roll2)
        {
            Debug.Log(roll1);
        }
        else
        {
            Debug.Log(roll2);
        }
    }
    //Sums the values of RollDice

    public void PrintList(List<int> values)
    {
        string output = "[";
        for (int i = 0; i < values.Count; i++)
        {
            if (i < values.Count - 1)
            {
                output += values[i] + ", ";
            }
            else
            {
                output += values[i] + "]";
            }
        }
        Debug.Log(output);
    }
}
