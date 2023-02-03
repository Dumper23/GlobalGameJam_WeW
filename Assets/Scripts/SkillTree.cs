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
        SkillNodes.Add(1, new Node(1, "MACHINE SEED", Database.Instance.MACHINE_SEED_DESCRIPTION, 0, 0));
        SkillNodes.Add(2, new Node(2, Database.Instance.MACHINE_SEED_DAMAGE_NAME, Database.Instance.MACHINE_SEED_DAMAGE_DESCRIPTION, Database.Instance.MACHINE_SEED_DAMAGE_COST[0], 1));
        SkillNodes.Add(3, new Node(3, Database.Instance.MACHINE_SEED_DAMAGE_NAME, Database.Instance.MACHINE_SEED_DAMAGE_DESCRIPTION, Database.Instance.MACHINE_SEED_DAMAGE_COST[1], 2));
        SkillNodes.Add(4, new Node(4, Database.Instance.MACHINE_SEED_DAMAGE_NAME, Database.Instance.MACHINE_SEED_DAMAGE_DESCRIPTION, Database.Instance.MACHINE_SEED_DAMAGE_COST[2], 3));
        SkillNodes.Add(5, new Node(5, Database.Instance.MACHINE_SEED_SPEED_NAME, Database.Instance.MACHINE_SEED_SPEED_DESCRIPTION, Database.Instance.MACHINE_SEED_SPEED_COST[0], 1));
        SkillNodes.Add(6, new Node(6, Database.Instance.MACHINE_SEED_SPEED_NAME, Database.Instance.MACHINE_SEED_SPEED_DESCRIPTION, Database.Instance.MACHINE_SEED_SPEED_COST[1], 5));
        SkillNodes.Add(7, new Node(7, Database.Instance.MACHINE_SEED_SPEED_NAME, Database.Instance.MACHINE_SEED_SPEED_DESCRIPTION, Database.Instance.MACHINE_SEED_SPEED_COST[2], 6));
        SkillNodes.Add(8, new Node(8, Database.Instance.MACHINE_SEED_CAPACITY_NAME, Database.Instance.MACHINE_SEED_CAPACITY_DESCRIPTION, Database.Instance.MACHINE_SEED_CAPACITY_COST[0], 1));
        SkillNodes.Add(9, new Node(9, Database.Instance.MACHINE_SEED_CAPACITY_NAME, Database.Instance.MACHINE_SEED_CAPACITY_DESCRIPTION, Database.Instance.MACHINE_SEED_CAPACITY_COST[1], 8));
        SkillNodes.Add(10, new Node(10, Database.Instance.MACHINE_SEED_CAPACITY_NAME, Database.Instance.MACHINE_SEED_CAPACITY_DESCRIPTION, Database.Instance.MACHINE_SEED_CAPACITY_COST[2], 9));
        SkillNodes.Add(11, new Node(11, Database.Instance.MACHINE_SEED_CHEST_NAME_UNO, Database.Instance.MACHINE_SEED_CHEST_DESCRIPTION_UNO, Database.Instance.MACHINE_SEED_CHEST_COST[0], 1));
        SkillNodes.Add(12, new Node(12, Database.Instance.MACHINE_SEED_CHEST_NAME, Database.Instance.MACHINE_SEED_CHEST_DESCRIPTION, Database.Instance.MACHINE_SEED_CHEST_COST[1], 11));
        SkillNodes.Add(13, new Node(13, Database.Instance.MACHINE_SEED_CHEST_NAME, Database.Instance.MACHINE_SEED_CHEST_DESCRIPTION, Database.Instance.MACHINE_SEED_CHEST_COST[2], 12));

        // Turret 2
        SkillNodes.Add(14, new Node(14, "RESIN SPIT", Database.Instance.RESIN_SPIT_DESCRIPTION, 0, 0));
        SkillNodes.Add(15, new Node(15, Database.Instance.RESIN_SPIT_SPEED_NAME, Database.Instance.RESIN_SPIT_SPEED_DESCRIPTION, Database.Instance.RESIN_SPIT_SPEED_COST[0], 14));
        SkillNodes.Add(16, new Node(16, Database.Instance.RESIN_SPIT_DURATION_NAME, Database.Instance.RESIN_SPIT_DURATION_DESCRIPTION, Database.Instance.RESIN_SPIT_DURATION_COST[0], 15));
        SkillNodes.Add(17, new Node(17, Database.Instance.RESIN_SPIT_DURATION_NAME, Database.Instance.RESIN_SPIT_DURATION_DESCRIPTION, Database.Instance.RESIN_SPIT_DURATION_COST[1], 16));
        SkillNodes.Add(18, new Node(18, Database.Instance.RESIN_SPIT_DAMAGE_NAME, Database.Instance.RESIN_SPIT_DAMAGE_DESCRIPTION, Database.Instance.RESIN_SPIT_DAMAGE_COST[0], 14));
        SkillNodes.Add(19, new Node(19, Database.Instance.RESIN_SPIT_STICKNESS_NAME, Database.Instance.RESIN_SPIT_STICKNESS_DESCRIPTION, Database.Instance.RESIN_SPIT_STICKNESS_COST[0], 18));
        SkillNodes.Add(20, new Node(20, Database.Instance.RESIN_SPIT_LONG_NAME, Database.Instance.RESIN_SPIT_LONG_DESCRIPTION, Database.Instance.RESIN_SPIT_LONG_COST[0], 19));
        SkillNodes.Add(21, new Node(21, Database.Instance.RESIN_SPIT_CAPACITY_NAME, Database.Instance.RESIN_SPIT_CAPACITY_DESCRIPTION, Database.Instance.RESIN_SPIT_CAPACITY_COST[0], 14));
        SkillNodes.Add(22, new Node(22, Database.Instance.RESIN_SPIT_CAPACITY_NAME, Database.Instance.RESIN_SPIT_CAPACITY_DESCRIPTION, Database.Instance.RESIN_SPIT_CAPACITY_COST[1], 21));
        SkillNodes.Add(23, new Node(23, Database.Instance.RESIN_SPIT_CAPACITY_NAME, Database.Instance.RESIN_SPIT_CAPACITY_DESCRIPTION, Database.Instance.RESIN_SPIT_CAPACITY_COST[2], 22));
        SkillNodes.Add(24, new Node(24, Database.Instance.RESIN_SPIT_CHEST_NAME_UNO, Database.Instance.RESIN_SPIT_CHEST_DESCRIPTION_UNO, Database.Instance.RESIN_SPIT_CHEST_COST[0], 14));
        SkillNodes.Add(25, new Node(25, Database.Instance.RESIN_SPIT_CHEST_NAME, Database.Instance.RESIN_SPIT_CHEST_DESCRIPTION, Database.Instance.RESIN_SPIT_CHEST_COST[1], 24));
        SkillNodes.Add(26, new Node(26, Database.Instance.RESIN_SPIT_CHEST_NAME, Database.Instance.RESIN_SPIT_CHEST_DESCRIPTION, Database.Instance.RESIN_SPIT_CHEST_COST[2], 25));

        // Turret 3
        SkillNodes.Add(27, new Node(27, "S SEEDNIPER", Database.Instance.S_SEEDNIPER_DESCRIPTION, 0, 0));
        SkillNodes.Add(28, new Node(28, Database.Instance.S_SEEDNIPER_DAMAGE_NAME, Database.Instance.S_SEEDNIPER_DAMAGE_DESCRIPTION, Database.Instance.S_SEEDNIPER_DAMAGE_COST[0], 27));
        SkillNodes.Add(29, new Node(29, Database.Instance.S_SEEDNIPER_DAMAGE_NAME, Database.Instance.S_SEEDNIPER_DAMAGE_DESCRIPTION, Database.Instance.S_SEEDNIPER_DAMAGE_COST[1], 28));
        SkillNodes.Add(30, new Node(30, Database.Instance.S_SEEDNIPER_RICOCHET_NAME, Database.Instance.S_SEEDNIPER_RICOCHET_DESCRIPTION, Database.Instance.S_SEEDNIPER_RICOCHET_COST[0], 29));
        SkillNodes.Add(31, new Node(31, Database.Instance.S_SEEDNIPER_SPEED_NAME, Database.Instance.S_SEEDNIPER_SPEED_DESCRIPTION, Database.Instance.S_SEEDNIPER_SPEED_COST[0], 27));
        SkillNodes.Add(32, new Node(32, Database.Instance.S_SEEDNIPER_SPEED_NAME, Database.Instance.S_SEEDNIPER_SPEED_DESCRIPTION, Database.Instance.S_SEEDNIPER_SPEED_COST[1], 31));
        SkillNodes.Add(33, new Node(33, Database.Instance.S_SEEDNIPER_SPEED_NAME, Database.Instance.S_SEEDNIPER_SPEED_DESCRIPTION, Database.Instance.S_SEEDNIPER_SPEED_COST[2], 32));
        SkillNodes.Add(34, new Node(34, Database.Instance.S_SEEDNIPER_CAPACITY_NAME, Database.Instance.S_SEEDNIPER_CAPACITY_DESCRIPTION, Database.Instance.S_SEEDNIPER_CAPACITY_COST[0], 27));
        SkillNodes.Add(35, new Node(35, Database.Instance.S_SEEDNIPER_CAPACITY_NAME, Database.Instance.S_SEEDNIPER_CAPACITY_DESCRIPTION, Database.Instance.S_SEEDNIPER_CAPACITY_COST[1], 34));
        SkillNodes.Add(36, new Node(36, Database.Instance.S_SEEDNIPER_CAPACITY_NAME, Database.Instance.S_SEEDNIPER_CAPACITY_DESCRIPTION, Database.Instance.S_SEEDNIPER_CAPACITY_COST[2], 35));
        SkillNodes.Add(37, new Node(37, Database.Instance.S_SEEDNIPER_CHEST_NAME_UNO, Database.Instance.S_SEEDNIPER_CHEST_DESCRIPTION_UNO, Database.Instance.S_SEEDNIPER_CHEST_COST[0], 27));
        SkillNodes.Add(38, new Node(38, Database.Instance.S_SEEDNIPER_CHEST_NAME, Database.Instance.S_SEEDNIPER_CHEST_DESCRIPTION, Database.Instance.S_SEEDNIPER_CHEST_COST[1], 37));
        SkillNodes.Add(39, new Node(39, Database.Instance.S_SEEDNIPER_CHEST_NAME, Database.Instance.S_SEEDNIPER_CHEST_DESCRIPTION, Database.Instance.S_SEEDNIPER_CHEST_COST[2], 38));

        // Turret 4
        SkillNodes.Add(40, new Node(40, "PINECONE LAUNCHER", Database.Instance.PINECONE_LAUNCHER_DESCRIPTION, 0, 0));
        SkillNodes.Add(41, new Node(41, Database.Instance.PINECONE_LAUNCHER_AREA_NAME, Database.Instance.PINECONE_LAUNCHER_AREA_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_AREA_COST[0], 40));
        SkillNodes.Add(42, new Node(42, Database.Instance.PINECONE_LAUNCHER_DAMAGE_NAME, Database.Instance.PINECONE_LAUNCHER_DAMAGE_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_DAMAGE_COST[1], 41));
        SkillNodes.Add(43, new Node(43, Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN_NAME, Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_DAMAGE_STUN_COST[0], 42));
        SkillNodes.Add(44, new Node(44, Database.Instance.PINECONE_LAUNCHER_SPEED_NAME, Database.Instance.PINECONE_LAUNCHER_SPEED_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_SPEED_COST[0], 40));
        SkillNodes.Add(45, new Node(45, Database.Instance.PINECONE_LAUNCHER_RANGE_NAME, Database.Instance.PINECONE_LAUNCHER_RANGE_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_RANGE_COST[0], 44));
        SkillNodes.Add(46, new Node(46, Database.Instance.PINECONE_LAUNCHER_CLUSTER_NAME, Database.Instance.PINECONE_LAUNCHER_CLUSTER_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CLUSTER_COST[0], 45));
        SkillNodes.Add(47, new Node(47, Database.Instance.PINECONE_LAUNCHER_CAPACITY_NAME, Database.Instance.PINECONE_LAUNCHER_CAPACITY_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CAPACITY_COST[0], 40));
        SkillNodes.Add(48, new Node(48, Database.Instance.PINECONE_LAUNCHER_CAPACITY_NAME, Database.Instance.PINECONE_LAUNCHER_CAPACITY_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CAPACITY_COST[1], 47));
        SkillNodes.Add(49, new Node(49, Database.Instance.PINECONE_LAUNCHER_CAPACITY_NAME, Database.Instance.PINECONE_LAUNCHER_CAPACITY_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CAPACITY_COST[2], 48));
        SkillNodes.Add(50, new Node(50, Database.Instance.PINECONE_LAUNCHER_CHEST_NAME_UNO, Database.Instance.PINECONE_LAUNCHER_CHEST_DESCRIPTION_UNO, Database.Instance.PINECONE_LAUNCHER_CHEST_COST[0], 40));
        SkillNodes.Add(51, new Node(51, Database.Instance.PINECONE_LAUNCHER_CHEST_NAME, Database.Instance.PINECONE_LAUNCHER_CHEST_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CHEST_COST[1], 50));
        SkillNodes.Add(52, new Node(52, Database.Instance.PINECONE_LAUNCHER_CHEST_NAME, Database.Instance.PINECONE_LAUNCHER_CHEST_DESCRIPTION, Database.Instance.PINECONE_LAUNCHER_CHEST_COST[2], 51));

        // Turret 5
        SkillNodes.Add(53, new Node(53, "NUT ROLL", Database.Instance.NUT_ROLL_DESCRIPTION, 0, 0));
        SkillNodes.Add(54, new Node(54, Database.Instance.NUT_ROLL_DAMAGE_NAME, Database.Instance.NUT_ROLL_DAMAGE_DESCRIPTION, Database.Instance.NUT_ROLL_DAMAGE_COST[0], 53));
        SkillNodes.Add(55, new Node(55, Database.Instance.NUT_ROLL_DAMAGE_NAME, Database.Instance.NUT_ROLL_DAMAGE_DESCRIPTION, Database.Instance.NUT_ROLL_DAMAGE_COST[1], 54));
        SkillNodes.Add(56, new Node(56, Database.Instance.NUT_ROLL_EXTRA_NAME, Database.Instance.NUT_ROLL_EXTRA_DESCRIPTION, Database.Instance.NUT_ROLL_EXTRA_COST[0], 55));
        SkillNodes.Add(57, new Node(57, Database.Instance.NUT_ROLL_SPEED_NAME, Database.Instance.NUT_ROLL_SPEED_DESCRIPTION, Database.Instance.NUT_ROLL_SPEED_COST[0], 53));
        SkillNodes.Add(58, new Node(58, Database.Instance.NUT_ROLL_SPEED_NAME, Database.Instance.NUT_ROLL_SPEED_DESCRIPTION, Database.Instance.NUT_ROLL_SPEED_COST[1], 57));
        SkillNodes.Add(59, new Node(59, Database.Instance.NUT_ROLL_HITS_NAME, Database.Instance.NUT_ROLL_HITS_DESCRIPTION, Database.Instance.NUT_ROLL_HITS_COST[0], 58));
        SkillNodes.Add(60, new Node(60, Database.Instance.NUT_ROLL_CAPACITY_NAME, Database.Instance.NUT_ROLL_CAPACITY_DESCRIPTION, Database.Instance.NUT_ROLL_CAPACITY_COST[0], 53));
        SkillNodes.Add(61, new Node(61, Database.Instance.NUT_ROLL_CAPACITY_NAME, Database.Instance.NUT_ROLL_CAPACITY_DESCRIPTION, Database.Instance.NUT_ROLL_CAPACITY_COST[1], 60));
        SkillNodes.Add(62, new Node(62, Database.Instance.NUT_ROLL_CAPACITY_NAME, Database.Instance.NUT_ROLL_CAPACITY_DESCRIPTION, Database.Instance.NUT_ROLL_CAPACITY_COST[2], 61));
        SkillNodes.Add(63, new Node(63, Database.Instance.NUT_ROLL_CHEST_NAME_UNO, Database.Instance.NUT_ROLL_CHEST_DESCRIPTION_UNO, Database.Instance.NUT_ROLL_CHEST_COST[0], 53));
        SkillNodes.Add(64, new Node(64, Database.Instance.NUT_ROLL_CHEST_NAME, Database.Instance.NUT_ROLL_CHEST_DESCRIPTION, Database.Instance.NUT_ROLL_CHEST_COST[1], 63));
        SkillNodes.Add(65, new Node(65, Database.Instance.NUT_ROLL_CHEST_NAME, Database.Instance.NUT_ROLL_CHEST_DESCRIPTION, Database.Instance.NUT_ROLL_CHEST_COST[2], 64));

        // Turret 6
        SkillNodes.Add(66, new Node(66, "PORCUTHROW", Database.Instance.PORCUTHROW_DESCRIPTION, 0, 0));
        SkillNodes.Add(67, new Node(67, Database.Instance.PORCUTHROW_PROJECTILES_NAME, Database.Instance.PORCUTHROW_PROJECTILES_DESCRIPTION, Database.Instance.PORCUTHROW_PROJECTILES_COST[0], 66));
        SkillNodes.Add(68, new Node(68, Database.Instance.PORCUTHROW_PROJECTILES_NAME, Database.Instance.PORCUTHROW_PROJECTILES_DESCRIPTION, Database.Instance.PORCUTHROW_PROJECTILES_COST[1], 67));
        SkillNodes.Add(69, new Node(69, Database.Instance.PORCUTHROW_PROJECTILES_NAME, Database.Instance.PORCUTHROW_PROJECTILES_DESCRIPTION, Database.Instance.PORCUTHROW_PROJECTILES_COST[2], 68));
        SkillNodes.Add(70, new Node(70, Database.Instance.PORCUTHROW_SPEED_NAME, Database.Instance.PORCUTHROW_SPEED_DESCRIPTION, Database.Instance.PORCUTHROW_SPEED_COST[0], 66));
        SkillNodes.Add(71, new Node(71, Database.Instance.PORCUTHROW_SPEED_NAME, Database.Instance.PORCUTHROW_SPEED_DESCRIPTION, Database.Instance.PORCUTHROW_SPEED_COST[0], 70));
        SkillNodes.Add(72, new Node(72, Database.Instance.PORCUTHROW_PIERCING_NAME, Database.Instance.PORCUTHROW_PIERCING_DESCRIPTION, Database.Instance.PORCUTHROW_PIERCING_COST[0], 71));
        SkillNodes.Add(73, new Node(73, Database.Instance.PORCUTHROW_CAPACITY_NAME, Database.Instance.PORCUTHROW_CAPACITY_DESCRIPTION, Database.Instance.PORCUTHROW_CAPACITY_COST[0], 66));
        SkillNodes.Add(74, new Node(74, Database.Instance.PORCUTHROW_CAPACITY_NAME, Database.Instance.PORCUTHROW_CAPACITY_DESCRIPTION, Database.Instance.PORCUTHROW_CAPACITY_COST[1], 73));
        SkillNodes.Add(75, new Node(75, Database.Instance.PORCUTHROW_CAPACITY_NAME, Database.Instance.PORCUTHROW_CAPACITY_DESCRIPTION, Database.Instance.PORCUTHROW_CAPACITY_COST[2], 74));
        SkillNodes.Add(76, new Node(76, Database.Instance.PORCUTHROW_CHEST_NAME_UNO, Database.Instance.PORCUTHROW_CHEST_DESCRIPTION_UNO, Database.Instance.PORCUTHROW_CHEST_COST[0], 66));
        SkillNodes.Add(77, new Node(77, Database.Instance.PORCUTHROW_CHEST_NAME, Database.Instance.PORCUTHROW_CHEST_DESCRIPTION, Database.Instance.PORCUTHROW_CHEST_COST[1], 76));
        SkillNodes.Add(78, new Node(78, Database.Instance.PORCUTHROW_CHEST_NAME, Database.Instance.PORCUTHROW_CHEST_DESCRIPTION, Database.Instance.PORCUTHROW_CHEST_COST[2], 77));

        // Turret 7
        SkillNodes.Add(79, new Node(79, "ELECTRIC POTATO", Database.Instance.ELECTRIC_POTATO_DESCRIPTION, 0, 0));
        SkillNodes.Add(80, new Node(80, Database.Instance.ELECTRIC_POTATO_RAY_NAME, Database.Instance.ELECTRIC_POTATO_RAY_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_RAY_COST[0], 79));
        SkillNodes.Add(81, new Node(81, Database.Instance.ELECTRIC_POTATO_RAY_NAME, Database.Instance.ELECTRIC_POTATO_RAY_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_RAY_COST[0], 80));
        SkillNodes.Add(82, new Node(82, Database.Instance.ELECTRIC_POTATO_SPEED_NAME, Database.Instance.ELECTRIC_POTATO_SPEED_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_SPEED_COST[0], 81));
        SkillNodes.Add(83, new Node(83, Database.Instance.ELECTRIC_POTATO_DAMAGE_NAME, Database.Instance.ELECTRIC_POTATO_DAMAGE_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_DAMAGE_COST[0], 79));
        SkillNodes.Add(84, new Node(84, Database.Instance.ELECTRIC_POTATO_STUN_NAME, Database.Instance.ELECTRIC_POTATO_STUN_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_STUN_COST[0], 83));
        SkillNodes.Add(85, new Node(85, Database.Instance.ELECTRIC_POTATO_STUN_NAME, Database.Instance.ELECTRIC_POTATO_STUN_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_STUN_COST[0], 84));
        SkillNodes.Add(86, new Node(86, Database.Instance.ELECTRIC_POTATO_CAPACITY_NAME, Database.Instance.ELECTRIC_POTATO_CAPACITY_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CAPACITY_COST[0], 79));
        SkillNodes.Add(87, new Node(87, Database.Instance.ELECTRIC_POTATO_CAPACITY_NAME, Database.Instance.ELECTRIC_POTATO_CAPACITY_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CAPACITY_COST[1], 86));
        SkillNodes.Add(88, new Node(88, Database.Instance.ELECTRIC_POTATO_CAPACITY_NAME, Database.Instance.ELECTRIC_POTATO_CAPACITY_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CAPACITY_COST[2], 87));
        SkillNodes.Add(89, new Node(89, Database.Instance.ELECTRIC_POTATO_CHEST_NAME_UNO, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION_UNO, Database.Instance.ELECTRIC_POTATO_CHEST_COST[0], 79));
        SkillNodes.Add(90, new Node(90, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[1], 89));
        SkillNodes.Add(91, new Node(91, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[2], 90));

        //Perso
        SkillNodes.Add(92, new Node(92, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[0], 0));
        SkillNodes.Add(93, new Node(93, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[1], 92));
        SkillNodes.Add(94, new Node(94, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[2], 93));
        SkillNodes.Add(95, new Node(95, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[0], 0));
        SkillNodes.Add(96, new Node(96, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[1], 95));
        SkillNodes.Add(97, new Node(97, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[2], 96));
        SkillNodes.Add(98, new Node(98, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[0], 0));
        SkillNodes.Add(99, new Node(99, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[1], 98));
        SkillNodes.Add(100, new Node(100, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[2], 99));
        SkillNodes.Add(101, new Node(101, Database.Instance.ELECTRIC_POTATO_CHEST_NAME, Database.Instance.ELECTRIC_POTATO_CHEST_DESCRIPTION, Database.Instance.ELECTRIC_POTATO_CHEST_COST[0], 0));

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
