using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public BoxCollider2D eatFoodTrigger;

    public Sprite closedMouth;
    public Sprite openedMouth;

    public LayerMask layerMask;
    private int layerIndex;

    private bool isSelected = false;

    void Start()
    {
        CloseMouth();
        layerIndex = (int)Mathf.Log(layerMask.value, 2);
    }

	void Update ()
    {
        if (GameManager.instance.IsEnd())
            return;

        HandleInput();

        if (isSelected)
        {
            OpenMouth();
        }
        else
        {
            CloseMouth();
        }
	}

    private void HandleInput()
    {
        isSelected = false;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(wp, (touch.position));
                if (hit.collider && hit.collider == gameObject.GetComponent<Collider2D>())
                {
                    isSelected = true;
                }
            }
        }
    }
    /*
    void OnMouseEnter()
    {
        isSelected = true;
    }

    void OnMouseExit ()
    {
        isSelected = false;
    }
    */
    private void CloseMouth()
    {
        transform.GetComponent<SpriteRenderer>().sprite = closedMouth;
        eatFoodTrigger.gameObject.SetActive(false);
    }

    private void OpenMouth()
    {
        transform.GetComponent<SpriteRenderer>().sprite = openedMouth;
        eatFoodTrigger.gameObject.SetActive(true);
    }
}
