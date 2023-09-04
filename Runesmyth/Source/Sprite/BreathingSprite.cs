using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Geometry;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BreathingSprite : Sprite
{
	// Curve representating breathing pattern
	Bezier m_curve;
	//List<Arc> m_arcs;
	// This needs to be normalized based on the breathTime
	private int _lastTangent;
	// We should finish interpolating along our curve in sixty draws
	// That is, we should loop our animation at least once in sixty draw calls.
	private const int _breathTime = 60;
	// Generate a list of floats between 0 60, then normalize them
	// These are going to be the points we want to find on the curve
	private List<float> _points = new List<float>(_breathTime);
	private Boolean _rising = false;

	public BreathingSprite(int width, int height, string textureName) : base(width, height, textureName)
	{
		// Create a curve based on our dimensions
		// For a start, lets only compress to a 75%  of our height
		System.Numerics.Vector2 p0 = new System.Numerics.Vector2(.8f, .8f);
		System.Numerics.Vector2 p1 = new System.Numerics.Vector2(1.0f, .8f);
		System.Numerics.Vector2 p2 = new System.Numerics.Vector2(.8f, 1.0f);
		System.Numerics.Vector2 p3 = new System.Numerics.Vector2(1.0f, 1.0f);

		m_curve = new Bezier(p0, p1, p2, p3);
		_lastTangent = new Random().Next(_breathTime);

		for (int i = 0; i < _breathTime; i++)
		{
			_points.Add(i);
		}
		// Normalize the points
		for (int i = 1; i < _points.Count; i++)
		{
			_points[i] = ((_points[i] - _points.Min()) / (_points.Max() - _points.Min()));
		}

		//arcs = curve.ToArcs(0.50f);
		// We're also going to start them off in a random spot in the curve, then follow through the rest of the curve
	}

	new public void Draw(GameTime gameTime)
	{
		// We need to stretch or compress our texture based on our curve
		Vector2 point = m_curve.Position(_points[_lastTangent]);
		if (_rising)
		{
			_lastTangent++;
		}
		else
		{
			_lastTangent--;
		}

		if (_lastTangent >= _breathTime)
		{
			_rising = false;
			_lastTangent = _breathTime - 1;
		}
		if (_lastTangent < 0)
		{
			_lastTangent = 0;
			_rising = true;
		}

		m_spriteBatch.Draw(
			m_texture,
			m_coordinates,
			null,
			Color.White,
			0,
			Vector2.Zero,
			point,
			m_effects,
			0
		 );
	}
}
