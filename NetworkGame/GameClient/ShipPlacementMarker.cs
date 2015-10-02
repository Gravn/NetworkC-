using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class ShipPlacementMarker:GameObject
    {
        //ShipPlacementMarker is used in setup of any Battleship game.
        //When all ships have been placed, the gamemode changes into firering mode, where FireMarkers is used.


        public float timer = 0;
        public int selectedShip;
        public int rotation;
        
        public ShipPlacementMarker(int posX, int posY)
            : base(posX, posY)
        {

        }

        public override void Update(float deltaTime)
        {
            switch (GameManager.currentKey)
            {
                case ConsoleKey.Q:
                    ChangeShipType(-1);
                    break;

                case ConsoleKey.E:
                    ChangeShipType(1);
                    break;

                case ConsoleKey.R:
                    Rotate();
                    break;
                
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    Move(0);
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    Move(1);
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    Move(2);
                    break;

                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    Move(3);
                    break;

                case ConsoleKey.Spacebar:
                    PlaceShip(posX, posY);
                    break;


            }
            Console.Title = "" + timer;
            timer += deltaTime;
            if (timer >= 1f)
            {
                Clear();
                timer = 0;
            }

            base.Update(deltaTime);

        }

        public void Move(int direction)
        {
            int paddingX = 0;
            int paddingY = 0;

            switch (rotation)
            { 
                case 0:
                    if (direction == 0)
                    {
                        paddingX = -selectedShip * 4;
                    }
                    else
                    {
                        paddingX = 0;
                    }
                    break;

                case 1:
                    if (direction == 1)
                    {
                        paddingY = -selectedShip * 4;
                    }
                    else
                    {
                        paddingY = 0;
                    }
                    break;

                case 2:

                    if (direction == 2)
                    {
                        paddingX = selectedShip * 4;
                    }
                    else
                    {
                        paddingX = 0;
                    }

                    break;


                case 3:
                    if (direction == 3)
                    {
                        paddingY = selectedShip * 4;
                    }
                    else
                    {
                        paddingY = 0;
                    }

                    break;

            }


            if ( direction == 0 && posX < 40 + paddingX)
            {
                Clear();
                posX += 4;
            }

            if ( direction == 1 && posY < 40 + paddingY )
            {
                Clear();
                posY += 4;
            }

            if ( direction == 2 && posX > 4 + paddingX)
            {
                Clear();
                posX -= 4;
            }

            if ( direction == 3 && posY > 4 + paddingY )
            {
                Clear();
                posY -= 4;
            }
        }

        public void Rotate()
        {
            switch (rotation)
            {
                case 0:
                    if (posY+selectedShip*4 > 40)
                    {
                        Clear();
                        posY -= selectedShip*4-(40-posY);
                    }
                    Clear();
                    rotation++;
                    break;
                case 1:
                    if (posX - selectedShip * 4 < 4)
                    {
                        Clear();
                        posX += selectedShip * 4 + (4 - posX);
                    }
                    Clear();
                    rotation++;
                    break;
                case 2:
                    if (posY - selectedShip * 4 < 4)
                    {
                        Clear();
                        posY += selectedShip * 4 + (4 - posY);
                    }
                    Clear();
                    rotation++;
                    break;
                case 3:
                    if (posX + selectedShip * 4 > 40)
                    {
                        Clear();
                        posX -= selectedShip * 4 - (40 - posX);
                    }
                    Clear();
                    rotation = 0;
                    break;
            }
        }

        public void ChangeShipType(int change)
        {
            Clear();
            switch (rotation)
            { 
                case 0:
                    if (change==1 && posX + selectedShip * 4 >= 40)
                    {
                        return;
                    }

                    if (change != 1 && selectedShip==0 && posX + 4*4 >40)
                    {
                        return;
                    }
                    break;

                case 1:
                    if (change==1 && posY + selectedShip * 4 >= 40)
                    {
                        return;
                    }

                    if (change != 1 && selectedShip==0 && posY + 4*4 >40)
                    {
                        return;
                    }
                    break;

                case 2:
                    if (change==1 && posX - selectedShip * 4 <= 4)
                    {
                        return;
                    }

                    if (change != 1 && selectedShip==0 && posX - 4*4 <4)
                    {
                        return;
                    }
                    break;

                case 3:
                    if (change==1 && posY - selectedShip * 4 <= 4)
                    {
                        return;
                    }

                    if (change != 1 && selectedShip==0 && posY - 4*4 <4)
                    {
                        return;
                    }
                    break;
            }

            if (change == 1)
            {
                if (selectedShip < 4)
                {
                    selectedShip++;
                }
                else
                {
                    selectedShip = 0;
                }
            }
            else
            {
                if (selectedShip > 0)
                {
                    selectedShip--;
                }
                else
                {
                    selectedShip = 4;
                }
            }


                
        }

        public void PlaceShip(int posX, int posY)
        {
            bool occupied = false;

            if(GameManager.ships[selectedShip]>0)
            {

                switch(rotation)
                {
                    case 0:
                        for (int i = 0; i <= selectedShip; i++)
                        {
                            if (GameManager.grid[(posX / 4)-1+i, (posY / 4)-1] != 0)
                            {
                                occupied = true;
                                return;
                            }
                        }

                        if (!occupied)
                        {
                            for (int i = 0; i <= selectedShip; i++)
                            {
                                GameManager.grid[(posX / 4)-1+i,(PosY / 4)-1] = selectedShip+1;
                            }
                        }
                        break;

                    case 1:
                        for (int i = 0; i <= selectedShip; i++)
                        {
                            if (GameManager.grid[(posX / 4)-1, (posY / 4)-1+i] != 0)
                            {
                                occupied = true;
                                return;
                            }
                        }

                        if (!occupied)
                        {
                            for (int i = 0; i <= selectedShip; i++)
                            {
                                GameManager.grid[(posX / 4) - 1, (PosY / 4) - 1 + i] = selectedShip+1;
                            }
                        }
                        break;

                    case 2:
                        for (int i = selectedShip; i >= 0; i--)
                        {
                            if (GameManager.grid[(posX / 4)-1-i, (posY / 4)-1] != 0)
                            {
                                occupied = true;
                                return;
                            }
                        }

                        if (!occupied)
                        {
                            for (int i = selectedShip; i >=0; i--)
                            {
                                GameManager.grid[(posX / 4) - 1 - i, (PosY / 4) - 1] = selectedShip+1;
                            }
                        }
                        break;

                    case 3:
                        for (int i = selectedShip; i >= 0; i--)
                        {
                            if (GameManager.grid[(posX / 4)-1, (posY / 4)-1-i] != 0)
                            {
                                occupied = true;
                                return;
                            }
                        }

                        if (!occupied)
                        {
                            for (int i = selectedShip; i >= 0; i--)
                            {
                                GameManager.grid[(posX / 4) - 1, (PosY / 4) - 1 - i] = selectedShip+1;
                            }
                        }
                        break;
                }

                GameManager.GameObjects.Add(new Ship(posX,PosY,selectedShip,rotation));
                GameManager.ships[selectedShip]--;
                Clear();
                bool moreToPlace = true;
                for (int i = 0; i < GameManager.ships.Length; i++)
                {
                    if (GameManager.ships[i] == 0)
                    {
                        moreToPlace = false;
                    }
                    else
                    {
                        moreToPlace = true;
                    }
                }

                if(moreToPlace == false)
                {
                    GameManager.ChangeGameMode();
                }

                GameManager.EndTurn();
            }
            
        }
        
        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            GameManager.drawer.DrawText(5, 48, "Carrier(5): " + GameManager.ships[4]+" Battleship(4): "+GameManager.ships[3]+" Cruiser(3): "+GameManager.ships[2],ConsoleColor.White);
            GameManager.drawer.DrawText(5, 49, "Destroyer(2): " + GameManager.ships[1] + " Submarine(1): " + GameManager.ships[0], ConsoleColor.White);
      

            switch(rotation)
            {
                case 0:
                    GameManager.drawer.DrawPicture(posX, posY, new string[]
                {
                   "GG",
                   "G",
                   "",
                   "G ",
                   "GG",
                });

                    GameManager.drawer.DrawPicture(posX + selectedShip * 4, posY, new string[]
                {
                   "   GG",
                   "    G",
                   "",
                   "    G",
                   "   GG",
                });
                if(timer >=0.5f)
                {
                    for (int i = 1; i <= selectedShip-1; i++)
                    {
                        GameManager.drawer.DrawPicture(posX + i * 4, posY+1, new string[]
                        {
                            "WWWWW",
                            "WWWWW",
                            "WWWWW",
                        });
                    }

                    GameManager.drawer.DrawPicture(posX + 1, posY + 1, new string[]
                    {
                        " WWW",
                        "WWWW",
                        " WWW",
                    });

                    GameManager.drawer.DrawPicture(posX + 1 + selectedShip * 4, posY + 1, new string[]
                    {
                        "W",
                        "WWW",
                        "W",
                    });
                }


                    break;
                case 1:
                  GameManager.drawer.DrawPicture(posX, posY, new string[]
                {
                   "GG GG",
                   "G   G"
                });

                GameManager.drawer.DrawPicture(posX, posY + selectedShip * 4, new string[]
                {
                    "",
                    "",
                    "",
                   "G   G",
                   "GG GG"
                });

                if (timer >= 0.5f)
                {
                    for (int i = 1; i <= selectedShip - 1; i++)
                    {

                        GameManager.drawer.DrawPicture(posX + 1, posY + i * 4, new string[]
                        {
                            "WWW",
                            "WWW",
                            "WWW",
                            "WWW",
                            "WWW"
                        });
                    }

                    GameManager.drawer.DrawPicture(posX + 1, posY + 1, new string[]
                    {
                        " W ",
                        "WWW",
                        "WWW",
                        "WWW"
                    });

                        GameManager.drawer.DrawPicture(posX + 1, posY + selectedShip * 4, new string[]
                    {
                        "WWW",
                        "WWW",
                        " W ",
                        " W "
                    });
                    }
                
                break;

                case 2:
                    GameManager.drawer.DrawPicture(posX-selectedShip*4, posY, new string[]
                    {
                       "GG",
                       "G",
                       "",
                       "G",
                       "GG",
                    });

                    GameManager.drawer.DrawPicture(posX, posY, new string[]
                    {
                       "   GG",
                       "    G",
                       "",
                       "    G",
                       "   GG",
                    });
                    if (timer >= 0.5f)
                    {
                        for (int i = 1; i <= selectedShip - 1; i++)
                        {
                            GameManager.drawer.DrawPicture(posX - i * 4, posY + 1, new string[]
                            {
                                "WWWWW",
                                "WWWWW",
                                "WWWWW",
                            });
                        }

                        GameManager.drawer.DrawPicture(posX, posY + 1, new string[]
                        {
                            "WWW ",
                            "WWWW",
                            "WWW",
                        });

                        GameManager.drawer.DrawPicture(posX + 1 - selectedShip * 4, posY + 1, new string[]
                        {
                            "  W",
                            "WWW",
                            "  W",
                        });
                    }
                break;
                case 3:
                    GameManager.drawer.DrawPicture(posX, posY - selectedShip * 4, new string[]
                    {
                       "GG GG",
                       "G   G"
                    });

                    GameManager.drawer.DrawPicture(posX, posY, new string[]
                    {
                        "",
                        "",
                        "",
                       "G   G",
                       "GG GG"
                    });
                    if (timer >= 0.5f)
                    {
                        for (int i = 1; i <= selectedShip - 1; i++)
                        {
                            GameManager.drawer.DrawPicture(posX + 1, posY - i * 4, new string[]
                        {
                            "WWW",
                            "WWW",
                            "WWW",
                            "WWW",
                            "WWW"
                        });
                        }

                        GameManager.drawer.DrawPicture(posX + 1, posY, new string[]
                        {
                            "WWW",
                            "WWW",
                            "WWW",
                            " W "
                        });

                        GameManager.drawer.DrawPicture(posX + 1, posY + 1 - selectedShip * 4, new string[]
                        {
                            " W ",
                            " W ",
                            "WWW",
                        });
                    }

                break;
            }
        }

        public void Clear()
        {
            switch (rotation)
            { 
                case 0:
                    for (int i = 0; i <= selectedShip; i++)
                    {
                        GameManager.drawer.DrawPicture(posX + i * 4, posY, new string[]
                        {
                            "bbbbb",
                            "bBBBb",
                            "bBBBb",
                            "bBBBb",
                            "bbbbb"
                        });
                    }
                    break;
                case 1:
                    for (int i = 0; i <= selectedShip; i++)
                    {
                        GameManager.drawer.DrawPicture(posX, posY + i * 4, new string[]
                        {
                            "bbbbb",
                            "bBBBb",
                            "bBBBb",
                            "bBBBb",
                            "bbbbb"
                        });
                    }
                    break;
                case 2:
                    for (int i = 0; i <= selectedShip; i++)
                    {
                        GameManager.drawer.DrawPicture(posX - i * 4, posY, new string[]
                        {
                            "bbbbb",
                            "bBBBb",
                            "bBBBb",
                            "bBBBb",
                            "bbbbb"
                        });
                    }
                    break;
                case 3:
                    for (int i = 0; i <= selectedShip; i++)
                    {
                        GameManager.drawer.DrawPicture(posX, posY - i * 4, new string[]
                        {
                            "bbbbb",
                            "bBBBb",
                            "bBBBb",
                            "bBBBb",
                            "bbbbb"
                        });
                    }
                    break;
            }   
        }
    }
}
