using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBooks : MonoBehaviour {
    private GameObject[] bookshelves;
    private Dictionary<GameObject, int> shelfData;
    private Vector3[] bookSlots = new Vector3[4];
    private System.Random rand = new System.Random();
    private HashSet<int> occupied = new HashSet<int>();
    private GameObject[] books;

    public Quaternion orientation = new Quaternion();
    public Vector3 scale = new Vector3(6, 24, 30);
    public float depth = 1.75f;
    public int numBooks = 10;
    public GameObject bookTemplate;

	// Use this for initialization
	void Start () {
        //get spawnable bookshelves
        bookshelves = GameObject.FindGameObjectsWithTag("BookSpawn");
        //Debug.Log(bookshelves.Length);
        shelfData = new Dictionary<GameObject, int>(bookshelves.Length);
        for (int i = 0; i < bookshelves.Length; i++)
        {
            //add bookshelf and initial number of special books to shelfData map
            shelfData.Add(bookshelves[i], 0);
        }
        //define book spawn locations in bookshelves
        //bookSlots[0] = new Vector3(depth, 1.7f, 1.47f);    //top left of bookcase
        bookSlots[0] = new Vector3(depth, 0.7f, 0.36f);    //left of 2nd shelf down
        bookSlots[1] = new Vector3(depth, 0.7f, -0.37f);    //right of 2nd shelf down
        bookSlots[2] = new Vector3(depth, -0.31f, 1.11f);    //left of 3rd row down (potential bug?)
        bookSlots[3] = new Vector3(depth, -1.31f, -1.11f);  //bottom right of bookcase
        orientation.eulerAngles = new Vector3(-90, 0, -90);     //set rotation of book

        //create array of books
        books = new GameObject[numBooks];
        for (int i = 0; i < numBooks; i++)
        {
            //place book in random location
            books[i] = Instantiate(bookTemplate);
            books[i].SetActive(true);

            //select random bookcase that does not have special book
            bool placed = false;    //keep choosing bookcases until every book is placed
            while (!placed)
            {
                int shelfNum = rand.Next(10);
                while (occupied.Contains(shelfNum))
                    shelfNum = rand.Next(10);
                GameObject tmpShelf = bookshelves[rand.Next(10)];

                //check that bookcase has no other special books
                int booksSpawned;
                if (shelfData.TryGetValue(tmpShelf, out booksSpawned) && booksSpawned == 0)
                {
                    //update number of books in shelf
                    shelfData[tmpShelf]++;
                    occupied.Add(shelfNum);
                    //store book in shelf
                    books[i].transform.SetParent(tmpShelf.transform);
                    //select random slot in bookshelf and set position, rotation, and scale
                    int shelfSlot = rand.Next(bookSlots.Length);
                    Vector3 pos = bookSlots[shelfSlot];
                    books[i].transform.localPosition = pos;
                    books[i].transform.localRotation = orientation;
                    books[i].transform.localScale = scale;

                    placed = true;
                }
            }
        }
        //select first book
        int spec1 = rand.Next(numBooks);
        books[spec1].transform.tag = "FirstBook";

        //select second book
        int spec2 = rand.Next(numBooks);
        while (spec2 == spec1)
            spec2 = rand.Next(numBooks);
        books[spec2].transform.tag = "SecondBook";

        //select third book
        int spec3 = rand.Next(numBooks);
        while (spec3 == spec1 || spec3 == spec2)
            spec3 = rand.Next(numBooks);
        books[spec3].transform.tag = "ThirdBook";
    }
}
