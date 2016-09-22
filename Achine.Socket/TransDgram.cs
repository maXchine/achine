namespace Achine.Socket {

    public class TransDgram {

        public string TagId { get; set; }

        public DgramCommand Type { get; set; }

        public int Index { get; set; }

        public int Length { get; set; }

        public byte[] Data { get; set; }
    }
}
