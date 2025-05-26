// Используем библиотеку движка Unity
using UnityEngine;

// Создаем класс PlayerController по шаблону MonoBehaviour
public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Создаем переменную скорости типа float (дробное число)
    private float direction; // Создаем переменную направления типа int (целое число)
    public float jumpForce = 8f;
    private Rigidbody2D rigidbody2D;

    private bool isGrounded = false;

    void Start() // Создаем метод Start (вызывается при старте игры)
    {
        // Получаем компонент Rigidbody2D из того объекта, на котором наложен скрипт
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() // Создаем метод Update (вызывается при каждом обновлении кадра)
    {
        direction = Input.GetAxis("Horizontal"); // Направление равно текущей нажатой клавише на оси
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate() // Создаем метод FixedUpdate (вызывается с фиксированной частотой)
    {
        // Устанавливаем векторную скорость для объекта
        rigidbody2D.linearVelocity = new Vector2(speed * direction, rigidbody2D.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
