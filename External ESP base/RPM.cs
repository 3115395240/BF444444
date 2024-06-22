/////////////XTREME HACK////////////////
///////////unknowncheats.me/////////////

using SharpDX;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace External_ESP_Base
{
    class RPM
    {
        private static IntPtr pHandle = IntPtr.Zero;

        public static IntPtr OpenProcess(int pId)
        {
            pHandle = Managed.OpenProcess(Managed.PROCESS_VM_READ | Managed.PROCESS_VM_WRITE | Managed.PROCESS_VM_OPERATION, false, pId);
            return pHandle;
        }

        public static IntPtr GetHandle()
        {
            return pHandle;
        }

        public static void CloseProcess()
        {
            Managed.CloseHandle(pHandle);
        }

        public static T Read<T>(Int64 address)
        {
            byte[] Buffer = new byte[Marshal.SizeOf(typeof(T))];
            IntPtr ByteRead;
            Managed.ReadProcessMemory(pHandle, address, Buffer, (uint)Buffer.Length, out ByteRead);

            // Get Struct from Buffer
            GCHandle handle = GCHandle.Alloc(Buffer, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            // Return
            return stuff;
        }

        public static bool Write<T>(Int64 address, T t)
        {
            Byte[] Buffer = new Byte[Marshal.SizeOf(typeof(T))];
            GCHandle handle = GCHandle.Alloc(t, GCHandleType.Pinned);
            Marshal.Copy(handle.AddrOfPinnedObject(), Buffer, 0, Buffer.Length);
            handle.Free();

            uint oldProtect;
            Managed.VirtualProtectEx(pHandle, (IntPtr)address, (uint)Buffer.Length, Managed.PAGE_READWRITE, out oldProtect);
            IntPtr ptrBytesWritten;
            return Managed.WriteProcessMemory(pHandle, address, Buffer, (uint)Buffer.Length, out ptrBytesWritten);
        }

        public static void WriteAngle(float _Yaw, float _Pitch)
        {
            Int64 pBase = Read<Int64>(Offsets.OFFSET_VIEWANGLES);
            Int64 m_authorativeAiming = Read<Int64>(pBase + Offsets.ClientSoldierWeapon.m_authorativeAiming);
            Int64 m_fpsAimer = Read<Int64>(m_authorativeAiming + Offsets.ClientSoldierAimingSimulation.m_fpsAimer);
            
            Write<float>(m_fpsAimer + Offsets.AimAssist.m_yaw, _Yaw);
            Write<float>(m_fpsAimer + Offsets.AimAssist.m_pitch, _Pitch);
        }

        public static string ReadName(Int64 address, UInt64 _Size)
        {
            byte[] buffer = new byte[_Size];
            IntPtr BytesRead;

            Managed.ReadProcessMemory(pHandle, address, buffer, _Size, out BytesRead);

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0)
                {
                    byte[] _buffer = new byte[i];
                    Buffer.BlockCopy(buffer, 0, _buffer, 0, i);
                    return Encoding.ASCII.GetString(_buffer);
                }
            }
            return Encoding.ASCII.GetString(buffer);
        }

        public static string ReadString(Int64 address, UInt64 _Size)
        {
            byte[] buffer = new byte[_Size];
            IntPtr BytesRead;

            Managed.ReadProcessMemory(pHandle, address, buffer, _Size, out BytesRead);
            return Encoding.ASCII.GetString(buffer);
        }

        public static bool IsValid(Int64 Address)
        {
            return (Address >= 0x10000 && Address < 0x000F000000000000);
        } 
    }
}
