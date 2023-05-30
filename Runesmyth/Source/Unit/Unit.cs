using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class Unit : Sprite
{
    // X,Y pos (in game)
    (int, int)  m_position;

    // Game properties
    UnitProperties m_properties;

    // static containers
    static List<Unit> s_units   = new List<Unit>(Constants.MAX_UNITS);
    static Unit s_playerUnit    = null;

    public Unit(int width, int height, string textureName) : base(width, height, textureName) // Might have to defaualt here on texture name
    {
         s_units.Add(this);
    }

    ~Unit()
    {
        s_units.Remove(this);
    }

    public static void DrawUnits(GameTime gameTime)
    {
        foreach (var unit in s_units)
        {
            unit.Draw(gameTime);
        }
    }
}