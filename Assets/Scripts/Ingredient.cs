using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private Blender blender;

    [SerializeField] private string ingredient;
    private Vector3 startPos;
    private float mousePosX, mousePosY;
    private bool isHeld = false, isHovered = false;

    private void Awake()
    {
        blender = GameObject.Find("Blender").GetComponent<Blender>();
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
        foreach (Collider2D hitTargets in Physics2D.OverlapCircleAll(transform.position, .75f))
        {
            if (hitTargets.tag == "Player")
                blender.Add(ingredient);
        }
            
        isHeld = false;
        transform.localPosition = startPos;
    }


    public string GetIngredient() { return ingredient; }
}
