using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class SingleFlipper : MonoBehaviour
{
    public float motorSpeed = 1000f;  // —корость вращени€ мотора
    public float motorMaxTorque = 10000f;  // ћаксимальный крут€щий момент мотора

    private HingeJoint2D hingeJoint;
    private JointMotor2D motor;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();

        // »нициализируем мотор с нулевой скоростью и максимальным крут€щим моментом
        motor = hingeJoint.motor;
        motor.maxMotorTorque = motorMaxTorque;
        motor.motorSpeed = 0f;
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            motor.motorSpeed = motorSpeed;  // ¬ращаем в одну сторону
        }
        else if (Input.GetKey(KeyCode.A))
        {
            motor.motorSpeed = -motorSpeed; // ¬ращаем в другую сторону
        }
        else
        {
            motor.motorSpeed = 0f;           // ќстанавливаем мотор, если нет нажати€
        }

        hingeJoint.motor = motor;
    }
}