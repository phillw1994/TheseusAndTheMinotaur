using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheseusandMinotaur;
using System.Diagnostics;

namespace TheseusAndMinotaurTest
{
    [TestClass]
    public class TAMTests
    {
        [TestMethod]
        public void TestLocationTheseus()
        {
            // Arrange
            Specials expected = Specials.Theseus;
            Specials result;
            Location loc = new Location(0, 0);

            loc.SetSpecial(Specials.Theseus);

            //Do
            result = loc.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special Tile set incorrectly");

        }

        [TestMethod]
        public void TestLocationMinotaur()
        {
            // Arrange
            Specials expected = Specials.Minotaur;
            Specials result;
            Location loc = new Location(0, 0);

            loc.SetSpecial(Specials.Minotaur);

            //Do
            result = loc.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special Tile set incorrectly");

        }

        [TestMethod]
        public void TestLocationExit()
        {
            // Arrange
            Specials expected = Specials.Exit;
            Specials result;
            Location loc = new Location(0, 0);

            loc.SetSpecial(Specials.Exit);

            //Do
            result = loc.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special Tile set incorrectly");

        }

        [TestMethod]
        public void TestMazeGetWidth()
        {
            // Arrange
            int expected = 5;
            int result;
            Maze maze = new Maze();

            maze.SetWidth(5);

            //Do
            result = maze.GetWidth();

            //Assert
            Assert.AreEqual(expected, result, "Maze Width is not 5");

        }

        [TestMethod]
        public void TestMazeGetHeight()
        {
            // Arrange
            int expected = 3;
            int result;
            Maze maze = new Maze();

            maze.SetHeight(3);

            //Do
            result = maze.GetHeight();

            //Assert
            Assert.AreEqual(expected, result, "Maze Height is not 3");

        }

        [TestMethod]
        public void TestCreateMap1()
        {
            // Arrange
            int expected1 = 5;
            int expected2 = 3;
            int result;
            Maze maze = new Maze();

            maze.CreateMap(5,3);

            //Do
            result = maze.GetHeight();

            //Assert
            Assert.AreEqual(expected2, result, "Maze Height is not 3");

            //Do
            result = maze.GetWidth();

            //Assert
            Assert.AreEqual(expected1, result, "Maze Width is not 5");

        }

        [TestMethod]
        public void TestMazeGetName()
        {
            // Arrange
            string expected = "New Map";
            string result;
            Maze maze = new Maze();

            maze.SetName("New Map");

            //Do
            result = maze.GetName();

            //Assert
            Assert.AreEqual(expected, result, "Maze Name is not New Map");

        }

        [TestMethod]
        public void TestAddSpecialTheseus()
        {
            // Arrange
            Specials expected = Specials.Theseus;
            Specials result;
            Tile[][] allTiles;
            Tile tile;
            Location l;
            Maze maze = new Maze();
            maze.AddSpecial(0,0,'T');

            //Do
            allTiles = maze.GetAllTiles();
            tile = allTiles[0][0];
            l = tile.GetLocation();
            result = l.GetSpecial();
            //Assert
            Assert.AreEqual(expected, result, "Special not set to Theseus");

        }

        [TestMethod]
        public void TestAddSpecialMinotaur()
        {
            // Arrange
            Specials expected = Specials.Minotaur;
            Specials result;
            Tile[][] allTiles;
            Tile tile;
            Location l;
            Maze maze = new Maze();
            maze.AddSpecial(0, 0, 'M');

            //Do
            allTiles = maze.GetAllTiles();
            tile = allTiles[0][0];
            l = tile.GetLocation();
            result = l.GetSpecial();
            //Assert
            Assert.AreEqual(expected, result, "Special not set to Minotaur");

        }

        [TestMethod]
        public void TestAddSpecialExit()
        {
            // Arrange
            Specials expected = Specials.Exit;
            Specials result;
            Tile[][] allTiles;
            Tile tile;
            Location l;
            Maze maze = new Maze();
            maze.AddSpecial(0, 0, 'X');

            //Do
            allTiles = maze.GetAllTiles();
            tile = allTiles[0][0];
            l = tile.GetLocation();
            result = l.GetSpecial();
            //Assert
            Assert.AreEqual(expected, result, "Special not set to Exit");

        }

        [TestMethod]
        public void TestTileSetTop1()
        {
            // Arrange
            bool expected = true;
            bool result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetTopWall(true);
            result = tile.GetTopWall();
            //Assert
            Assert.AreEqual(expected, result, "Top Wall False");

        }

        [TestMethod]
        public void TestTileSetTop2()
        {
            // Arrange
            bool expected = false;
            bool result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetTopWall(false);
            result = tile.GetTopWall();
            //Assert
            Assert.AreEqual(expected, result, "Top Wall True");

        }

        [TestMethod]
        public void TestTileSetLeft1()
        {
            // Arrange
            bool expected = true;
            bool result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetLeftWall(true);
            result = tile.GetLeftWall();
            //Assert
            Assert.AreEqual(expected, result, "Left Wall False");

        }

        [TestMethod]
        public void TestTileSetLeft2()
        {
            // Arrange
            bool expected = false;
            bool result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetTopWall(false);
            result = tile.GetTopWall();
            //Assert
            Assert.AreEqual(expected, result, "Left Wall True");

        }

        [TestMethod]
        public void TestTileGetLocation()
        {
            // Arrange
            bool expected = true;
            Location loc;
            bool result = false;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            loc = tile.GetLocation();
            if (loc.GetType() ==  typeof(Location))
            {
                result = true;
            }

            //Assert
            Assert.AreEqual(expected, result, "Location does not exist or of wrong type");

        }

        [TestMethod]
        public void TestTileGetSpecialTheseus()
        {
            // Arrange
            Specials expected = Specials.Theseus;
            Specials result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetSpecial(Specials.Theseus);
            result = tile.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special tile set incorrectly");

        }

        [TestMethod]
        public void TestTileGetSpecialMinotaur()
        {
            // Arrange
            Specials expected = Specials.Minotaur;
            Specials result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetSpecial(Specials.Minotaur);
            result = tile.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special tile set incorrectly");

        }

        [TestMethod]
        public void TestTileGetSpecialExit()
        {
            // Arrange
            Specials expected = Specials.Exit;
            Specials result;
            Tile tile;

            //Do
            tile = new Tile(0, 0);
            tile.SetSpecial(Specials.Exit);
            result = tile.GetSpecial();

            //Assert
            Assert.AreEqual(expected, result, "Special tile set incorrectly");

        }
    }
}
