using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public RawImage instruct1;
    public RawImage instruct2;
    public RawImage instruct3;
    public RawImage instruct4;
    public RawImage instruct5;

    public GameObject greetings;
    public Text words;

    private bool done=false;
    private int count=0;
    private bool dirty = false;


    public Text t1;
    public Image i1;
    public Text t2;
    public Image i2;
    public Text t3;
    public Image i3;
    public Text t4;
    public Image i4;
    public Text t5;
    public Image i5;


    // Start is called before the first frame update
    void Start()
    {
;
        instruct1.enabled = false;
        t1.enabled = false;
        i1.enabled = false;
        instruct2.enabled = false;
        t2.enabled = false;
        i2.enabled = false;
        instruct3.enabled = false;
        t3.enabled = false;
        i3.enabled = false;
        instruct4.enabled = false;
        t4.enabled = false;
        i4.enabled = false;
        instruct5.enabled = false;
        t5.enabled = false;
        i5.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            if (done == true)
            {
                SceneManager.LoadScene("Tire");
            }
        }
        switch (count){
            case 1:
                {
                    greetings.SetActive(false);
                    instruct1.enabled = true;
                    t1.enabled = true;
                    i1.enabled = true;
                    break;
                }
            case 2:
                {
                    instruct1.enabled = false;
                    t1.enabled = false;
                    i1.enabled = false;
                    instruct2.enabled = true;
                    t2.enabled = true;
                    i2.enabled = true;
                    break;
                }
            case 3:
                {
                    instruct2.enabled = false;
                    t2.enabled = false;
                    i2.enabled = false;
                    instruct3.enabled = true;
                    t3.enabled = true;
                    i3.enabled = true;
                    break;
                }
            case 4:
                {
                    instruct3.enabled = false;
                    t3.enabled = false;
                    i3.enabled = false;
                    instruct4.enabled = true;
                    t4.enabled = true;
                    i4.enabled = true;
                    break;
                }
            case 5:
                {
                    instruct4.enabled = false;
                    t4.enabled = false;
                    i4.enabled = false;
                    instruct5.enabled = true;
                    t5.enabled = true;
                    i5.enabled = true;
                    break;
                }
            case 6:
                {
                    instruct5.enabled = false;
                    t5.enabled = false;
                    i5.enabled = false;
                    greetings.SetActive(true);
                    words.text = "Now let's get on our way";
                    break;
                }
            case 7:
                {
                    done = true;
                    break;
                }

        }
        
    }

}
