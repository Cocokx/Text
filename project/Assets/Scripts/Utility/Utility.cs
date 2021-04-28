using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Utility
{
    public static float GetAnimaClipTimeLenght(Animator _animator, string _animaName)
    {
        float length = 0;
        AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name.Equals(_animaName))
            {
                length = clip.length;
                break;
            }
        }
        return length;
    }
    public static float GetAngleByVector(Vector2 _vector)
    {
        float mAngle = Mathf.Atan2(_vector.y, _vector.x) * Mathf.Rad2Deg;
        return mAngle;
    }

    public static long GetCurrentTimeSpan()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long ret = Convert.ToInt64(ts.TotalSeconds);
        return ret;
    }

    public static void FisherYatesShuffle<T>(List<T> list)
    {
        if (null != list && list.Count > 0)
        {
            List<T> cache = new List<T>();
            int currentIndex;
            while (list.Count > 0)
            {
                currentIndex = UnityEngine.Random.Range(0, list.Count);
                cache.Add(list[currentIndex]);
                list.RemoveAt(currentIndex);
            }
            for (int i = 0; i < cache.Count; i++)
            {
                list.Add(cache[i]);
            }
        }
        else
            Debug.LogError("---FisherYatesShuffle-data-error------");
        
    }


    public static string SetCoinStyle(float num)
    {
        // Debug.Log("传进来的数" + num);
        double Number = num;
        string str = "";
        if ((Number < 0.1f && Number >= 0) || (Number > -0.1f && Number <= 0))
            str = "0";
        else
        {
            int index = Number.ToString().IndexOf(".");
            if (index == -1)
                str = Number.ToString("N1");
            else
                str = ((float.Parse)(Number.ToString().Substring(0, index + 2)).ToString("N1"));
        }
        // Debug.Log(str+"显示的最终结果");

        return str.Replace(".0", "");
    }


    public static List<T> RandomSortList<T>(List<T> ListT)
    {
        System.Random random = new System.Random();
        List<T> newList = new List<T>();
        foreach (T item in ListT)
        {
            newList.Insert(random.Next(newList.Count), item);
        }
        return newList;
    }
}

