using QuanLyKho_CSharp.DAO;
using QuanLyKho_CSharp.DTO;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_CSharp.BUS
{
    internal class ChatLieuBUS
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
            if (string.IsNullOrEmpty(tenCl) || tenCl == "Tất cả")
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

        public Boolean insertChatLieu(ChatLieuDTO cl)
        {
            Boolean result = clieuDAO.Insert(cl) != 0;
            if (result)
            {
                chatLieuList.Add(cl);
            }
            return result;
        }

        // Tìm kiếm chất liệu
        public BindingList<ChatLieuDTO> SearchChatLieu(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return chatLieuList;
            }
            
            var result = chatLieuList.Where(cl => 
                cl.Tenchatlieu.ToLower().Contains(searchText.ToLower()) ||
                cl.Machatlieu.ToString().Contains(searchText)).ToList();
            return new BindingList<ChatLieuDTO>(result);
        }
    }
}
