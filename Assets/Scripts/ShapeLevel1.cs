

using UnityEngine;

public class ShapeLevel1 : ShapeBaseController
{
    public override ShapeTypes shapeType
    {
        get;
        set;
    } = ShapeTypes.ShapeLevel1;

    [SerializeField]
    private GameObject upperShape;

    private void OnCollisionEnter(Collision collision)
    {
        ShapeBaseController controller = collision.gameObject.GetComponent<ShapeBaseController>();
        if (collision.gameObject.CompareTag("Shape") && controller && shapeType == controller.shapeType)
        {
            Debug.Log("Shape collided with the same level shape");
            Debug.Log(controller.shapeType);
        }
    }

}
