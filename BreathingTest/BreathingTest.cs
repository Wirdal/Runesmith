using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class BreathingTest : Game
{
    static Unit tempUnit;

    public BreathingTest()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        GameManagers.s_contentManager = Content;
        GameManagers.s_graphics = new GraphicsDeviceManager(this);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
        // Sprite batch can only be initalized after graphics device, which is from base initilization 
        GameManagers.s_spriteBatch = new SpriteBatch(GameManagers.s_graphics.GraphicsDevice);
        tempUnit = new Unit(64, 64, "");
        tempUnit.Visible = true;
        tempUnit.m_texture = GameManagers.s_contentManager.Load<Texture2D>("Sprites\\player\\base\\octopode_1");
        tempUnit.m_spriteBatch = GameManagers.s_spriteBatch;
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
        GameManagers.s_graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
        GameManagers.s_spriteBatch.Begin();
        Unit.DrawUnits(gameTime);
        GameManagers.s_spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
