using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDecal : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] private Sprite[] blood;

    private void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        int rand = Random.Range(0, blood.Length);
        renderer.sprite = blood[rand];
    }
}