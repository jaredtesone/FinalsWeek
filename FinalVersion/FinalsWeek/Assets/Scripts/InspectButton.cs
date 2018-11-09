using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectButton : MonoBehaviour {
    [SerializeField]
    Image cluePage1;
    [SerializeField]
    Image cluePage2;
    [SerializeField]
    Image cluePage3;
    [SerializeField]
    Image cluePage0;

    [SerializeField]
    Image gotBook1;
    [SerializeField]
    Image gotBook2;
    [SerializeField]
    Image gotBook3;


    Player player;
    bool foundFirstBook = false;
    bool foundSecondBook = false;
    bool foundThirdBook = false;


    public bool WetherFoundFirstBook
    {
        get { return foundFirstBook; }
        set { foundFirstBook = value; }


    }
    public bool WetherFoundSecondBook
    {
        get { return foundSecondBook; }
        set { foundSecondBook = value; }

    }
    public bool WetherFoundThirdBook
    {
        get { return foundThirdBook; }
        set { foundThirdBook = value; }

    }


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

      
        
    }
	
	// Update is called once per frame
	void Update () {

  
	}

    public void OnZerothClick()
    {
        if (player.WhetherCloseToTheZerothBook == true )
        {

            Image clue0 = Instantiate(cluePage0, transform.position, transform.rotation);
            clue0.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

         
        }
    }

        public void OnFirstClick()
        {

            if (player.WhetherCloseToTheFirstBook == true && foundFirstBook==false)
        {
           
      Image clue1 = Instantiate(cluePage1, transform.position, transform.rotation);
            clue1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
         
            foundFirstBook = true;
            Image GotBookOne = Instantiate(gotBook1, new Vector3(100, 800, 0), transform.rotation);
            GotBookOne.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);


        }
  
    }

    public void OnSecondClick()
    {
        if (foundFirstBook == true && player.WhetherCloseToTheSecondBook == true && foundSecondBook==false){
     
            Image clue2 = Instantiate(cluePage2, transform.position, transform.rotation);
            clue2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
   
            foundSecondBook = true;
            Image GotBookTwo = Instantiate(gotBook2, new Vector3(200, 800, 0), transform.rotation);
            GotBookTwo.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);


        }

    }


    public void OnThirdClick()
    {

        if (player.WhetherCloseToTheThirdBook == true && foundThirdBook == false&& foundSecondBook==true)
        {

            Image clue3 = Instantiate(cluePage3, transform.position, transform.rotation);
            clue3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            foundThirdBook = true;
            Image GotBookThree = Instantiate(gotBook3,new Vector3(300,800,0), transform.rotation);
            GotBookThree.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);



        }

    }

}
    
 

