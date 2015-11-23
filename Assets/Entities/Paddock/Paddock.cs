using UnityEngine;
using System.Collections;

public class Paddock : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Pony")
        {
            collider.GetComponent<Pony>().Finish();
            LevelController.Instance.OnPonyEnterPaddock();
        }
    }
}
