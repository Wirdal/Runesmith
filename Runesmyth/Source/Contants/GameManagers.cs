using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class GameManagers
{
    private static GameManagers s_managerInstance = null;
    private static readonly object padlock = new object();
    // Static managers. Initialized in game class
    public static GraphicsDeviceManager s_graphics;
    public static SpriteBatch s_spriteBatch;
    public static ContentManager s_contentManager;

    GameManagers() { }
    public static GameManagers Instance
    {
        get
        {
            lock(padlock)
            {
                if (s_managerInstance == null)
                {
                    s_managerInstance = new GameManagers();
                }
                return s_managerInstance;
            }
        }
    }


}
