using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ÀÁººË«ÖØËøµ¥Àý
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : class, new ()
{
    private static T m_instance;
    private static readonly Object m_obj = new Object();

    protected Singleton() { }

    public static T Instance()
    {
        if(m_instance == null)
        {
            lock(m_obj)
            {
                if(m_instance == null)
                {
                    m_instance = new T();
                }
            }
        }
        return m_instance;
    }
}
