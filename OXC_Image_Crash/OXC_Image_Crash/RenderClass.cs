using ClickableTransparentOverlay;
using ImGuiNET;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System;
using System.Security;
using Veldrid.MetalBindings;
using TextCopy;

namespace OXC_Image_Crash
{
    public class GUI_Renderer : Overlay
    {
        //Hotkey Stuff
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vkey);

        //dont do shit here go to Config
        public static bool logerror = true;
        public static bool logsuccess = true;

        public static bool RGBtext;
        public static bool RGBBorder = true;
        public static bool RGBButtons = true;
        public static Vector4 MenuColor = new Vector4(1f, 1f, 1f, 1f);

        float rainbowSpeed = 1;
        float hue = 0.0f;
        bool show = true;
        Vector2 size = new Vector2(600, 320);

        private static string UserID = "UserID";


        //Menu Renderer
        protected override void Render()
        {
            if (GetAsyncKeyState(0x09) < 0)
            {
                show = !show;
                Thread.Sleep(250);
            }
            if (show)
            {
                //Title
                ImGui.Begin($"OXC_Crash_Tool", ImGuiWindowFlags.NoResize);
                ImGui.Text(DateTime.Now.ToString() + $" || {Misc.OnlinePlayers} Players Online");
                if (ImGui.Button("Save Changes"))
                {
                    //some code that saves a Dunno MenuConfig.txt file with all the menu apperiance Variables
                }
                //Style
                ImGuiStylePtr style = ImGui.GetStyle();
                style.Alpha = 1f;
                style.WindowBorderSize = 2f;
                style.WindowRounding = 10f;
                style.FrameRounding = 10f;
                style.AntiAliasedLines = true;
                style.Colors[(int)ImGuiCol.Button] = new Vector4(0, 0.1f, 0.5f, 0.7f);
                style.Colors[(int)ImGuiCol.CheckMark] = new Vector4(255, 255, 255, 1f);
                style.Colors[(int)ImGuiCol.TitleBgActive] = MenuColor - new Vector4(0, 0.1f, 0.5f, 0.8f);
                style.Colors[(int)ImGuiCol.Text] = MenuColor + new Vector4(0, 0.1f, 0.5f, 0.7f);
                ImGui.SetNextWindowSize(size);

                //Menu Settings
                ImGui.BeginChild("Menu Settings", new Vector2(200, 140), true);
                ImGui.Text("Menu Settings");
                if (RGBBorder || RGBButtons || RGBtext)
                {
                    Vector3 RGBColor = HSVToRGB(hue, 1.0f, 1.0f);
                    hue += rainbowSpeed / 360.0f;
                    Vector4 Rainbow = new Vector4(RGBColor.X, RGBColor.Y, RGBColor.Z, 0.3f);



                    //Menu Appearance RGB Buttons Start
                    if (RGBBorder) {
                        style.Colors[(int)ImGuiCol.Border] = Rainbow; style.Colors[(int)ImGuiCol.TitleBgActive] = Rainbow;
                    }
                    if (RGBButtons) {
                        style.Colors[(int)ImGuiCol.CheckMark] = Rainbow + new Vector4(0, 0, 0, 0.8f); style.Colors[(int)ImGuiCol.Button] = Rainbow;
                    }
                    if (RGBtext)
                    {
                        style.Colors[(int)ImGuiCol.Text] = Rainbow;
                    }
                    //Menu Appearance RGB Buttons Stop
                }
                else { style.Colors[(int)ImGuiCol.Border] = MenuColor; style.Colors[(int)ImGuiCol.Text] = MenuColor + new Vector4(0, 0.1f, 0.5f, 0.7f); }

                //RGB Buttons
                ImGui.Checkbox("RGB Text", ref RGBtext); ImGui.Checkbox("RGB Border", ref RGBBorder); ImGui.Checkbox("RGB Buttons", ref RGBButtons);

                //Rainbow Speed Slider
                ImGui.Text("Rainbow Speed :"); ImGui.SliderFloat("", ref rainbowSpeed, 0.1f, 10f);

                //Menu Color Sliders
                ImGui.Text("Menu Appearance");
                ImGui.SliderFloat("Red", ref MenuColor.X, 0.01f, 1f); ImGui.SliderFloat("Green", ref MenuColor.Y, 0.01f, 1f); ImGui.SliderFloat("Blue", ref MenuColor.Z, 0.01f, 1f);
                ImGui.ColorButton("My Penis is Very Big", MenuColor, ImGuiColorEditFlags.None, new Vector2(200, 10));

                ImGui.EndChild();
                ImGui.SameLine();

                //BotUtils
                ImGui.BeginChild("BotUtils", new Vector2(375, 140), true);
                ImGui.Text("BotUtils");
                ImGui.InputTextMultiline("", ref UserID, 100, new Vector2(175, 20), ImGuiInputTextFlags.NoHorizontalScroll);
                ImGui.SameLine();
                if (ImGui.Button("Paste Clipboard")) { String User = ClipboardService.GetText().ToString(); UserID = User; }
                if (ImGui.Button("Crash User"))
                {
                    Misc.CrashUser(UserID);
                }
              
                ImGui.EndChild();
                ImGui.BeginChild("Console Settings", new Vector2(200, 100), true);
                ImGui.Text("Console Settings");
                ImGui.Checkbox("Log Error", ref logerror); //log errors
                ImGui.Checkbox("Log Success", ref logsuccess); //log success
                ImGui.EndChild();
                ImGui.EndMenu();
            }
        }
        private Vector3 HSVToRGB(float hue, float saturation, float value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue * 6));
            float f = hue * 6 - hi;
            float p = value * (1 - saturation);
            float q = value * (1 - f * saturation);
            float t = value * (1 - (1 - f) * saturation);
            float r, g, b;
            switch (hi)
            {
                case 0:
                    r = value;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value;
                    break;
                default:
                    r = value;
                    g = p;
                    b = q;
                    break;
            }
            return new Vector3(r, g, b);
        }
    }
}