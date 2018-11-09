using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [SerializeField]
     GameObject InspectButton;
    [SerializeField]
    GameObject Monster;
    [SerializeField]
    GameObject Door;
    [SerializeField]
    Material Correct;
    [SerializeField]
    GameObject MonsterPunch;
    [SerializeField]
    GameObject DropBook;

    NavMeshAgent navMeshAgent;
    InspectButton inspectButton;


    

    //float //timeToShowText = 20;
    bool getCloseToTheZerothBook = false;
    bool getCloseToTheFirstBook = false;
    bool getCloseToTheSecondBook = false;
    bool getCloseToTheThirdBook = false;
    bool getCloseToTheOtherBooks = false;
    bool playerGotHit = false;
    private Animator anim;
    private System.Timers.Timer time = new System.Timers.Timer();
    private bool done = false;
    private Collision collided;
  

    public bool WhetherCloseToTheZerothBook
    {
        get { return getCloseToTheZerothBook; }
    }

    public bool WhetherCloseToTheFirstBook 
    {
        get { return getCloseToTheFirstBook; }

    }
    public bool WhetherCloseToTheSecondBook
    {
        get { return getCloseToTheSecondBook; }

    }
    public bool WhetherCloseToTheThirdBook
    {
        get { return getCloseToTheThirdBook; }

    }
    public bool WhetherCloseToTheOtherBook
    {

        get { return getCloseToTheOtherBooks; }
    }
    public bool WhetherPlayerGotHit
    {
        get { return playerGotHit; }

    }
    // Use this for initialization
    void Start () {
        inspectButton = InspectButton.GetComponent<InspectButton>();
        navMeshAgent = Monster.GetComponent<NavMeshAgent>();
        anim = Monster.GetComponent<Animator>();
    




    }

    // Update is called once per frame
    void Update () {
		if(inspectButton.WetherFoundFirstBook == true && inspectButton.WetherFoundSecondBook == true && inspectButton.WetherFoundThirdBook == true)
        {
            Destroy(Door.GetComponent<MeshRenderer>().material);
            Door.GetComponent<MeshRenderer>().material = Correct;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        //collided = collision;
        //done = false;
     
        //time.Start();
        //time.Interval = 360;
        
        //while (!done) ;
        if (collision.gameObject.tag == "Monster")
        {
            anim.SetTrigger("Attac");
            print("monster hit the player");
            if (inspectButton.WetherFoundFirstBook == false && inspectButton.WetherFoundSecondBook == false && inspectButton.WetherFoundThirdBook == false)
            {
                SceneManager.LoadScene("YouLose");

            }

            if (inspectButton.WetherFoundFirstBook == true && inspectButton.WetherFoundSecondBook == false && inspectButton.WetherFoundThirdBook == false)
            {
                // check for the book and delete the first book
                //found the first book set to false
                //delete the book sign

                //play the sound
                Monster.transform.position = new Vector3(-200, -200, 0);

                //timeToShowText = 20;

                GameObject bookSign = GameObject.FindWithTag("BookSign");
                if (bookSign != null)
                {
                    Destroy(bookSign);
                    navMeshAgent.destination = new Vector3(0, 0, 0);
                    inspectButton.WetherFoundFirstBook = false;

                    transform.position = new Vector3(18, 0, -18);
                    MonsterPunch.GetComponent<AudioSource>().Play(0);
                    DropBook.GetComponent<AudioSource>().Play(0);
                }

            }

            if (inspectButton.WetherFoundSecondBook == true && inspectButton.WetherFoundThirdBook == false && inspectButton.WetherFoundFirstBook == true)
            {
                // check for the book and delete the first book
                //found the first book set to false
                //delete the book sign
                Monster.transform.position = new Vector3(-200, -200, 0);

                //timeToShowText = 20;

                GameObject bookSign = GameObject.FindWithTag("BookSignTwo");
                if (bookSign != null)
                {
                    Destroy(bookSign);
                    navMeshAgent.destination = new Vector3(0, 0, 0);
                    inspectButton.WetherFoundSecondBook = false;
                    transform.position = new Vector3(18, 0, -18);
                    MonsterPunch.GetComponent<AudioSource>().Play(0);
                    DropBook.GetComponent<AudioSource>().Play(0);
                }
            }
            if (inspectButton.WetherFoundThirdBook == true && inspectButton.WetherFoundFirstBook == true && inspectButton.WetherFoundThirdBook == true)
            {
                // check for the book and delete the first book
                //found the first book set to false
                //delete the book sign


                Monster.transform.position = new Vector3(-200, -200, 0);


                GameObject bookSign = GameObject.FindWithTag("BookSignThree");
                if (bookSign != null)
                {
                    Destroy(bookSign);
                    navMeshAgent.destination = new Vector3(0, 0, 0);
                    inspectButton.WetherFoundThirdBook = false;
                    transform.position = new Vector3(18, 0, -18);
                    MonsterPunch.GetComponent<AudioSource>().Play(0);
                    DropBook.GetComponent<AudioSource>().Play(0);
                }

            }



        }

    }


    //private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    //{
    //    time.Stop();
    //    done = true;
    //    death();
    //}

    private void OnTriggerEnter(Collider other)
    {   if(other.gameObject.tag =="InitialBook")
        {
            getCloseToTheZerothBook = true;
            print("hit the zeroth book");

        }
        else if (other.gameObject.tag == "Book")
        {
        getCloseToTheOtherBooks = true;
            print("hit the book");

        }

        else if (other.gameObject.tag == "FirstBook")
        {
            getCloseToTheFirstBook = true;
            print("hit the first book");

        }
        else  if (other.gameObject.tag == "SecondBook")
        {
            getCloseToTheSecondBook = true;
            print("hit the second book");
        }
        else if (other.gameObject.tag == "ThirdBook")
        {
            getCloseToTheThirdBook = true;
            print("hit the Third book");
        }
        else if (other.gameObject.tag == "Door")
        {   if (inspectButton.WetherFoundFirstBook == true && inspectButton.WetherFoundSecondBook == true&& inspectButton.WetherFoundThirdBook==true)
            {
           
                
                print("win");

                SceneManager.LoadScene("YouWin");

            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InitialBook")
        {
            getCloseToTheZerothBook = false;
        }

        else if (other.gameObject.tag == "FirstBook")
        {
            getCloseToTheFirstBook =false;
        }
        else  if (other.gameObject.tag == "SecondBook")
        {
            getCloseToTheSecondBook =false;
        }
        else if (other.gameObject.tag == "ThirdBook")
        {
            getCloseToTheThirdBook = false;
        }
        else if(other.gameObject.tag=="Monster")
        {
            playerGotHit = false;

        }
        else if (other.gameObject.tag == "Book")
        {
            getCloseToTheOtherBooks = false;

        }

    }
}
