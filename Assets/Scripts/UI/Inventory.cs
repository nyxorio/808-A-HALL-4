using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Image[] keyFills;
    public Transform keysParent;
    public GameObject keyContainerPrefab;

    [SerializeField] private int itemMax;
    public int currentCollected;
    private int currentActivated;

    // Start is called before the first frame update
    void Start()
    {
        currentCollected = 0;
        currentActivated = 0;

        keyFills = new Image[itemMax];

        InstantiateKeyContainers();
    }

    public void GetItem()
    {
        currentCollected++;
        SetFilledKeys();
    }

    public void ActivateItem()
    {
        currentCollected--;
        currentActivated++;
        SetFilledKeys();
    }

    void SetFilledKeys()
    {
        for (int i = 0; i < keyFills.Length; i++)
        {
            if (i < currentCollected)
            {
                keyFills[i].fillAmount = 1;
                keyFills[i].color = Color.red;
            }
            else if (i<currentCollected + currentActivated)
            {
                keyFills[i].fillAmount = 1;
                keyFills[i].color = Color.green;
            }
            else
            {
                keyFills[i].fillAmount = 0;
            }
        }
    }

    void InstantiateKeyContainers()
    {
        for (int i = 0; i < itemMax; i++)
        {
            GameObject temp = Instantiate(keyContainerPrefab);
            temp.transform.SetParent(keysParent, false);
            keyFills[i] = temp.transform.Find("KeyFill").GetComponent<Image>();
        }
    }
}
