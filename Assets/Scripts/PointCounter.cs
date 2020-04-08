using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum NumPlayer
{
    PLAYER_ONE, PLAYER_TWO
};

public class PointCounter : MonoBehaviour
{
    private Transform rect;
    private Text text;
    private int player_one_points;
    private int player_two_points;

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponent<Text>();
        this.rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = this.player_one_points
            + "   "
            + this.player_two_points;
    }

    public void AddPoint(NumPlayer player)
    {
        if (player == NumPlayer.PLAYER_ONE)
            this.player_one_points += 1;
        else if (player == NumPlayer.PLAYER_TWO)
            this.player_two_points += 1;

        StartCoroutine(this.ScalePoints());
    }

    private IEnumerator ScalePoints()
    {
        float time_elapsed = 0f;
        float total_time = 0.2f;
        Vector3 old_scale = this.rect.localScale;

        while (time_elapsed < total_time)
        {
            float current_scale = Mathf.Clamp(
                total_time / time_elapsed, 0f, 2f
            );
            this.rect.localScale = new Vector3(current_scale, current_scale, 1);
            time_elapsed += Time.deltaTime;

            yield return null;
        }

        this.rect.localScale = old_scale;
    }
}
