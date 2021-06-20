using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    public int WeaponIndex;
    public int PlayerIndex;
    bool WeaponTake;

    public GameObject panel;
    public GameObject diePanel;
    public AudioSource Walls;
    public AudioReverbZone magmaSound;
    public AudioReverbZone birdsSound;

    public GameObject trigger;
    public GameObject Spawn;
    public GameObject[] Weapons;
    public GameObject[] Drop;

    //private Animator ch_animator;

    private ControllerScript _control;


    // Start is called before the first frame update
    void Start()
    {
        _control = GameObject.FindObjectOfType<ControllerScript>();
       // ch_animator = GetComponent<Animator>();
        foreach (GameObject weapon in Weapons)
        {
            weapon.SetActive(false);
            Weapons[WeaponIndex].SetActive(true);
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) & WeaponTake == true)
        {
            foreach (GameObject weapon in Weapons)
            {
                weapon.SetActive(false);
                Weapons[WeaponIndex].SetActive(true);
                panel.SetActive(false);
            }
            Instantiate(Drop[PlayerIndex], Spawn.transform.position, transform.rotation);
            PlayerIndex = WeaponIndex; 
        }
        
    }

    void OnTriggerStay(Collider other)
    {

        if(other.tag == "SwordTriggerDrop")
        {
            WeaponIndex = 0;
            WeaponTake = true;
            panel.SetActive(true);
            
        }
        if (other.tag == "HammerTriggerDrop")
        {
            WeaponIndex = 1;
            WeaponTake = true;
            panel.SetActive(true);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger.SetActive(true);
            Walls.Play();
        }

        if (other.tag == "Magma")
        {
            _control.ch_animator.SetTrigger("Die");
            diePanel.SetActive(true);
            _control.enabled = false;
        }
        if(other.tag == "MagmaSound")
        {
            magmaSound.GetComponent<AudioSource>().Play();
        }
        if(other.tag == "BirdsSound")
        {
            birdsSound.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SwordTriggerDrop"|| other.tag == "HammerTriggerDrop")
        {
            WeaponTake = false;
            panel.SetActive(false);
        }
        if(other.tag == "MagmaSound")
        {
            magmaSound.GetComponent<AudioSource>().Pause();
        }
        if (other.tag == "BirdsSound")
        {
            birdsSound.GetComponent<AudioSource>().Pause();
        }
    }

}
