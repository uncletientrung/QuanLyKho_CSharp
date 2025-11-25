using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.DAO
{
    public interface DAOInterface<T>
    {
        int Insert(T t);
        int Update(T t);
        int Delete(int t);
        BindingList<T> SelectAll();
        T SelectById(int t);
        int GetAutoIncrement();
    }
}