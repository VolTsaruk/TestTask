using UnityEngine;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    List<ControlGroup> m_objectGroup = new List<ControlGroup>();
    public ControlGroup ControlGroup;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            InterfaceController.ButtonController.AddButton(ControlGroup);
            
        }
        InterfaceController.ButtonController.RedrawInterface();
    }

}
