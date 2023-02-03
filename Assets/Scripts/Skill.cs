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
    public Sprite[] icons;
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

        if (icons.Length == 3) image.sprite = node.buyed ? icons[0] : !SkillTree.Instance.GetNode(node.previousNodeId).buyed ? icons[0] :
            SkillTree.Instance.Money >= node.cost ? icons[2] : icons[1];
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
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.1f;
    }

    public void UpdateLine()
    {
        if(SkillTree.Instance.GetNode(node.previousNodeId).id == 0)
        {
            if (lineRenderer.startWidth < 10.0f) lineRenderer.startWidth += 0.5f;
            if (lineRenderer.endWidth < 1.0f) lineRenderer.endWidth += 0.3f;
            if (node.previousNodeId != 0) SkillTree.Instance.GetNode(node.previousNodeId).skill.UpdateLine();

        } else
        {
            if (lineRenderer.startWidth < 1.0f) lineRenderer.startWidth += 0.1f;
            if (lineRenderer.endWidth < 1.5f) lineRenderer.endWidth += 0.1f;
            if (node.previousNodeId != 0) SkillTree.Instance.GetNode(node.previousNodeId).skill.UpdateLine();

        }
    }
}
