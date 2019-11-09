using UnityEngine;

public class Dice : MonoBehaviour
{
    public static int Roll(int _size, int _amount)
    {
        int result = new int();
        for (int i = 0; i < _amount; i++)
        {
            System.Random r = new System.Random();
            int rInt = r.Next(1, _size);
            result += rInt;
        }
        return result;
    }
}
