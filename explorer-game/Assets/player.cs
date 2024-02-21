using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    SpriteRenderer collectibleSpriteRenderer;
    public GameObject[] collectibleSprite;
    public Sprite[] tools;
    public int toolIndex=0;
    public TextMeshProUGUI movInstructText;
    public bool nearCollectible = false;
    public string collectibleName;
    private bool collectable = true;
    public Animator animator;
    public float movementThreshold = 0.1f;
    public GameObject inspectionMenu;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("Collectible") && collectable)
        {
            Debug.Log("Collided");
            movInstructText.text = "Press space to pick up!";
        }
        nearCollectible = true;
        collectibleName = col.name;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectible"))
        {
            movInstructText.text = "Use arrow keys to move";
        }
        nearCollectible = false;
        collectibleName = "";
    }

    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.CompareTag("Collectible"))
    //    {
    //        movInstructText.text = "Use arrow keys to move";
    //    }

    //}

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
        bool isMoving = Mathf.Abs(horizontalInput) > movementThreshold;
        animator.SetBool("IsMoving", isMoving);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, 12f);
        }
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && nearCollectible)
        {
            int index = FindSpriteIndexByName(collectibleName);

            if (index != -1)
            {
                Debug.Log(toolIndex);
                Debug.Log("sprite indez"+index);
                collectibleSpriteRenderer = collectibleSprite[index].GetComponent<SpriteRenderer>();
                if (collectibleSpriteRenderer != null && collectable)
                {
                    tools[toolIndex] = collectibleSprite[index].GetComponent<SpriteRenderer>().sprite;
                    toolIndex++;
                    collectable = false;
                    collectibleSpriteRenderer.enabled = false;
                    collectibleSprite[index].SetActive(false);
                }
                else
                {
                    Debug.LogError("SpriteRenderer component not found!");
                }
            }
            else
            {
                Debug.LogError("Sprite not found!");
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inspectionMenu.SetActive(!inspectionMenu.activeSelf);
            if(inspectionMenu.activeSelf && tools[0]!=null)
            {
                Debug.Log(tools.Length);
                for (int i = 0; i < tools.Length; i++)
                {
                    Sprite tool = tools[i];
                    Debug.Log("GameObject Name: " + tool.name);
                    GameObject obj = GameObject.Find("Collectible "+ (i+1).ToString());
                    obj.GetComponent<SpriteRenderer>().sprite = tool;
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = "Gem: Key stone to go to next level";
                }
            }
        }

    }

    int FindSpriteIndexByName(string name)
    {
        for (int i = 0; i < collectibleSprite.Length; i++)
        {
            if (collectibleSprite[i].name == name)
            {
                return i;
            }
        }
        return -1;
    }
}
