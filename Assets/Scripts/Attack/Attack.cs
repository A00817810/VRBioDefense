using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int damage;
    private GameObject attacker;

    public int Damage { get => damage; set => damage = value; }
    public GameObject Attacker { get => attacker; set => attacker = value; }
}
