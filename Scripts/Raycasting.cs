using TMPro;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    string Raycastinghitname;
    public GameObject CHESS;
    public GameObject BOSS;
    public GameObject imposterHostage;
    public GameObject Weapon;
    public GameObject MiniBoss;
    public TextMeshProUGUI MyText;
    int goals = 0;
    
    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Raycastinghitname == "BOSS")
            {
                Destroy(BOSS);
                goals = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Raycastinghitname == "CHESS")
            {
                Destroy(GameObject.Find("CHESS"));
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Raycastinghitname == "imposterHostage")
            {
                Destroy(GameObject.Find("imposterHostage"));
                goals = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Raycastinghitname == "Weapon")
            {
                Destroy(GameObject.Find("Weapon"));
                goals = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Raycastinghitname == "MiniBoss")
            {
                Destroy(MiniBoss);
                goals = 2;
            }
        }

        



            }



    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4))

        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            Raycastinghitname = hit.collider.transform.root.gameObject.name;

            if (Raycastinghitname == "Weapon")
            {
                MyText.text = "Press E to pick up the weapon";
            }

            if (Raycastinghitname == "MiniBoss")
            {
                MyText.text = "Press E to slay the vampire Demon Tree";
            }

            if (Raycastinghitname == "imposterHostage")
            {
                MyText.text = "Press E to slay the imposterHostage";
            }

            if (Raycastinghitname == "BOSS")
            {
                MyText.text = "Press E to slay the Vampire King";
            }

            if (Raycastinghitname == "CHESS")
            {
                MyText.text = "Press E to play Chess";
            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            Raycastinghitname = "Empty";
            if (goals == 0 )
            {
                MyText.text = "Collect Vampire Clues (books) and pick up your blade in the altar";
            }
           
            if (goals == 1)
            {
                MyText.text = "After you unlock level 2, slay the vampires and the demon tree";
            }

            if (goals == 2)
                {
                MyText.text = "After you unlock level 3, save the hostages and slay the imposter hostage (vampire)";
            }

            if (goals == 3)
            {
                MyText.text = "After you unlock the final level, Slay Dracula!";
            }

            if (goals == 4)
            {
                MyText.text = "The Hunt is Over!";
            }

        }


    }
}

