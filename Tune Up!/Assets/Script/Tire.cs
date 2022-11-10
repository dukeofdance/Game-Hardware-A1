using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tire : MonoBehaviour
{
    public SerialController serialController;


    public GameObject l1;
    public GameObject l2;
    public GameObject l3;
    public GameObject l4;
    public GameObject l5;

    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;

    float num1;
    float num2;
    float num3;
    float num4;
    float num5;

    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    bool flag5 = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (flag1 == true)
        {
            t1.text = num1 + "%";
            //t1.text = (int)(((num1 % 360) / 360) * 100) + "%";
        }
        if (flag2 == true)
        {
            t2.text = (int)(((num2 % 360) / 360) * 100) + "%";
        }
        if (flag3 == true)
        {
            t3.text = (int)(((num3 % 360) / 360) * 100) + "%";
        }
        if (flag4 == true)
        {
            t4.text = (int)(((num4 % 360) / 360) * 100) + "%";
        }
        if (flag5 == true)
        {
            t5.text = (int)(((num5 % 360) / 360) * 100) + "%";
        }

        string message = serialController.ReadSerialMessage();

        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("YoH0");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("DEAD");
        else
        {
            if (message == null || message.Equals(""))
            {
                return;
            }
            else
            {
                Debug.Log("Message myDude: " + message);
                port = message.Split(":");
                Debug.Log("p1: " + port[0]);
                Debug.Log("p2: " + port[1]);
                Debug.Log("p3: " + port[2]);

                if (port[0].Equals("A1"))
                {
                    int temp = int.Parse(port[1]);
                    //num1 += temp;
                    if (temp != 0)
                    {
                        if (port[2].Equals("CW"))
                        {
                            num1 += Mathf.Pow(temp,0);
                        }
                        else if (port[2].Equals("CCW")&&num1>0)
                        {
                            num1 -= Mathf.Pow(temp,0);
                        }
                        else
                        {
                            Debug.Log("AFGEAVDAFSASDF");
                        }
                    }
                    //num1 += 1;
                    l1.transform.rotation = Quaternion.Euler(0, 0, num1);
                    flag1 = true;

                }
                if (Input.GetKey(KeyCode.W))
                {
                    num2 += 1;
                    l2.transform.rotation = Quaternion.Euler(0, 0, num2);
                    flag2 = true;

                }
                if (Input.GetKey(KeyCode.E))
                {
                    num3 += 1;
                    l3.transform.rotation = Quaternion.Euler(0, 0, num3);
                    flag3 = true;

                }
                if (Input.GetKey(KeyCode.R))
                {
                    num4 += 1;
                    l4.transform.rotation = Quaternion.Euler(0, 0, num4);
                    flag4 = true;

                }
                if (Input.GetKey(KeyCode.T))
                {
                    num5 += 1;
                    l5.transform.rotation = Quaternion.Euler(0, 0, num5);
                    flag5 = true;

                }
            }
        }

    }


}
