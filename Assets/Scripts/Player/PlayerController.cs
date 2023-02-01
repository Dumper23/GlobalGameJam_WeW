using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move player in 2D space
    public float movementSpeed = 4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public float groundCheckDistance = 1f;
    public float interactionRange = 0.5f;
    public LayerMask groundLayer;
    public GameObject interactionSymbolE;
    public GameObject interactionSymbolWS;
    public Material outlineMaterial;

    private float moveDirection = 0;
    private Rigidbody2D r2d;
    public List<IEInteractable> oldInteractables = new List<IEInteractable>();
    public List<Material> oldMaterials = new List<Material>();

    BoxCollider2D mainCollider;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        //Move
        moveDirection = Mathf.Lerp(moveDirection, Input.GetAxis("Horizontal"), 0.03f);
        if (moveDirection < 0.1f)
        {
            r2d.velocity = new Vector2(0, r2d.velocity.y);
        }

        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (moveDirection < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            r2d.velocity = new Vector2(r2d.velocity.x * movementSpeed, jumpHeight);
        }

        r2d.velocity = new Vector2(moveDirection * movementSpeed, r2d.velocity.y);
        #endregion


        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        List<IEInteractable> interactables = new List<IEInteractable>();

        foreach (var collision in collisions)
        {
            if (collision.GetComponent<IEInteractable>())
            {
                interactables.Add(collision.GetComponent<IEInteractable>());
                if (!oldInteractables.Contains(collision.GetComponent<IEInteractable>())) {
                    oldInteractables.Add(collision.GetComponent<IEInteractable>());
                }
                if (!oldMaterials.Contains(collision.GetComponent<SpriteRenderer>().material) && !collision.GetComponent<SpriteRenderer>().material.name.Equals("outline (Instance)")) {
                    oldMaterials.Add(collision.GetComponent<SpriteRenderer>().material);
                }
            }
        }

        foreach (var interaction in interactables)
        {
            if (interaction.iconName == "E")
            {
                interactionSymbolE.SetActive(true);
                interactionSymbolWS.SetActive(false);
            }
            else if (interaction.iconName == "WS")
            {
                interactionSymbolE.SetActive(false);
                interactionSymbolWS.SetActive(true);
            }

            interaction.gameObject.GetComponent<SpriteRenderer>().material = outlineMaterial;
            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction.Interaction();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                interaction.Interaction("up");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                interaction.Interaction("down");
            }
        }

        for (int i = 0; i < oldInteractables.Count; i++)
        {
            if (!interactables.Contains(oldInteractables[i]))
            {
                oldInteractables[i].gameObject.GetComponent<SpriteRenderer>().material = oldMaterials[i];
                if (oldInteractables[i] != null)
                {
                    oldInteractables.Remove(oldInteractables[i]);
                }
                if (oldMaterials[i] != null)
                {
                    oldMaterials.Remove(oldMaterials[i]);
                }
            }
        }

        if(interactables.Count <= 0)
        {
            interactionSymbolE.SetActive(false);
            interactionSymbolWS.SetActive(false);
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(mainCollider.bounds.center, Vector2.down, mainCollider.bounds.extents.y + groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}