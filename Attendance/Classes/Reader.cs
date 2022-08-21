using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Classes
{
    public class RFT_230
    {
        [DllImport("MF_API.dll")]
        public static extern int MF_InitComm(String portname, int baud);
        [DllImport("MF_API.dll")]
        public static extern int MF_ExitComm();
        [DllImport("MF_API.dll")]
        public static extern int MF_Request(short DeviceAddr, short mode, ref byte CardType);
        [DllImport("MF_API.dll")]
        public static extern int MF_Anticoll(short DeviceAddr, ref byte snr);
        [DllImport("MF_API.dll")]
        public static extern int MF_Select(short DeviceAddr, ref Byte snr);
        [DllImport("MF_API.dll")]
        public static extern int MF_LoadKey(short DeviceAddr, ref Byte key);
        [DllImport("MF_API.dll")]

        public static extern int MF_Authentication(short DeviceAddr, short AuthType, short block, ref Byte snr);
        [DllImport("MF_API.dll")]
        public static extern int MF_Read(short DeviceAddr, short block, short numbers, ref Byte databuff);
        [DllImport("MF_API.dll")]
        public static extern int MF_Write(short DeviceAddr, short block, short numbers, ref Byte databuff);

    }
}
