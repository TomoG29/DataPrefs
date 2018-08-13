using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Test_list_vector3();
        PlayerPrefs.DeleteAll();
    }

    private void Test_long()
    {
        string key = "sample_Test_long";
        long v = 1000000000000;

        DataPrefs.SetLong(key, v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetLong(key).ToString());
    }

    private void Test_long_init()
    {
        string key = "sample_Test_long_init";
        long v = 1000000000000;

        DataPrefs.SetLong(key + "wrong", v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetLong(key, 0).ToString());
    }

    private void Test_ulong()
    {
        string key = "sample_Test_ulong";
        ulong v = 10000000000000000000;

        DataPrefs.SetULong(key, v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetULong(key).ToString());
    }

    private void Test_ulong_init()
    {
        string key = "sample_Test_ulong_init";
        ulong v = 10000000000000000000;

        DataPrefs.SetULong(key + "wrong", v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetULong(key, 0).ToString());
    }

    private void Test_vector2()
    {
        string key = "sample_Test_vector2";
        Vector2 v = new Vector2(1.0f, 1.5f);

        DataPrefs.SetVector2(key, v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetVector2(key).ToString());
    }

    private void Test_vector2_init()
    {
        string key = "sample_Test_vector2_init";
        Vector2 v = new Vector2(1.0f, 1.5f);

        DataPrefs.SetVector2(key + "wrong", v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetVector2(key, Vector2.zero).ToString());
    }

    private void Test_vector3()
    {
        string key = "sample_Test_vector3";
        Vector3 v = new Vector3(1.0f, 1.5f, 2.0f);

        DataPrefs.SetVector3(key, v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetVector3(key).ToString());
    }

    private void Test_vector3_init()
    {
        string key = "sample_Test_vector3_init";
        Vector3 v = new Vector3(1.0f, 1.5f, 2.0f);

        DataPrefs.SetVector3(key + "wrong", v);
        DataPrefs.Save();

        Debug.Log(DataPrefs.GetVector2(key, Vector3.zero).ToString());
    }

    private void Test_list_int()
    {
        string key = "sample_Test_list_int";
        List<int> v = new List<int>();
        v.Add(10);
        v.Add(200);
        v.Add(300);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<int> ans = DataPrefs.GetListInt(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_int_init()
    {
        string key = "sample_Test_list_int_init";
        List<int> v = new List<int>();
        v.Add(10);
        v.Add(200);
        v.Add(300);

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<int> init = new List<int> { 0 };
        List<int> ans = DataPrefs.GetListInt(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_int_del()
    {
        string key = "sample_Test_list_int_del";
        List<int> v = new List<int>();
        v.Add(10);
        v.Add(200);
        v.Add(300);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListIntKey(key);

        List<int> init = new List<int> { 0 };
        List<int> ans = DataPrefs.GetListInt(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }

    }

    private void Test_list_int_AtSet()
    {
        string key = "sample_Test_list_int_AtSet";
        List<int> v = new List<int>();
        v.Add(10);
        v.Add(200);
        v.Add(300);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListIntAt(key, 1, 500);

        DataPrefs.Save();

        List<int> init = new List<int> { 0 };
        List<int> ans = DataPrefs.GetListInt(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_int_AtGet()
    {
        string key = "sample_Test_list_int_AtGet";
        List<int> v = new List<int>();
        v.Add(10);
        v.Add(200);
        v.Add(300);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListIntAt(key, 1, 0).ToString());
    }

    private void Test_list_float()
    {
        string key = "sample_Test_list_float";
        List<float> v = new List<float>();
        v.Add(0.1f);
        v.Add(0.2f);
        v.Add(0.3f);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<float> ans = DataPrefs.GetListFloat(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_float_init()
    {
        string key = "sample_Test_list_float_init";
        List<float> v = new List<float>();
        v.Add(0.1f);
        v.Add(0.2f);
        v.Add(0.3f);

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<float> init = new List<float> { 0 };
        List<float> ans = DataPrefs.GetListFloat(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_float_del()
    {
        string key = "sample_Test_list_float_del";
        List<float> v = new List<float>();
        v.Add(0.1f);
        v.Add(0.2f);
        v.Add(0.3f);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListFloatKey(key);

        List<float> init = new List<float> { 0 };
        List<float> ans = DataPrefs.GetListFloat(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_float_AtSet()
    {
        string key = "sample_Test_list_float_AtSet";
        List<float> v = new List<float>();
        v.Add(0.1f);
        v.Add(0.2f);
        v.Add(0.3f);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListFloatAt(key, 1, 5.0f);

        DataPrefs.Save();

        List<float> init = new List<float> { 0 };
        List<float> ans = DataPrefs.GetListFloat(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_float_AtGet()
    {
        string key = "sample_Test_list_float_AtGet";
        List<float> v = new List<float>();
        v.Add(0.1f);
        v.Add(0.2f);
        v.Add(0.3f);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListFloatAt(key, 1, 0.0f).ToString());
    }

    private void Test_list_string()
    {
        string key = "sample_Test_list_string";
        List<string> v = new List<string>();
        v.Add("a");
        v.Add("b");
        v.Add("c");

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<string> ans = DataPrefs.GetListString(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_string_init()
    {
        string key = "sample_Test_list_string_init";
        List<string> v = new List<string>();
        v.Add("a");
        v.Add("b");
        v.Add("c");

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<string> init = new List<string> { "k" };
        List<string> ans = DataPrefs.GetListString(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_string_del()
    {
        string key = "sample_Test_list_string_del";
        List<string> v = new List<string>();
        v.Add("a");
        v.Add("b");
        v.Add("c");

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListStringKey(key);

        List<string> init = new List<string> { "k" };
        List<string> ans = DataPrefs.GetListString(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }

    }

    private void Test_list_string_AtSet()
    {
        string key = "sample_Test_list_string_AtSet";
        List<string> v = new List<string>();
        v.Add("a");
        v.Add("b");
        v.Add("c");

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListStringAt(key, 1, "m");

        DataPrefs.Save();

        List<string> init = new List<string> { "k" };
        List<string> ans = DataPrefs.GetListString(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_string_AtGet()
    {
        string key = "sample_Test_list_string_AtGet";
        List<string> v = new List<string>();
        v.Add("a");
        v.Add("b");
        v.Add("c");

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListStringAt(key, 1, "n").ToString());
    }

    private void Test_list_long()
    {
        string key = "sample_Test_list_long";
        List<long> v = new List<long>();
        v.Add(1000000000000000);
        v.Add(2000000000000000);
        v.Add(3000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<long> ans = DataPrefs.GetListLong(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_long_init()
    {
        string key = "sample_Test_list_long_init";
        List<long> v = new List<long>();
        v.Add(1000000000000000);
        v.Add(2000000000000000);
        v.Add(3000000000000000);

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<long> init = new List<long> { 0 };
        List<long> ans = DataPrefs.GetListLong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_long_del()
    {
        string key = "sample_Test_list_long_del";
        List<long> v = new List<long>();
        v.Add(1000000000000000);
        v.Add(2000000000000000);
        v.Add(3000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListLongKey(key);

        List<long> init = new List<long> { 0 };
        List<long> ans = DataPrefs.GetListLong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }

    }

    private void Test_list_long_AtSet()
    {
        string key = "sample_Test_list_long_AtSet";
        List<long> v = new List<long>();
        v.Add(1000000000000000);
        v.Add(2000000000000000);
        v.Add(3000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListLongAt(key, 1, 7000000000000000);

        DataPrefs.Save();

        List<long> init = new List<long> { 0 };
        List<long> ans = DataPrefs.GetListLong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_long_AtGet()
    {
        string key = "sample_Test_list_long_AtGet";
        List<long> v = new List<long>();
        v.Add(1000000000000000);
        v.Add(2000000000000000);
        v.Add(3000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListLongAt(key, 1, 7000000000000000).ToString());
    }

    private void Test_list_ulong()
    {
        string key = "sample_Test_list_ulong";
        List<ulong> v = new List<ulong>();
        v.Add(10000000000000000000);
        v.Add(12000000000000000000);
        v.Add(14000000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<ulong> ans = DataPrefs.GetListULong(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_ulong_init()
    {
        string key = "sample_Test_list_ulong_init";
        List<ulong> v = new List<ulong>();
        v.Add(10000000000000000000);
        v.Add(12000000000000000000);
        v.Add(14000000000000000000);

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<ulong> init = new List<ulong> { 0 };
        List<ulong> ans = DataPrefs.GetListULong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_ulong_del()
    {
        string key = "sample_Test_list_ulong_del";
        List<ulong> v = new List<ulong>();
        v.Add(10000000000000000000);
        v.Add(12000000000000000000);
        v.Add(14000000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListULongKey(key);

        List<ulong> init = new List<ulong> { 0 };
        List<ulong> ans = DataPrefs.GetListULong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }

    }

    private void Test_list_ulong_AtSet()
    {
        string key = "sample_Test_list_ulong_AtSet";
        List<ulong> v = new List<ulong>();
        v.Add(10000000000000000000);
        v.Add(12000000000000000000);
        v.Add(14000000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListULongAt(key, 1, 16000000000000000000);

        DataPrefs.Save();

        List<ulong> init = new List<ulong> { 0 };
        List<ulong> ans = DataPrefs.GetListULong(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_ulong_AtGet()
    {
        string key = "sample_Test_list_ulong_AtGet";
        List<ulong> v = new List<ulong>();
        v.Add(10000000000000000000);
        v.Add(12000000000000000000);
        v.Add(14000000000000000000);

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListULongAt(key, 1, 16000000000000000000).ToString());
    }

    private void Test_list_vector2()
    {
        string key = "sample_Test_list_vector2";
        List<Vector2> v = new List<Vector2>();
        v.Add(new Vector2(1, 1));
        v.Add(new Vector2(3, 3));
        v.Add(new Vector2(10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<Vector2> ans = DataPrefs.GetListVector2(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector2_init()
    {
        string key = "sample_Test_list_vector2_init";
        List<Vector2> v = new List<Vector2>();
        v.Add(new Vector2(1, 1));
        v.Add(new Vector2(3, 3));
        v.Add(new Vector2(10, 10));

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<Vector2> init = new List<Vector2> { Vector2.zero };
        List<Vector2> ans = DataPrefs.GetListVector2(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector2_del()
    {
        string key = "sample_Test_list_vector2_del";
        List<Vector2> v = new List<Vector2>();
        v.Add(new Vector2(1, 1));
        v.Add(new Vector2(3, 3));
        v.Add(new Vector2(10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListVector2Key(key);

        List<Vector2> init = new List<Vector2> { Vector2.zero };
        List<Vector2> ans = DataPrefs.GetListVector2(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector2_AtSet()
    {
        string key = "sample_Test_list_vector2_AtSet";
        List<Vector2> v = new List<Vector2>();
        v.Add(new Vector2(1, 1));
        v.Add(new Vector2(3, 3));
        v.Add(new Vector2(10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListVector2At(key, 1, new Vector2(15, 15));

        DataPrefs.Save();

        List<Vector2> init = new List<Vector2> { Vector2.zero };
        List<Vector2> ans = DataPrefs.GetListVector2(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector2_AtGet()
    {
        string key = "sample_Test_list_vector2_AtGet";
        List<Vector2> v = new List<Vector2>();
        v.Add(new Vector2(1, 1));
        v.Add(new Vector2(3, 3));
        v.Add(new Vector2(10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListVector2At(key, 1, Vector2.zero).ToString());
    }

    private void Test_list_vector3()
    {
        string key = "sample_Test_list_vector3";
        List<Vector3> v = new List<Vector3>();
        v.Add(new Vector3(1, 1, 1));
        v.Add(new Vector3(3, 3, 3));
        v.Add(new Vector3(10, 10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        List<Vector3> ans = DataPrefs.GetListVector3(key);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector3_init()
    {
        string key = "sample_Test_list_vector3_init";
        List<Vector3> v = new List<Vector3>();
        v.Add(new Vector3(1, 1, 1));
        v.Add(new Vector3(3, 3, 3));
        v.Add(new Vector3(10, 10, 10));

        DataPrefs.SetList(key + "wrong", v);

        DataPrefs.Save();

        List<Vector3> init = new List<Vector3> { Vector3.zero };
        List<Vector3> ans = DataPrefs.GetListVector3(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector3_del()
    {
        string key = "sample_Test_list_vector3_del";
        List<Vector3> v = new List<Vector3>();
        v.Add(new Vector3(1, 1, 1));
        v.Add(new Vector3(3, 3, 3));
        v.Add(new Vector3(10, 10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();
        DataPrefs.DeleteListVector3Key(key);

        List<Vector3> init = new List<Vector3> { Vector3.zero };
        List<Vector3> ans = DataPrefs.GetListVector3(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector3_AtSet()
    {
        string key = "sample_Test_list_vector3_AtSet";
        List<Vector3> v = new List<Vector3>();
        v.Add(new Vector3(1, 1, 1));
        v.Add(new Vector3(3, 3, 3));
        v.Add(new Vector3(10, 10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        DataPrefs.SetListVector3At(key, 1, new Vector3(15, 15, 15));

        DataPrefs.Save();

        List<Vector3> init = new List<Vector3> { Vector3.zero };
        List<Vector3> ans = DataPrefs.GetListVector3(key, init);

        for (int i = 0; i < ans.Count; i++)
        {
            Debug.Log(ans[i].ToString());
        }
    }

    private void Test_list_vector3_AtGet()
    {
        string key = "sample_Test_list_vector3_AtGet";
        List<Vector3> v = new List<Vector3>();
        v.Add(new Vector3(1, 1, 1));
        v.Add(new Vector3(3, 3, 3));
        v.Add(new Vector3(10, 10, 10));

        DataPrefs.SetList(key, v);

        DataPrefs.Save();

        Debug.Log(DataPrefs.GetListVector3At(key, 1, Vector3.zero).ToString());
    }

}
