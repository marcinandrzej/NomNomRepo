using System.Collections;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    private const float MIN_TIME = 0.4f;
    private const float MAX_TIME = 1.2f;
    private const float BOMO_PROBABILITY = 0.15f;
    public const float FORCE = 300.0f;

    public Sprite[] foodSprites;
    public Sprite bombSprite;
    public GameObject dropdownPrefab;

    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    public LayerMask foodLayer;
    public LayerMask bombLayer;

    private int foodIndex;
    private int bombIndex;

    private Vector3 bombScale = new Vector3(0.3f, 0.3f, 1.0f);

    private Vector2 rightToLeft = new Vector2(-0.45f, 1.0f);
    private Vector2 leftToRight = new Vector2(0.45f, 1.0f);

    private bool wait1 = false;
    private bool wait2 = false;

    void Start ()
    {
        foodIndex = (int)Mathf.Log(foodLayer.value, 2);
        bombIndex = (int)Mathf.Log(bombLayer.value, 2);
    }
	
	void Update ()
    {
        if (GameManager.instance.IsEnd())
            return;

        if (!wait1)
            StartCoroutine(CreateFoodL());

        if (!wait2)
            StartCoroutine(CreateFoodR());
    }

    private IEnumerator CreateFoodL()
    {
        wait1 = true;
        float timer = Random.Range(MIN_TIME, MAX_TIME);
        yield return new WaitForSeconds(timer);
        if (Random.Range(0.0f, 1.0f) > BOMO_PROBABILITY)
            CreateFood(leftSpawnPoint, leftToRight);
        else
            CreateBomb(leftSpawnPoint, leftToRight);
        wait1 = false;
    }

    private IEnumerator CreateFoodR()
    {
        wait2 = true;
        float timer = Random.Range(MIN_TIME, MAX_TIME);
        yield return new WaitForSeconds(timer);
        if(Random.Range(0.0f,1.0f) > BOMO_PROBABILITY)
            CreateFood(rightSpawnPoint, rightToLeft);
        else
            CreateBomb(rightSpawnPoint, rightToLeft);
        wait2 = false;
    }

    private void CreateFood(Transform spawnPoint, Vector2 direction)
    {
        GameObject go = Instantiate(dropdownPrefab);
        go.transform.position = spawnPoint.position;
        go.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
        go.layer = foodIndex;
        go.AddComponent<CircleCollider2D>();
        go.GetComponent<Rigidbody2D>().AddForce(direction * FORCE);
    }

    private void CreateBomb(Transform spawnPoint, Vector2 direction)
    {
        GameObject go = Instantiate(dropdownPrefab);
        go.transform.position = spawnPoint.position;
        go.GetComponent<SpriteRenderer>().sprite = bombSprite;
        go.layer = bombIndex;
        go.transform.localScale = bombScale;
        go.AddComponent<CircleCollider2D>();
        go.GetComponent<Rigidbody2D>().AddForce(direction * FORCE);
    }
}
