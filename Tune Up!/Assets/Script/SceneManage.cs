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

    private bool i1,i2,i3;
    private int count=1;
    private bool dirty = false;
    // Start is called before the first frame update
    void Start()
    {
        i2 = false;
        i3 = false;
        instruct1.enabled = true; ;
        instruct2.enabled = false; ;
        instruct3.enabled = false; ;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            if (i3 == true)
            {
                SceneManager.LoadScene("Tire");
            }
        }
        switch (count){
            case 2:
                {
                    i2 = true;
                    instruct1.enabled = false; ;
                    instruct2.enabled = true; ;
                    break;
                }
            case 3:
                {
                    i3 = true;
                    instruct2.enabled = false; ;
                    instruct3.enabled = true; ;
                    break;
                }
            
        }
        
    }

}
