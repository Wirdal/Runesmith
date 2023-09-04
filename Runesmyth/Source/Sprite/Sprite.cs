using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
public class Sprite : IDrawable
{
	// Actual sprite texutre
	public Texture2D m_texture;
	//Basic
	protected int m_height;
	protected int m_width;
	protected int m_rotation;
	protected Vector2 m_scale = new Vector2(1, 1);
	protected SpriteEffects m_effects;

	// Location on the screen
	protected Vector2 m_coordinates = new Vector2(300, 300);
	public int DrawOrder { get; set; } = -1;
	public bool Visible { get; set; } = false;
	public SpriteBatch m_spriteBatch { get; set; } = null;

	protected Sprite()
	{
		Visible = false;
	}

	protected Sprite(int width, int height, string textureName)
	{
		m_width = width;
		m_height = height;
		//m_texture = Runesmyth.s_contentManager.Load<Texture2D>(textureName);
	}

	// IDrawable
	public event EventHandler<EventArgs> DrawOrderChanged;
	public event EventHandler<EventArgs> VisibleChanged;
	public void Draw(GameTime gameTime)
	{
		DrawInternal(gameTime);
	}

	protected void DrawInternal(GameTime gameTime)
	{
		m_spriteBatch.Draw(m_texture, m_coordinates, Color.White);
	}

	public void Scale(int scale)
	{
		m_width *= scale;
		m_height *= scale;
	}
}