

// INHERITANCE
public class ShapeLevel1 : ShapeBaseController
{
    // POLYMORPHISM
    // ENCAPSULATION
    protected override ShapeTypes shapeType
    {
        get;
        set;
    } = ShapeTypes.ShapeLevel1;

    // POLYMORPHISM
    // ENCAPSULATION
    protected override int worth
    {
        get;
        set;
    } = 10;
}
