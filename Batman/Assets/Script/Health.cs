using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text textabc;
    Bat_Car bat_Car;

    // Start is called before the first frame update
    void Start()
    {
        bat_Car = FindObjectOfType<Bat_Car>();
        textabc = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        textabc.text = bat_Car.HealthRet().ToString();
        
        if (int.Parse(textabc.text) < 350 && int.Parse(textabc.text) > 155)
        {
            textabc.color = new Color(1.0f, 0.64f, 0.0f);
        }
        if (int.Parse(textabc.text) <= 150)
        {
            textabc.color = Color.red;
        }

    }
}
