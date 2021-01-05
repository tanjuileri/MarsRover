using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public enum Direction
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    public class Rover
    {
        private int _positionX;
        private int _positionY;
        private Direction _direction;
        private int _maximumPositionX;
        private int _maximumPositionY;

        public Rover(string location, int maximumX, int maximumY)
        {
            var arr = location.Split(" "); //positionX, positionY, Direction
            _positionX = Convert.ToInt32(arr[0]);
            _positionY = Convert.ToInt32(arr[1]);
            _maximumPositionX = maximumX;
            _maximumPositionY = maximumY;

            switch (arr[2])
            {
                case "N":
                    _direction = Direction.N;
                    break;
                case "E":
                    _direction = Direction.E;
                    break;
                case "S":
                    _direction = Direction.S;
                    break;
                case "W":
                    _direction = Direction.W;
                    break;
                default:
                    throw new Exception("Unknow Direction");

            }
        }
        public string LastPosition
        {
            get
            {
                return string.Format("{0} {1} {2}", _positionX, _positionY, _direction);
            }
        }

        private void ChangeDirection(string rotateDirection)
        {
            if (rotateDirection == "R")
            {
                if (_direction == Direction.W)
                    _direction = Direction.N;
                else
                    _direction++;
            }
            else if (rotateDirection == "L")
            {
                if (_direction == Direction.N)
                    _direction = Direction.W;
                else
                    _direction--;
            }
            else
            {
                throw new Exception("Unknow Rotation");
            }
        }

        public void Move(string orders)
        {
            foreach (var order in orders)
            {
                if (order == 'L' || order == 'R')
                {
                    ChangeDirection(order.ToString());
                }
                else if (order == 'M')
                {
                    bool isFailedMoving = false;

                    switch (_direction)
                    {
                        case Direction.N:
                            if (_positionY == _maximumPositionY)
                                isFailedMoving = true;
                            else
                                _positionY += 1;
                            break;
                        case Direction.E:
                            if (_positionX == _maximumPositionX)
                                isFailedMoving = true;
                            else
                                _positionX += 1;
                            break;
                        case Direction.S:
                            if (_positionY == 0)
                                isFailedMoving = true;
                            else
                                _positionY -= 1;
                            break;
                        case Direction.W:
                            if (_positionX == 0)
                                isFailedMoving = true;
                            else
                                _positionX -= 1;
                            break;
                    }

                    if (isFailedMoving)
                        throw new Exception(string.Format("Can't go any further in the {0} direction", _direction));

                }
                else
                {
                    throw new Exception("Unknow Order");
                }
            }
        }
    }
}
