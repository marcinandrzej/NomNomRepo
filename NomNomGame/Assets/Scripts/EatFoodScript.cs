using UnityEngine;

public class EatFoodScript : MonoBehaviour
{
    public GameObject bombEffect;

    public LayerMask foodLayer;
    public LayerMask bombLayer;

    private int layerIndex;
    private int layerIndex2;

    void Start ()
    {
        layerIndex = (int)Mathf.Log(foodLayer.value, 2);
        layerIndex2 = (int)Mathf.Log(bombLayer.value, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance.IsEnd())
            return;

        if (other.gameObject.layer == layerIndex)
        {
            Destroy(other.gameObject);
            GameManager.instance.AddPoints();
        }
        else if(other.gameObject.layer == layerIndex2)
        {
            GameObject ef = Instantiate(bombEffect);
            ef.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, -2.0f);
            Destroy(ef, 1.0f);
            Destroy(other.gameObject);
            GameManager.instance.EndGame();
        }
    }
}
