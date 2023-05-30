using System;
using System.Windows.Forms;

public class Controller
{
    //Every properties, variables and method that behind the game logic
    public float gravity
    { get; set; }
    public float drag
    { get; set; }
    public int score
    { get; set; }

    public int defaultDisplayLocationX
    { get; set; }
    public int defaultDisplayLocationY
    { get; set; }

    public bool isCollided
    { get; set; }
    public bool isGameOver
    { get; set; }
    public bool previousIsGameOver
    { get; set; }
    public bool isGameStarted
    { get; set; }
    public bool isScored
    { get; set; }

    public bool toggleDevMode
    { get; set; }

    public int selectorMenuLargeSize
    { get; set; }
    public int selectorMenuSmallSize
    { get; set; }
    public Color defaultPlayerColor
    { get; set; }

    public Controller(float gravity, float drag, int defDisplayX, int defDisplayY)
    {
        this.gravity = gravity;
        this.drag = drag;

        this.score = 0;

        this.defaultDisplayLocationX = defDisplayX;
        this.defaultDisplayLocationY = defDisplayY;

        this.isGameOver = false;
        this.previousIsGameOver = false;
        this.isGameStarted = false;
        this.isScored = false;
        this.toggleDevMode = false;

    }

    public void CheckCollision(Player player, Pipe pipe, PictureBox ground)
    {
        previousIsGameOver = isGameOver;

        if (isGameOver == false)
        {
            if (player.player.Bounds.IntersectsWith(pipe.pipeTop.Bounds) ||
                player.player.Bounds.IntersectsWith(pipe.pipeBot.Bounds) ||
                player.player.Bounds.IntersectsWith(ground.Bounds) ||
                player.player.Location.Y < new Point(0, -100).Y)
            {
                isGameOver = true;
            }
            else
            {
                isGameOver = false;
            }
        }
    }

    public void CheckIfScored(Pipe pipe, Player player, Label display)
    {
        bool previousIsScored = isScored;

        Rectangle scoreBox = pipe.gap.Bounds;

        if (player.player.Bounds.IntersectsWith(scoreBox))
        {
            this.isScored = true;
        }
        else
        {
            this.isScored = false;
        }

        if (this.isScored != previousIsScored && previousIsScored && player.playerHorizontalSpeed == 0) //Reward
        {
            score++;
            pipe.pipeSpeed += 0.1f;
            UpdateDisplayScoreText(display);
        }
    }

    public void GameOver(Label display, string gameOverText, Pipe pipe)
    {
        display.Text = gameOverText;
        UpdateDisplayLocation(display);

        pipe.pipeSpeed = 0;
    }

    public void UpdateDisplayScoreText(Label display)
    {
        display.Text = this.score.ToString();
        UpdateDisplayLocation(display);
    }

    public void UpdateDisplayLocation(Label display)
    {
        display.Location = new Point(defaultDisplayLocationX - display.Size.Width / 2, defaultDisplayLocationY); ;
    }

    public void InitColorSelectorMenu(int smallSize, int largeSize, Color colorLeft, Color colorMiddle, Color colorRight, PictureBox selectLeft, PictureBox selectMiddle, PictureBox selectRight, int windowWidth, int windowHeight)
    {
        int offset = smallSize / 2;

        this.selectorMenuLargeSize = largeSize;
        this.selectorMenuSmallSize = smallSize;

        selectLeft.Size = new Size(largeSize, largeSize);
        selectLeft.Location = new Point(windowWidth / 4 - offset, windowHeight / 2 - offset);
        selectLeft.BackColor = colorLeft;
        this.defaultPlayerColor = colorLeft;

        selectMiddle.Size = new Size(smallSize, smallSize);
        selectMiddle.Location = new Point(2 * windowWidth / 4 - offset, windowHeight / 2 - offset);
        selectMiddle.BackColor = colorMiddle;

        selectRight.Size = new Size(smallSize, smallSize);
        selectRight.Location = new Point(3 * windowWidth / 4 - offset, windowHeight / 2 - offset);
        selectRight.BackColor = colorRight;

    }

    public void ColorSelectorHighlightControll(PictureBox selector, PictureBox selectLeft, PictureBox selectMiddle, PictureBox selectRight, Player player)
    {
        if (selector == selectLeft && selector.Width != selectorMenuLargeSize)
        {
            selectorMenuSmallSize = selector.Width;
            selectMiddle.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selectRight.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selector.Size = new Size(selectorMenuLargeSize, selectorMenuLargeSize);

            player.player.BackColor = selectLeft.BackColor;
        }
        else if (selector == selectMiddle && selector.Width != selectorMenuLargeSize)
        {
            selectorMenuSmallSize = selector.Width;
            selectLeft.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selectRight.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selector.Size = new Size(selectorMenuLargeSize, selectorMenuLargeSize);

            player.player.BackColor = selectMiddle.BackColor;
        }
        else if (selector == selectRight && selector.Width != selectorMenuLargeSize)
        {
            selectorMenuSmallSize = selector.Width;
            selectMiddle.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selectLeft.Size = new Size(selectorMenuSmallSize, selectorMenuSmallSize);
            selector.Size = new Size(selectorMenuLargeSize, selectorMenuLargeSize);

            player.player.BackColor = selectRight.BackColor;
        }

    }

    public void TerminateSelectorMenu(PictureBox selectLeft, PictureBox selectMiddle, PictureBox selectRight)
    { 
        selectLeft.Dispose();
        selectMiddle.Dispose();
        selectRight.Dispose();
    }
}
