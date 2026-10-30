using UnityEngine;
using UnityEngine.UI;

public class Ui_Show : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Slider _healthBar;
    
    void Start()
    {
        _ball.OnTouchingGround += UpdateUi;
        _healthBar.maxValue = _ball.MaxHealth;
        _healthBar.value = _ball.MaxHealth;
    }

    void UpdateUi(int damage)
    {
        // Need to subtract damage because currentHealth is not updated
        _healthBar.value = _ball.CurrentHealth - damage;
    }
}
