using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TriggerMessage : MonoBehaviour
{
    public TextMeshProUGUI Mytext;
    public GameObject MyStatus;
    public Image MyImage;
    public Sprite MySecondImageSprite;
    public GameObject Door;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name=="TriggerMessage1")
        {
            MyStatus.SetActive(true);
            MyStatus.GetComponent<TextMeshProUGUI>().text = "University";
        }


        if (other.gameObject.name == "TriggerMessage2")
        {
            MyStatus.SetActive(true);
            MyStatus.GetComponent<TextMeshProUGUI>().text = "City Center";
            
        }


        if (other.gameObject.name == "TriggerMessage3")
        {
            MyStatus.SetActive(true);
            MyStatus.GetComponent<TextMeshProUGUI>().text = "Castle";
        }

        if (other.gameObject.name == "TriggerMessage4")
        {
            MyStatus.SetActive(true);
            MyStatus.GetComponent<TextMeshProUGUI>().text = "Altar";
            MyImage.sprite = MySecondImageSprite;
            Door.GetComponent<Animator>().Play("DoorOpen");
            
        }

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "TriggerMessage1")
        {
            MyStatus.SetActive(false);
        }

        if (other.gameObject.name == "TriggerMessage2")
        {
            MyStatus.SetActive(false);
        }

        if (other.gameObject.name == "TriggerMessage3")
        {
            MyStatus.SetActive(false);
        }
    }

    public void ButtonClicked()
    {
        Mytext.text = "LET THE HUNT BEGIN";
    }


}
