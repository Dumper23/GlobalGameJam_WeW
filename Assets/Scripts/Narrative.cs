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

    private Dictionary<string, string[]> dialogs = new Dictionary<string, string[]>();
    private int dialogIndex = 0;

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

    public void stopNpcScene()
    {
        NPC npc = GameManager.Instance.npcToAppear;
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        GameManager.Instance.handleAnimationAndSound();
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
}
