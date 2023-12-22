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

    public abstract int worth
    {
        get;
        set;
    }

    [SerializeField]
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
        if (collision.gameObject.CompareTag("Shape") && controller && shapeType == controller.shapeType)
        {
            Debug.Log("Shape collided with the same level shape");
            Debug.Log(controller.shapeType);
            if (!controller.isUpgrading)
            {
                mergeShapes();
            }
            Destroy(gameObject);
        }
    }

    private void mergeShapes()
    {
        isUpgrading = true;
        var mergedShape = GameManager.Instance.SpawnShape(upperShape, transform.position);
        mergedShape.GetComponent<Rigidbody>().isKinematic = false;
        mergedShape.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
        GameManager.Instance.AddPoints(worth);
    }
}
