using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks
{
    public class Attack
    {
        public int hits;
        public float[] windUp;
        public float animTime;
        public Vector2 attackPos;
        public float rad;
        public int[] attackType;
        public float[] damage;
        public float balChange;

        public Attack(int hits, float[] windUp, float animTime, Vector2 attackPos, float rad,
            int[] attackType, float[] damage, float balChange)
        {
            this.hits = hits;
            this.windUp = windUp;
            this.animTime = animTime;
            this.attackPos = attackPos;
            this.rad = rad;
            this.attackType = attackType;
            this.damage = damage;
            this.balChange = balChange;

        }
        public int GetType(int h, bool ud)
        {
            return (attackType[h] == 0) ? 0 : (ud) ? 1 : 2;
        }
    }
    public static Dictionary<string, Attack> SetGroundAttacks()
    {
        Dictionary<string, Attack> attacks = new Dictionary<string, Attack>();
        //COMBO ATTACKS
        attacks.Add("combo",                                //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f,0f), 2f,                     //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            20f));                                          //balance change

        attacks.Add("forwardCombo",                         //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(1f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            20f));                                          //balance change

        //PHYSICAL ATTACKS
        attacks.Add("phys",                                 //name
            new Attack(1, new float[] { 0.4f },             //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0 }, new float[] { 6f },            //attack type, damage
            0f));                                           //balance change
        attacks.Add("physUp",                               //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("physDown",                             //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("physForward",                          //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 1f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change

        //MAGICAL ATTACKS
        attacks.Add("mag",                                  //name
            new Attack(1, new float[] { 0.3f },             //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 1 }, new float[] { 8f },      //attack type, damage
            8f));                                           //balance change
        attacks.Add("magUp",                                //name
            new Attack(2, new float[] { 0.2f, 0.2f },       //swings, wind up
            1f, new Vector2(0.75f, 1.5f), 1f,                  //total anim time, pos, radius
            new int[] { 1, 1 }, new float[] { 3f, 3f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("magDown",                              //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("magForward",                           //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change

        return attacks;
    }

    public static Dictionary<string, Attack> SetAirAttacks()
    {
        Dictionary<string, Attack> attacks = new Dictionary<string, Attack>();
        //COMBO ATTACKS
        attacks.Add("combo",                                //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                     //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            20f));                                          //balance change

        attacks.Add("forwardCombo",                         //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(1f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            20f));                                          //balance change

        //PHYSICAL ATTACKS
        attacks.Add("phys",                                 //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("physUp",                               //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("physDown",                             //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("physForward",                          //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 1f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change

        //MAGICAL ATTACKS
        attacks.Add("mag",                                  //name
            new Attack(1, new float[] { 0.3f },             //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 1 }, new float[] { 8f },      //attack type, damage
            8f));                                           //balance change
        attacks.Add("magUp",                                //name
            new Attack(2, new float[] { 0.2f, 0.2f },       //swings, wind up
            1f, new Vector2(0.75f, 1.5f), 1f,                  //total anim time, pos, radius
            new int[] { 1, 1 }, new float[] { 3f, 3f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("magDown",                              //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change
        attacks.Add("magForward",                           //name
            new Attack(2, new float[] { 0.5f, 0.25f },      //swings, wind up
            1f, new Vector2(0f, 0f), 2f,                    //total anim time, pos, radius
            new int[] { 0, 1 }, new float[] { 10f, 10f },   //attack type, damage
            0f));                                           //balance change

        return attacks;
    }
}
