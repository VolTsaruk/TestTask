using UnityEngine;
using System.Collections.Generic;

public static class ObjectCreator
{
    static Dictionary<string, List<GameObject>> objectsCache = new Dictionary<string, List<GameObject>>();
    public static GameObject Instantiate(GameObject prefab, string name)
    {
        GameObject obj;
        if(objectsCache.ContainsKey(name))
        {
            List<GameObject> list = objectsCache[name];
            if(list.Count>0)
            {
                int last = list.Count - 1;
                obj = list[last];
                list.RemoveAt(last);
            }
            else
            {
                obj = CreateInstance(prefab);
            }
        }
        else
        {
            objectsCache.Add(name, new List<GameObject>());
            obj = CreateInstance(prefab);
        }
        obj.SetActive(true);
        return obj;
    }
    static GameObject CreateInstance(GameObject prefab)
    {
        return Object.Instantiate(prefab) as GameObject;
    }
    public static void Destroy(GameObject obj, string categoryName)
    {
        objectsCache[categoryName].Add(obj);
        obj.SetActive(false);
    }
}
