using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayText;
    private string _input = string.Empty;
    private string _operand1 = string.Empty;
    private string _operand2 = string.Empty;
    private char _operation;
    private double _result = 0.0;
    
    
    void Start()
    {
        _displayText.text = "";
    }
    

    public void DigitClick(int digit)
    {
        ClearDisplay();
        _input += digit.ToString();
        UpdateDisplay();
    }
    
    public void DotClick()
    {
        ClearDisplay();
        _input += ".";
        UpdateDisplay();
    }
    
    public void PlusClick()
    {
        _operand1 = _input;
        _operation = '+';
        _input = String.Empty;
        UpdateDisplay();
    }
    
    public void MinusClick()
    {
        _operand1 = _input;
        _operation = '-';
        _input = String.Empty;
        UpdateDisplay();
    }
    
    public void MultiplyClick()
    {
        _operand1 = _input;
        _operation = '*';
        _input = String.Empty;
        UpdateDisplay();
    }
    
    public void DivideClick()
    {
        _operand1 = _input;
        _operation = '/';
        _input = String.Empty;
        UpdateDisplay();
    }

    public void ClrClick()
    {
        ClearDisplay();
        ClearMemory();
    }
    
    
    public void EqualsClick()
    {
        _operand2 = _input;
        double num1, num2;
        double.TryParse(_operand1, out num1);
        double.TryParse(_operand2, out num2);
        
        ClearDisplay();
        ClearMemory();
        
        if (_operation == '+')
        {
            _result = num1 + num2;
            DisplayResult();
        }
        
        else if (_operation == '-')
        {
            _result = num1 - num2;
            DisplayResult();
        }
        
        else if (_operation == '*')
        {
            _result = num1 * num2;
            DisplayResult();
        }
        
        else if (_operation == '/')
        {
            if (num2 != 0)
            {
                _result = num1 / num2;
                DisplayResult();
            }

            else
            {
                _displayText.text = "Error Div/Zero!";
            }
            
        }
        
    }

    private void ClearMemory()
    {
        _input = string.Empty;
        _operand1 = string.Empty;
        _operand2 = string.Empty;
    }

    private void ClearDisplay()
    {
        _displayText.text = "";
    }
    private void UpdateDisplay()
    {
        _displayText.text += _input;
    }

    private void DisplayResult()
    {
        _displayText.text = _result.ToString();
    }


}
