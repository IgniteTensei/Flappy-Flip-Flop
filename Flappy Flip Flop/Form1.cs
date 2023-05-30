using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Flappy_Flip_Flop
{
    public partial class mainWindow : Form
    {
        float globalDeltaTime = 0.0f;
        //float globalSpawnTimer = 0.0f;

        Controller gameController;
        Utilities gameUtilities;

        //List<Pipe> pipeList;

        Player player;
        Pipe defaultPipes;

        public mainWindow()
        {
            InitializeComponent();
            gameController = new Controller(4.0f, 400.0f, Width / 2, 55);
            gameUtilities = new Utilities();

        }
        private void mainWindow_Load(object sender, EventArgs e)
        {
            gameController.InitColorSelectorMenu(70, 100, Color.Gold, Color.Green, Color.Blue, selectLeft, selectMiddle, selectRight, Width, Height);

            gameController.UpdateDisplayLocation(lblDisplay);

            player = new Player(
                Height / 2 - 50 * 2, //Starting pos of the player
                185, //Starting position from the left wall
                50, //Size of the base rectangle of the player
                gameController.defaultPlayerColor); //Color of the player

            defaultPipes = new Pipe(

                10, //Speed of the pipes
                150, //Size of the gap
                gameUtilities.GetRandomGapHeight(Height / 3, Height - (Height / 3)), //Random gap position
                60, //Width of the pipes
                Width,  //Width of the window
                Height, //Height of the window
                100, //Offset X of the window for the pipes
                100, //Offset Y of the window for the pipes
                Color.Black);

            defaultPipes.BuildPipes();

            SpawnPlayer(player);
            PlayerSetStartPoint();
            SpawnPipes(defaultPipes);
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            UpdateDeltaTime();
            //UpdateSpawnTimer();

            player.PlayerPhysics(gameController.gravity, globalDeltaTime);
            player.player.Left += Convert.ToInt32(player.playerHorizontalSpeed);

            defaultPipes.UpdateMovePipe(Width);
            if (defaultPipes.pipeTop.Left < -80)
            {
                defaultPipes.BuildPipes(gameUtilities.GetRandomGapHeight(Height / 3, Height - (Height / 3)));
            }

            gameController.CheckCollision(player, defaultPipes, ground);
            if (gameController.isGameOver)
            {
                gameController.GameOver(lblDisplay, "It's Joever!", defaultPipes);
                PlayerDieAnimation();
            }

            gameController.CheckIfScored(defaultPipes, player, lblDisplay);


            if (player.player.Top > Height + 200)
            {
                gameTimer.Stop();
            }

            PlayerStartAnimation();
        }

        private void keyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                player.PlayerJump(40);
                SetDeltaTime(Convert.ToInt32(gameController.drag));

            }

            if (e.KeyCode == Keys.Enter)
            {
                if (!gameController.isGameStarted)
                {
                    gameTimer.Enabled = true;

                    gameController.UpdateDisplayScoreText(lblDisplay);
                    gameController.isGameStarted = true;
                }

                gameController.TerminateSelectorMenu(selectLeft, selectMiddle, selectRight);
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Q)
            {             
                gameController.toggleDevMode = !gameController.toggleDevMode;

                if (gameController.toggleDevMode)
                {
                    defaultPipes.gap.BackColor = Color.Red;
                }
                else
                {
                    defaultPipes.gap.BackColor = Color.Transparent;
                }
            }

            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
            }

        }

        private void UpdateDeltaTime()
        {           
            globalDeltaTime += gameTimer.Interval;

        }
        private void SetDeltaTime(int deltaTime)
        {
            globalDeltaTime = deltaTime;
        }
        private void ResetDeltaTime()
        {
            globalDeltaTime = 0.0f;
        }


        private void PlayerDieAnimation()
        {
            if (gameController.isGameOver != gameController.previousIsGameOver && gameController.previousIsGameOver == false)
            {
                player.PlayerCollisionaCounterForce(2);
                player.PlayerJump(40);
                SetDeltaTime(400);
            }
        }
        private void PlayerStartAnimation()
        {
            if (gameController.isGameStarted &&
                !gameController.isGameOver &&
                player.player.Location.X < player.startingPlayerLocation.X)
            {
                player.playerHorizontalSpeed = 15;
            }
            else if (!gameController.isGameOver)
            {
                player.playerHorizontalSpeed = 0;
            }
        }
        private void PlayerSetStartPoint()
        {
            player.player.Left = -100;
        }

        private void SpawnPlayer(Player player)
        {
            Controls.Add(player.player);
        }
        private void SpawnPipes(Pipe pipe)
        {
            //Add to list

            Controls.Add(pipe.pipeTop);
            Controls.Add(pipe.pipeBot);
            Controls.Add(pipe.gap);
        }

        /*private void UpdateSpawnTimer(int spawnTimeValue)
        {
            float spawnTimer = 0f;
            globalSpawnTimer += gameTimer.Interval;
            spawnTimer = globalSpawnTimer / 1000;

            if (Convert.ToInt32(spawnTimer) > spawnTimeValue)
            {
                SpawnPipes(defaultPipes);
            }
        }*/

        //DespawnPipes -> remove from list, from controls

        //SpawnController

        private void selectLeft_Click(object sender, EventArgs e)
        {
            gameController.ColorSelectorHighlightControll(selectLeft, selectLeft, selectMiddle, selectRight, player);

        }

        private void selectMiddle_Click(object sender, EventArgs e)
        {
            gameController.ColorSelectorHighlightControll(selectMiddle, selectLeft, selectMiddle, selectRight, player);
        }

        private void selectRight_Click(object sender, EventArgs e)
        {
            gameController.ColorSelectorHighlightControll(selectRight, selectLeft, selectMiddle, selectRight, player);
        }

        

    }
}