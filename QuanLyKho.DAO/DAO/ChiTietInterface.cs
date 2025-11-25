using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO
{
    public interface ChiTietInterface<T>
    {
        int Insert(BindingList<T> list);
        int Delete(int ma);
        int Update(BindingList<T> t, int ma);
        BindingList<T> SelectAll(int ma);

    }
}
