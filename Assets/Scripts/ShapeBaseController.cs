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

// ABSTRACTION
public abstract class ShapeBaseController : MonoBehaviour
{

    public bool IsInGame = false;

    [SerializeField]
    private ParticleSystem PopVFX;

    // ABSTRACTION
    protected abstract ShapeTypes shapeType
    {
        get;
        set;
    }
    // ABSTRACTION
    protected abstract int worth
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
            if (!controller.isUpgrading && !isUpgrading)
            {
                isUpgrading = true;
                controller.isUpgrading = true;
                mergeShapes(collision.gameObject.transform.position);
            }
            if (isUpgrading)
            {
                Destroy(gameObject);
            }
        }
    }

    private void mergeShapes(Vector3 targetPosition)
    {
        var mergedShape = GameManager.Instance.SpawnShape(upperShape, (transform.position + targetPosition) / 2);
        mergedShape.GetComponent<Rigidbody>().isKinematic = false;
        mergedShape.GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
        AudioManager.Instance.PopSound.Play();
        PlayPopVFX();
        mergedShape.GetComponent<ShapeBaseController>().PlayPopVFX();
        mergedShape.GetComponent<ShapeBaseController>().IsInGame = true;
        GameManager.Instance.AddPoints(worth);
    }

    public void PlayPopVFX()
    {
        PopVFX.Play();
    }
}
