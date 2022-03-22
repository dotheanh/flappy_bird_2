using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public SpriteRenderer numberDigit1;
    public SpriteRenderer numberDigit2;

    public Sprite number0;
    public Sprite number1;
    public Sprite number2;
    public Sprite number3;
    public Sprite number4;
    public Sprite number5;
    public Sprite number6;
    public Sprite number7;
    public Sprite number8;
    public Sprite number9;

    public void SetScore(int score)
    {
        this.SetValue(score/10, numberDigit1);
        this.SetValue(score%10, numberDigit2);
    }

    private void SetValue(int value, SpriteRenderer numberDigit)
    {
        switch(value) 
        {
        case 0:
            numberDigit.sprite = number0; 
            break;
        case 1:
            numberDigit.sprite = number1; 
            break;
        case 2:
            numberDigit.sprite = number2; 
            break;
        case 3:
            numberDigit.sprite = number3; 
            break;
        case 4:
            numberDigit.sprite = number4; 
            break;
        case 5:
            numberDigit.sprite = number5; 
            break;
        case 6:
            numberDigit.sprite = number6; 
            break;
        case 7:
            numberDigit.sprite = number7; 
            break;
        case 8:
            numberDigit.sprite = number8; 
            break;
        case 9:
            numberDigit.sprite = number9; 
            break;
        default:
            numberDigit.sprite = number0; 
            break;
        }
    }
}
