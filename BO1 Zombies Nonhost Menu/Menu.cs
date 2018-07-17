using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using PS3Lib;

namespace BO1_Zombies_Nonhost_Menu
{
    public class Menu
    {
        private static PS3API PS3 = mainform.PS3;
        private static List<List<Option>> MenuStruct = new List<List<Option>>();
        private static bool Menu_Open = false;
        private static int Scroller_Index = 0;
        private static int Menu_Index = 0;

        private static bool Godmode = false;
        private static bool Noclip = false;
        private static bool UFO = false;
        private static bool Thirdperson = false;
        private static int FOV = 65;
        private static bool Notarget = false;


        enum Buttons
        {
            Cross = 0xB4EB83,
            Circle = 0xB4EB93,
            Square = 0xB4EBA3,
            Triangle = 0xB4EBB3,
            L1 = 0xB4EBC3,
            R1 = 0xB4EBD3,
            L2 = 0xB4EC93,
            R2 = 0xB4ECA3,
            Up = 0xB4ECB3,
            Down = 0xB4ECC3,
            Left = 0xB4ECD3,
            Right = 0xB4ECE3
        }

        enum DPADDuration
        {
            Up = 0xB4ECB6,
            Down = 0xB4ECC6,
            Left = 0xB4ECD6,
            Right = 0xB4ECE6
        }

        public class FPS
        {
            public static float X
            {
                get { return PS3.Extension.ReadFloat(0x00827950); }
                set { PS3.Extension.WriteFloat(0x00827950, value); }
            }

            public static float Y
            {
                get { return PS3.Extension.ReadFloat(0x00827958); }
                set { PS3.Extension.WriteFloat(0x00827958, value); }
            }

            public static void EnableFPS()
            {
                PS3.SetMemory(0x00407554, new byte[] { 0x40, 0x00 });
            }

            public static void DisableFPS()
            {
                PS3.SetMemory(0x00407554, new byte[] { 0x40, 0x9A });
            }

            public static string Text
            {
                get { return PS3.Extension.ReadString(0x008283a8); }
                set { PS3.Extension.WriteString(0x008283a8, value); }
            }
        }

        class Option
        {
            public string optionText;
            public Action optionFunction;
            public object optionParameter;

            public Option(string optText, Action optFunc, object optParam)
            {
                optionText = optText;
                optionFunction = optFunc;
                optionParameter = optParam;
            }
        }

        public static void Submenu()
        {
            //Scroller_Index = 0;
            Menu_Index = (int)MenuStruct[Menu_Index][Scroller_Index].optionParameter;
            Scroller_Index = 0;
            UpdateMenu();
        }

        public static void Menu_Struct()
        {
            List<Option> main_menu = new List<Option>();
            main_menu.Add(new Option("Godmode", ToggleGodmode, null));
            main_menu.Add(new Option("Noclip", ToggleNoclip, null));
            main_menu.Add(new Option("UFO", ToggleUFO, null));
            main_menu.Add(new Option("Third Person", ToggleThirdperson, null));
            main_menu.Add(new Option("Toggle FOV", ToggleFOV, null));
            main_menu.Add(new Option("No Target", ToggleNotarget, null));
            main_menu.Add(new Option("Give Ammo", GiveItem, "ammo"));
            main_menu.Add(new Option("Perks Menu", Submenu, 1));
            main_menu.Add(new Option("Weapons Menu", Submenu, 2));

            List<Option> perks_menu = new List<Option>();
            perks_menu.Add(new Option("Juggernog", GiveItem, "zombie_perk_bottle_doubletap"));

            List<Option> weapons_menu = new List<Option>();
            weapons_menu.Add(new Option("Raygun", GiveItem, "ray_gun_zm"));
            weapons_menu.Add(new Option("Thundergun", GiveItem, "thundergun_upgraded_zm "));
            weapons_menu.Add(new Option("Wunderwaffe", GiveItem, "tesla_gun_upgraded_zm"));
            weapons_menu.Add(new Option("Mustang & Sally", GiveItem, "m1911_upgraded_zm "));
            weapons_menu.Add(new Option("Monkeys", GiveItem, "zombie_cymbal_monkey"));
            weapons_menu.Add(new Option("Minigun", GiveItem, "minigun_zm"));

            MenuStruct.Add(main_menu);
            MenuStruct.Add(perks_menu);
            MenuStruct.Add(weapons_menu);
        }

