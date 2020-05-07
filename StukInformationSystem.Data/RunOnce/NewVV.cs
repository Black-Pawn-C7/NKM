using System;

namespace StukInformationSystem.Data.RunOnce {
    internal class NewVV {
        public int VVID;
        public DateTime TagDate;
        public bool WS;
        public byte[] Protokoll;

        public NewVV(Random rnd) {
            WS = false;
            var b = new byte[1990];
            rnd.NextBytes(b);
            Protokoll = b;
        }
    }
}