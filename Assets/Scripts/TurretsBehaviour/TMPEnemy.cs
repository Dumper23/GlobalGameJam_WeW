using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMPEnemy : MonoBehaviour
{

    [SerializeField]
    private bool wanaMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wanaMove) {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 2);
        }
    }

    public void Damage(int damage)
    {
        Debug.Log("-" + damage + " Damage");
    }
}
