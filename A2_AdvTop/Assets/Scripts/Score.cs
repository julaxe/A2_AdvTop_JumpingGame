using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI textT;

    [SerializeField]
    private Player player;

    void Start()
    {
        textT = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        textT.text = "SCORE: " + player.Score;
    }
}
