using UnityEngine;
using System.Collections.Generic;

public  class LevelInitializer:MonoBehaviour
{
    Bounds bounds;
    public GameObject ControlGroupPrefab;
    public GameObject PonyPrefab;
    List<ControlGroup> m_groups = new List<ControlGroup>();
    List<Pony> m_ponies = new List<Pony>();
    void InitControlGroup(Vector2 position, Color color)
    {
        ControlGroup group = ObjectCreator.Instantiate(ControlGroupPrefab, "ControlGroup").GetComponent<ControlGroup>();
        group.transform.position = position;
        group.transform.parent = transform.parent;
        group.SetGroupColor(color);
        m_groups.Add(group);
        InterfaceController.ButtonController.AddButton(group);
        
    }
    void InitPony(Vector2 position)
    {
        Pony pony = ObjectCreator.Instantiate(PonyPrefab, "Pony").GetComponent<Pony>();
        pony.transform.parent = transform.parent;
        pony.transform.position = position;
        m_ponies.Add(pony);
    }
    public void Init(int numDogs=3, int numPonys=10)
    {
        bounds = GetComponent<Renderer>().bounds;
        for (int i = 0; i < numDogs; i++)
        {
            InitControlGroup(new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)), new Color(Random.Range(0,1f), Random.Range(0, 1f), Random.Range(0, 1f)));
        }
        for(int i=0; i< numPonys; i++)
        {
            InitPony(new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)));
        }
        InterfaceController.ButtonController.RedrawInterface();
    }
    public void DestroyLevel()
    {
        foreach(ControlGroup x in m_groups)
        {
            ObjectCreator.Destroy(x.gameObject, "ControlGroup");
        }
        foreach(Pony x in m_ponies)
        {
            ObjectCreator.Destroy(x.gameObject, "Pony");
        }
        m_groups.Clear();
        m_ponies.Clear();
        InterfaceController.ButtonController.Reset();
    }
    public List<ControlGroup> GetInitializedGroups()
    {
        return m_groups;
    }



}
