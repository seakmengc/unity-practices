using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;

    private int currentFedAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //var position = Camera.main.WorldToScreenPoint(transform.position);

        //hungerSlider.transform.position = position;
    }

    public void Feed()
    {
        currentFedAmount++;

        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;

        if (currentFedAmount >= amountToBeFed)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().IncrementScore();
            Destroy(gameObject, 0.1f);
        }
    }
}
