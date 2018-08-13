using System.Collections.Generic;
using UnityEngine;
using System;

public static class DataPrefs
{
    public static string key_x = "x";
    public static string key_y = "y";
    public static string key_z = "z";
    public static string key_vector2 = "Vector2";
    public static string key_vector3 = "Vector3";
    public static string key_list = "List";
    public static string key_exist = "exist";

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    //---------------------------------------------------------------------------------------------------------------
    // long
    //---------------------------------------------------------------------------------------------------------------

    public static void SetLong(string key, long val)
    {
        _SetLong(key, val);
    }

    private static void _SetLong(string key, long val)
    {
        PlayerPrefs.SetString(key, val.ToString());
    }

    public static long GetLong(string key)
    {
        return _GetLong(key);
    }

    public static long GetLong(string key, long init)
    {
        if (PlayerPrefs.HasKey(key))//exist
            return _GetLong(key);
        return init;
    }

    private static long _GetLong(string key)
    {
        return Convert.ToInt64(PlayerPrefs.GetString(key));
    }

    //---------------------------------------------------------------------------------------------------------------
    // ulong
    //---------------------------------------------------------------------------------------------------------------

    public static void SetULong(string key, ulong val)
    {
        _SetULong(key, val);
    }

    private static void _SetULong(string key, ulong val)
    {
        PlayerPrefs.SetString(key, val.ToString());
    }

    public static ulong GetULong(string key)
    {
        return _GetULong(key);
    }

    public static ulong GetULong(string key, ulong init)
    {
        if (PlayerPrefs.HasKey(key))
            return _GetULong(key);
        return init;
    }

    private static ulong _GetULong(string key)
    {
        return Convert.ToUInt64(PlayerPrefs.GetString(key));
    }

    //---------------------------------------------------------------------------------------------------------------
    // Vector2
    //---------------------------------------------------------------------------------------------------------------

    public static void SetVector2(string key, Vector2 val)
    {
        _SetVector2(key + key_vector2, val);
    }

    private static void _SetVector2(string key, Vector2 val)
    {
        PlayerPrefs.SetFloat(key + key_x, val.x);
        PlayerPrefs.SetFloat(key + key_y, val.y);
    }

    public static Vector2 GetVector2(string key)
    {
        return _GetVector2(key + key_vector2);
    }

    public static Vector2 GetVector2(string key, Vector2 init)
    {
        string Key = key + key_vector2;
        if (PlayerPrefs.HasKey(Key + key_x) && PlayerPrefs.HasKey(Key + key_x))
            return _GetVector2(Key);

        Debug.Log("Don't exist key");
        return init;
    }

    private static Vector2 _GetVector2(string key)
    {
        return new Vector2(PlayerPrefs.GetFloat(key + key_x), PlayerPrefs.GetFloat(key + key_y));
    }

    //---------------------------------------------------------------------------------------------------------------
    // Vector3
    //---------------------------------------------------------------------------------------------------------------

    public static void SetVector3(string key, Vector3 val)
    {
        _SetVector3(key, val);
    }

    private static void _SetVector3(string key, Vector3 val)
    {
        PlayerPrefs.SetFloat(key + key_vector3 + key_x, val.x);
        PlayerPrefs.SetFloat(key + key_vector3 + key_y, val.y);
        PlayerPrefs.SetFloat(key + key_vector3 + key_z, val.z);
    }

    public static Vector3 GetVector3(string key)
    {
        return _GetVector3(key + key_vector3);
    }

    public static Vector3 GetVector3(string key, Vector3 init)
    {
        string Key = key + key_vector3;
        if (PlayerPrefs.HasKey(Key + key_x) && PlayerPrefs.HasKey(Key + key_y) && PlayerPrefs.HasKey(Key + key_z))
            return _GetVector3(Key);

        Debug.Log("Don't exist key");
        return init;
    }

    private static Vector3 _GetVector3(string key)
    {
        return new Vector3(PlayerPrefs.GetFloat(key + key_x), PlayerPrefs.GetFloat(key + key_y), PlayerPrefs.GetFloat(key + key_z));
    }

    //---------------------------------------------------------------------------------------------------------------
    // List
    //---------------------------------------------------------------------------------------------------------------

    public static bool HashKeyList(string key)
    {
        return PlayerPrefs.HasKey(key + key_list + key_exist);
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<int>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<int> val)
    {
        _SetListInt(key, val);
    }

    public static void SetListInt(string key, List<int> val)
    {
        _SetListInt(key, val);
    }

