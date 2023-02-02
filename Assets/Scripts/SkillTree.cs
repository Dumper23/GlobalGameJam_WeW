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
        Money = 50000;

        //Base
        SkillNodes.Add(0, new Node(0, "Name 0", "Desc 0", 0, 0));
        SkillNodes[0].buyed = true;

        // Turret 1
        SkillNodes.Add(1, new Node(1, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(2, new Node(2, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 1));
        SkillNodes.Add(3, new Node(3, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 2));
        SkillNodes.Add(4, new Node(4, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 3));
        SkillNodes.Add(5, new Node(5, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 1));
        SkillNodes.Add(6, new Node(6, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 5));
        SkillNodes.Add(7, new Node(7, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 6));
        SkillNodes.Add(8, new Node(8, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 1));
        SkillNodes.Add(9, new Node(9, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 8));
        SkillNodes.Add(10, new Node(10, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 9));
        SkillNodes.Add(11, new Node(11, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 1));
        SkillNodes.Add(12, new Node(12, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 11));
        SkillNodes.Add(13, new Node(13, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 12));

        // Turret 2
        SkillNodes.Add(14, new Node(14, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(15, new Node(15, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 14));
        SkillNodes.Add(16, new Node(16, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 15));
        SkillNodes.Add(17, new Node(17, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 16));
        SkillNodes.Add(18, new Node(18, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 14));
        SkillNodes.Add(19, new Node(19, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 18));
        SkillNodes.Add(20, new Node(20, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 19));
        SkillNodes.Add(21, new Node(21, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 14));
        SkillNodes.Add(22, new Node(22, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 21));
        SkillNodes.Add(23, new Node(23, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 22));
        SkillNodes.Add(24, new Node(24, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 14));
        SkillNodes.Add(25, new Node(25, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 24));
        SkillNodes.Add(26, new Node(26, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 25));

        // Turret 3
        SkillNodes.Add(27, new Node(27, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(28, new Node(28, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 27));
        SkillNodes.Add(29, new Node(29, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 28));
        SkillNodes.Add(30, new Node(30, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 29));
        SkillNodes.Add(31, new Node(31, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 27));
        SkillNodes.Add(32, new Node(32, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 31));
        SkillNodes.Add(33, new Node(33, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 32));
        SkillNodes.Add(34, new Node(34, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 27));
        SkillNodes.Add(35, new Node(35, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 34));
        SkillNodes.Add(36, new Node(36, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 35));
        SkillNodes.Add(37, new Node(37, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 27));
        SkillNodes.Add(38, new Node(38, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 37));
        SkillNodes.Add(39, new Node(39, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 38));

        // Turret 4
        SkillNodes.Add(40, new Node(40, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(41, new Node(41, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 40));
        SkillNodes.Add(42, new Node(42, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 41));
        SkillNodes.Add(43, new Node(43, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 42));
        SkillNodes.Add(44, new Node(44, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 40));
        SkillNodes.Add(45, new Node(45, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 44));
        SkillNodes.Add(46, new Node(46, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 45));
        SkillNodes.Add(47, new Node(47, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 40));
        SkillNodes.Add(48, new Node(48, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 47));
        SkillNodes.Add(49, new Node(49, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 48));
        SkillNodes.Add(50, new Node(50, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 40));
        SkillNodes.Add(51, new Node(51, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 50));
        SkillNodes.Add(52, new Node(52, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 51));

        // Turret 5
        SkillNodes.Add(53, new Node(53, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(54, new Node(54, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 53));
        SkillNodes.Add(55, new Node(55, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 54));
        SkillNodes.Add(56, new Node(56, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 55));
        SkillNodes.Add(57, new Node(57, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 53));
        SkillNodes.Add(58, new Node(58, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 57));
        SkillNodes.Add(59, new Node(59, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 58));
        SkillNodes.Add(60, new Node(60, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 53));
        SkillNodes.Add(61, new Node(61, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 60));
        SkillNodes.Add(62, new Node(62, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 61));
        SkillNodes.Add(63, new Node(63, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 53));
        SkillNodes.Add(64, new Node(64, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 63));
        SkillNodes.Add(65, new Node(65, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 64));

        // Turret 6
        SkillNodes.Add(66, new Node(66, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(67, new Node(67, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 66));
        SkillNodes.Add(68, new Node(68, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 67));
        SkillNodes.Add(69, new Node(69, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 68));
        SkillNodes.Add(70, new Node(70, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 66));
        SkillNodes.Add(71, new Node(71, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 70));
        SkillNodes.Add(72, new Node(72, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 71));
        SkillNodes.Add(73, new Node(73, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 66));
        SkillNodes.Add(74, new Node(74, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 73));
        SkillNodes.Add(75, new Node(75, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 74));
        SkillNodes.Add(76, new Node(76, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 66));
        SkillNodes.Add(77, new Node(77, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 76));
        SkillNodes.Add(78, new Node(78, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 77));

        // Turret 7
        SkillNodes.Add(79, new Node(79, "MACHINE SEED", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 10, 0));
        SkillNodes.Add(80, new Node(80, "Damage I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 79));
        SkillNodes.Add(81, new Node(81, "Damage II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 80));
        SkillNodes.Add(82, new Node(82, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 81));
        SkillNodes.Add(83, new Node(83, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 79));
        SkillNodes.Add(84, new Node(84, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 83));
        SkillNodes.Add(85, new Node(85, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 84));
        SkillNodes.Add(86, new Node(86, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 79));
        SkillNodes.Add(87, new Node(87, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 86));
        SkillNodes.Add(88, new Node(88, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 87));
        SkillNodes.Add(89, new Node(89, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 79));
        SkillNodes.Add(90, new Node(90, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 89));
        SkillNodes.Add(91, new Node(91, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 90));

        //Perso
        SkillNodes.Add(92, new Node(92, "Damage III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 0));
        SkillNodes.Add(93, new Node(93, "Speed I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 92));
        SkillNodes.Add(94, new Node(94, "Speed II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 93));
        SkillNodes.Add(95, new Node(95, "Speed III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 0));
        SkillNodes.Add(96, new Node(96, "Capacity I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 95));
        SkillNodes.Add(97, new Node(97, "Capacity II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 96));
        SkillNodes.Add(98, new Node(98, "Capacity III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 0));
        SkillNodes.Add(99, new Node(99, "Chest I", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 20, 98));
        SkillNodes.Add(100, new Node(100, "Chest II", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 30, 99));
        SkillNodes.Add(101, new Node(101, "Chest III", "Lorem ipsum bla bla bla bla bla bla bla bla bla", 40, 0));

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
