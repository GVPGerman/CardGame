using UnityEngine;

public abstract class ChareecterCharacteristicsControll : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxDamage;
    private int _currentHealth;
    private int _currentDamage;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentDamage = _maxDamage;
    }
    
    protected virtual void Heal(ChareecterCharacteristicsControll target, int healthPoint)
    {
        IncreaseHealthPoints(target, healthPoint);

        while (target._currentHealth > _maxHealth)
        {
            --target._currentHealth;
        }
    }

    protected virtual void Buff(ChareecterCharacteristicsControll target, int healthPoint, int damage)
    {
        IncreaseHealthPoints(target, healthPoint);
        IncreaseDamage(target, damage);
    }

    protected virtual void DealDamage(ChareecterCharacteristicsControll target, int damage)
    {
        Debug.Log($"{gameObject.name} наносит {damage} цели: {target.gameObject.name.ToString()}");
        target.TakeDamage(damage);
    }

    protected void IncreaseHealthPoints(ChareecterCharacteristicsControll target, int healthPoint)
    {
        Debug.Log($"{gameObject.name} увеличивает хп на {healthPoint} цель: {target.gameObject.name.ToString()}");
        target._currentHealth += healthPoint;
    }

    protected void IncreaseDamage(ChareecterCharacteristicsControll target, int damage)
    {
        Debug.Log($"{gameObject.name} увеличивает хп на {damage} цель: {target.gameObject.name.ToString()}");
        target._currentDamage += damage;
    }

    private void TakeDamage(int damage)
    {
        _maxHealth -= damage;
        Debug.Log($"{gameObject.name} получил {damage} урона. Осталось здоровья: {_maxHealth}");

        if (!IsAlive())
            Die();
    }

    private bool IsAlive()
    {
        return _maxHealth > 0;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
