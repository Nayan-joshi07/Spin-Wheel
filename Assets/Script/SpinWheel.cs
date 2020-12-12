using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinWheel : MonoBehaviour
{
    [SerializeField] Button spinButton;
    [SerializeField] TextMeshProUGUI[] text;
    [SerializeField] bool blowUpDown = true;
    float randomValue;
    float timeInterval;
    float timeIntervalText=3.0f;
    int textSize = 32;
    //Set Active/Deactive the GameObject
    public GameObject Wheel;
    public GameObject Claim;
    public int angle;


    void Awake()
    {
    }
    void Start()
    {
        StartCoroutine(WheelSpin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!blowUpDown)
        {
            StopCoroutine(SpinButtonUpDown());
        }
        else
        {
            StartCoroutine(SpinButtonUpDown());
        }

    }
    IEnumerator WheelSpin()
    {
        blowUpDown = false;
        randomValue = Random.Range(20.0f, 30.0f);
        timeInterval = 0.1f;
        for (float i = 0.0f; i <= randomValue; i++)
        {
            transform.Rotate(0, 0, 30);
            if (i > (randomValue * 0.5f))
            {
                timeInterval = 0.2f;
            }
            if (i > (randomValue * 0.85f))
            {
                timeInterval = 0.4f;
            }
            yield return new WaitForSeconds(timeInterval);
        }
        angle = (int)transform.eulerAngles.z / 30;
        TextSystem();
    }
    private void TextSystem()
    {
        //Stop the Couritine of the Wheel;
        StopCoroutine(WheelSpin());
        //Start the Couritine of the Text;
        StartCoroutine(TextBlow());
    }
    IEnumerator TextBlow()
    {
        float interval=0;
        while (interval < timeIntervalText)
        {
            text[angle].fontSize = textSize;
            interval += Time.deltaTime;
            text[angle].fontSize = 2*textSize;
        }
        yield return new WaitForSeconds(timeIntervalText);
        text[angle].fontSize = 2*textSize;
        WheelToClaim();
    }
    private void WheelToClaim()
    {
        StopCoroutine(TextBlow());
        Wheel.SetActive(false);
        Claim.SetActive(true);
    }
    public void ClaimToWheel()
    {
        Claim.SetActive(false);
        Wheel.SetActive(true);
        blowUpDown = true;
    }
    public void SpinAgain()
    {
        if (blowUpDown)
        {
            StopAllCoroutines();
            spinButton.transform.localScale = new Vector3(1f, 1f, 1f);
            StartCoroutine(WheelSpin());
        }
    }
    IEnumerator SpinButtonUpDown()
    {
        float timeInterval = 2.0f;
        Vector3 temp;
        temp = spinButton.transform.localScale;
        for (float i = 0.0f; i < 0.1f; i = i + 0.1f)
        {
            temp.x += Time.deltaTime;
            temp.y += Time.deltaTime;
            temp.z += Time.deltaTime;
            if (temp.x <= 1.3f)
            {
                spinButton.transform.localScale = temp;
            }
            else 
            {
                break;
            }
        }
        yield return new WaitForSeconds(timeInterval);
        for (float i = 0.0f; i < 0.1f; i = i + 0.1f)
        {
            temp.x -= Time.deltaTime;
            temp.y -= Time.deltaTime;
            temp.z -= Time.deltaTime;
            if (temp.x >= 1f)
            {
                spinButton.transform.localScale = temp;
            }
            else 
            {
                break;
            }
        }

    }
}
