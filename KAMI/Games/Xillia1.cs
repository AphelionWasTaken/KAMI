using System;
using KAMI.Cameras;
using KAMI.Utilities;

namespace KAMI.Games
{
    class Xillia1 : Game<HAVACamera>
    {
        const uint BaseAddress = 0xE1552C;

        DerefChain m_hor;
        DerefChain m_vert;

        public Xillia1(IntPtr ipc) : base(ipc)
        {
            var baseChain = DerefChain.CreateDerefChain(ipc, BaseAddress);
            m_hor = baseChain.Chain(0x78);
            m_vert = baseChain.Chain(0x7C);
        }

        public override void UpdateCamera(int diffX, int diffY)
        {
            if (DerefChain.VerifyChains(m_hor, m_vert))
            {
                m_camera.Hor = (float)(IPCUtils.ReadFloat(m_ipc, (uint)m_hor.Value));
                m_camera.Vert = (float)(IPCUtils.ReadFloat(m_ipc, (uint)m_vert.Value));
            
                m_camera.Update(diffX * SensModifier, diffY * SensModifier);

                IPCUtils.WriteFloat(m_ipc, (uint)m_hor.Value, m_camera.Hor);
                IPCUtils.WriteFloat(m_ipc, (uint)m_vert.Value, m_camera.Vert);           
            }
        }
    }
}
