using UnityEngine;
using System.Collections.Generic;

public  class LevelInitializer:MonoBehaviour
{
    Bounds bounds;
    public GameObject ControlGroupPrefab;
    List<ControlGroup> m_groups = new List<ControlGroup>();
    void InitControlGroup(Vector2 position, Color color)
    {
        ControlGroup group = ObjectCreator.Instantiate(ControlGroupPrefab, "ControlGroup").GetComponent<ControlGroup>();
        group.transform.position = position;
        group.transform.parent = transform.parent;
        group.SetGroupColor(color);
        m_groups.Add(group);
        InterfaceController.ButtonController.AddButton(group);
       
    }
    public void Init()
    {
        bounds = GetComponent<Renderer>().bounds;
        for (int i = 0; i < 3; i++)
        {
            InitControlGroup(new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)), new Color(Random.Range(0,1f), Random.Range(0, 1f), Random.Range(0, 1f)));
        }
        InterfaceController.ButtonController.RedrawInterface();
    }
    public List<ControlGroup> GetInitializedGroups()
    {
        return m_groups;
    }



}
