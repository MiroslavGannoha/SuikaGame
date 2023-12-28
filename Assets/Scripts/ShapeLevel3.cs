

// INHERITANCE
public class ShapeLevel3 : ShapeBaseController
{
    protected override ShapeTypes shapeType
    {
        get;
        set;
    } = ShapeTypes.ShapeLevel3;

    protected override int worth
    {
        get;
        set;
    } = 30;
}
