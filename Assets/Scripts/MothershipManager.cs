using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothershipManager : MonoBehaviour
{
    // Objects to spawn
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject purple;
    // ScoreManager object to keep track of score
    public ScoreManager results;

    // ToSpawn for every object created
    GameObject ToSpawn;
    Vector3 positionToSpawn = new Vector3(0.0f, 3.27f, -1f);
    // Arrays of objects for each color
    public GameObject[] reds;
    private int currentReds = 0;
    public GameObject[] greens;
    private int currentGreens = 0;
    public GameObject[] blues;
    private int currentBlues = 0;
    public GameObject[] purples;
    private int currentPurples = 0;
    // Start is called before the first frame update
    void Start()
    {
        results = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // Spawn enemies
        ToSpawn = GameObject.Instantiate(red, positionToSpawn, transform.rotation);
        ToSpawn = GameObject.Instantiate(green, new Vector3(1.1f, 3.27f, 0f), transform.rotation);
        ToSpawn = GameObject.Instantiate(blue, new Vector3(2.2f, 3.27f, 0f), transform.rotation);
        ToSpawn = GameObject.Instantiate(purple, new Vector3(3.3f, 3.27f, 0f), transform.rotation);

        // Get arrays for each color with all objects of each color
        reds = GameObject.FindGameObjectsWithTag("red");
        currentReds = reds.Length;
        greens = GameObject.FindGameObjectsWithTag("green");
        currentGreens = greens.Length;
        blues = GameObject.FindGameObjectsWithTag("blue");
        currentBlues = blues.Length;
        purples = GameObject.FindGameObjectsWithTag("purple");
        currentPurples = purples.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // Update current amount of objects in array
        reds = GameObject.FindGameObjectsWithTag("red");
        greens = GameObject.FindGameObjectsWithTag("green");
        blues = GameObject.FindGameObjectsWithTag("blue");
        purples = GameObject.FindGameObjectsWithTag("purple");
        // Check if object was destroyed
        if (reds.Length < currentReds || greens.Length < currentGreens || blues.Length < currentBlues || purples.Length < currentPurples)
        {
            if (reds.Length < currentReds)
            {
                results.updateScore("red");
            }
            else if (greens.Length < currentGreens)
            {
                results.updateScore("green");
            }
            else if (blues.Length < currentBlues)
            {
                results.updateScore("blue");
            }
            else if (purples.Length < currentPurples)
            {
                results.updateScore("purple");
            }
            // Resize current amount of objects for future comparisions
            currentReds = reds.Length;
            currentGreens = greens.Length;
            currentBlues = blues.Length;
            currentPurples = purples.Length;
            // Increase speed of all objects for each array of objects colors
            foreach (GameObject element in reds)
            {
                element.GetComponent<Enemy>().speedIncrease();
            }
            foreach (GameObject element in greens)
            {
                element.GetComponent<Enemy>().speedIncrease();

            }
            foreach (GameObject element in blues)
            {
                element.GetComponent<Enemy>().speedIncrease();

            }
            foreach (GameObject element in purples)
            {
                element.GetComponent<Enemy>().speedIncrease();

            }
        }
    }
}
