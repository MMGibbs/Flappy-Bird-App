namespace Flappy_Bird_App
{
    public partial class Form1 : Form
    {

        //https://youtu.be/yUCCv-sFUDQ?t=1370
        int pipeSpeed = 8;
        int gravity = 7;
        int score = 0;

        public Form1()
        {
            InitializeComponent();

            gameOver.Visible=false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score.ToString();

            if(pipeBottom.Left < -90)
            {
                pipeBottom.Left = 750;
                score++;
            }
            
            if(pipeTop.Left < -80)
            {
                pipeTop.Left = 631;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {
                endGame();
            }

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space) 
            {
                gravity = -7;
            }

        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) 
            {
                gravity = 7;
            }
        }

        private void endGame()
        {
            gameTimer.Enabled = false;
            gameOver.Visible=true;
        }

    }
}