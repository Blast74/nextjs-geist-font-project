using System;
using System.Runtime.InteropServices;
using System.Threading;

class MouseMover
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    static extern bool GetCursorPos(out POINT lpPoint);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Mouse Mover started. Press Ctrl+C to stop.");

        while (true)
        {
            if (GetCursorPos(out POINT currentPos))
            {
                // Move mouse slightly right and back left
                SetCursorPos(currentPos.X + 1, currentPos.Y);
                Thread.Sleep(100);
                SetCursorPos(currentPos.X, currentPos.Y);
            }
            Thread.Sleep(30000); // Wait 30 seconds
        }
    }
}
