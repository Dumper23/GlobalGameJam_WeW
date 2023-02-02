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
    public Image image;
    public LineRenderer lineRenderer;

    // Clase
    private SkillTree.Node node;

    public void Init()
    {
        node = SkillTree.Instance.GetNode(id);
        SkillTree.Instance.SkillNodes[id].skill = this;
    }

    public void UpdateUI()
    {
        if (SkillTree.Instance.GetNode(node.previousNodeId).buyed) gameObject.SetActive(true); else gameObject.SetActive(false);

        if (node == null) Init();

        image.color = node.buyed ? Color.yellow : !SkillTree.Instance.GetNode(node.previousNodeId).buyed ? Color.gray :
            SkillTree.Instance.Money >= node.cost ? Color.green : Color.red;
    }

    public void Buy()
    {
        if (SkillTree.Instance.Money < node.cost || node.buyed || !SkillTree.Instance.GetNode(node.previousNodeId).buyed) return;
        SkillTree.Instance.Money -= node.cost;
        node.buyed = true;
        SkillTree.Instance.UpdateAllSkillsUI();

        // Roots UI
        CreateLine();
        if (node.previousNodeId != 0) SkillTree.Instance.GetNode(node.previousNodeId).skill.UpdateLine();

        //Accio
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltip_Static(node);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltip_Static();
    }

    public void CreateLine()
    {
        lineRenderer.SetPosition(1, this.gameObject.transform.position);
        if(node.previousNodeId!=0) lineRenderer.SetPosition(0, SkillTree.Instance.GetNode(node.previousNodeId).skill.gameObject.transform.position);
        lineRenderer.startWidth = 10;
        lineRenderer.endWidth = 5;
    }

    public void UpdateLine()
    {
        if(lineRenderer.startWidth < 60) lineRenderer.startWidth += 5;
        if (lineRenderer.endWidth < 40) lineRenderer.endWidth += 5;
        if (node.previousNodeId != 0) SkillTree.Instance.GetNode(node.previousNodeId).skill.UpdateLine();
    }
}
