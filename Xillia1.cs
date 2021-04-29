using KAMI.Cameras;
using System;

namespace KAMI.Games
{
    public class Xillia1 : Game<HAVACamera>
    {
        const uint m_address = 0x00E3E64C;

        public Xillia1(IntPtr ipc) : base(ipc)
        {
        }

        public override void UpdateCamera(int diffX, int diffY)
        {
            m_camera.Vert = IPCUtils.ReadFloat(m_ipc, m_address + 4);
            m_camera.Hor = IPCUtils.ReadFloat(m_ipc, m_address);
            m_camera.Update(diffX * SensModifier, diffY * SensModifier);
            IPCUtils.WriteFloat(m_ipc, m_address + 4, m_camera.Vert);
            IPCUtils.WriteFloat(m_ipc, m_address, m_camera.Hor);
        }
    }
}
