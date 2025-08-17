using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public HingeJoint2D leftFlipper;
    public HingeJoint2D rightFlipper;

    public float motorSpeed = 1000f; // �������� ������
    public float motorTorque = 10000f; // ������ ������

    private JointMotor2D leftMotor;
    private JointMotor2D rightMotor;

    void Start()
    {
        // ������������� �������
        leftMotor = leftFlipper.motor;
        rightMotor = rightFlipper.motor;
    }

    void Update()
    {
        // ������� A � ������������ ����� �������
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateFlipper(leftFlipper, true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ActivateFlipper(leftFlipper, false);
        }

        // ������� D � ������������ ������ �������
        if (Input.GetKeyDown(KeyCode.D))
        {
            ActivateFlipper(rightFlipper, true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ActivateFlipper(rightFlipper, false);
        }
    }

    void ActivateFlipper(HingeJoint2D flipper, bool activate)
    {
        flipper.useMotor = activate;
        JointMotor2D motor = flipper.motor;

        if (activate)
        {
            // �������� ����� � ������ ���������
            motor.motorSpeed = motorSpeed * (flipper == leftFlipper ? 1 : -1); // ����������� ������� �� �������
            motor.maxMotorTorque = motorTorque;
            flipper.motor = motor;
        }
        else
        {
            // ��������� ����� (����������� � �������� ���������)
            motor.motorSpeed = 0;
            motor.maxMotorTorque = 0;
            flipper.motor = motor;
            flipper.useMotor = false; // ��������� ����� ����� ��������
        }
    }
}