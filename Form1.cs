using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BlockchainWinForms
{
    public partial class Form1 : Form
    {
        // Danh sách mô phỏng chuỗi blockchain
        private List<Block> blockchain = new List<Block>();

        public Form1()
        {
            InitializeComponent();

            // Gán trạng thái khởi đầu cho label
            lblStatus.Text = "⏳ Chưa tạo chuỗi blockchain";
            lblStatus.ForeColor = Color.Gray;
        }

        // Nút: Tạo Blockchain mẫu
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            blockchain.Clear(); // Xóa chuỗi cũ

            // Tạo block gốc (Genesis block)
            blockchain.Add(new Block(0, "Genesis Block", "0"));

            // Tạo thêm 4 block tiếp theo (block 1 -> 8)
            for (int i = 1; i <= 8; i++)
            {
                var prev = blockchain[i - 1];
                blockchain.Add(new Block(i, $"Giao dịch {i}", prev.Hash));
            }

            UpdateComboBox();    // Cập nhật danh sách chọn block
            DisplayBlockchain(); // Hiển thị ra màn hình
        }

        // Cập nhật danh sách ComboBox để chọn block cần sửa
        private void UpdateComboBox()
        {
            cboBlockIndex.Items.Clear();
            for (int i = 1; i < blockchain.Count; i++) // Bỏ qua Genesis Block
            {
                cboBlockIndex.Items.Add($"Block {i}");
            }

            if (cboBlockIndex.Items.Count > 0)
                cboBlockIndex.SelectedIndex = 0;
        }

        // Nút: Sửa dữ liệu trong block được chọn
        private void btnTamper_Click(object sender, EventArgs e)
        {
            if (blockchain.Count < 2) return;
            if (cboBlockIndex.SelectedIndex == -1) return;

            int index = cboBlockIndex.SelectedIndex + 1; // Vì bỏ qua block 0
            string newData = txtTamperData.Text.Trim();

            if (string.IsNullOrEmpty(newData))
            {
                MessageBox.Show("Hãy nhập dữ liệu mới để sửa block.");
                return;
            }

            blockchain[index].Data = newData;                      // Cập nhật dữ liệu
            blockchain[index].Hash = blockchain[index].ComputeHash(); // Cập nhật lại hash

            DisplayBlockchain();
            MessageBox.Show($"🔧 Đã sửa dữ liệu Block {index}. Chuỗi bị phá vỡ!");
        }

        // Nút: Cập nhật lại toàn bộ chuỗi từ block 1
        private void btnUpdateChain_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < blockchain.Count; i++)
            {
                blockchain[i].PreviousHash = blockchain[i - 1].Hash;
                blockchain[i].Hash = blockchain[i].ComputeHash();
            }

            DisplayBlockchain();
            MessageBox.Show("✅ Chuỗi đã được cập nhật lại!");
        }

        // Hàm hiển thị toàn bộ blockchain, kiểm tra toàn vẹn và tô màu lỗi
        private void DisplayBlockchain()
        {
            rtbBlocks.Clear();
            bool isValid = true;

            for (int i = 0; i < blockchain.Count; i++)
            {
                var block = blockchain[i];

                string shortHash = block.Hash.Length >= 10 ? block.Hash.Substring(0, 10) : block.Hash;
                string shortPrev = block.PreviousHash.Length >= 10 ? block.PreviousHash.Substring(0, 10) : block.PreviousHash;

                string display = $"Block {block.Index}\n" +
                                 $"Data: {block.Data}\n" +
                                 $"Hash: {shortHash}...\n" +
                                 $"PrevHash: {shortPrev}...";

                // Kiểm tra xem chuỗi có bị sai không (hash không khớp)
                bool blockError = (i > 0 && block.PreviousHash != blockchain[i - 1].Hash);

                if (blockError)
                {
                    display += " [❌ LỖI: Hash không khớp]";
                    rtbBlocks.SelectionColor = Color.Red;
                    isValid = false;
                }
                else
                {
                    rtbBlocks.SelectionColor = Color.Black;
                }

                rtbBlocks.AppendText(display + "\n\n");
            }

            // Ghi trạng thái tổng thể của chuỗi
            lblStatus.Text = isValid ? "✅ Chuỗi hợp lệ" : "❌ Chuỗi bị lỗi";
            lblStatus.ForeColor = isValid ? Color.Green : Color.Red;
        }
    }
}
