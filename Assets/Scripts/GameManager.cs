using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Sprite[] images = new Sprite[4];
    public GameObject bubbles;
    public GameObject bubblePrefab;

    // Start is called before the first frame update
    void Start()
    {
        bubbles = GameObject.Find("Bubbles");
        init();
        
    }

    private void init()
    {
        int x = 9;
        int y = 4;

        for(int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Vector2 pos = new Vector2((i % 2 == 0 ? (-2.5f + j * 0.6f) : (-2.2f + j * 0.6f)), (3.5f - i*0.5f));
                Debug.Log(pos.x);
                Debug.Log(pos.y);

                generateBubble(pos);
                
            }
        }
    }

    // create new bubble accurding to the value
    /*private Bubble generateBubble(Vector2 pos)
    {
        float rand = Random.Range(0f, 1f);

        return rand < 0.05 ? new Bubble(16, images[3], pos, bubbles.transform ) :
               rand < 0.15 ? new Bubble(8, images[2], pos, bubbles.transform) :
               rand < 0.35 ? new Bubble(4, images[1], pos, bubbles.transform) :
               new Bubble(2, images[0], pos, bubbles.transform);

    }*/
    private void generateBubble(Vector2 pos)
    {
        float rand = Random.Range(0.0f,1.0f);
        int pow = rand < 0.05 ? 3 :
                  rand < 0.15 ? 2 :
                  rand < 0.35 ? 1 : 0;

        createBubble((int)Mathf.Pow(2,pow+1), images[pow], pos, bubbles.transform);
    

    }
    public void createBubble(int value, Sprite image, Vector2 pos, Transform parent)
    {
        GameObject bubObj = Instantiate(bubblePrefab, pos, Quaternion.identity, parent);
        string textVal = value.ToString();
        bubObj.GetComponentInChildren<TextMeshPro>().fontSize = 18 - (textVal.Length - 1) * 2;

        bubObj.GetComponentInChildren<TextMeshPro>().text = textVal;
        bubObj.AddComponent(typeof(Bubble));
        bubObj.GetComponent<Bubble>().value = value;
        bubObj.GetComponent<SpriteRenderer>().sprite = image;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
