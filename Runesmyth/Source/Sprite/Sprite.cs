using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

abstract public class Sprite : IDrawable
{
    // Actual sprite texutre
    public Texture2D m_texture;

    //Basic
    int m_height;
    int m_width;
    int m_rotation;
    int m_scale;

    // Location on the screen
    Vector2 m_coordinates = new Vector2(0,0);

    // Breathing
    bool m_breathingEnabled;
    int m_deltaX;
    int m_deltaY;
    int m_maxBreathX;
    int m_maxBreathY;
    bool m_risingX;
    bool m_risingY;

    protected Sprite()
    {
        Visible = false;
    }

    protected Sprite(int width, int height, string textureName)
    {
        m_breathingEnabled = false;
        m_width = width;
        m_height = height;
        //m_texture = Runesmyth.s_contentManager.Load<Texture2D>(textureName);
    }

    // IDrawable
    public event EventHandler<EventArgs> DrawOrderChanged;
    public event EventHandler<EventArgs> VisibleChanged;

    public int DrawOrder { get; set; } = -1;

    public bool Visible { get; set; } = false;

    public SpriteBatch m_spriteBatch { get; set; } = null;

    public void Draw(GameTime gameTime)
    {
        if (m_breathingEnabled)
        {
            DrawInternalBreathing(gameTime);
        } 
        else
        {
            DrawInternal(gameTime);
        }
    }

    // Wrapper for breathing. Stretches sprite and calls draw Internal
    private void DrawInternalBreathing(GameTime gameTime)
    {

    }

    private void DrawInternal(GameTime gameTime)
    {
        m_spriteBatch.Draw(m_texture, m_coordinates, Color.White);
    }
}