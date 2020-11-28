using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public Sprite[] images = new Sprite[4];
    public GameObject bubbles;
    public GameObject bubblePrefab;
    public GameObject arrow;
    public bool isCannonEmpty = true;
    bool isFiring = false;
    GameObject currBubble;
    private int maxRows = 11;
    private int maxCols = 9;
    public GameObject[,] bubbleMatrix;

    // Start is called before the first frame update
    void Start()
    {

        bubbles = GameObject.Find("Bubbles");
        bubbleMatrix = new GameObject[maxRows,maxCols];
        init();
        
    }

    private void init()
    {
        //initialize board
        int x = maxCols;
        int y = 5;

        for(int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Vector2 pos = new Vector2((i % 2 == 0 ? (-2.5f + j * 0.6f) : (-2.2f + j * 0.6f)), (3.5f - i*0.5f));
                generateBubble(pos);
                //bubbleMatrix[i, j].GetComponent<Bubble>().position = pos;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCannonEmpty)
        {
            Vector2 pos = new Vector2(0, -3.8f);
            currBubble = generateBubble(pos);
            currBubble.tag = "CurrBubble";
            isCannonEmpty = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            currBubble.GetComponent<Bubble>().startMoving(arrow.transform.rotation);
            isFiring = true;
        }
        if (isFiring && !currBubble.GetComponent<Bubble>().IsMoving())
        {
            isCannonEmpty = true;
            isFiring = false;
        }
    }

    private GameObject generateBubble(Vector2 pos)
    {
        float rand = UnityEngine.Random.Range(0.0f,1.0f);
        int pow = rand < 0.15 ? 3 :
                  rand < 0.25 ? 2 :
                  rand < 0.6 ? 1 : 0;
        return createBubble((int)Mathf.Pow(2,pow+1), images[pow], pos, bubbles.transform);
    }

    public GameObject createBubble(int value, Sprite image, Vector2 pos, Transform parent)
    {
        GameObject bubObj = Instantiate(bubblePrefab, pos, Quaternion.identity, parent);
        string textVal = value.ToString();
        bubObj.GetComponentInChildren<TextMeshPro>().fontSize = 18 - (textVal.Length - 1) * 2;
        bubObj.GetComponentInChildren<TextMeshPro>().text = textVal;
        bubObj.AddComponent(typeof(Bubble));
        bubObj.GetComponent<Bubble>().value = value;
        bubObj.GetComponent<SpriteRenderer>().sprite = image;
        return bubObj;
        
    }

    
}
