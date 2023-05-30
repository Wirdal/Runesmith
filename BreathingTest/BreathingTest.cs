using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class BreathingTest : Game
{
    public static GraphicsDeviceManager s_graphics;
    public static SpriteBatch s_spriteBatch;
    public static ContentManager s_contentManager;

    static Unit tempUnit;

    public BreathingTest()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        s_graphics = new GraphicsDeviceManager(this);
        s_contentManager = Content;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        tempUnit = new Unit(64, 64, "");
        tempUnit.Visible = true;
        tempUnit.m_texture = s_contentManager.Load<Texture2D>("Sprites\\player\\base\\octopode_1");
        s_spriteBatch = new SpriteBatch(s_graphics.GraphicsDevice);
        tempUnit.m_spriteBatch = s_spriteBatch;
        base.Initialize();
    }

    protected override void LoadContent()
    {

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        s_graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        s_spriteBatch.Begin();
        Unit.DrawUnits(gameTime);
        s_spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
