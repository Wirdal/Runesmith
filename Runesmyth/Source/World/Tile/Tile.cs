using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tile : Sprite
{
	// Coordinate system
	(int, int) m_coordinate;

	bool m_occupied;
	Unit m_occupyingUnit;
}
