﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//public class TDeepChildFinder<T, K> where T : IEnumerable
//{
//    //Breadth-first search
//    public T FindDeepChild(T aParent, string aFieldLink, K aField)
//    {
//        Queue<T> queue = new Queue<T>();
//        queue.Enqueue(aParent);
//        while (queue.Count > 0)
//        {
//            var c = queue.Dequeue();
//            if (aParent.GetType().GetField(aFieldLink, BindingFlags.NonPublic | BindingFlags.Instance).Equals(aField))
//                return c;
//            foreach (T t in c)
//                queue.Enqueue(t);
//        }
//        return default(T);
//    }
//}
public static class TransformDeepChildExtension
{
    //Breadth-first search
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        Queue<Transform> queue = new Queue<Transform>();
        queue.Enqueue(aParent);
        while (queue.Count > 0)
        {
            var c = queue.Dequeue();
            if (c.name == aName)
                return c;
            foreach (Transform t in c)
                queue.Enqueue(t);
        }
        return null;
    }
}