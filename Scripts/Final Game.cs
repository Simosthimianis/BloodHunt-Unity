using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalGame : MonoBehaviour
{
    int Clues = 0;
    int targets = 0;
    int hostages = 0;
    public GameObject BOSS;
    public GameObject target;
    public AudioSource CharactersSounds;
    public AudioClip Jump;
    public AudioClip Roar;
    public AudioClip Smash;
    public AudioClip Collect;
    public AudioClip Slash;
    public TextMeshProUGUI Mytext;
    public TextMeshProUGUI Mytextprogress;
    public TextMeshProUGUI MytextList;
    public int metritis = 1;
    public List<string> Messages;
    public GameObject PrefabToSpawn;
    public GameObject Cylinder;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mytextprogress.text = "Last Hunt Clues" + PlayerPrefs.GetInt("HowManyClues", 0). ToString();
        MytextList.text = Messages[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
           GameObject Bat = Instantiate(PrefabToSpawn, Cylinder.transform.position, Cylinder.transform.rotation);
            Destroy(Bat,1);
        }

        


        if(Input.GetKeyUp(KeyCode.Space))
        {
            CharactersSounds.PlayOneShot(Jump);
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            CharactersSounds.PlayOneShot(Roar);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Obstacle")
        {
            CharactersSounds.PlayOneShot(Smash);
            Destroy(collision.gameObject);
        }


    }

   
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Clue")
        {
            CharactersSounds.PlayOneShot(Collect);
            Destroy(other.gameObject);
            MytextList.text = Messages[1] + metritis;
            Clues = Clues + 1;
            metritis = metritis + 1;
            Mytext.text = metritis.ToString();

            PlayerPrefs.SetInt("HowManyClues", metritis);

            Debug.Log("investigation clues" + Clues);

            if (Clues == 15)
            {
                Destroy(GameObject.Find("LEVEL 2 DOOR"));
            }
            
            if (metritis == 15)
            {
                MytextList.text = Messages[2];
            }

        }

        if (other.gameObject.name == "target")
        {
            CharactersSounds.PlayOneShot(Slash);
            Destroy(other.gameObject);
            targets = targets + 1;
            Debug.Log("target blood" + targets);

            if (targets == 18)
            {
                Destroy(GameObject.Find("LEVEL 3 DOOR"));
            }


            if (targets == 5)
            {
                Invoke("CylinderON", 3);
            }


        }

        if (other.gameObject.name == "Hostage")
        {
            CharactersSounds.PlayOneShot(Collect);
            Destroy(other.gameObject);
           hostages = hostages + 1;
            Debug.Log("freed prisoners" + hostages);

            if (hostages == 4)
            {
                Destroy(GameObject.Find("FINAL LEVEL"));
            }

        }
    }


void CylinderON()
{
    Cylinder.SetActive(true);
    InvokeRepeating("CreateBats", 3, 1);
}



void CreateBats()
{
    GameObject Bat = Instantiate(PrefabToSpawn, Cylinder.transform.position, Cylinder.transform.rotation);
        Destroy(Bat, 2);
}


}
