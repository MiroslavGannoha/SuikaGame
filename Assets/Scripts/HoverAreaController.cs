using UnityEngine;

public class HoverAreaController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePos.z = 0;
        worldMousePos.y = 6f;
        gameManager.SetActiveShapePosition(worldMousePos);
    }

    void OnMouseUp()
    {
        gameManager.DropShape();
    }

    // void OnMouseEnter()
    // {
    //     Debug.Log("Mouse is over GameObject.");
    // }
}
