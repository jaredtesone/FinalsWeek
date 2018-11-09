using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBooks : MonoBehaviour {
    private GameObject[] bookshelves;
    private Dictionary<GameObject, int> shelfData;
    private Vector3[] bookSlots = new Vector3[5];
    private System.Random rand = new System.Random();
    private HashSet<int> occupied = new HashSet<int>();
    private GameObject[] books;

    public Quaternion orientation = new Quaternion();
    public float depth = 1.72f;
    public int numBooks = 10;
    public GameObject bookTemplate;

	// Use this for initialization
	void Start () {
        //get spawnable bookshelves
        bookshelves = GameObject.FindGameObjectsWithTag("BookSpawn");
        Debug.Log(bookshelves.Length);
        shelfData = new Dictionary<GameObject, int>(bookshelves.Length);
        for (int i = 0; i < bookshelves.Length; i++)
        {
            //add bookshelf and initial number of special books to shelfData map
            shelfData.Add(bookshelves[i], 0);
        }
        Debug.Log(shelfData.Count);
        //define book spawn locations in bookshelves
        bookSlots[0] = new Vector3(depth, 2, 1.45f);    //top left of bookcase
        bookSlots[1] = new Vector3(depth, 1, 0.33f);    //left of 2nd shelf down
        bookSlots[2] = new Vector3(depth, 1, -0.4f);    //right of 2nd shelf down
        bookSlots[3] = new Vector3(depth, 0, 1.08f);    //left of 3rd row down
        bookSlots[4] = new Vector3(depth, -1, -1.15f);  //bottom right of bookcase
        orientation.eulerAngles = new Vector3(-90, 0, -90);     //set rotation of book

        //create array of books
        books = new GameObject[numBooks];
        for (int i = 0; i < numBooks; i++)
        {
            //place book in random location
            books[i] = Instantiate(bookTemplate);
            Debug.Log(books[i].GetType());
            books[i].SetActive(true);
            //select random bookcase that does not have special book
            int shelfNum = rand.Next(10);
            while (occupied.Contains(shelfNum))
                shelfNum = rand.Next(10);
            GameObject tmpShelf = bookshelves[rand.Next(10)];

            //check that bookcase has no other special books
            int booksSpawned;
            if (shelfData.TryGetValue(tmpShelf, out booksSpawned) && booksSpawned != 0)
            {
                //update number of books in shelf
                shelfData[tmpShelf]++;
                occupied.Add(shelfNum);
                //store book in shelf
                books[i].transform.SetParent(tmpShelf.transform);
                //select random slot in bookshelf and set rotation
                books[i].transform.SetPositionAndRotation(bookSlots[rand.Next(5)], orientation);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
