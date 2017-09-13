using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public Text normalText;
    public GameObject ScrollBar;
    public GameObject[] Buttons;
    public GameObject cliker;
    public GameObject multiplierX5;
    public GameObject multiplierX10;
    public GameObject multiplierButton;
    public float timeToMoney;
    private float timeBar = 5f;
    private float timeBarGone;
    private float vel = 0.5f;
    private bool velRunning;
    public Scrollbar powerBar;
    private int actualButton;
    public float score = 0f;
    private float lastUpdate;
    public float multiplier = 1f;
    public bool isActive = false;
    public bool isOn = false;


    // Update is called once per frame
    void Update ()
    {
        if(Time.time - lastUpdate >= timeToMoney)
        {
            score += 1f * multiplier;
            lastUpdate = Time.time;
            SetCountText();
        }
        PowerUpBar();
    }

    void PowerUpBar()
    {
        if(velRunning)
        {
            if(timeBarGone >0)
            {
                timeBarGone -= Time.deltaTime;
                LerpingScrollBar();
            }
            else
            {
                velRunning = false;
                powerBar.gameObject.SetActive(false);
                timeToMoney = 1f;
            }
        }
    }

    void LerpingScrollBar()
    {
        float tempfloat = timeBarGone / timeBar;
        powerBar.size = tempfloat;
    }

    public void Acelerator()
    {
        if(!velRunning)
        {
            velRunning = true;
            timeBarGone = timeBar;
            powerBar.gameObject.SetActive(true);
            timeToMoney *= 0.1f;
        }
    }

    public void ClickerMultiplier()
    {
        score += 2f;
        SetCountText();
    }
    public void ClickerMultiplierX5()
    {
        score += 5f;
        SetCountText();
    }
    public void ClickerMultiplierX10()
    {
        score += 10f;
        SetCountText();
    }

    public void Abilities()
    {
        if(isOn == false)
        {
            ScrollBar.SetActive(true);
            isOn = true;
        }
        else
        {
            ScrollBar.SetActive(false);
            isOn = false;
        }
    }

    public void SetMultiplierX4()
    {
        if(score >= 200f)
        {
            score -= 200f;
            multiplier = 4;
            normalText.text = "X4";
            SetCountText();
            Buttons[actualButton].GetComponent<Button>().interactable = false;
            Buttons[actualButton + 1].GetComponent<Button>().interactable = true;
            actualButton++;
        }
    }

    public void SetMultiplierX8()
    {
        if (score >= 400f)
        {
            score -= 400f;
            multiplier = 8;
            normalText.text = "X8";
            SetCountText();
            Buttons[actualButton].GetComponent<Button>().interactable = false;
            Buttons[actualButton + 1].GetComponent<Button>().interactable = true;
            actualButton++;
        }
    }

    public void ClickX5()
    {
        if (score >= 600f)
        {
            score -= 600f;
            cliker.SetActive(false);
            multiplierX5.SetActive(true);
            Buttons[actualButton].GetComponent<Button>().interactable = false;
            Buttons[actualButton + 1].GetComponent<Button>().interactable = true;
            actualButton++;
        }
        
    }

    public void ClickX10()
    {
        if (score >= 800f)
        {
            score -= 800f;
            multiplierX5.SetActive(false);
            multiplierX10.SetActive(true);
            Buttons[actualButton].GetComponent<Button>().interactable = false;
        }
        
    }

    public void AddScore()
    {
        if (isActive == false)
        {
            multiplier = 2f;
            normalText.text = "X2";
            SetCountText();
            isActive = true;
           
            return;
        }
        if (isActive == true)
        {
            multiplier = 3f;
            normalText.text = "X3";
            SetCountText();
            multiplierButton.SetActive(false);
        }
    }

    public void SetCountText()
    {
        scoreText.text = "Score: $" + score.ToString();
    }
}
