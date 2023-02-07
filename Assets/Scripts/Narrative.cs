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
    private string[] floorColors = { "blue", "orange", "yellow", "green", "white" };
    private int introKeyIndex = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        this.initializeDialogs();
    }

    private void initializeDialogs()
    {
        #region NPC

        string[] conejoDialogs = { "how r u you doing pal?" };
        this.dialogs.Add("conejo", conejoDialogs);

        string[] perritoDialogs = { "Hey! It looks like I'm the first to arrive", "I've brought you the new turret designs and the necessary ammunition for it" };
        this.dialogs.Add("perrito", perritoDialogs);

        string[] chinchillaDialogs = { "Well, I bring heavy artillery to finish with those bugs", "Let's go with everything wimpy!" };
        this.dialogs.Add("chinchilla", chinchillaDialogs);

        string[] castorDialogs = { "Hey pal, I bring new turret designs, stick your enemies to the ground...", "Well, to the tree, with my super design, all yours!" };
        this.dialogs.Add("castor", castorDialogs);

        string[] puercoespinDialogs = { "Good night newbie, I bring you a little present", "Hehehe destroy those bastards at ease!" };
        this.dialogs.Add("puercoespin", puercoespinDialogs);

        string[] capybaraDialogs = { "Hello...I brought something that might help you...", "I hope it helps you, I'll be here if you need anything" };
        this.dialogs.Add("capybara", capybaraDialogs);

        string[] rataDialogs = { "Hey boy come here, I've brought you a nice gadget muahahaha", "All yours, give those bugs a good cramp!" };
        this.dialogs.Add("rata", rataDialogs);

        #endregion NPC

        #region UNLOCK FLOORS

        string[] bunnyDialogs4 = {
            "How you doing soldier? The tree has been nourished with the corpses of our enemies",
            "It has grown bigger and unlocked a new floor! (a little macabre if you think about it...)"
        };
        this.dialogs.Add("bunny4", bunnyDialogs4);

        string[] bunnyDialogs5 = {
            "Look at this soldier! The tree has grown again",
            "Help to protect it, and it will protect you back",
        };
        this.dialogs.Add("bunny5", bunnyDialogs5);

        string[] bunnyDialogs6 = {
            "Though day, huh? Why don't you take a few seconds and relax with me",
            "This empty new room is pretty comfy",
        };
        this.dialogs.Add("bunny6", bunnyDialogs6);

        string[] bunnyDialogs7 = {
            "Keep the good job you're doing soldier!",
            "Some of our allies have arrived, but there are many more on their way",
            "We have to make this tree grow so we can all fit in!"
        };
        this.dialogs.Add("bunny7", bunnyDialogs7);

        string[] bunnyDialogs8 = {
            "Damn, that last day was kinda hard, wasn't it?",
            "Fortunately the tree has gotten bigger so...another turret it is!",
        };
        this.dialogs.Add("bunny8", bunnyDialogs8);

        string[] bunnyDialogs9 = {
            "Holy carrots! I'm starting to have dizziness up here",
            "It's getting so tall!",
        };
        this.dialogs.Add("bunny9", bunnyDialogs9);

        string[] bunnyDialogs10 = {
            "Yey! another floor...yes, those insects won't stop us",
            "Tell me, what turret will you put here?"
        };
        this.dialogs.Add("bunny10", bunnyDialogs10);

        string[] bunnyDialogs11 = {
            "Come on soldier! Just one last effort and we will win this war!",
            "Something tells me we are close! Hold on a little longer and put right now a turret in here!",
        };
        this.dialogs.Add("bunny11", bunnyDialogs11);

        string[] bunnyDialogs12 = {
            "Well..this is it soldier. We made it. I think this tree is at its best",
            "It's gotten so tall and majestic! Look at its roots! They are strong. Like you",
            "Let's finish this once and for all! Shall we?"
        };
        this.dialogs.Add("bunny12", bunnyDialogs12);

        #endregion UNLOCK FLOORS

        #region INTRO

        string[] intro0 = {
            "Hey you! Wake up soldier, no time to sleep!",
            "You are the first of the United Rodent Army that arrives to this outpost",
            "The enemy knows no mercy and they will do anything to reach the top of this tree and steal our supplies",
            "If we hold on and resist 23 more days, all of our allies will have arrived and we will win the war!"
        };
        this.dialogs.Add("intro0", intro0);

        string[] intro1 = {
            "But captain...I don't think we have the time...",
            "Look...I think I just got a premonitory dream. And the fate that waits us is quite...",
            "Like an apocalyptic and massively destructive near future that the main character of an indie game has to somehow manage to solve?"
        };
        this.dialogs.Add("intro1", intro1);

        string[] intro2 =
        {
            "What in the- how dare you break the fourth wall while we are at war soldier?!\nFOCUS! Or we ain't gonna see a tomorrow!",
            "I will be guarding the ammunition on this floor. Open that chest and take a magazine",
            "Each magazine fills all the ammunition of a turret",
            "Now go upstairs and build the first turret on the balcony to defend us. Fast! the enemy is coming",
            "They don't attack at night, so take advantage of that and prepare for tomorrow"
        };
        this.dialogs.Add("intro2", intro2);

        string[] intro3 = {
            "Holy carrots soldier! I really thought those ants were going to invade our tree!",
            "As the days pass the tree will absorb the fallen enemies and grow, giving you the option to place more defenses",
            "I have asked for reinforcements, they bring ammunition and designs of different types of turrets that will serve to protect this tree",
            "You can improve some aspects of the turrets by talking to me",
            "I will give you access to the roots of the tree, the stronger they are, the stronger the tree will be"
        };
        this.dialogs.Add("intro3", intro3);

        #endregion INTRO
    }

    public void startNpcScene(NPC npc)
    {
        GameManager.Instance.setDayNightAnimationPlaying(true);

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
        GameManager.Instance.setDayNightAnimationPlaying(true);

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

    public void startIntroScene()
    {
        GameManager.Instance.setDayNightAnimationPlaying(true);

        this.dialogIndex = 0;
        this.introKeyIndex = 0;
        this.gameObject.SetActive(true);
        this.transform.Find("Background").gameObject.SetActive(true);
        this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("static");
        this.transform.Find("Dream").gameObject.SetActive(true);
        this.transform.Find("Dream").gameObject.GetComponent<Animator>().Play("fadeIn"); //dura 6.5f
        Invoke("startIntroScene2", 8f);
    }

    public void startGameOverScene()
    {
        GameManager.Instance.setDayNightAnimationPlaying(true);
        this.gameObject.transform.Find("FloorBackground").gameObject.SetActive(false);
        this.gameObject.transform.Find("characters").gameObject.SetActive(false);
        this.dialogIndex = 0;
        this.introKeyIndex = 0;
        this.gameObject.SetActive(true);
        this.gameObject.transform.Find("Background").gameObject.SetActive(true);
        this.gameObject.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("Dream").gameObject.SetActive(true);
        this.gameObject.transform.Find("Dream").gameObject.GetComponent<Animator>().Play("fadeIn"); //dura 6.5f
        Invoke("showGameOver", 8f);
    }

    public void startEndGameScene()
    {
        GameManager.Instance.gameEnd.SetActive(true);
        GameManager.Instance.setDayNightAnimationPlaying(true);
        this.gameObject.SetActive(true);
        GameManager.Instance.background.SetActive(true);
        GameManager.Instance.background.GetComponent<Animator>().Play("black");
        GameManager.Instance.tree.SetActive(true);
        GameManager.Instance.tree.GetComponent<Animator>().Play("camera");
        GameManager.Instance.playerAnim.SetActive(true);
        GameManager.Instance.playerAnim.transform.GetChild(0).GetComponent<Animator>().Play("walk");
        Invoke("showExitButton", 20);
    }

    public void showExitButton()
    {
        GameManager.Instance.exitButton.SetActive(true);
        GameManager.Instance.exitButton.GetComponent<Animator>().Play("exitButtonFadeIn");
    }

    public void showGameOver()
    {
        this.transform.Find("Dream").gameObject.SetActive(false);
        this.transform.Find("GameOver").gameObject.SetActive(true);
        this.transform.Find("GameOver").gameObject.transform.GetChild(0).GetComponent<Animator>().Play("gameOver");
        this.transform.Find("GameOver").gameObject.transform.GetChild(1).GetComponent<Animator>().Play("exitButtonFadeIn");
    }

    public void startIntroScene2()
    {
        GameManager.Instance.setDayNightAnimationPlaying(true);

        //first dialog bunny
        this.transform.Find("Dream").gameObject.SetActive(false);
        this.transform.Find("FloorBackground").gameObject.SetActive(true);
        this.transform.Find("characters").gameObject.SetActive(true);
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

        //Play animations
        this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find("bunny").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeIn");

        Invoke("nextDialogBunnyIntro", 1);
    }

    public void startIntroScene3()
    {
        GameManager.Instance.setDayNightAnimationPlaying(true);

        this.dialogIndex = 0;
        this.introKeyIndex = 3;
        this.gameObject.SetActive(true);
        this.transform.Find("Background").gameObject.SetActive(true);
        this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.transform.Find("FloorBackground").gameObject.SetActive(true);
        this.transform.Find("characters").gameObject.SetActive(true);
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

        //Play animations
        this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find("bunny").gameObject.GetComponent<Animator>().Play("fadeIn");
        this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeIn_white");
        this.gameObject.transform.Find("characters").transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeIn");

        Invoke("nextDialogBunnyIntro", 1);
    }

    public void stopNpcScene()
    {
        GameManager.Instance.setDayNightAnimationPlaying(false);

        NPC npc = GameManager.Instance.npcToAppear;
        this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        GameManager.Instance.handleChangeState();
    }

    public void stopFloorScene()
    {
        GameManager.Instance.setDayNightAnimationPlaying(false);

        this.gameObject.SetActive(false);
        GameManager.Instance.handleChangeState();
    }

    public void stopIntroScene()
    {
        GameManager.Instance.setDayNightAnimationPlaying(false);

        this.gameObject.SetActive(false);
        if (this.introKeyIndex != 3)
        {
            GameManager.Instance.changeDayState();
        }
        else
        {
            GameManager.Instance.handleChangeState();
        }
    }

    public void nextDialog()
    {
        NPC npc = GameManager.Instance.npcToAppear;
        if (this.dialogs.TryGetValue(npc.npcId, out string[] dialogs))
        {
            if (this.dialogIndex < dialogs.Length)
            {
                this.gameObject.transform.Find("characters").transform.Find(npc.ammoId).transform.Find(npc.npcId).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogs[this.dialogIndex]);
                this.dialogIndex++;
                Invoke("nextDialog", 4);
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
                Invoke("nextDialogBunny", 4);
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

    public void nextDialogBunnyIntro()
    {
        if (this.dialogs.TryGetValue("intro" + this.introKeyIndex, out string[] dialogs))
        {
            if (this.dialogIndex < dialogs.Length)
            {
                if (this.introKeyIndex != 1)
                {
                    //It's bunny
                    this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.SetActive(true);
                    this.gameObject.transform.Find("characters").transform.Find("player").transform.GetChild(0).gameObject.SetActive(false);
                    this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogs[this.dialogIndex]);
                    this.dialogIndex++;
                }
                else
                {
                    //It's player
                    this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.SetActive(false);
                    this.gameObject.transform.Find("characters").transform.Find("player").transform.GetChild(0).gameObject.SetActive(true);
                    this.gameObject.transform.Find("characters").transform.Find("player").transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().SetText(dialogs[this.dialogIndex]);
                    this.dialogIndex++;
                }

                switch (this.introKeyIndex)
                {
                    case 0:
                        Invoke("nextDialogBunnyIntro", 4.5f);
                        break;

                    case 1:
                        Invoke("nextDialogBunnyIntro", 5.5f);
                        break;

                    case 2:
                        Invoke("nextDialogBunnyIntro", 7f);
                        break;

                    case 3:
                        Invoke("nextDialogBunnyIntro", 7f);
                        break;
                }
            }
            else
            {
                if (this.introKeyIndex < 2)
                {
                    this.introKeyIndex++;
                    this.dialogIndex = 0;
                    Invoke("nextDialogBunnyIntro", 3.5f);
                }
                else
                {
                    //Play animations
                    this.transform.Find("Background").gameObject.GetComponent<Animator>().Play("fadeOut");
                    this.transform.Find("FloorBackground").gameObject.GetComponent<Animator>().Play("fadeOut_white");
                    this.gameObject.transform.Find("characters").transform.Find("bunny").gameObject.GetComponent<Animator>().Play("fadeOut");
                    this.gameObject.transform.Find("characters").transform.Find("bunny").transform.GetChild(0).gameObject.GetComponent<Animator>().Play("fadeOut_white");
                    this.gameObject.transform.Find("characters").transform.Find("player").gameObject.GetComponent<Animator>().Play("fadeOut");
                    Invoke("stopIntroScene", 1);
                }
            }
        }
    }
}