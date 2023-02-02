using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public List<IEInteractable> oldInteractables = new List<IEInteractable>();
    public GameObject placementMenu;
    public GameObject removeMenu;
    //public List<Material> oldMaterials = new List<Material>();
    public string currentState;
    public AudioClip[] audios;

    private GameObject currentInteractionObject;
    private Animator animator;
    private float moveDirection = 0;
    private Rigidbody2D r2d;
    private BoxCollider2D mainCollider;
    private AudioSource audio;

    private static string PLAYER_WALK = "walk";
    private static string PLAYER_IDLE = "idle";

    private static string AUDIO_WALK = null;
    private static string AUDIO_JUMP = null;
    private static string AUDIO_INTERACT = null;
    private static string AUDIO_FLOOR_CHANGE = null;
    [HideInInspector]
    public Dictionary<string, int> resourcesInventory = new Dictionary<string, int>();
    [HideInInspector]
    public Dictionary<string, int> turretsInventory = new Dictionary<string, int>();
    public GameObject inventoryUISlot1_select;
    public GameObject inventoryUISlot2_select;
    public GameObject inventoryUISlot3_select;
    public GameObject inventoryUISlot4_select;
    public TextMeshProUGUI turretAmountText0;
    public TextMeshProUGUI turretAmountText1;
    public TextMeshProUGUI turretAmountText2;
    public TextMeshProUGUI turretAmountText3;
    public TextMeshProUGUI turretAmountText4;
    public TextMeshProUGUI turretAmountText5;
    public TextMeshProUGUI turretAmountText6;
    private int currentSlot = 0;

    // Use this for initialization
    void Start()
    {
        changeSlotSelected(1);
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.getPlayerInMenu())
        {
            closeMenu();
            #region Movement
            //Move
            moveDirection = Mathf.Lerp(moveDirection, Input.GetAxis("Horizontal"), 0.03f);
            if (Mathf.Abs(moveDirection) < 0.1f)
            {
                changeAnimationState(PLAYER_IDLE);
                r2d.velocity = new Vector2(0, r2d.velocity.y);
            }
            else
            {
                changeAnimationState(PLAYER_WALK);
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

            #region Interaction
            Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, interactionRange);
            List<IEInteractable> interactables = new List<IEInteractable>();

            foreach (var collision in collisions)
            {
                if (collision.GetComponent<IEInteractable>())
                {
                    interactables.Add(collision.GetComponent<IEInteractable>());
                    if (!oldInteractables.Contains(collision.GetComponent<IEInteractable>()))
                    {
                        oldInteractables.Add(collision.GetComponent<IEInteractable>());
                        currentInteractionObject = collision.gameObject;
                    }
                    /*if (!oldMaterials.Contains(collision.GetComponent<SpriteRenderer>().material) && !collision.GetComponent<SpriteRenderer>().material.name.Equals("outline (Instance)")) {
                        oldMaterials.Add(collision.GetComponent<SpriteRenderer>().material);
                    }*/
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

                //interaction.gameObject.GetComponent<SpriteRenderer>().material = outlineMaterial;
                if (Input.GetButtonDown("Interaction"))
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
                    //oldInteractables[i].gameObject.GetComponent<SpriteRenderer>().material = oldMaterials[i];
                    if (oldInteractables[i] != null)
                    {
                        oldInteractables[i].EndInteraction();
                        oldInteractables.Remove(oldInteractables[i]);
                    }
                    /*if (oldMaterials[i] != null)
                    {
                        oldMaterials.Remove(oldMaterials[i]);
                    }*/
                }
            }

            if (interactables.Count <= 0)
            {
                interactionSymbolE.SetActive(false);
                interactionSymbolWS.SetActive(false);
            }
            #endregion

            if (Input.GetButtonDown("Slot1"))
            {
                changeSlotSelected(1);
            }
            else if (Input.GetButtonDown("Slot2"))
            {
                changeSlotSelected(2);
            }
            else if (Input.GetButtonDown("Slot3"))
            {
                changeSlotSelected(3);
            }
            else if (Input.GetButtonDown("Slot4"))
            {
                changeSlotSelected(4);
            }

            if (Input.GetButtonDown("Map"))
            {
                GameManager.Instance.toggleMapView();
            }
        }
        else
        {
            interactionSymbolE.SetActive(false);
            changeAnimationState(PLAYER_IDLE);
            r2d.velocity = new Vector2(0, r2d.velocity.y);
            if (Input.GetButtonDown("Cancel"))
            {
                GameManager.Instance.hidePlacementMenuUI();
                GameManager.Instance.hideRemoveMenuUI();
            }
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(mainCollider.bounds.center, Vector2.down, mainCollider.bounds.extents.y + groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    //Animator state machine
    private void changeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    public void storeTurret()
    {
        updateTurretInventoryNumberUI();
        closeMenu();
    }

    public void placeTurret(string turretId)
    {
        GameManager.Instance.placeTurret(currentInteractionObject.transform.position, turretId);
        updateTurretInventoryNumberUI();
        closeMenu();
    }

    public void changeSlotSelected(int slot)
    {
        switch (slot) {
            case 1:
                inventoryUISlot1_select.SetActive(true);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(false);
                break;
            case 2:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(true);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(false);
                break;
            case 3:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(true);
                inventoryUISlot4_select.SetActive(false);
                break;
            case 4:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(true);
                break;
        }
        currentSlot = slot;
    }

    public void updateTurretInventoryNumberUI()
    { 
        if(turretsInventory.TryGetValue("MACHINE_SEED", out int amount))
        {
            turretAmountText0.SetText("x" + amount);
        }
        else
        {
            turretAmountText0.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("RESIN_SPIT", out int amount1))
        {
            turretAmountText1.SetText("x" + amount1);
        }
        else
        {
            turretAmountText1.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("S_SEEDNIPER", out int amount2))
        {
            turretAmountText2.SetText("x" + amount2);
        }
        else
        {
            turretAmountText2.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("PINECONE_LAUNCHER", out int amount3))
        {
            turretAmountText3.SetText("x" + amount3);
        }
        else
        {
            turretAmountText3.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("NUT_ROLL", out int amount4))
        {
            turretAmountText4.SetText("x" + amount4);
        }
        else
        {
            turretAmountText4.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("PORCUTHROW", out int amount5))
        {
            turretAmountText5.SetText("x" + amount5);
        }
        else
        {
            turretAmountText5.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("ELECTRIC_POTATO", out int amount6))
        {
            turretAmountText6.SetText("x" + amount6);
        }
        else
        {
            turretAmountText6.SetText("x" + 0);
        }
    }

    public void closeMenu()
    {
        GameManager.Instance.hideRemoveMenuUI();
        GameManager.Instance.hidePlacementMenuUI();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}