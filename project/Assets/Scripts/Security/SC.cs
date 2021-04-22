using UnityEngine;
using System.Collections;
using System.Text;

public class SC
{
    public const int M = 64;
    public const int B = 255;

    public static byte[] E(byte[] _v)
    {
        int vl = _v.Length;
        int l = 0;

        if (vl < 2)
            l = 0;
        else
        {
            int m = (vl - 1 > M ? M : vl - 1);
            l = Random.Range(1, m);
        }

        byte[] rt = new byte[vl + l + 1];

        int r = 0;
        for (int i = 0; i < rt.Length - 1; i++)
        {
            if (r < l)
            {
                if (i % 2 == 1)
                {
                    rt[i] = (byte)Random.Range(0, B);
                    r++;
                }
                else
                {
                    rt[i] = _v[i - r];
                }
            }
            else
            {
                rt[i] = _v[i - r];
            }
        }
        rt[rt.Length - 1] = (byte)l;

        return rt;
    }
}


