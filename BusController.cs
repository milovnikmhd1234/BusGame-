using UnityEngine;

public class BusController : MonoBehaviour {
    public float motorForce = 1500f;
    public float breakForce = 3000f;
    public float maxSteerAngle = 35f;

    public WheelCollider frontLeft, frontRight, backLeft, backRight;

    void FixedUpdate() {
        // Ovládání z klávesnice (WSAD)
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // Pohon zadních kol
        backLeft.motorTorque = v * motorForce;
        backRight.motorTorque = v * motorForce;

        // Zatáčení předních kol
        frontLeft.steerAngle = h * maxSteerAngle;
        frontRight.steerAngle = h * maxSteerAngle;

        // Brzda (Mezerník)
        if (Input.GetKey(KeyCode.Space)) {
            ApplyBrake();
        } else {
            ReleaseBrake();
        }
    }

    void ApplyBrake() {
        backLeft.brakeTorque = breakForce;
        backRight.brakeTorque = breakForce;
    }

    void ReleaseBrake() {
        backLeft.brakeTorque = 0;
        backRight.brakeTorque = 0;
    }
}
