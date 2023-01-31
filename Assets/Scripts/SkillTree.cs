using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public class Node
    {
        public int id;
        public string name;
        public string desc;
        public int cost;
        public bool buyed;
        public int previousNodeId;
        public Skill skill;

        public Node(int id, string name, string desc, int cost, int previousNodeId)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.cost = cost;
            buyed = false;
            this.previousNodeId = previousNodeId;
        }
    }

    public static SkillTree Instance;
    private void Awake() => Instance = this;

    public Dictionary<int, Node> SkillNodes = new Dictionary<int, Node>();
    public List<Skill> SkillHolder;

    //public List<Skill> SkillsList;
    //public GameObject SkillHolder;

    public int Money;

    private void Start()
    {
        Money = 2000;

        //Base
        SkillNodes.Add(0, new Node(0, "Name 0", "Desc 0", 0, 0));
        SkillNodes[0].buyed = true;

        SkillNodes.Add(1, new Node(1, "Name 1", "Desc 1", 10, 0));
        SkillNodes.Add(2, new Node(2, "Name 2", "Desc 2", 20, 1));
        SkillNodes.Add(3, new Node(3, "Name 3", "Desc 3", 30, 2));
        SkillNodes.Add(4, new Node(4, "Name 4", "Desc 4", 40, 0));
        SkillNodes.Add(5, new Node(5, "Name 5", "Desc 5", 50, 4));
        SkillNodes.Add(6, new Node(6, "Name 6", "Desc 6", 60, 5));

        foreach (Skill skill in SkillHolder) skill.Init();

        UpdateAllSkillsUI();
    }

    public Node GetNode(int id)
    {
        return SkillNodes[id];
    }

    public void UpdateAllSkillsUI()
    {
        foreach (Node node in SkillNodes.Values)
        {
            if (node.id == 0) continue;
            node.skill.UpdateUI();
        }
    }

}
