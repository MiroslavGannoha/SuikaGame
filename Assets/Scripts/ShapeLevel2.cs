

// INHERITANCE
public class ShapeLevel2 : ShapeBaseController
{
    protected override ShapeTypes shapeType
    {
        get;
        set;
    } = ShapeTypes.ShapeLevel2;

    protected override int worth
    {
        get;
        set;
    } = 20;
}
