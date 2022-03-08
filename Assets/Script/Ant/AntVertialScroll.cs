using UnityEngine;
 
public class AntVertialScroll : AntScroll
{
    public int id = 55;
    protected override void Awake()
    {
        horizontal = false;
        vertical = true;
        base.Awake();
    }

    protected override float GetDimension(Vector2 vector)
	{
		return vector.y;
	}

	protected override Vector2 GetVector(float value)
	{
		return new Vector2(0, -value);
	}

    protected override float GetPos(Vector2 vector)
    {
        return -vector.y;
    }
}
