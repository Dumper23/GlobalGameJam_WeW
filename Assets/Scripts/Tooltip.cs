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

    private void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = localPoint;
    }

    private void ShowTooltip(SkillTree.Node node)
    {
        gameObject.SetActive(true);

        tooltipName.text = node.name;
        tooltipDesc.text = node.desc;
        tooltipCost.text = node.cost.ToString() + " Abono ";

        /*float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + textPaddingSize * 2f, tooltipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;*/
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
