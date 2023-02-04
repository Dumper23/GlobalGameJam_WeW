using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.SerializableAttribute]
public class ammoSlot
{
    public int currentAmount = 0;
    public string currentAmmoType = "";
    public bool hasAmmo = false;
    public Sprite ammoImage;
}

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
    public GameObject interactionSymbolR;
    public GameObject interactionSymbolWS;
    public Material outlineMaterial;
    public List<IEInteractable> oldInteractables = new List<IEInteractable>();
    public GameObject placementMenu;
    public GameObject removeMenu;
    public GameObject inventoryContainer;

    //public List<Material> oldMaterials = new List<Material>();
    public string currentState;

    public AudioClip[] audios;

    private GameObject currentInteractionObject;
    private Animator animator;
    private float moveDirection = 0;
    private Rigidbody2D r2d;
    private BoxCollider2D mainCollider;
    public AudioSource[] audioSources;

    private static string PLAYER_WALK = "walk";
    private static string PLAYER_IDLE = "idle";

    public int AUDIO_WALK = 0;
    public int AUDIO_JUMP = 1;
    public int AUDIO_INTERACT = 2;
    public int AUDIO_FLOOR_CHANGE = 3;
    public int AUDIO_TURRET_PLACE = 4;
    public int AUDIO_CANCEL = 5;
    public int AUDIO_PICK_TURRET = 6;
    public int AUDIO_INVENTORY = 7;
    public int AUDIO_BUY = 8;

    [HideInInspector]
    public Dictionary<string, int> turretsInventory = new Dictionary<string, int>();

    public ammoSlot ammoSlot1 = new ammoSlot();

    public ammoSlot ammoSlot2 = new ammoSlot();

    public ammoSlot ammoSlot3 = new ammoSlot();

    public ammoSlot ammoSlot4 = new ammoSlot();

    public GameObject inventoryUISlot1_select;
    public GameObject inventoryUISlot2_select;
    public GameObject inventoryUISlot3_select;
    public GameObject inventoryUISlot4_select;

    public Image inventoryUISlot1_ResourceImage;
    public Image inventoryUISlot2_ResourceImage;
    public Image inventoryUISlot3_ResourceImage;
    public Image inventoryUISlot4_ResourceImage;

    public Image liftDelayCircle;

    public TextMeshProUGUI slotAmmoAmount1;
    public TextMeshProUGUI slotAmmoAmount2;
    public TextMeshProUGUI slotAmmoAmount3;
    public TextMeshProUGUI slotAmmoAmount4;

    public TextMeshProUGUI turretAmountText0;
    public TextMeshProUGUI turretAmountText1;
    public TextMeshProUGUI turretAmountText2;
    public TextMeshProUGUI turretAmountText3;
    public TextMeshProUGUI turretAmountText4;
    public TextMeshProUGUI turretAmountText5;
    public TextMeshProUGUI turretAmountText6;

    [HideInInspector]
    public int currentSlot = 0;

    public float stepTime;
    public float timeToStep;

    // Use this for initialization
    private void Start()
    {
        ammoSlot1.hasAmmo = false;
        ammoSlot2.hasAmmo = false;
        ammoSlot3.hasAmmo = false;
        ammoSlot4.hasAmmo = false;

        slotAmmoAmount1.SetText("");
        slotAmmoAmount2.SetText("");
        slotAmmoAmount3.SetText("");
        slotAmmoAmount4.SetText("");

        inventoryUISlot1_select.SetActive(true);
        inventoryUISlot2_select.SetActive(false);
        inventoryUISlot3_select.SetActive(false);
        inventoryUISlot4_select.SetActive(false);
        currentSlot = 1;

        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.Instance.getPlayerInMenu() && !GameManager.Instance.getDayNightAnimationPlaying())
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
                if (Time.time >= stepTime)
                {
                    audioSources[AUDIO_WALK].clip = audios[AUDIO_WALK];
                    audioSources[AUDIO_WALK].Play();
                    stepTime = Time.time + timeToStep - Mathf.Abs(moveDirection) * 0.1f;
                }
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
                audioSources[AUDIO_JUMP].clip = audios[AUDIO_JUMP];
                audioSources[AUDIO_JUMP].Play();
            }

            r2d.velocity = new Vector2(moveDirection * movementSpeed, r2d.velocity.y);

            #endregion Movement

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
                        currentInteractionObject.GetComponent<IEInteractable>().setOutline();
                    }
                }
            }

            foreach (var interaction in interactables)
            {
                if (interaction.iconName == "E")
                {
                    interactionSymbolE.SetActive(true);
                    interactionSymbolWS.SetActive(false);
                    //interactionSymbolR.SetActive(false);
                }
                else if (interaction.iconName == "WS")
                {
                    interactionSymbolE.SetActive(false);
                    interactionSymbolWS.SetActive(true);
                    interactionSymbolR.SetActive(false);
                }
                else if (interaction.iconName == "ER")
                {
                    interactionSymbolE.SetActive(true);
                    interactionSymbolWS.SetActive(false);
                    interactionSymbolR.SetActive(true);
                }
                else if (interaction.iconName == "R")
                {
                    interactionSymbolE.SetActive(false);
                    interactionSymbolWS.SetActive(false);
                    interactionSymbolR.SetActive(true);
                }

                if (Input.GetButtonDown("Interaction"))
                {
                    interaction.Interaction("E");
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    interaction.Interaction("up");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    interaction.Interaction("down");
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    interaction.Interaction("R");
                }
            }

            for (int i = 0; i < oldInteractables.Count; i++)
            {
                if (!interactables.Contains(oldInteractables[i]))
                {
                    //oldInteractables[i].gameObject.GetComponent<SpriteRenderer>().material = oldMaterials[i];
                    if (oldInteractables[i] != null)
                    {
                        oldInteractables[i].GetComponent<IEInteractable>().setOriginal();
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
                interactionSymbolR.SetActive(false);
            }

            #endregion Interaction

            if (Input.GetButtonDown("Slot1") && Database.Instance.PLAYER_INVENTORY_LVL >= 0)
            {
                changeSlotSelected(1);
            }
            else if (Input.GetButtonDown("Slot2") && Database.Instance.PLAYER_INVENTORY_LVL >= 1)
            {
                changeSlotSelected(2);
            }
            else if (Input.GetButtonDown("Slot3") && Database.Instance.PLAYER_INVENTORY_LVL >= 2)
            {
                changeSlotSelected(3);
            }
            else if (Input.GetButtonDown("Slot4") && Database.Instance.PLAYER_INVENTORY_LVL >= 3)
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
            changeAnimationState(PLAYER_IDLE);
            r2d.velocity = new Vector2(0, r2d.velocity.y);
            if (Input.GetButtonDown("Cancel"))
            {
                GameManager.Instance.hidePlacementMenuUI();
                GameManager.Instance.hideRemoveMenuUI();
                GameManager.Instance.setRootView(false);
            }
        }
    }

    private bool isGrounded()
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
        GameManager.Instance.pickupTurret(currentInteractionObject.GetComponent<TurretPlacholder>());
        updateTurretInventoryNumberUI();
        closeMenu();
    }

    public void placeTurret(string turretId)
    {
        GameManager.Instance.placeTurret(currentInteractionObject.transform.position, turretId, currentInteractionObject.GetComponent<TurretPlacholder>());
        updateTurretInventoryNumberUI();
        closeMenu();
    }

    public void changeSlotSelected(int slot)
    {
        switch (slot)
        {
            case 1:
                inventoryUISlot1_select.SetActive(true);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(false);
                audioSources[AUDIO_INVENTORY].clip = audios[AUDIO_INVENTORY];
                audioSources[AUDIO_INVENTORY].Play();
                break;

            case 2:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(true);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(false);
                audioSources[AUDIO_INVENTORY].clip = audios[AUDIO_INVENTORY];
                audioSources[AUDIO_INVENTORY].Play();
                break;

            case 3:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(true);
                inventoryUISlot4_select.SetActive(false);
                audioSources[AUDIO_INVENTORY].clip = audios[AUDIO_INVENTORY];
                audioSources[AUDIO_INVENTORY].Play();
                break;

            case 4:
                inventoryUISlot1_select.SetActive(false);
                inventoryUISlot2_select.SetActive(false);
                inventoryUISlot3_select.SetActive(false);
                inventoryUISlot4_select.SetActive(true);
                audioSources[AUDIO_INVENTORY].clip = audios[AUDIO_INVENTORY];
                audioSources[AUDIO_INVENTORY].Play();
                break;
        }
        currentSlot = slot;
    }

    public void updateInventorySlots()
    {
        if (Database.Instance.PLAYER_INVENTORY_LVL >= 0)
        {
            inventoryUISlot1_ResourceImage.gameObject.transform.parent.gameObject.SetActive(true);
            if (ammoSlot1.ammoImage == null)
            {
                inventoryUISlot1_ResourceImage.gameObject.SetActive(false);
                ammoSlot1.currentAmount = 0;
                slotAmmoAmount1.SetText("");
            }
            else
            {
                inventoryUISlot1_ResourceImage.gameObject.SetActive(true);
                inventoryUISlot1_ResourceImage.sprite = ammoSlot1.ammoImage;
                slotAmmoAmount1.SetText(ammoSlot1.currentAmount.ToString());
            }
        }
        else if (Database.Instance.PLAYER_INVENTORY_LVL < 0)
        {
            inventoryUISlot1_ResourceImage.gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (Database.Instance.PLAYER_INVENTORY_LVL >= 1)
        {
            inventoryUISlot2_ResourceImage.gameObject.transform.parent.gameObject.SetActive(true);
            if (ammoSlot2.ammoImage == null)
            {
                inventoryUISlot2_ResourceImage.gameObject.SetActive(false);
                ammoSlot2.currentAmount = 0;
                slotAmmoAmount2.SetText("");
            }
            else
            {
                inventoryUISlot2_ResourceImage.gameObject.SetActive(true);
                inventoryUISlot2_ResourceImage.sprite = ammoSlot2.ammoImage;
                slotAmmoAmount2.SetText(ammoSlot2.currentAmount.ToString());
            }
        }
        else if (Database.Instance.PLAYER_INVENTORY_LVL < 1)
        {
            inventoryUISlot2_ResourceImage.gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (Database.Instance.PLAYER_INVENTORY_LVL >= 2)
        {
            inventoryUISlot3_ResourceImage.gameObject.transform.parent.gameObject.SetActive(true);
            if (ammoSlot3.ammoImage == null)
            {
                inventoryUISlot3_ResourceImage.gameObject.SetActive(false);
                ammoSlot3.currentAmount = 0;
                slotAmmoAmount3.SetText("");
            }
            else
            {
                inventoryUISlot3_ResourceImage.gameObject.SetActive(true);
                inventoryUISlot3_ResourceImage.sprite = ammoSlot3.ammoImage;
                slotAmmoAmount3.SetText(ammoSlot3.currentAmount.ToString());
            }
        }
        else if (Database.Instance.PLAYER_INVENTORY_LVL < 2)
        {
            inventoryUISlot3_ResourceImage.gameObject.transform.parent.gameObject.SetActive(false);
        }

        if (Database.Instance.PLAYER_INVENTORY_LVL >= 3)
        {
            inventoryUISlot4_ResourceImage.gameObject.transform.parent.gameObject.SetActive(true);
            if (ammoSlot4.ammoImage == null)
            {
                inventoryUISlot4_ResourceImage.gameObject.SetActive(false);
                ammoSlot4.currentAmount = 0;
                slotAmmoAmount4.SetText("");
            }
            else
            {
                inventoryUISlot4_ResourceImage.gameObject.SetActive(true);
                inventoryUISlot4_ResourceImage.sprite = ammoSlot4.ammoImage;
                slotAmmoAmount4.SetText(ammoSlot4.currentAmount.ToString());
            }
        }
        else if (Database.Instance.PLAYER_INVENTORY_LVL < 3)
        {
            inventoryUISlot4_ResourceImage.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    public void updateTurretInventoryNumberUI()
    {
        if (turretsInventory.TryGetValue("MACHINE_SEED", out int amount))
        {
            turretAmountText0.color = Color.green;
            turretAmountText0.SetText("x" + amount);
        }
        else
        {
            turretAmountText0.color = Color.yellow;
            turretAmountText0.SetText("x" + 10);
        }

        if (turretsInventory.TryGetValue("S_SEEDNIPER", out int amount1))
        {
            turretAmountText1.SetText("x" + amount1);
        }
        else
        {
            turretAmountText1.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("RESIN_SPIT", out int amount2))
        {
            turretAmountText2.SetText("x" + amount2);
        }
        else
        {
            turretAmountText2.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("PORCUTHROW", out int amount3))
        {
            turretAmountText3.SetText("x" + amount3);
        }
        else
        {
            turretAmountText3.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("PINECONE_LAUNCHER", out int amount4))
        {
            turretAmountText4.SetText("x" + amount4);
        }
        else
        {
            turretAmountText4.SetText("x" + 0);
        }

        if (turretsInventory.TryGetValue("NUT_ROLL", out int amount5))
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

    public void UpdateDatabase()
    {
        if (Database.Instance.PLAYER_SPEED_LVL > 0)
        {
            movementSpeed = Database.Instance.PLAYER_SPEEDY[Database.Instance.PLAYER_SPEED_LVL - 1];
        }
    }
}