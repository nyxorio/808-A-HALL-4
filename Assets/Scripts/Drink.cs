using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    private NPC character;
    private Dictionary<string, int> drink;
    private string drinkName;

    private Vector3 startPos;
    private float mousePosX, mousePosY;
    private bool isHeld = false;

    private void Awake()
    {
        character = GameObject.Find("Character").GetComponent<NPC>();
    }

    public void NextOrder(GameObject character)
    {
        this.character = character.GetComponent<NPC>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isHeld)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(mousePos.x - mousePosX, mousePos.y - mousePosY, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosX = mousePos.x - transform.localPosition.x;
            mousePosY = mousePos.y - transform.localPosition.y;

            startPos = transform.localPosition;

            isHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isHeld = false;

        foreach (Collider2D hitTargets in Physics2D.OverlapCircleAll(transform.position, .75f, playerLayer))
        {
            if (hitTargets.tag == "NPC")
            {
                character.Receive(drink);
                GetComponent<SpriteRenderer>().sprite = null;
                GetComponent<Collider2D>().enabled = false;
                break;
            }
            if (hitTargets.tag == "Trash")
            {
                GetComponent<SpriteRenderer>().sprite = null;
                GetComponent<Collider2D>().enabled = false;
                break;
            }
        }

        transform.localPosition = startPos;
    }

    public void SetMix(Dictionary<string, int> mix)
    {
        drink = new Dictionary<string, int>(mix);
    }
}
