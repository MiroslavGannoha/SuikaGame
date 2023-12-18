using UnityEngine;

public enum ShapeTypes
{
    ShapeLevel1,
    ShapeLevel2,
    ShapeLevel3,
    ShapeLevel4,
    ShapeLevel5,
    ShapeLevel6,
    ShapeLevel7,
    ShapeLevel8,
    ShapeLevel9,
}

public abstract class ShapeBaseController : MonoBehaviour
{

    public abstract ShapeTypes shapeType
    {
        get;
        set;
    }

    private GameObject upperShape;

    public bool isUpgrading = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        ShapeBaseController controller = collision.gameObject.GetComponent<ShapeBaseController>();
        if (collision.gameObject.CompareTag("Shape") && controller && shapeType == controller.shapeType && controller.isUpgrading == false)
        {
            Debug.Log("Shape collided with the same level shape");
            Debug.Log(controller.shapeType);
            mergeShapes();

        }
    }

    private void mergeShapes()
    {
        isUpgrading = true;
        GameManager.Instance.SpawnShape(upperShape, transform.position);

    }
}
