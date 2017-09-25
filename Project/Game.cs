using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room currentRoom { get; set; }
        public Player Player { get; set; }
        bool elevatorActive = false;
        bool courtyardLocked = true;
        public void InitializeGame()
        {
            Player = new Player();
            var caves = new Room("The Caves", "Deep, cold, dark caves that run deep below Castle Dracula with seemingly no indication of how one arrived here in the first place.");
            var parlor = new Room("Parlor", "A parlor that once entertained guests now covered in dust and old relics.");
            var tower = new Room("Tower", "The highest room in Castle Dracula. Home to many secrets. A rope hangs outside the window. Maybe you can use it to climb to the ground below?");
            var courtyard = new Room("Courtyard", "An old, crumbling courtyard. Behind it looms Castle Dracula.");

            caves.Items.Add(availableItems.MysteriousKey.Name, availableItems.MysteriousKey);
            caves.Exits.Add("forward", parlor);
            parlor.Exits.Add("forward", tower);
            parlor.Exits.Add("back", caves);
            tower.Exits.Add("forward", courtyard);
            tower.Exits.Add("back", parlor);
            courtyard.Exits.Add("back", tower);
            currentRoom = caves;

            System.Console.WriteLine("Welcome to Castle Dracula.");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("Type 'Help' at any time during your adventure to display helpful controls.");
            System.Console.WriteLine("Type 'Room' at any time during your adventure to display the name and description of the room you are in.");
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine("You wake up, cold and confused deep within the caves that lie below Castle Dracula in Transylvania.");
            System.Console.WriteLine(" ");
            System.Console.WriteLine("There isn't much to see in the darkness, however you can make out the faint outline of strange items on an old, wooden table in front of you.");
            System.Console.WriteLine("You run your hands slowly across the table. After feeling some strange things that feel like bones, cobwebs, your hands run across a large, intricate metal key.");
            System.Console.WriteLine("...");
            System.Console.WriteLine("The key is mysterious but may come in handy later on.");

            showControls();
        }

        void showControls()
        {
            Console.Write("What would you like to do now? ");
            System.Console.WriteLine("\n------------------------------");
            System.Console.WriteLine("1. Pick up item");
            System.Console.WriteLine("2. Move Forward");
            System.Console.WriteLine("3. Move Back");
            if (Player.Inventory.ContainsKey("Mysterious Key"))
            {
                System.Console.WriteLine("4. Use Mysterious Key");
            }
            System.Console.WriteLine("------------------------------");
            userInput();


        }
        void showRoom()
        {
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine(currentRoom.Name);
            System.Console.WriteLine(currentRoom.Description);
            System.Console.WriteLine("------------------------------");

        }
        void userInput()
        {

            var response = Console.ReadLine();
            if (response.ToLower() == "help")
            {
                showControls();
            }
            else if (response == "1")
            {
                if (!Player.Inventory.ContainsKey("Mysterious Key"))
                {
                    Player.Inventory.Add(availableItems.MysteriousKey.Name, availableItems.MysteriousKey);
                    System.Console.WriteLine("Pocketed Mysterious Key. Awarded a point for your wise decision.");
                    System.Console.WriteLine(" ");
                    Player.Points++;
                    System.Console.WriteLine("Points: " + Player.Points);
                }
                else
                {
                    System.Console.WriteLine("Already took the mysterious key with you.");
                }
            }
            else if (response == "2")
            {
                if (currentRoom.Exits.ContainsKey("forward"))
                {

                    if (currentRoom.Name == "Parlor")
                    {
                        if (elevatorActive)
                        {
                            System.Console.WriteLine("You climb in the elevator and ascend upward into the unknown.");
                            System.Console.WriteLine("Awarded a point for ingenuity!");
                            Player.Points++;
                            System.Console.WriteLine("Points: " + Player.Points);
                            currentRoom = currentRoom.Exits["forward"];
                            showRoom();
                        }
                        else
                        {
                            System.Console.WriteLine("The elevator is jammed. Almost as if it needs to be activated somehow.");
                        }
                    }
                    else
                    {
                        currentRoom = currentRoom.Exits["forward"];
                        showRoom();
                    }

                }
                else
                {
                    System.Console.WriteLine("Nowhere to go!");
                }
            }
            else if (response == "3")
            {
                if (currentRoom.Exits.ContainsKey("back"))
                {
                    currentRoom = currentRoom.Exits["back"];
                    showRoom();
                }
                else
                {
                    System.Console.WriteLine("Nowhere to go!");
                }
            }
            else if (response == "4")
            {
                UseMysteriousKey("Mysterious Key");
            }
            else if (response.ToLower() == "room")
            {
                showRoom();
            }
            else
            {
                System.Console.WriteLine("Invalid command, please try again.");
            }
            showControls();
        }

        public void UseMysteriousKey(string itemName)
        {

            if (Player.Inventory.ContainsKey("Mysterious Key"))
            {
                if (currentRoom.Name == "The Caves")
                {
                    System.Console.WriteLine("Used the Mysterious Key on the coffin. It seems to work. Unlocked The coffin...");
                    System.Console.WriteLine("Something seems to have awoken. Dracula himself rises from the coffin. You are his first meal. GAME OVER.");
                }
                if (currentRoom.Name == "Parlor")
                {
                    System.Console.WriteLine("The room is dark, but not nearly as dark as the caves.");
                    System.Console.WriteLine("Glancing around the room, you notice the only place you may be able to use the Mysterious Key...");
                    System.Console.WriteLine("An old elevator shaft that seems to go to the upper levels of the castle.");
                    System.Console.WriteLine("Using the Mysterious Key, you turn the crank on the elevator. It begins to move.");
                    elevatorActive = true;
                    showControls();
                }
                if (currentRoom.Name == "Tower")
                {
                    System.Console.WriteLine("A statue of a dragon sits on a bedside table in what appears to be Count Dracula's sleeping quarters.");
                    System.Console.WriteLine("Inserting the key into the dragons mouth, a rope falls to the ground below just outside the window.");
                    System.Console.WriteLine("A faint metallic clink is heard in the distance.");
                    System.Console.WriteLine("A point for cleverness!");
                    System.Console.WriteLine(" ");
                    Player.Points++;
                    System.Console.WriteLine("Points: " + Player.Points);
                    courtyardLocked = false;
                    System.Console.WriteLine("Descend the rope into the courtyard below?");
                    System.Console.WriteLine(" ");
                }
                if (currentRoom.Name == "Courtyard")
                {
                    if (!courtyardLocked)
                    {
                        System.Console.WriteLine("Used the mysterious Key to open the other half of the courtyard gate.");
                        System.Console.WriteLine("You escape to freedom and win the day!");
                        System.Console.WriteLine("A point for bravery!");
                        Player.Points++;
                        System.Console.WriteLine(" ");
                        System.Console.WriteLine("Points: " + Player.Points);
                    }
                    else
                    {
                        System.Console.WriteLine("The courtyard gate seems to be halfway unlocked, but appears to be held shut by another locking mechanism, they mechanics to which clearly lie elsewhere.");
                    }
                }

            }
            else
            {
                System.Console.WriteLine("No items available to be used.");
            }
        }

    }
}