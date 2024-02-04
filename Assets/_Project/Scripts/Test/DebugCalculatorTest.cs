using UnityEngine;

public class DebugCalculatorTest : MonoBehaviour
{
    [SerializeField] int num;
    [SerializeField] int iterator;
    [SerializeField] int multiplier;
    [SerializeField] int divider;


    void Awake()
    {
        for (int i = 0; i < iterator; i++)
        {
            num += num;
        }

        Calc();

        print(num);
    }

    void Calc()
    {
        num *= multiplier;

        num /= divider;
    }
}