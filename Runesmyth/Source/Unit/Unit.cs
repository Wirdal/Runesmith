using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class Unit
{
	// X,Y pos (in game)
	(int, int) m_position;

	// Game properties
	UnitProperties m_properties;

	// static containers
	static List<Unit> s_units = new List<Unit>(Constants.MAX_UNITS);
	static Unit? s_playerUnit = null;
	
	protected Sprite? m_sprite;

	public Unit() // Might have to defaualt here on texture name
	{
		s_units.Add(this);
		m_properties = new UnitProperties();
	}

	public void InitializeSprite(SpriteBatch spriteBatch, Texture2D texture)
	{
		if (m_sprite != null)
		{
			throw new InvalidOperationException("Cannot re-intialize sprite for unit");
		}
		m_sprite = new BreathingSprite(128, 128);
		m_sprite.m_texture = texture;
		m_sprite.m_spriteBatch = spriteBatch;
	}

	~Unit()
	{
		s_units.Remove(this);
	}

	public static void DrawUnits(GameTime gameTime)
	{
		foreach (var unit in s_units)
		{
			if (unit.m_sprite is Sprite sprite)
			{
				sprite.Draw(gameTime);
			}
		}
	}
}