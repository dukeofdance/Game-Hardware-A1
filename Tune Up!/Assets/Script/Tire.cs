using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tire : MonoBehaviour
{
    public SerialController serialController;

    //Lugnuts
    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;

    //Lugnut text
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;
    //WinUI
    public Text winText;
    public Image winBG;
    //Direction
    public Text turnText;
    public RawImage arrow;
    public RawImage wrench;
     
    //each lugnut's rotation amount
    float num1;
    float num2;
    float num3;
    float num4;
    float num5;

    //dirtyflags
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;

    //prevents interacting with a lugnut that's already out
    bool d1;
    bool d2;
    bool d3;
    bool d4;
    bool d5;

    //Loosened all lugnuts
    bool changed = false;

    //Speed of spinning
    public int spinSpeed;
    public int LugScale;

    string[] port= new string[3];//3
    // Start is called before the first frame update
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        t1.text = "0%";
        t2.text = "0%";
        t3.text = "0%";
        t4.text = "0%";
        t5.text = "0%";
        winText.enabled = false;
        winBG.enabled = false;

        d1 = true;
        d2 = true;
        d3 = true;
        d4 = true;
        d5 = true;
        l1.transform.rotation = Quaternion.Euler(0, 180, num1 * spinSpeed);//rotate object
        l2.transform.rotation = Quaternion.Euler(0, 180, num2 * spinSpeed);//rotate object
        l3.transform.rotation = Quaternion.Euler(0, 180, num3 * spinSpeed);//rotate object
        l4.transform.rotation = Quaternion.Euler(0, 180, num4 * spinSpeed);//rotate object
        l5.transform.rotation = Quaternion.Euler(0, 180, num5 * spinSpeed);//rotate object

    }

    // Update is called once per framq
    void Update()
    {
        //Debug.Log("1: " + num1);
        //Debug.Log("2: " + num2);
        //Debug.Log("3: " + num3);
        //Debug.Log("4: " + num4);
        //Debug.Log("5: " + num5);
        
        WinState(); 
        
        if (flag1 == true)
        {

            if (num1 >= 100)
            {
                t1.color = Color.red;
                d1 = false;
                num1 = 100;
                if (changed == false)
                    l1.SetActive(false);
                else
                    l1.SetActive(true);
            }

            t1.text = num1 + "%";//update text            
            flag1 = false;
        }
        if (flag2 == true)
        {

            if (num2 >= 100)
            {
                d2 = false;
                t2.color = Color.red;
                num2 = 100;
                if (changed == false)
                    l2.SetActive(false);
                else
                    l2.SetActive(true);
            }

            t2.text = num2 + "%";//update text
            flag2 = false;


        }
        if (flag3 == true)
        {

            if (num3 >= 100)
            {
                d3 = false;
                num3 = 100;
                t3.color = Color.red;
                if (changed == false)
                    l3.SetActive(false);
                else
                    l3.SetActive(true);
            }
            t3.text = num3 + "%";//update text
            flag1 = false;

        }
        if (flag4 == true)
        {

            if (num4 >= 100)
            {
                d4 = false;
                num4 = 100;
                t4.color = Color.red;
                if (changed == false)
                    l4.SetActive(false);
                else
                    l4.SetActive(true);
            }
            t4.text = num4 + "%";//update text
            flag4 = false;
        }
        if (flag5 == true)
        {

            if (num5 >= 100)
            {
                d5 = false;
                num5 = 100;
                t5.color = Color.red;
                if (changed == false)
                    l5.SetActive(false);
                else
                    l5.SetActive(true);
            }
            t5.text = num5 + "%";//update text
            flag5 = false;
        }

        //Keyboard Control for testing
         {/*
             if (d1 == true)
             {
                 if (Input.GetKey(KeyCode.Q))
                 {
                     if (changed == false)
                         num1 += 10;
                     else
                         num1 -= 10;
                     flag1 = true;
                 }
                 if (Input.GetKey(KeyCode.W))
                 {
                     if (changed == false)
                         num1 -= 10;
                     else
                         num1 += 10;
                     flag1 = true;
                 }
             }
             if (d2 == true)
             {
                 if (Input.GetKey(KeyCode.E))
                 {
                     if (changed == false)
                         num2 += 10;
                     else
                         num2 -= 10;
                     flag2 = true;

                 }
                 if (Input.GetKey(KeyCode.R))
                 {
                     if (changed == false)
                         num2 -= 10;
                     else
                         num2 += 10;
                     flag2 = true;

                 }
             }
             if (d3 == true)
             {
                 if (Input.GetKey(KeyCode.T))
                 {
                     if (changed == false)
                         num3 += 10;
                     else
                         num3 -= 10;
                     flag3 = true;

                 }
                 if (Input.GetKey(KeyCode.Y))
                 {
                     if (changed == false)
                         num3 -= 10;
                     else
                         num3 += 10;
                     flag3 = true;

                 }
             }
             if (d4 == true)
             {
                 if (Input.GetKey(KeyCode.U))
                 {
                     if (changed == false)
                         num4 += 10;
                     else
                         num4 -= 10;
                     flag4 = true;

                 }
                 if (Input.GetKey(KeyCode.I))
                 {
                     if (changed == false)
                         num4 -= 10;
                     else
                         num4 += 10;
                     flag4 = true;

                 }
             }
             if (d5 == true)
             {
                 if (Input.GetKey(KeyCode.O))
                 {
                     if (changed == false)
                         num5 += 10;
                     else
                         num5 -= 10;
                     flag5 = true;

                 }
                 if (Input.GetKey(KeyCode.P))
                 {
                     if (changed == false)
                         num5 -= 10;
                     else
                         num5 += 10;
                     flag5 = true;

                 }
             }
         */}

        /*Arduino Control*/

        {
            string message = serialController.ReadSerialMessage();

            if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
                Debug.Log("YoH0");
            else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
                Debug.Log("DEAD");
            else
            {
                if (message == null || message.Equals(""))
                    return;
                else
                {
                    Debug.Log("Message myDude: " + message);
                    port = message.Split(":");
                    {
                        Debug.Log("p1: " + port[0]);
                        Debug.Log("p2: " + port[1]);
                        Debug.Log("p3: " + port[2]);
                    }
                    if (d1 == true)
                    {
                        if (port[0].Equals("A1"))
                        {
                            int temp = int.Parse(port[1]);

                            if (temp != 0)
                            {
                                if (changed == false)
                                {
                                    if (port[2].Equals("CCW"))
                                    {
                                        num1 += Mathf.Pow(temp, 0)*LugScale;
                                    }
                                    else if (port[2].Equals("CW") && num1 > 0)
                                    {
                                        num1 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                                else
                                {
                                    if (port[2].Equals("CW"))
                                    {
                                        num1 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CCW") && num1 > 0)
                                    {
                                        num1 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                            }
                            l1.transform.rotation = Quaternion.Euler(0, 180, num1 * spinSpeed);//rotate object
                            flag1 = true;

                        }
                    }
                    if (d2 == true)
                    {
                        if (port[0].Equals("A2"))
                        {
                            int temp = int.Parse(port[1]);

                            if (temp != 0)
                            {
                                if (changed == false)
                                {
                                    if (port[2].Equals("CCW"))
                                    {
                                        num2 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CW") && num2 > 0)
                                    {
                                        num2 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                                else
                                {
                                    if (port[2].Equals("CC"))
                                    {
                                        num2 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CCW") && num2 > 0)
                                    {
                                        num2 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                            }
                            l2.transform.rotation = Quaternion.Euler(0, 180, num2 * spinSpeed);//rotate object
                            flag2 = true;
                        }
                    }
                    if (d3 == true)
                    {
                        if (port[0].Equals("A3"))
                        {
                            int temp = int.Parse(port[1]);

                            if (temp != 0)
                            {
                                if (changed == false)
                                {
                                    if (port[2].Equals("CW"))
                                    {
                                        num3 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CCW") && num3 > 0)
                                    {
                                        num3 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                                else
                                {
                                    if (port[2].Equals("CCW"))
                                    {
                                        num3 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CW") && num3 > 0)
                                    {
                                        num3 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                            }
                            l3.transform.rotation = Quaternion.Euler(0, 180, num3 * spinSpeed);//rotate object
                            flag3 = true;
                        }
                    }
                    if (d4 == true)
                    {
                        if (port[0].Equals("A4"))
                        {
                            int temp = int.Parse(port[1]);

                            if (temp != 0)
                            {
                                if (changed == false)
                                {
                                    if (port[2].Equals("CW"))
                                    {
                                        num4 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CCW") && num4 > 0)
                                    {
                                        num4 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                                else
                                {
                                    if (port[2].Equals("CCW"))
                                    {
                                        num4 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CW") && num4 > 0)
                                    {
                                        num4 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                            }
                            l4.transform.rotation = Quaternion.Euler(0, 180, num4 * spinSpeed);//rotate object
                            flag4 = true;
                        }
                    }
                    if (d5 == true)
                    {
                        if (port[0].Equals("A5"))
                        {
                            int temp = int.Parse(port[1]);

                            if (temp != 0)
                            {
                                if (changed == false)
                                {
                                    if (port[2].Equals("CCW"))
                                    {
                                        num5 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CW") && num5 > 0)
                                    {
                                        num5 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                                else
                                {
                                    if (port[2].Equals("CW"))
                                    {
                                        num5 += Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else if (port[2].Equals("CCW") && num5 > 0)
                                    {
                                        num5 -= Mathf.Pow(temp, 0) * LugScale;
                                    }
                                    else
                                    {
                                        Debug.Log("AFGEAVDAFSASDF");
                                    }
                                }
                            }
                            l5.transform.rotation = Quaternion.Euler(0, 180, num5 * spinSpeed);//rotate object
                            flag5 = true;
                        }
                    }
                }
            }
        }

    

    }

    void WinState()
    {
        if (num1 >= 100 && num2 >= 100 && num3 >= 100 && num4 >= 100 && num5 >= 100)
        {
            if (changed == false)
            {
                changed = true;
                arrow.transform.rotation = Quaternion.Euler(0, 180, -10);
                wrench.transform.rotation = Quaternion.Euler(0, 0,0);
                turnText.text = "Tighten";
                winBG.enabled = true;
                winText.enabled = true;
                winText.text = "You took out all the lugnuts. Removing Tire please wait...";
                num1 = 0;
                num2 = 0;
                num3 = 0;
                num4 = 0;
                num5 = 0;
                StartCoroutine(TireAnim());
            }
            else
            {
                
                SceneManager.LoadScene("End");
            }
        }
    }
    IEnumerator TireAnim()
    {

        gameObject.transform.position = new Vector3(100, gameObject.transform.position.y, gameObject.transform.position.z);
        yield return new WaitForSeconds(3);
        winText.text = "We have replaced the tire. Please fasten the lugnuts to the tire.";
        gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        yield return new WaitForSeconds(3);
        winText.enabled = false;
        winBG.enabled = false;
        num1 = 0;
        num2 = 0;
        num3 = 0;
        num4 = 0;
        num5 = 0;
        
        t1.color = Color.black;
        t2.color = Color.black;
        t3.color = Color.black;
        t4.color = Color.black;
        t5.color = Color.black;

        t1.text = "0%";
        t2.text = "0%";
        t3.text = "0%";
        t4.text = "0%";
        t5.text = "0%";

        l1.SetActive(true);
        l2.SetActive(true);
        l3.SetActive(true);
        l4.SetActive(true);
        l5.SetActive(true);
        
        d1 = true;
        d2 = true;
        d3 = true;
        d4 = true;
        d5 = true;

    }
}
  