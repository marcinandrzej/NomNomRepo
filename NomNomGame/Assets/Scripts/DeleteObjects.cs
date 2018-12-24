using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    public LayerMask foodLayer;
    public LayerMask bombLayer;
    private int layerIndex;
    private int layerIndex2;

    void Start()
    {
        layerIndex = (int)Mathf.Log(foodLayer.value, 2);
        layerIndex2 = (int)Mathf.Log(bombLayer.value, 2);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == layerIndex2)
            Destroy(other.gameObject);
        else if (other.gameObject.layer == layerIndex)
        {
            Destroy(other.gameObject);
            GameManager.instance.EndGame();
        }
    }
}
