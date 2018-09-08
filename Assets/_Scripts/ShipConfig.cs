[System.Serializable]
public struct ShipConfig
{
    public float maxVelocity;
    public float velocityAcceleration;

    public float xMaxRotationSpeed;
    public float yMaxRotationSpeed;
    public float rotationAcceleration;  // TODO implement for less-arcade-more-real feeling?
}