using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLogic : MonoBehaviour {
    [SerializeField]
    GameObject InspectButton;
    [SerializeField]
    GameObject CloseButton;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    Image gotBook1;
    [SerializeField]
    Image gotBook2;
    [SerializeField]
    Image gotBook3;
    Player player;
    //InspectButton inspectButton;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InspectButton.SetActive(false);
        CloseButton.SetActive(false);
        //inspectButton = InspectButton.GetComponent<InspectButton>();

    }
	
	// Update is called once per frame
	void Update () {

        if (player.WhetherCloseToTheFirstBook == true||player.WhetherCloseToTheSecondBook==true||player.WhetherCloseToTheThirdBook==true||player.WhetherCloseToTheZerothBook==true||player.WhetherCloseToTheOtherBook==true)
        {
            InspectButton.SetActive(true);
        }
        else {
            InspectButton.SetActive(false);
        }

        GameObject clue = GameObject.FindWithTag("Clue");
        if (clue != null)
        {
            CloseButton.SetActive(true);

        }
        else{

            CloseButton.SetActive(false);
        }

   


    }
}
