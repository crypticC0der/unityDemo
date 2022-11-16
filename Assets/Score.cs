
using TMPro;
public static class Score{
	public static int score=0;
	public static TextMeshProUGUI scoreboard;

	public static void Increase(){
		score++;
		scoreboard.text="Score: "+score.ToString();
	}
}
