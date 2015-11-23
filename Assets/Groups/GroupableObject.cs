using UnityEngine;
using System.Collections;

///<summary>Provides communication between game object and it's group</summary>
public class GroupableObject : MonoBehaviour
{
   
    public ControlGroup ParentGroup;
    public void SetParent(ControlGroup parentGroup)
    {
        if (ParentGroup == null)
        {
            ParentGroup = parentGroup;
            transform.parent = parentGroup.transform;
        }
    }
    public void Free()
    {
        ParentGroup = null;
        transform.parent = LevelController.Instance.transform;
    }
    public void OnClick()
    {
        if (ParentGroup != null)
            ParentGroup.Activate();
    }
    public void ApplyMove(Vector2 direction)
    {

    }

}
