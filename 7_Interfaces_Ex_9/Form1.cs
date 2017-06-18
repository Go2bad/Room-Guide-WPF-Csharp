using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_Interfaces_Ex_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CreateObjects();
            MoveToANewLocation(garden);
        }

        Random random = new Random();

        Location currentLocation;

        Room dinningRoom;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;

        Outside garden;
        OutsideWithDoor backYard;
        OutsideWithDoor frontYard;

        int MovesDone = 0;

        int ChecksDone = 0;

        public void CreateObjects()
        {
            dinningRoom = new Room("dinning room", "chrustal'naya lustra", "");
            livingRoom = new RoomWithDoor("living room", "starinniy kover", "", "matalicheskay dver'");
            kitchen = new RoomWithDoor("kitchen", "plita iz nerghaveushei stali", "", "setchataya dver'");

            garden = new Outside("garden", true, "");
            backYard = new OutsideWithDoor("back yard", false , "", "setchataya dver'");
            frontYard = new OutsideWithDoor("front yard", false, "", "matalicheskay dver'");

            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { dinningRoom, frontYard };
            kitchen.Exits = new Location[] { backYard, dinningRoom };

            garden.Exits = new Location[] { frontYard, backYard };
            frontYard.Exits = new Location[] { livingRoom, garden };
            backYard.Exits = new Location[] { garden, kitchen };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen; 
        }

        private void MoveToANewLocation(Location myLocation)
        {  
            MovesDone++;

            currentLocation = myLocation;

            exits.Items.Clear();

            description.Text = currentLocation.Description;

            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                exits.Items.Add(currentLocation.Exits[i].name); 
            }

            exits.SelectedIndex = 0;

            if (currentLocation is IHasExteriorDoor)
            {
                // goThroughTheDoor.Visible = true;
                goThroughTheDoor.Enabled = true;

            }
            else
            {
                // goThroughTheDoor.Visible = false;
                goThroughTheDoor.Enabled = false;
            }
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void hide_Click(object sender, EventArgs e)
        {
            Random myRandom = new Random();

            int randomNumber = myRandom.Next(1, 7);

            description.Text += " Your random number is " + randomNumber + ". You can start to go in search!";

            if (randomNumber == 1)
            {
                // frontyard +
                frontYard.opponent = " I'm here.";
                             
            }
            else if (randomNumber == 2)
            {
                // garden
                garden.opponent = " I'm here.";
            }
            else if (randomNumber == 3)
            {
                // backyard +
                backYard.opponent = " I'm here.";
            }
            else if (randomNumber == 4)
            {
                // livingroom +
                livingRoom.opponent = " I'm here.";
            }
            else if (randomNumber == 5)
            {
                // dinningroom
                dinningRoom.opponent = " I'm here.";
            }
            else if (randomNumber == 6)
            {
                // kitchen +
                kitchen.opponent = " I'm here.";
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            ChecksDone++;

            if(String.IsNullOrEmpty(currentLocation.opponent) != true)
            {
                description.Text += currentLocation.opponent + " You have moved " + MovesDone + " times and made " + ChecksDone + " attempts";
            }
            else
            {
                description.Text += " Here's empty, check another room!";
            }
        }
    }

    abstract class Location
    {
        public Location(string name, string opponent)
        {
            this.name = name;
            this.opponent = opponent;
        }

        public string name { get; private set; }

        public string opponent { get; set; }

        public Location[] Exits;

        public virtual string Description
        {
            get
            {
                string description = "You are located in " + name + ". You also can see doors, which lead to:";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += " " + Exits[i].name;
                    if (i != Exits.Length - 1)
                    {
                        description += ",";
                    }
                }
                description += ".";
                return description;
            }
        }
    }

    class Room : Location
    {
        public Room(string name, string decoration, string opponent) : base(name, opponent)
        {
            this.decoration = decoration;
        }

        private string decoration;

        public override string Description
        {
            get
            {
                return base.Description + " Here you can see " + decoration + ".";
            }
        }
    }

    class Outside : Location
    {
        public Outside(string name, bool hot, string opponent) : base(name, opponent)
        {
            this.hot = hot;
        }

        public bool hot;

        public override string Description
        {
            get
            {
                string newDescription = base.Description;
                if (hot)
                {
                    newDescription += " Here's hot.";
                }           
                return newDescription;
            }
        }
    }

    interface IHasExteriorDoor
    {
        string DoorDescription { get; }

        Location DoorLocation { get; set; }
    }

    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string opponent, string doorDescription) : base(name, decoration, opponent)
        {
            doorDescription = DoorDescription;
        }

        public string DoorDescription { get; set; }

        public Location DoorLocation { get; set; }
    }

    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(string name, bool hot, string opponent,  string doorDescription) : base(name, hot, opponent)
        {
            doorDescription = DoorDescription;
        }

        public string DoorDescription { get; set; }

        public Location DoorLocation { get; set; }
    }

    /*
       1) создание класса Opponent *
       
            *   закрытое поле Location(myLocation) - отслеживание положения
                закрытое поле Random(random) ** - поиск случайного укромного места 
              
            **  Random myRandom = new Random();
                int randomNumber = myRandom.Next(1, 11);
         
       2) создание интерфейса (который описывает укромные места)
       3) сделать изменения в форме (возможность проверять наличие укромных местечек и отслеживать, сколько ходов было сделано, пытаясь найти соперника) 
       4) добавление метода Move() - перемещение соперника
       5) добавление метода Check() с параметром location - возвращение значение true, когда соперник прячется
   */  
}
