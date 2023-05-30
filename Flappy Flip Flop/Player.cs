using System;
using System.Diagnostics;
using System.Drawing;

public class Player
{
    public PictureBox player
    { get; set; }

    public Color startingPlayerColor
    { get; set; }
    public Point startingPlayerLocation
    { get; set; } 
    public Size startingPlayerSize
    { get; set; }

    public float playerPosition
    { get; set; }
    public float playerVerticalSpeed
    { get; set; }
    public float playerHorizontalSpeed
    { get; set; }

    public Player(int startHeight, int offsetX, int size, Color playerColor)
    {
        this.player = new PictureBox();

        this.player.Location = new Point(offsetX, startHeight);
        this.startingPlayerLocation = new Point(offsetX, startHeight);

        this.player.Size = new Size(size, size);
        this.startingPlayerSize = new Size(size, size);

        this.player.BackColor =  playerColor;
        this.startingPlayerColor = playerColor;

        this.playerPosition = startHeight;
        this.playerVerticalSpeed = 0;
        this.playerHorizontalSpeed = 0;

    }

    public void PlayerPhysics(float gravity, float deltaTime)
    {
        this.playerVerticalSpeed = this.playerVerticalSpeed + (gravity * deltaTime / 1000);
        this.playerPosition = this.playerPosition + (this.playerVerticalSpeed * deltaTime / 1000);
        this.player.Top = Convert.ToInt32(this.playerPosition);
    }

    public void PlayerJump(float jumpForce)
    {
        this.playerVerticalSpeed = -jumpForce;
    }

    public void PlayerCollisionaCounterForce(int force)
    {
        this.playerHorizontalSpeed = -force;
    }

    public void ResetPlayer()
    {
        this.player.Location = this.startingPlayerLocation;
        this.player.Size = this.startingPlayerSize;
        this.player.BackColor = this.startingPlayerColor;

        this.playerPosition = this.player.Location.Y;
        this.playerVerticalSpeed = 0;
        this.playerHorizontalSpeed = 0;
    }

}
