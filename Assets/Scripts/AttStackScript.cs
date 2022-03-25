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
                return "forward combo";
            //check for combo attack without direction
            else if (stored[(int)Inputs.PAttack] && stored[(int)Inputs.MAttack])
                return "combo";
            //check all physical attacks
            else if (stored[(int)Inputs.PAttack])
            {
                //up
                if (stored[(int)Inputs.Up])
                    return "phys up";
                //down
                else if (stored[(int)Inputs.Down])
                    return "phys down";
                //forward
                else if (stored[(int)Inputs.Forward])
                    return "phys forward";
                //none
                else
                    return "phys";
            }
            //check all magical attacks
            else if (stored[(int)Inputs.MAttack])
            {
                //up
                if (stored[(int)Inputs.Up])
                    return "mag up";
                //down
                else if (stored[(int)Inputs.Down])
                    return "mag down";
                //forward
                else if (stored[(int)Inputs.Forward])
                    return "mag forward";
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

