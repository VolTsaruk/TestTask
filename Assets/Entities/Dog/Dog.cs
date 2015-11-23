using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour
{

    public SpriteRenderer Collar;
    public void SetCollarColor(Color color)
    {
        Collar.color = color;
    }




}
