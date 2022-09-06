using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttStackScript
{
    private float executeTimer = 0f;
    private const float EXECUTE_MAX = 0.09f;

    public enum Inputs
    {
        Up,
        Down,
        Forward,
        PAttack,
        MAttack,
        Counter
    }

    public bool[] stored = new bool[6];

    public void Store(Inputs i)
    {
        stored[(int)i] = true;
    }
    public string Update(float t)
    {
        executeTimer += t;
        if (executeTimer >= EXECUTE_MAX)
        {
            //execute stored attack, based on preference order
            //counter takes all precedence
            if (stored[(int)Inputs.Counter])
                return "counter";
            //check for combo attack plus pushing a direction
            else if (stored[(int)Inputs.PAttack] && stored[(int)Inputs.MAttack] && stored[(int)Inputs.Forward])
                return "forwardCombo";
            //check for combo attack without direction
            else if (stored[(int)Inputs.PAttack] && stored[(int)Inputs.MAttack])
                return "combo";
            //check all physical attacks
            else if (stored[(int)Inputs.PAttack])
            {
                //up
                if (stored[(int)Inputs.Up])
                    return "physUp";
                //down
                else if (stored[(int)Inputs.Down])
                    return "physDown";
                //forward
                else if (stored[(int)Inputs.Forward])
                    return "physForward";
                //none
                else
                    return "phys";
            }
            //check all magical attacks
            else if (stored[(int)Inputs.MAttack])
            {
                //up
                if (stored[(int)Inputs.Up])
                    return "magUp";
                //down
                else if (stored[(int)Inputs.Down])
                    return "magDown";
                //forward
                else if (stored[(int)Inputs.Forward])
                    return "magForward";
                //none
                else
                    return "mag";
            }
            //no attacks pressed
            else
                return "none";
        }
        else
        {
            return "waiting";
        }
    }
    public void Reset()
    {
        executeTimer = 0f;
        for (int i = 0; i < 6; i++)
            stored[i] = false;
    }
}

