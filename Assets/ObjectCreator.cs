using UnityEngine;
using System.Collections.Generic;

public static class ObjectCreator
{
    public static GameObject Instantiate(GameObject prefab, string name)
    {
        return Object.Instantiate(prefab) as GameObject;
    }

}
