using UnityEngine;

public class MyVector2
{
    private float _x, _y;

    public float X => _x;
    public float Y => _y;
    public float Magnitude => Mathf.Sqrt(SqrMagnitude);
    public float SqrMagnitude => ((_x * _x) + (_y * _y));
    
    public MyVector2(float newX, float newY)
    {
        _x = newX;
        _y = newY;
    }

    public MyVector2 Normalize()
    {
        float magn = Magnitude;
        float x = _x / magn;
        float y = _y / magn;
        return new MyVector2(x, y);
    }

    public static MyVector2 operator + (MyVector2 l, MyVector2 r)
    {
        return new MyVector2(l.X + r.X, l.Y + r.Y);
    }
}
