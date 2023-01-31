using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Skill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int id;

    // Graphic
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    // Clase
    private SkillTree.Node node;

    public void Init()
    {
        node = SkillTree.Instance.GetNode(id);
        SkillTree.Instance.SkillNodes[id].skill = this;
    }

    public void UpdateUI()
    {
        if (node == null) Init();
        TitleText.text = node.name;
        DescriptionText.text = $"{node.desc}\nCost: {node.cost}";

        GetComponent<Image>().color = !SkillTree.Instance.GetNode(node.previousNodeId).buyed ? Color.yellow :
            SkillTree.Instance.Money >= node.cost ? Color.green : Color.white;
    }

    public void Buy()
    {
        if (SkillTree.Instance.Money < node.cost || node.buyed) return;
        SkillTree.Instance.Money -= node.cost;
        node.buyed = true;
        SkillTree.Instance.UpdateAllSkillsUI();
        //Accio
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltip_Static(node.desc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltip_Static();
    }
}
