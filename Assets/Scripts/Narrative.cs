using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class backgroundFloor
{
    public string floor;
    public string ammoId;
    public Sprite sprite;
}

[System.Serializable]
public class Narrative : MonoBehaviour
{
    public List<backgroundFloor> backgroundFloors;
    public List<Sprite> colorFloors;

    private Dictionary<string, string[]> dialogs = new Dictionary<string, string[]>();
    private int dialogIndex = 0;
    private string[] floorColors = {"blue", "orange", "yellow", "green","white"};

    // Start is called before the first frame update
    void Awake()
    {
        this.initializeDialogs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initializeDialogs()
    {
        #region NPC
        string[] conejoDialogs = { "conejoDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("conejo", conejoDialogs);

        string[] perritoDialogs = { "perritoDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("perrito", perritoDialogs);

        string[] chinchillaDialogs = { "chinchillaDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("chinchilla", chinchillaDialogs);

        string[] castorDialogs = { "castorDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("castor", castorDialogs);

        string[] puercoespinDialogs = { "puercoespinDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("puercoespin", puercoespinDialogs);

        string[] capybaraDialogs = { "capybaraDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("capybara", capybaraDialogs);

        string[] rataDialogs = { "rataDialogs how r u you doing pal?", "I've got a bunch of sunflower seeds for ya!" };
        this.dialogs.Add("rata", rataDialogs);
        #endregion

        #region UNLOCK FLOORS
        string[] bunnyDialogs4 = { 
            "Floor 4", 
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny4", bunnyDialogs4);

        string[] bunnyDialogs5 = {
            "Floor 5",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny5", bunnyDialogs5);

        string[] bunnyDialogs6 = {
            "Floor 6",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny6", bunnyDialogs6);

        string[] bunnyDialogs7 = {
            "Floor 7",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny7", bunnyDialogs7);

        string[] bunnyDialogs8 = {
            "Floor 8",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny8", bunnyDialogs8);

        string[] bunnyDialogs9 = {
            "Floor 9",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny9", bunnyDialogs9);

        string[] bunnyDialogs10 = {
            "Floor 10",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny10", bunnyDialogs10);

        string[] bunnyDialogs11 = {
            "Floor 11",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny11", bunnyDialogs11);

        string[] bunnyDialogs12 = {
            "Floor 12",
            "New floor unlocked!",
        };
        this.dialogs.Add("bunny12", bunnyDialogs12);
        #endregion
    }
    
    public void startNpcScene(NPC npc)
    {
        this.dialogIndex = 0;
        this.gameObject.SetActive(true);
        this.transform.Find("FloorBackground").GetComponent<Image>().sprite = this.backgroundFloors.Find((x) => x.ammoId == npc.ammoId).sprite;
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).gameObject.SetActive(true);
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

        //Play animations
        this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeIn");

        Invoke("nextDialog", 1);
    }

    public void startFloorScene()
    {
        this.dialogIndex = 0;
        this.gameObject.SetActive(true);
        this.transform.Find("FloorBackground").GetComponent<Image>().sprite = this.colorFloors.Find((x) => x.name == this.floorColors[GameManager.Instance.floorColorIndex]);
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

        //Play animations
        this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find("bunny").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeIn");

        Invoke("nextDialogBunny", 1);
    }

    public void stopNpcScene()
    {
        NPC npc = GameManager.Instance.npcToAppear;
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        GameManager.Instance.handleChangeState();
    }

    public void stopFloorScene()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.handleChangeState();
    }

    public void nextDialog()
    {
        NPC npc = GameManager.Instance.npcToAppear;
        if(this.dialogs.TryGetValue(npc.npcId, out string[] dialogs))
        {
            if(this.dialogIndex < dialogs.Length)
            {
                this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogs[this.dialogIndex]);
                this.dialogIndex++;
                Invoke("nextDialog", 3);
            }
            else
            {
                //Play animations
                this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeOut");
                this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeOut_white");
                this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).gameObject.GetComponent<Animator>().Play("fadeOut");
                this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeOut_white");
                this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeOut");

                Invoke("stopNpcScene", 1);
            }
        }
    }

    public void nextDialogBunny()
    {
        int unlockedFloors = GameManager.Instance.unlockedFloors;
        if (this.dialogs.TryGetValue("bunny" + unlockedFloors, out string[] dialogs))
        {
            if (this.dialogIndex < dialogs.Length)
            {
                this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogs[this.dialogIndex]);
                this.dialogIndex++;
                Invoke("nextDialogBunny", 3);
            }
            else
            {
                //Play animations
                this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeOut");
                this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeOut_white");
                this.gameObject.transform.Find("characters").transform.Find("bunny").gameObject.GetComponent<Animator>().Play("fadeOut");
                this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeOut_white");
                this.gameObject.transform.Find("characters").transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeOut");
                Invoke("stopFloorScene", 1);
            }
        }
    }
}
