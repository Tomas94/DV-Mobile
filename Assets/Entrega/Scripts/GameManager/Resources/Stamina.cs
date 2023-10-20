using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina
{
    int _maxStamina;
    int _currentStamina;

    public Stamina(int maxStamina)
    {
        _maxStamina = maxStamina;
        _currentStamina = _maxStamina;
    }

    public int MaxStamina
    {
        get
        {
            return _maxStamina;
        }
        set
        {
            if (_maxStamina != value)
            {
                _maxStamina = value;
            }
        }
    }

    public void ConsumeStamina()
    {
        _currentStamina = _currentStamina <= 0 ? 0 : _currentStamina--;
    }

    public void RechargeStamina()
    {
        _currentStamina = _currentStamina >= _maxStamina ? _maxStamina : _currentStamina++;
    }

    public void RefillStamina()
    {
        _currentStamina = _maxStamina;
    }
}