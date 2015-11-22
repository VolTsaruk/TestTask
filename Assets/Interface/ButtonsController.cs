using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonsController : MonoBehaviour {

    List<GroupButton> m_buttons = new List<GroupButton>();
    public GameObject GroupButtonPrefab;



    void Awake()
    {
        InterfaceController.ButtonController = this;
    }

    public void AddButton(ControlGroup group)
    {
        GroupButton button = ObjectCreator.Instantiate(GroupButtonPrefab, "GroupButton").GetComponent<GroupButton>();
        button.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>(), false);
        button.SetControlGroup(group);
        group.SetGroupButton(button);
        button.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();
        m_buttons.Add(button);
    }

    public void RedrawInterface()
    {
        if (m_buttons.Count == 0) return;
        float width = m_buttons[0].GetComponent<RectTransform>().rect.width;
        int count = m_buttons.Count;
        float left = (1 - count) * width / 2;
        for (int i = 0; i < count; i++)
        {
            m_buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(left, 0);
            left += width;
        }
    }

}