        public static void MenuLoop()
        {
            Menu_Struct();

            PS3.ConnectTarget();//Don't know why, but these are needed again..?
            PS3.AttachProcess();
            RPC.Init();

            while (true)
            {
                
                Thread.Sleep(100);

                if (Menu_Open)//If menu is opened
                {
                    //If left is held (Close menu / go back a menu)
                    if (buttonPressed(Buttons.Left))
                    {
                        Console.WriteLine("DPAD LEFT pressed");
                        Menu_Index = 0;
                        Scroller_Index = 0;
                        FPS.Text = "Hold RIGHT to open";
                        Menu_Open = false;
                    }

                    //If dpad up is pressed (scroll up)
                    if (buttonPressed(Buttons.Up))
                    {
                        Console.WriteLine("DPAD UP pressed");
                        Scroller_Index = (Scroller_Index != 0) ? Scroller_Index - 1 : MenuStruct[Menu_Index].Count - 1;
                        UpdateMenu();
                    }

                    //If dpad down is pressed (scroll down)
                    if (buttonPressed(Buttons.Down))
                    {
                        Console.WriteLine("DPAD DOWN pressed");
                        Scroller_Index = (Scroller_Index != MenuStruct[Menu_Index].Count - 1) ? Scroller_Index + 1 : 0;
                        UpdateMenu();
                    }

                    //If square is pressed (select)
                    if (buttonPressed(Buttons.Square))
                    {
                        Console.WriteLine("SQUARE pressed");
                        MenuStruct[Menu_Index][Scroller_Index].optionFunction?.Invoke();
                    }
                }
                else //if menu is closed
                {
                    //If dpad right is held (Open menu)
                    if (buttonPressed(Buttons.Right))
                    {
                        Console.WriteLine("DPAD RIGHT pressed");
                        Menu_Index = 0;
                        Scroller_Index = 0;
                        UpdateMenu();
                        Menu_Open = true;
                    }
                }
            }
        }

        private static void UpdateMenu()
        {
            string text = "^5[DUKE'S FPS MENU]^7\n";//title as the first line
            for(int i=0; i<MenuStruct[Menu_Index].Count; i++)
            {
                if (i == Scroller_Index)
                    text = text + "^1" + MenuStruct[Menu_Index][i].optionText + "^7\n";
                else
                    text = text + MenuStruct[Menu_Index][i].optionText + "\n";
            }
            FPS.Text = text;
        }

        private static bool buttonPressed(Buttons button)
        {
            byte[] buffer = PS3.GetBytes((uint)button, 1);
            if (buffer[0] == 0x01)
                return true;
            return false;
        }

        private static int dpad_pressDuration(DPADDuration button)
        {
            return PS3.Extension.ReadInt16((uint)button);
        }

        private static void GiveItem()
        {
            string itemname = (string)MenuStruct[Menu_Index][Scroller_Index].optionParameter;
            RPC.Cbuff_AddText(0, "give " + itemname);
        }

        private static void ToggleGodmode()
        {
            Godmode = !Godmode;
            RPC.Cbuff_AddText(0, "god " + (Godmode ? "ON" : "OFF"));
        }

        private static void ToggleNoclip()
        {
            Noclip = !Noclip;
            RPC.Cbuff_AddText(0, "noclip " + (Noclip ? "ON" : "OFF"));
        }

        private static void ToggleUFO()
        {
            UFO = !UFO;
            RPC.Cbuff_AddText(0, "ufo " + (UFO ? "ON" : "OFF"));
        }

        private static void ToggleThirdperson()
        {
            Thirdperson = !Thirdperson;
            RPC.Cbuff_AddText(0, "cg_thirdPerson " + (Thirdperson ? "ON" : "OFF"));
        }

        private static void ToggleFOV()
        {
            if (FOV == 65)
                FOV = 80;
            else if (FOV == 80)
                FOV = 90;
            else if (FOV == 90)
                FOV = 120;
            else
                FOV = 65;
            RPC.Cbuff_AddText(0, "cg_fov " + FOV.ToString());
        }

        private static void ToggleNotarget()
        {
            Notarget = !Notarget;
            RPC.Cbuff_AddText(0, "notarget " + (Notarget ? "ON" : "OFF"));
        }
    }
}
