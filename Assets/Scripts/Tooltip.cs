using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;

    [SerializeField]
    private Camera uiCamera;

    [SerializeField]
    private TMP_Text tooltipName;
    [SerializeField]
    private TMP_Text tooltipDesc;
    [SerializeField]
    private TMP_Text tooltipCost;
    [SerializeField]
    private RectTransform backgroundRectTransform;
    [SerializeField]
    private RectTransform canvasRectTransform;

    private void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);

        
        if (localPoint.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width/2){
            localPoint.x -= ((backgroundRectTransform.rect.width + localPoint.x) - canvasRectTransform.rect.width/2);
        }

        if (localPoint.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height/2){
            localPoint.y -= ((backgroundRectTransform.rect.height + localPoint.y) - canvasRectTransform.rect.height / 2);
        }

        transform.localPosition = localPoint;
    }

    private void ShowTooltip(SkillTree.Node node)
    {
        gameObject.SetActive(true);

        tooltipName.text = node.name;
        tooltipDesc.text = node.desc;
        if (node.cost != 0) tooltipCost.text = node.cost.ToString() + " Fertilizer";
        else tooltipCost.text = "";
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(SkillTree.Node node)
    {
        Instance.ShowTooltip(node);
    }

    public static void HideTooltip_Static()
    {
        Instance.HideTooltip();
    }
}
