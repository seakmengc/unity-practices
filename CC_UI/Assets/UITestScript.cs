using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestScript : MonoBehaviour
{
    private Slider slider;
    public AudioSource classicalMusic;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = classicalMusic.volume;
        slider.onValueChanged.AddListener(MyFunction);
    }

    private void MyFunction(float value)
    {
        Debug.Log("Value changed to " + value.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
