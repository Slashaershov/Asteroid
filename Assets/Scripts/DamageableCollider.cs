using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;using System;

public class DamageableCollider : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private int _damageValue;
    private DamageDealer _dealer;
    private Damageable _damageable;

    public void Awake()
    {
        _dealer = new DamageDealer(_damageValue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsInLayerMask(other.gameObject.layer, _targetLayers))
        {
            _dealer.Damage(other.GetComponent<DamageableCollider>().Damage);
        }
    }

    public void Damage(Damage dmg)
    {

    }

    private bool IsInLayerMask(int layer, LayerMask mask) //TODO: do extention
    {
        return (mask.value & (1 << layer)) != 0;
    }

}



public class DamageService
{
    public void GetDamage()
    {

    }
}

public interface IDamageService
{
    public void Damage(DamageableCollider col1, DamageableCollider col2);
}

public class DamageDealer
{
    private int _damageValue;
    public int DamageValue => _damageValue;
    public DamageDealer(int damageValue)
    {
        _damageValue = damageValue;
    }

    public void Damage(Action<Damage> damageAction)
    {
        var dmg = new Damage(_damageValue);
        damageAction?.Invoke(dmg);
    }

    public void OnDamage()
    {

    }
}

public interface IDamageable
{
    public bool TryGetDamage(Damage dmg);
}

public class Damage
{
    public int Value;
    public Damage(int value)
    {
        Value = value;
    }
}

public class Damageable
{
    private int _maxHp = 5;
    private Stats _stats;

    public Damageable(int maxHp)
    {
        _maxHp = maxHp;
        _stats = new Stats(maxHp);
    }

    public bool TryGetDamage(Damage dmg)
    {
        return _stats.TryGetDamage(dmg.Value);
    }

    private void OnCharacterDie()
    {
       // _onCharacterDie?.Invoke();
       // gameObject.SetActive(false);
    }
}


public class Stats
{
    private const int MIN_HP = 0;
    private int _hp;
    private int _maxHp;

    private Action _onDie;

    public Stats(int maxHp, Action onDie = null)
    {
        _maxHp = maxHp;
        _hp = maxHp;
        _onDie = onDie;
    }

    public void Reset()
    {
        _hp = _maxHp;
    }

    public bool TryGetDamage(int value)
    {
        _hp = Mathf.Clamp(_hp - value, MIN_HP, _maxHp);
        if (_hp == MIN_HP)
        {
            _onDie?.Invoke();
        }
        return true;
    }
}