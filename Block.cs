using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainWinForms
{
    public class Block
    {
        // Thứ tự của block trong chuỗi
        public int Index { get; set; }

        // Dữ liệu (ví dụ: nội dung giao dịch)
        public string Data { get; set; }

        // Hash của block trước (liên kết chuỗi)
        public string PreviousHash { get; set; }

        // Hash hiện tại (duy nhất đại diện cho block)
        public string Hash { get; set; }

        // Thời gian tạo block (dùng để tính Hash)
        public string Timestamp { get; set; }

        // Constructor tạo một block mới
        public Block(int index, string data, string previousHash)
        {
            Index = index;
            Data = data;
            PreviousHash = previousHash;
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Hash = ComputeHash(); // Tự động tạo mã Hash khi khởi tạo
        }

        // Phương thức tạo Hash bằng SHA-256
        public string ComputeHash()
        {
            string rawData = Index + Data + PreviousHash + Timestamp;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(rawData);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
