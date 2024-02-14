using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonsAbilities : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    public void ShowPanel()
    {
        Panel.SetActive(true);
    }
}
