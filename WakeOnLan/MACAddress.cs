using System;

namespace WakeOnLan {
    public class MACAddress {
        private readonly byte[] _bytes;

        public MACAddress(byte[] bytes) {
            if (bytes.Length != 6) {
                throw new ArgumentException("MAC address must have 6 bytes");
            }
            this._bytes = bytes;
        }

        public byte this[int i] {
            get { return _bytes[i]; }
            set { _bytes[i] = value; }
        }

        public override string ToString() {
            return BitConverter.ToString(_bytes, 0, 6);
        }
    }
}
