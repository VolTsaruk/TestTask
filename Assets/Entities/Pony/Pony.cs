using UnityEngine;
using System.Collections;

public class Pony : MonoBehaviour {

    public void AttachToGroup(ControlGroup group)
    {
        GetComponent<GroupableObject>().SetParent(group);
    }
    public void Detach()
    {
        GetComponent<GroupableObject>().Free();
    }

}
