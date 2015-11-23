using UnityEngine;
using System.Collections;

public class Catcher : MonoBehaviour
{
    public Dog parentDog;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag=="Pony")
        {
            collider.GetComponent<Pony>().AttachToGroup(parentDog.GetComponent<GroupableObject>().ParentGroup);
        }
    }

    


}
