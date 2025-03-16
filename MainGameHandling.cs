using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;
using static DungeonExplorer.MainGameHandling;
using static System.Windows.Forms.AxHost;


namespace DungeonExplorer
{
    public class MainGameHandling
    {
        //setup
        private static MainGameHandling instance = null;
        private static readonly object padlock = new object();

        Player Player;

        public static MainGameHandling Instance
        {
            
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MainGameHandling();
                    }
                }
                return instance;
            }
        }

        
        private FormEvents form1 = new FormEvents();
        public int GridSize = 25;

        public List<List<Room>> MapGrid = new List<List<Room>>();

        public List<Room> RoomList = new List<Room>();

        public Dictionary<string, Effect> List_Effect = new Dictionary<string, Effect>();
        public Dictionary<string, Weapon> List_Weapon = new Dictionary<string, Weapon>();
        public Dictionary<string, Item> List_Item = new Dictionary<string, Item>();
        public Dictionary<string, Enemy> List_Enemy = new Dictionary<string, Enemy>();
        public Dictionary<string, Attack> List_Attack = new Dictionary<string, Attack>();
        public Dictionary<string, Dictionary<Enemy, int>> List_EnemyPool = new Dictionary<string, Dictionary<Enemy, int>>();
        public Dictionary<string, Dictionary<Item, int>> List_LootPool = new Dictionary<string, Dictionary<Item, int>>();

        public enum PlayerEffectTypes
        {
            Health,
            Energy,
            AttackMult,
            DamageMult
        };
        public enum MiscTypes
        {
            Loot,
            Exit,
            Death
        }
        //button-state action stuff: so if button 1 is pressed it gives a different action-int in different situations
        
        public Dictionary<GridButton_States, Dictionary<int, int>> Actions = new Dictionary<GridButton_States, Dictionary<int, int>>
        {
            {GridButton_States.Navigation, new Dictionary<int, int>{ { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 }, { 8, 8 }, { 9, 9 } } },
            {GridButton_States.Misc, new Dictionary<int, int>{ { 1, 10 }, { 2, 11 }, { 3, 12 }, { 4, 13 }, { 5, 14 }, { 6, 15 }, { 7, 16 }, { 8, 17 }, { 9, 18 } } },
            {GridButton_States.Combat, new Dictionary<int, int>{ { 1, 19 }, { 2, 20 }, { 3, 21 }, { 4, 22 }, { 5, 23 }, { 6, 24 }, { 7, 25 }, { 8, 26 }, { 9, 27 } } },
            {GridButton_States.Inventory, new Dictionary<int, int>{ { 1, 28 }, { 2, 29 }, { 3, 30 }, { 4, 31 }, { 5, 32 }, { 6, 33 }, { 7, 34 }, { 8, 35 }, { 9, 36 } } },
            {GridButton_States.InvItem, new Dictionary<int, int>{ { 1, 37 }, { 2, 38 }, { 3, 39 }, { 4, 40 }, { 5, 41 }, { 6, 42 }, { 7, 43 }, { 8, 44 }, { 9, 45 } } },
        };
        //creating effect clsses (unused)
        public Dictionary<string, Effect> Get_Effects(bool Created)
        {
            if (Created == false)
            {
                #region Script Dependencies
                AttackEffects EffectsList_Attacks = new AttackEffects();
                ItemEffects EffectsList_Items = new ItemEffects();
                #endregion
                List_Effect = new Dictionary<string, Effect>();

                Effect Effect_Attack_Null = new Effect { Name = "None", Function = EffectsList_Attacks.Null };
                List_Effect.Add("Attack Null", Effect_Attack_Null);
                Effect Effect_Item_Null = new Effect { Name = "None", Function = EffectsList_Items.Null };
                List_Effect.Add("Item Null", Effect_Item_Null);

                Effect Effect_Item_Consume = new Effect { Name = "Consume", Function = EffectsList_Items.Consume };
                List_Effect.Add("Consume", Effect_Item_Consume);

                return List_Effect;
            }
            else
            {
                return List_Effect;
            }
        }
        //creating item classes
        public Dictionary<string, Item> Get_Items(bool Created)
        {
            if (Created == false)
            {
                List_Item = new Dictionary<string, Item>(); 

                Item Item_Null = new Item { ItemName = " ", Description = " ", Effect = null, Consume_Intensity = 0, EffectData = null };
                List_Item.Add("Null", Item_Null);
                Item Item_K = new Item { ItemName = "Exit Keycard", Description = "It's a keycard to exit the facility.", Effect = null, Consume_Intensity = 0, EffectData = null };
                List_Item.Add("Keycard", Item_K);                   
                Item Item_Water = new Item { ItemName = "Bottled Water", Description = "It's just bottled water.", Effect = null , Consume_Intensity = 25, EffectData = null };
                List_Item.Add("Water", Item_Water);
                Item Item_Food1 = new Item { ItemName = "MRE", Description = "It's just an MRE.", Effect = null, Consume_Intensity = 45, EffectData = null };
                List_Item.Add("MRE", Item_Food1);

                return List_Item;
            }
            else
            {
                return List_Item;
            }
        }
        //creating weapon classes (unused)
        public Dictionary<string, Weapon> Get_Weapons(bool Created)
        {
            if (Created == false)
            {
                List_Weapon = new Dictionary<string, Weapon>();
                Weapon Weapon_Null = new Weapon { WeaponName = " ", BaseDamage = 0, Multiplier = 0, StatType = StatTypes.STR, Attack = Get_Attacks(false)["Player Punch"], SourceItem = null };
                List_Weapon.Add("Null", Weapon_Null);

                return List_Weapon;
            }
            else
            {
                return List_Weapon;
            }
        }
        //creating attack classes (unused)
        public Dictionary<string, Attack> Get_Attacks(bool Created)
        {
            if (Created == false)
            {
                List_Attack = new Dictionary<string, Attack>();

                Attack Player_Punch = new Attack { Name = "Punch", BaseDamage = 1, Multiplier = 4, StatType = StatTypes.STR, Effect = Get_Effects(false)["Attack Null"], EffectData = new EffectData { Name = "None", Intensity = 0, Duration = 0, Description = "f" }, Description = "" };
                List_Attack.Add("Player Punch", Player_Punch);
                Attack Enemy_Punch_1 = new Attack { Name = "Punch", BaseDamage = 2, Multiplier = 2, StatType = StatTypes.STR, Effect = Get_Effects(false)["Attack Null"], EffectData = new EffectData { Name = "None", Intensity = 0, Duration = 0, Description = "f" }, Description = "" };
                List_Attack.Add("Enemy Punch", Enemy_Punch_1);
                return List_Attack;
            }
            else
            {
                return List_Attack;
            }
            
        }
        //creating enemy classes (unused)
        public Dictionary<string, Enemy> Get_Enemies(bool Created)
        {
            if (Created == false)
            {
                Enemy Enemy_Test1 = new Enemy
                {
                    EnemyName = "Enemy_Test1",
                    Description = "Test Description",
                    ImagePath = "null",
                    Stats =
                    new Dictionary<StatTypes, int>{
                        {StatTypes.STR, 5},
                        {StatTypes.DEX, 5},
                        {StatTypes.INT, 5},
                        {StatTypes.CHA, 5}
                    }
                };
                List_Enemy.Add("Test 1", Enemy_Test1);

                return List_Enemy;
            }
            else
            {
                return List_Enemy;
            }

        }
        //creating room classes, placing exit room down, setting player position randomly
        public List<List<Room>> Get_Rooms(bool Created)
        {
            if (Created == false)
            {
                List_EnemyPool = new Dictionary<string, Dictionary<Enemy, int>>();
                List_LootPool = new Dictionary<string, Dictionary<Item, int>>();
                MapGrid = new List<List<Room>>();

                Random random = new Random();

                Player Player = Player.Instance.InitialPlayerSetup(false, Get_Items(false)["Null"]);

                Player.Instance.EquippedPrimary = Get_Weapons(false)["Null"];
                Player.Instance.EquippedSecondary = Get_Weapons(false)["Null"];

                #region Setup Lootpools
                Dictionary<Item, int> LootPool_Armoury = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Keycard"], 1}
                };
                Dictionary<Item, int> LootPool_Hallway = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1}
                };
                Dictionary<Item, int> LootPool_Storage2 = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Keycard"], 1},
                    {Get_Items(false)["MRE"], 1},
                    {Get_Items(false)["MRE"], 1}

                };
                Dictionary<Item, int> LootPool_Storage1 = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1}
                };
                Dictionary<Item, int> LootPool_Bedroom = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Keycard"], 1}
                };
                Dictionary<Item, int> LootPool_Dining = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["MRE"], 1},
                    {Get_Items(false)["MRE"], 1}
                };
                Dictionary<Item, int> LootPool_Office = new Dictionary<Item, int>
                {
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Water"], 1},
                    {Get_Items(false)["Keycard"], 1}
                };
                #endregion
                #region Setup Enemy Pools
                Dictionary<Enemy, int> Empty = new Dictionary<Enemy, int>
                {
                
                };
                #endregion

                #region Setup Rooms
                Room Room_Hallway1 = new Room { RoomName = "Room_Hallway1", LootChance = 0.0, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "The hallway was barren, save for some bullet casings and streaks of blood.", LootPool = LootPool_Hallway, EnemyPool = Empty };
                RoomList.Add(Room_Hallway1);
                RoomList.Add(Room_Hallway1);
                RoomList.Add(Room_Hallway1);
                Room Room_Hallway2 = new Room { RoomName = "Room_Hallway2", LootChance = 0.2, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "The hallway was barren, save for some bullet casings and streaks of blood. To the far end was an emplacement of sandbags.", LootPool = LootPool_Hallway, EnemyPool = Empty };
                RoomList.Add(Room_Hallway2);
                RoomList.Add(Room_Hallway2);
                Room Room_SupplyCloset1 = new Room { RoomName = "Room_SupplyCloset1", LootChance = 0.2, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "A supply closet filled with a whole lot of nothing, save for cleaning supplies.", LootPool = LootPool_Storage1, EnemyPool = Empty };
                RoomList.Add(Room_SupplyCloset1);
                RoomList.Add(Room_SupplyCloset1);
                Room Room_SupplyCloset2 = new Room { RoomName = "Room_SupplyCloset2", LootChance = 0.3, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "A supply closet filled with a whole lot of maintenance supplies.", LootPool = LootPool_Storage2, EnemyPool = Empty };
                RoomList.Add(Room_SupplyCloset2);
                Room Room_Armoury1 = new Room { RoomName = "Room_Armoury1", LootChance = 0.5, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "The armoury used to be filled with weapons, but the others took everything during the riot.", LootPool = LootPool_Armoury, EnemyPool = Empty };
                RoomList.Add(Room_Armoury1);
                Room Room_Bedroom1 = new Room { RoomName = "Room_Bedroom1", LootChance = 0.4, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "One of the crewmates' bedrooms. Messy, and mostly just personal trinkets.", LootPool = LootPool_Bedroom, EnemyPool = Empty };
                RoomList.Add(Room_Bedroom1);
                Room Room_Office1 = new Room { RoomName = "Room_Office1", LootChance = 0.3, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "An office, littered with smashed computer hardware and not much else.", LootPool = LootPool_Office, EnemyPool = Empty };
                RoomList.Add(Room_Office1);
                RoomList.Add(Room_Office1);
                RoomList.Add(Room_Office1);
                Room Room_Dining1 = new Room { RoomName = "Room_Dining1", LootChance = 0.5, EnemyChance = 0.5, MaxTicks = 5, Cleared = false, TicksSinceCleared = 0, ImagePath = "One of the dining halls on the ship, littered with blood all over the floor and walsl, alongside some abandoned food.", LootPool = LootPool_Dining, EnemyPool = Empty };
                RoomList.Add(Room_Dining1);


                Room Room_Exit = new Room { RoomName = "The Exit", LootChance = 0, EnemyChance = 0, MaxTicks = 1, Cleared = false, TicksSinceCleared = 0, ImagePath = "null", LootPool = LootPool_Armoury, EnemyPool = Empty };
                #endregion
                #region Setting Up MapGrid
                for (int row = 0; row < GridSize; row++)
                {
                    List<Room> TempRow = new List<Room>();
                    MapGrid.Add(TempRow);
                    for (int col = 0; col < GridSize; col++)
                    {
                        TempRow.Add(RoomList[random.Next(RoomList.Count)]);
                    }
                }
                int EndRoomRandX = random.Next(GridSize);
                int EndRoomRandY = random.Next(GridSize);
                Player.Instance.Pos_x = EndRoomRandX;
                Player.Instance.Pos_y = EndRoomRandY;
                Console.WriteLine(MapGrid.Count);
                MapGrid[EndRoomRandX][EndRoomRandY] = Room_Exit;
                while (Player.Instance.Pos_x == EndRoomRandX && Player.Instance.Pos_y == EndRoomRandY)
                {
                    Player.Instance.Pos_x = random.Next(GridSize);
                    Player.Instance.Pos_y = random.Next(GridSize);
                }
                #endregion
                return (MapGrid);
            }
            else
            {
                return (MapGrid);
            }
        }

        //setup for new game
        public void StartGameNew(string name, int playerClass, bool[] challenges)
        {
            List_Effect = Get_Effects(false);
            List_Item = Get_Items(false);
            List_Attack = Get_Attacks(false);
            List_Item = Get_Items(false);
            List_Enemy = Get_Enemies(false);
            List_Weapon = Get_Weapons(false);

            Player.Instance.Store_Map();
            MapGrid = Player.Instance.Stored_MapGrid;
            

        }

        //unusedd
        public void Scenario_Click()
        {
            
        }

        public void Inspect_Click()
        {

        }

        //processing each room the player steps in (rolling loot dice to see if they find loot, etc)
        public void Process_Room(Room CurrentRoom)
        {
            if (CurrentRoom.RoomName == "The Exit")
            {
                Player.Instance.CurrentState = GridButton_States.Misc;
                Player.Instance.DescriptionString = ($"You found the exit.");
                LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                Player.Instance.Misc_Status = MiscTypes.Exit;
            }
            else
            {
                Random random = new Random();
                if (CurrentRoom.LootChance > 0)
                {
                    double LootDice = random.NextDouble();
                    if (LootDice > CurrentRoom.LootChance)
                    {
                        Player.Instance.CurrentState = GridButton_States.Misc;
                        Player.Instance.CurrentLoot = null;

                        List<Item> TempItemList = Enumerable.ToList(CurrentRoom.LootPool.Keys);
                        Player.Instance.CurrentLoot = TempItemList[random.Next(TempItemList.Count)];
                        Player.Instance.CurrentState = GridButton_States.Misc;
                        Player.Instance.DescriptionString = ($"You found a {Player.Instance.CurrentLoot.ItemName}.");
                        LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                        Player.Instance.Misc_Status = MiscTypes.Loot;
                    }

                }
            }
        }

        public void CloseForm()
        {
            form1.CloseForm();
        }
        //unused
        public void Initiate_Combat(Enemy NewEnemy)
        {
            Enemy CurrentEnemy = NewEnemy;
            Player.CurrentEnemy = NewEnemy;
            Player.CurrentState = GridButton_States.Combat;
        }
        //if exit room, checks if player has the keycard before letting them win
        //if loot room, lets player consume the item, max energy at 100
        //if keycard found, sets keycard found variable to true
        public void Misc_Interaction(Room CurrentRoom, MiscTypes Action, int ActionNumber)
        {
            MiscTypes Action_Type = Action; 
            switch(Action_Type)
            {
                case MiscTypes.Loot:
                    int Action_Number = ActionNumber;
                    switch(Action_Number)
                    {
                        case 10:
                            //Player.Instance.DescriptionString = ($"Your inventory was full, so you decided to leave the {Player.Instance.CurrentLoot.ItemName} be.");
                            //for (int InvIndex = 0; InvIndex < 8; InvIndex++)
                            //{
                            //    if(Player.Instance.GetInventory()[InvIndex].ItemName == Get_Items(false)["Null"].ItemName);
                            //    {
                            //        Player.Instance.SetInventory(InvIndex, Player.Instance.CurrentLoot);
                            //        Player.Instance.DescriptionString = ($"You picked up the  {Player.Instance.CurrentLoot.ItemName}");
                            //        LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                            //        break;
                            //    }
                            //}
                            if(Player.Instance.CurrentLoot.ItemName == "Exit Keycard" )
                            {
                                Player.Instance.QuickFix_KeycardMoment = true;
                                Player.Instance.DescriptionString = ($"You picked up the  {Player.Instance.CurrentLoot.ItemName}");
                                LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                            }
                            if (Player.Instance.CurrentLoot.Consume_Intensity>0)
                            {
                                Player.Instance.Energy += Player.Instance.CurrentLoot.Consume_Intensity;
                                if(Player.Instance.Energy>100)
                                {
                                    Player.Instance.Energy = 100;
                                }
                                Player.Instance.DescriptionString = ($"You consumed the  {Player.Instance.CurrentLoot.ItemName}");
                                LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                            }

                            Player.Instance.CurrentState = GridButton_States.Navigation;
                        break;
                        case 12:
                            Player.Instance.CurrentState = GridButton_States.Navigation;

                        break;
                    }
                    break;
                case MiscTypes.Exit:
                    Action_Number = ActionNumber;
                    switch (Action_Number)
                    {
                        case 10:
                            Player.Instance.DescriptionString = ($"You couldn't get the exit to open in any way.");
                            //for (int InvIndex = 0; InvIndex < 8; InvIndex++)
                            //{
                            //    if (Player.Instance.GetInventory()[InvIndex] == Get_Items(true)["Exit Keycard"]);
                            //    {
                            //        Player.Instance.DescriptionString = ($"You put the keycard into the slot, and the door opened.");
                            //        break;
                            //    }
                            //}
                            if(Player.Instance.QuickFix_KeycardMoment == true)
                            {
                                Player.Instance.DescriptionString = ($"You put the keycard into the slot, and the door opened.");
                                Player.Instance.Win = true;
                                break;
                            }

                            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                            Player.Instance.CurrentState = GridButton_States.Navigation;
                            LogicToDisplay.Instance.LabelText("You successfully escaped.");
                            form1.Close();
                            break;
                        case 12:
                            Player.Instance.CurrentState = GridButton_States.Navigation;

                            break;
                    }
                    break;
            }
        }

        //unused
        public void Combat_Interaction(Enemy CurrentEnemy, int ActionNumber)
        {

        }

        //lets player move around if they are alive, and it won't allow the player to go out of the generated map
        public void Navigate(Room CurrentRoom, int Action)
        {
            if(Player.Instance.Health>0&&Player.Instance.Win==false)
            {

            
            Player.Instance.UpdateTick();
            int Action_Number = Action;
                switch (Action_Number)
                {
                    case 2:
                        if (0 < Player.Instance.Pos_y)
                        {
                            Player.Instance.Pos_y -= 1;
                            Process_Room(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y]);
                        }
                        else
                        {
                            Player.Instance.DescriptionString = ("The bulkhead ahead is sealed shut. You'll have to go another way.");
                            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);

                        }
                        break;
                    case 4:
                        if (0 < Player.Instance.Pos_x)
                        {
                            Player.Instance.Pos_x -= 1;
                            Process_Room(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y]);
                        }
                        else
                        {
                            Player.Instance.DescriptionString = ("The bulkhead ahead is sealed shut. You'll have to go another way.");
                            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                        }
                        break;
                    case 6:
                        if (GridSize - 1 > Player.Instance.Pos_x)
                        {
                            Player.Instance.Pos_x += 1;
                            Process_Room(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y]);
                        }
                        else
                        {
                            Player.Instance.DescriptionString = ("The bulkhead ahead is sealed shut. You'll have to go another way.");
                            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                        }
                        break;
                    case 8:
                        if (GridSize - 1 > Player.Instance.Pos_y)
                        {
                            Player.Instance.Pos_y += 1;
                            Process_Room(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y]);
                        }
                        else
                        {
                            Player.Instance.DescriptionString = ("The bulkhead ahead is sealed shut. You'll have to go another way.");
                            LogicToDisplay.Instance.LabelText(Player.Instance.DescriptionString);
                        }
                        break;
                }
            }
        }

        //processes .NET button inputs depending on the situation.
        public void Process_Action(int Action)
        {
            int Action_Number = Action;

            switch (Action_Number)
            {
                #region Navigation 
                case 2:
                    Navigate(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][ Player.Instance.Pos_y], Action_Number);
                    break;
                case 4:
                    Navigate(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][Player.Instance.Pos_y], Action_Number);
                    break;
                case 6:
                    Navigate(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][ Player.Instance.Pos_y], Action_Number);
                    break;
                case 8:
                    Navigate(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][ Player.Instance.Pos_y], Action_Number);
                    break;
                #endregion
                case 10:
                    Misc_Interaction(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][ Player.Instance.Pos_y], Player.Instance.Misc_Status, Action_Number);
                    break;
                case 12:
                    Misc_Interaction(Player.Instance.Stored_MapGrid[Player.Instance.Pos_x][ Player.Instance.Pos_y], Player.Instance.Misc_Status, Action_Number);
                    break;
                //case 19:
                //    Combat_Interaction(Player.Instance.CurrentEnemy, Action_Number);
                //    break;
                //case 20:
                //    Combat_Interaction(Player.Instance.CurrentEnemy, Action_Number);
                //    break;
                //case 21:
                //    Combat_Interaction(Player.Instance.CurrentEnemy, Action_Number);
                //    break;
                //adding combat later cos fuck this shit




            }
        }

        public void Button9_Pressed(int button)
        {
            Process_Action(Actions[Player.Instance.CurrentState][button]);
        }


    }

    public class Player
    {
        //setup
        private static Player instance = null;
        private static readonly object padlock = new object();

        Player()
        { }

        public static Player Instance
        {

            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Player();
                        MainGameHandling game = new MainGameHandling();
                    }
                }
                return instance;
            }
        }



        public string PlayerName;
        public int Health;
        public int Energy;
        public int EnergyPerTick;
        public int Pos_x;
        public int Pos_y;
        public int AttackMult;
        public int DamageMult;
        private string _desc;
        public string DescriptionString = "This bullshit doesn't work and i'm this close to just ending it all so press this to view the current situation text shit";
        public Item[] Inventory = new Item[8];
        public Effect[] EffectsList;
        public Weapon EquippedPrimary;// = MainGameHandling.Instance.List_Weapon["Null"];
        public Weapon EquippedSecondary;// = MainGameHandling.Instance.List_Weapon["Null"];
        public List<List<Room>> Stored_MapGrid;
        public Item CurrentLoot;
        public bool QuickFix_KeycardMoment = false;
        public bool Win = false;

        public Enemy CurrentEnemy;
        public MiscTypes Misc_Status;

        private GridButton_States currentState;

        public GridButton_States CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value; // Update the underlying field
                switch (currentState)
                {
                    case GridButton_States.Navigation:
                        SwitchStates(currentState);
                        break;
                    case GridButton_States.Combat:
                    case GridButton_States.Misc:
                    case GridButton_States.Inventory:
                    case GridButton_States.InvItem:
                        SwitchStates(currentState);
                        break;
                }
            }
        }

        public Panel_States CurrentPanel;

        //unused
        public void SetInventory(int Index, Item ItemToSet)
        {
            Inventory[Index] = ItemToSet;
            for (int InvIndex = 0; InvIndex < 8; InvIndex++)
            {
                Console.WriteLine(Inventory[InvIndex].ItemName);

            }
        }
        //unused
        public Item[] GetInventory()
        {
            return Inventory;
        }

        
        public (string, GridButton_States) Get_DescString()
        {
            return (DescriptionString, CurrentState);
        }
        public void SwitchStates(GridButton_States state)
        {
            LogicToDisplay.Instance.SwitchStates(state);
        }

        //properly sets the map so it doesn't turn to null like C# loves to do
        public void Store_Map()
        {
            Stored_MapGrid = MainGameHandling.Instance.Get_Rooms(false);

        }
        public List<List<Room>> ReturnRoom()
        {
            return Stored_MapGrid;
        }
        //polishes up player setup to initialise game
        public Player InitialPlayerSetup(bool loadPlayer, Item NullItem)
        {
            for (int InvIndex = 0; InvIndex < 8; InvIndex++)
            {
                Inventory[InvIndex] = MainGameHandling.Instance.Get_Items(false)["Null"];
            }
            CurrentLoot = null;

            var PlayerStats = new Dictionary<StatTypes, int>
            {
                {StatTypes.STR, 5},
                {StatTypes.DEX, 5},
                {StatTypes.INT, 5},
                {StatTypes.CHA, 5}
            };
            Health = 100;
            Energy = 100;
            EnergyPerTick = 3;
            AttackMult = 1;
            DamageMult = 1;
            DescriptionString = "test"; 
            

            return instance;
        }

        public void LoadPlayerData()
        {
            //nothing atm, might add in next update
        }
        public void EndGame_PlayerDeath()
        {
            MessageBox.Show("You collapse onto the ground, dead.");
            MainGameHandling.Instance.CloseForm();
        }
        //tick update, takes away energy, and health if needed, kills the player if health is zero, would have also applied effects but effects aren't implemented
        public void UpdateTick()
        {
            Energy = Energy - EnergyPerTick;
            if (Energy < 0)
            {
                Health = Health + Energy;
                Energy = 0;
            }
            if (Health <= 0)
            {
                Health = 0;
                EndGame_PlayerDeath();
            }


            //cba to add effects either
            //if (EffectsList.OfType<Effect>().Any())
            //{
            //    for (int EffectIndex = 0; EffectIndex <= EffectsList.Count(); EffectIndex++)
            //    {
            //        EffectsList[EffectIndex].Function(EffectsList[EffectIndex].Name, EffectsList[EffectIndex].EffectData.Intensity, EffectsList[EffectIndex].EffectData.Duration, EffectsList[EffectIndex].EffectData.Description);
            //    }
            //}

            for (int row = 0; row < MainGameHandling.Instance.GridSize; row++)
            {
                for (int col = 0; col < MainGameHandling.Instance.GridSize; col++)
                {
                    if (row == Pos_x && col == Pos_y)
                    {
                    }
                    else
                    {
                        if(MainGameHandling.Instance.MapGrid[row][ col].Cleared == true)
                        {
                            MainGameHandling.Instance.MapGrid[row][ col].TicksSinceCleared += 1;
                            if (MainGameHandling.Instance.MapGrid[row][ col].TicksSinceCleared == MainGameHandling.Instance.MapGrid[row][ col].MaxTicks)
                            {
                                MainGameHandling.Instance.MapGrid[row][ col].TicksSinceCleared = 0;
                                MainGameHandling.Instance.MapGrid[row][ col].Cleared = false;
                            }
                        }
                        
                    }
                }
            }
        }
    }

    #region Enums, Classes and whatnot

    public class TextArg : EventArgs
    {
        public string Message { get; set; }
        public TextArg(string message)
        {
            this.Message = message;
        }
    }
    public enum StatTypes
    {
        STR,
        DEX,
        INT,
        CHA
    }
    public enum GridButton_States
    {
        Navigation,
        Combat,
        Misc,
        Inventory,
        InvItem
    };
    public enum Panel_States
    {
        Scenario,
        Inspect
    };
    #endregion
    #region Classes
    public class Attack
    {
        public string Name;
        public int BaseDamage;
        public int Multiplier;
        public StatTypes StatType;
        public Effect Effect;
        public EffectData EffectData;
        public string Description;
    }

    public class EffectData
    {
        public string Name;
        public string Description;
        public int Intensity;
        public int Duration;
    }

    public class Effect
    {
        public Action<string, int, int, string> Function;
        public string Name;
        public string Description;
        public int Intensity;
        public EffectData EffectData;

    }


    public class Item
    {
        public string ItemName;
        public string Description;
        public Effect Effect;
        public int Consume_Intensity;
        public EffectData EffectData;

    }

    public class Weapon
    {
        public string WeaponName;
        public int BaseDamage;
        public Item SourceItem;
        public int Multiplier;
        public StatTypes StatType;
        public bool Ammo;
        public Item AmmoItem;
        public Attack Attack;
    }

    public class Room
    {
        public Dictionary<Enemy, int> EnemyPool;
        public Dictionary<Item, int> LootPool;
        public double EnemyChance;
        public double LootChance;
        public string RoomName;
        public string ImagePath;
        public int MaxTicks;

        public bool Cleared;
        public int TicksSinceCleared;
    }

    public class Enemy
    {
        internal string EnemyName;
        internal Attack[] Attacks;
        internal Dictionary<StatTypes, int> Stats = new Dictionary<StatTypes, int>
        {
            {StatTypes.STR, 5},
            {StatTypes.DEX, 5},
            {StatTypes.INT, 5},
            {StatTypes.CHA, 5}
        };
        public string Description;
        public string ImagePath;

    }                                                
    #endregion
}