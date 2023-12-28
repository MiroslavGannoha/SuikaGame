using UnityEngine;

public class LimiterController : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision");
        if (col.gameObject.CompareTag("Shape"))
        {
        Debug.Log("Shape");
            var controller = col.gameObject.GetComponent<ShapeBaseController>();
            if (controller.IsInGame)
            {
                GameManager.Instance.EndGame();
            } else {
                controller.IsInGame = true;
            }
        }
    }
}
