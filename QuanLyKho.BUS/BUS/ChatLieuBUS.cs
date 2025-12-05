using QuanLyKho.DAO;
using QuanLyKho.DTO;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.BUS
{
    public class ChatLieuBUS
    {
        public readonly ChatLieuDAO clieuDAO = ChatLieuDAO.getInstance();
        private BindingList<ChatLieuDTO> chatLieuList;

        public ChatLieuBUS()
        {
            chatLieuList = clieuDAO.SelectAll();
        }
        public BindingList<ChatLieuDTO> getChatLieuList()
        {
            chatLieuList = clieuDAO.SelectAll();
            return chatLieuList;
        }

        public String LayTenChatLieu(SanPhamDTO sp)
        {
            ChatLieuDTO chatLieu;
            chatLieu = chatLieuList.FirstOrDefault(cl => cl.Machatlieu == sp.Machatlieu);
            return chatLieu.Tenchatlieu.ToString();
        }

        public int LayMaChatLieu(String tenCl)
        {
            if (string.IsNullOrEmpty(tenCl) || tenCl == "Tất cả chất liệu")
            {
                return 0;
            }
            ChatLieuDTO chatLieu;
            chatLieu = chatLieuList.FirstOrDefault(cl => cl.Tenchatlieu == tenCl);
            if(chatLieu == null)
            {
                return 0;
            }    
            return chatLieu.Machatlieu;
        }

        

        public BindingList<ChatLieuDTO> searchChatLieu(string keyword)
        {
            List<ChatLieuDTO> result = chatLieuList.Where(cl => cl.Tenchatlieu.ToLower().Contains(keyword.ToLower()) ||
            cl.Machatlieu.ToString().Contains(keyword)).ToList();
            return new BindingList<ChatLieuDTO>(result);
        }

        // Thêm chất liệu mới
        public Boolean insertChatLieu(ChatLieuDTO chatLieu)
        {
            Boolean result = clieuDAO.Insert(chatLieu) != 0;
            if (result)
            {
                chatLieuList.Add(chatLieu);
            }
            return result;
        }

        // Cập nhật chất liệu
        public Boolean updateChatLieu(ChatLieuDTO chatLieuSua)
        {
            Boolean result = clieuDAO.Update(chatLieuSua) != 0;
            if (result)
            {
                var chatLieu = chatLieuList.FirstOrDefault(cl => cl.Machatlieu == chatLieuSua.Machatlieu);
                if (chatLieu != null)
                {
                    chatLieu.Tenchatlieu = chatLieuSua.Tenchatlieu;
                }
            }
            return result;
        }

        // Xóa chất liệu
        public Boolean removeChatLieu(int maChatLieu)
        {
            ChatLieuDTO chatLieuXoa = getChatLieuById(maChatLieu);
            Boolean result = clieuDAO.Delete(maChatLieu) != 0;
            if (result && chatLieuXoa != null)
            {
                chatLieuList.Remove(chatLieuXoa);
            }
            return result;
        }

        // Lấy chất liệu theo ID
        public ChatLieuDTO getChatLieuById(int maChatLieu)
        {
            return clieuDAO.SelectById(maChatLieu);
        }

        // Lấy mã tự động tăng
        public int getAutoMaChatLieu()
        {
            return clieuDAO.GetAutoIncrement();
        }
    }
}
