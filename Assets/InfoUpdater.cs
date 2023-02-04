using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoUpdater : MonoBehaviour
{

    public TMP_Text day;
    public TMP_Text time;
    public TMP_Text enemies;
    public TMP_Text money;
    public TMP_Text lives;
    public GameObject sunMoon;

    private float timeValue = 0;
    private bool timeUp = false;
    private int dayStateValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUp)
        {
            timeValue += Time.deltaTime;
            sunMoon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            if (timeValue > 0) timeValue -= Time.deltaTime; else timeValue = 0;
            sunMoon.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        DisplayTime(timeValue);
        money.text = GameManager.Instance.fertilizer.ToString() + " f";
        money.text = GameManager.Instance.playerHP.ToString();

    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0) timeToDisplay = 0;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    public void ChangeDay()
    {
        if (dayStateValue % 2 == 0)
        {
            timeValue = 0;

        }
        else
        {
            timeValue = 60;
        }

        timeUp = !timeUp;
        dayStateValue++;
        SetDay(dayStateValue / 2);
    }

    public void SetDay(int value)
    {
        day.text = value.ToString();
    }

    public void SetEnemies(int value)
    {
        enemies.text = value.ToString();
    }

}
