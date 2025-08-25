using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public HingeJoint2D leftFlipper;
    public HingeJoint2D rightFlipper;

    public float motorSpeed = 1000f; // Скорость мотора
    public float motorTorque = 10000f; // Момент мотора

    private JointMotor2D leftMotor;
    private JointMotor2D rightMotor;

    void Start()
    {
        // Инициализация моторов
        leftMotor = leftFlipper.motor;
        rightMotor = rightFlipper.motor;
    }

    void Update()
    {
        // Нажатие A — активировать левый флиппер
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateFlipper(leftFlipper, true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ActivateFlipper(leftFlipper, false);
        }

        // Нажатие D — активировать правый флиппер
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
            // Включаем мотор с нужной скоростью
            motor.motorSpeed = motorSpeed * (flipper == leftFlipper ? 1 : -1); // направление зависит от стороны
            motor.maxMotorTorque = motorTorque;
            flipper.motor = motor;
        }
        else
        {
            // Отключаем мотор (возвращение в исходное положение)
            motor.motorSpeed = 0;
            motor.maxMotorTorque = 0;
            flipper.motor = motor;
            flipper.useMotor = false; // отключить мотор после возврата
        }
    }
}