    private static void _SetListInt(string key, List<int> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            PlayerPrefs.SetInt(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<int> GetListInt(string key)
    {
        return _GetListInt(key);
    }

    public static List<int> GetListInt(string key, List<int> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListInt(key);

        Debug.Log("Don't exist key");
        return init;
    }

    private static List<int> _GetListInt(string key)
    {
        List<int> val = new List<int>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key))
                break;

            val.Add(PlayerPrefs.GetInt(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListIntKey(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString();
            while (PlayerPrefs.HasKey(Key))
            {
                PlayerPrefs.DeleteKey(Key);
                count++;
                Key = key + key_list + count.ToString();
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListIntAt(string key, int index, int val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            PlayerPrefs.SetInt(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static int GetListIntAt(string key, int index, int init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            return PlayerPrefs.GetInt(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<string>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<string> val)
    {
        _SetListString(key, val);
    }

    public static void SetListString(string key, List<string> val)
    {
        _SetListString(key, val);
    }

    private static void _SetListString(string key, List<string> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            PlayerPrefs.SetString(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<string> GetListString(string key)
    {
        return _GetListString(key);
    }

    public static List<string> GetListString(string key, List<string> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListString(key);
        return init;
    }

    private static List<string> _GetListString(string key)
    {
        List<string> val = new List<string>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key))
                break;

            val.Add(PlayerPrefs.GetString(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListStringKey(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString();
            while (PlayerPrefs.HasKey(Key))
            {
                PlayerPrefs.DeleteKey(Key);
                count++;
                Key = key + key_list + count.ToString();
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListStringAt(string key, int index, string val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            PlayerPrefs.SetString(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static string GetListStringAt(string key, int index, string init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            return PlayerPrefs.GetString(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<float>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<float> val)
    {
        _SetListFloat(key, val);
    }

    public static void SetListFloat(string key, List<float> val)
    {
        _SetListFloat(key, val);
    }

    private static void _SetListFloat(string key, List<float> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            PlayerPrefs.SetFloat(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<float> GetListFloat(string key)
    {
        return _GetListFloat(key);
    }

    public static List<float> GetListFloat(string key, List<float> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListFloat(key);
        return init;
    }

    private static List<float> _GetListFloat(string key)
    {
        List<float> val = new List<float>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key))
                break;

            val.Add(PlayerPrefs.GetFloat(hash_key));
            count++;
        }

        return val;
    }

    public static void DeleteListFloatKey(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString();
            while (PlayerPrefs.HasKey(Key))
            {
                PlayerPrefs.DeleteKey(Key);
                count++;
                Key = key + key_list + count.ToString();
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListFloatAt(string key, int index, float val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            PlayerPrefs.SetFloat(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static float GetListFloatAt(string key, int index, float init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            return PlayerPrefs.GetFloat(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<long>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<long> val)
    {
        _SetListLong(key, val);
    }

    public static void SetListLong(string key, List<long> val)
    {
        _SetListLong(key, val);
    }

    private static void _SetListLong(string key, List<long> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            SetLong(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<long> GetListLong(string key)
    {
        return _GetListLong(key);
    }

    public static List<long> GetListLong(string key, List<long> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListLong(key);
        return init;
    }

    private static List<long> _GetListLong(string key)
    {
        List<long> val = new List<long>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key))
                break;

            val.Add(GetLong(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListLongKey(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString();
            while (PlayerPrefs.HasKey(Key))
            {
                PlayerPrefs.DeleteKey(Key);
                count++;
                Key = key + key_list + count.ToString();
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListLongAt(string key, int index, long val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            SetLong(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static long GetListLongAt(string key, int index, long init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            return GetLong(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<ulong>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<ulong> val)
    {
        _SetListULong(key, val);
    }

    public static void SetListULong(string key, List<ulong> val)
    {
        _SetListULong(key, val);
    }

    private static void _SetListULong(string key, List<ulong> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            SetULong(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<ulong> GetListULong(string key)
    {
        return _GetListULong(key);
    }

    public static List<ulong> GetListULong(string key, List<ulong> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListULong(key);
        return init;
    }

    private static List<ulong> _GetListULong(string key)
    {
        List<ulong> val = new List<ulong>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key))
                break;

            val.Add(GetULong(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListULongKey(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString();
            while (PlayerPrefs.HasKey(Key))
            {
                PlayerPrefs.DeleteKey(Key);
                count++;
                Key = key + key_list + count.ToString();
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListULongAt(string key, int index, ulong val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            SetULong(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static ulong GetListULongAt(string key, int index, ulong init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key))
            return GetULong(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<Vector2>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<Vector2> val)
    {
        _SetListVector2(key, val);
    }

    public static void SetListVector2(string key, List<Vector2> val)
    {
        _SetListVector2(key, val);
    }

    private static void _SetListVector2(string key, List<Vector2> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            SetVector2(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<Vector2> GetListVector2(string key)
    {
        return _GetListVector2(key);
    }

    public static List<Vector2> GetListVector2(string key, List<Vector2> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListVector2(key);
        return init;
    }

    private static List<Vector2> _GetListVector2(string key)
    {
        List<Vector2> val = new List<Vector2>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key + key_vector2 + key_x) || !PlayerPrefs.HasKey(hash_key + key_vector2 + key_y))
                break;

            val.Add(GetVector2(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListVector2Key(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString() + key_vector2;
            while (PlayerPrefs.HasKey(Key + key_x) && PlayerPrefs.HasKey(Key + key_y))
            {
                PlayerPrefs.DeleteKey(Key + key_x);
                PlayerPrefs.DeleteKey(Key + key_y);
                count++;
                Key = key + key_list + count.ToString() + key_vector2;
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListVector2At(string key, int index, Vector2 val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key + key_vector2 + key_x) && PlayerPrefs.HasKey(Key + key_vector2 + key_y))
            SetVector2(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static Vector2 GetListVector2At(string key, int index, Vector2 init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key + key_vector2 + key_x) && PlayerPrefs.HasKey(Key + key_vector2 + key_y))
            return GetVector2(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

    //---------------------------------------------------------------------------------------------------------------
    // List<Vector3>
    //---------------------------------------------------------------------------------------------------------------

    public static void SetList(string key, List<Vector3> val)
    {
        _SetListVector3(key, val);
    }

    public static void SetListVector3(string key, List<Vector3> val)
    {
        _SetListVector3(key, val);
    }

    private static void _SetListVector3(string key, List<Vector3> val)
    {
        PlayerPrefs.SetString(key + key_list + key_exist, "true");
        for (int i = 0; i < val.Count; i++)
        {
            SetVector3(key + key_list + i.ToString(), val[i]);
        }
    }

    public static List<Vector3> GetListVector3(string key)
    {
        return _GetListVector3(key);
    }

    public static List<Vector3> GetListVector3(string key, List<Vector3> init)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))
            return _GetListVector3(key);
        return init;
    }

    private static List<Vector3> _GetListVector3(string key)
    {
        List<Vector3> val = new List<Vector3>();

        int count = 0;
        string hash_key;

        while (true)
        {
            hash_key = key + key_list + count.ToString();

            if (!PlayerPrefs.HasKey(hash_key + key_vector3 + key_x) || !PlayerPrefs.HasKey(hash_key + key_vector3 + key_y) || !PlayerPrefs.HasKey(hash_key + key_vector3 + key_z))
                break;

            val.Add(GetVector3(hash_key));
            count++;
        }
        return val;
    }

    public static void DeleteListVector3Key(string key)
    {
        if (PlayerPrefs.HasKey(key + key_list + key_exist))//exist
        {
            int count = 0;
            string Key = key + key_list + count.ToString() + key_vector3;
            while (PlayerPrefs.HasKey(Key + key_x) && PlayerPrefs.HasKey(Key + key_y) && PlayerPrefs.HasKey(Key + key_z))
            {
                PlayerPrefs.DeleteKey(Key + key_x);
                PlayerPrefs.DeleteKey(Key + key_y);
                PlayerPrefs.DeleteKey(Key + key_z);
                count++;
                Key = key + key_list + count.ToString() + key_vector3;
            }

            PlayerPrefs.DeleteKey(key + key_list + key_exist);
        }
        else
        {
            Debug.Log("Don't exit thie key = " + key);
        }
    }

    public static void SetListVector3At(string key, int index, Vector3 val)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key + key_vector3 + key_x) && PlayerPrefs.HasKey(Key + key_vector3 + key_y) && PlayerPrefs.HasKey(Key + key_vector3 + key_z))
            SetVector3(Key, val);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
        }
    }

    public static Vector3 GetListVector3At(string key, int index, Vector3 init)
    {
        string Key = key + key_list + index.ToString();
        if (PlayerPrefs.HasKey(Key + key_vector3 + key_x) && PlayerPrefs.HasKey(Key + key_vector3 + key_y) && PlayerPrefs.HasKey(Key + key_vector3 + key_y))
            return GetVector3(Key);
        else
        {
            Debug.Log("Don't exist key or index : key = " + key + " , index = " + index.ToString());
            return init;
        }
    }

}
