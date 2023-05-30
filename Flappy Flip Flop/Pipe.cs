using Flappy_Flip_Flop;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

public class Pipe
{
    public float pipeSpeed
    { get; set; }

	public PictureBox pipeTop
    { get; set; }
	public PictureBox pipeBot
    { get; set; }
    public PictureBox gap
    { get; set; }

    public int gapPosition
    { get; set; }

    public int gapSize
    { get; set; }
    public int pipeWidth
    { get; set; }
    public Size window
    { get; set; }
    public Size windowMargin
    { get; set; }
    public Color pipeColor
    { get; set; }

    public Rectangle hitBoxOfPipeTop
    { get; set; }
    public Rectangle hitBoxOfPipeBot
    { get; set; }
    public Rectangle hitBoxGap
    { get; set; }


    public Pipe(float speed, int gapSize, int gapPosition, int pipeWidth, int windowWidth, int windowHeight, int windowMarginX, int windowMarginY, Color pipeColor)
    {
        //Building of the pipes and the gap between.
        this.pipeTop = new PictureBox();
        this.pipeBot = new PictureBox();
        this.gap = new PictureBox();

        this.pipeSpeed = speed;

        this.gapSize = gapSize;
        this.gapPosition = gapPosition;
        this.pipeWidth = pipeWidth;      
        this.window = new Size(windowWidth, windowHeight);
        this.windowMargin = new Size(windowMarginX, windowMarginY);
        this.pipeColor = pipeColor;
    }

    public void BuildPipes()
    {
        this.pipeTop.Location = new Point(this.window.Width + this.windowMargin.Width, -this.windowMargin.Height);
        this.pipeTop.Size = new Size(this.pipeWidth, this.gapPosition - (this.gapSize / 2));
        this.pipeTop.BackColor = pipeColor;

        this.pipeBot.Location = new Point(this.window.Width + this.windowMargin.Width, this.gapPosition + (this.gapSize / 2));
        this.pipeBot.Size = new Size(this.pipeWidth, this.window.Width + this.windowMargin.Width);
        this.pipeBot.BackColor = this.pipeColor;

        this.hitBoxGap = new Rectangle(
        this.pipeTop.Location.X + this.pipeTop.Width / 2,
        this.pipeTop.Height + this.pipeTop.Location.Y,
        1,
        this.pipeBot.Location.Y - (this.pipeTop.Height + this.pipeTop.Location.Y));

        this.gap.Bounds = this.hitBoxGap;
    }

    public void BuildPipes(int gapPosition)
    {
        this.pipeTop.Location = new Point(this.window.Width + this.windowMargin.Width, -this.windowMargin.Height);
        this.pipeTop.Size = new Size(this.pipeWidth, gapPosition - (this.gapSize / 2));
        this.pipeTop.BackColor = pipeColor;

        this.pipeBot.Location = new Point(this.window.Width + this.windowMargin.Width, gapPosition + (this.gapSize / 2));
        this.pipeBot.Size = new Size(this.pipeWidth, this.window.Width + this.windowMargin.Width);
        this.pipeBot.BackColor = this.pipeColor;

        this.hitBoxGap = new Rectangle(
        this.pipeTop.Location.X + this.pipeTop.Width / 2,
        this.pipeTop.Height + this.pipeTop.Location.Y,
        1,
        this.pipeBot.Location.Y - (this.pipeTop.Height + this.pipeTop.Location.Y));

        this.gap.Bounds = this.hitBoxGap;

    }

    public void UpdateMovePipe(int mainWindowWidth)
    {
        this.pipeTop.Left -= Convert.ToInt32(this.pipeSpeed);
        this.pipeBot.Left -= Convert.ToInt32(this.pipeSpeed);
        this.gap.Left -= Convert.ToInt32(this.pipeSpeed);

        if (this.pipeTop.Left < -100)
        {
            this.pipeTop.Left = mainWindowWidth + 100;
            this.pipeBot.Left = mainWindowWidth + 100;
            this.gap.Left = mainWindowWidth + this.pipeTop.Width/2 + 100;

        }

    }
    


}
