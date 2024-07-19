using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi_game
{
    public class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void add(Position position)
        {
            this.x += position.x;
            this.y += position.y;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Position p = (Position)obj;
            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return (x << 16) ^ y;
        }
        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.x + p2.x, p1.y + p2.y);
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.x - p2.x, p1.y - p2.y);
        }

        public static Position operator *(Position p1, int i)
        {
            return new Position(p1.x * i, p1.y * i);
        }

        public static bool operator ==(Position p1, Position p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;

            if ((object)p1 == null || (object)p2 == null)
                return false;

            return p1.Equals(p2);
        }

        public static bool operator !=(Position p1, Position p2)
        {
            return !(p1 == p2);
        }

        public Position GetNormalized()
        {

            return new Position(NormalizeNumber(x), NormalizeNumber(y));
        }

        private int NormalizeNumber(int number)
        {
            return number < 0 ? -1 : number == 0 ? 0 : 1;
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}

