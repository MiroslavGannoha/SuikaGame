using UnityEngine;

public class LimiterController : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Shape"))
        {
            // POLYMORPHISM
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
