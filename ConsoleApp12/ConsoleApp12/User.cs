using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12;


class User
{
    
    public int Id;
    public string Name;
    public string Username;
    public string Email;
    public string Phone;
    public string Website;
    public bool IsDeleted = false;
    /*public User(string username, string name, string email, string phone, string website)
    {
        Username = username;
        Name = name;
        Email = email;
        Phone = phone;
        Website = website;
        Id = _idDefault++;
    }*/

}
/*
 * "id": 1, - private
"name": "Leanne Graham",
"username": "Bret",
"email": "Sincere@april.biz",
"phone": "1-770-736-8031 x56442",
"website": "hildegard.org",


user ve post crud(create, read, udate, delete) => delete soft delete olmalidir.IsDeleted true/false olaraq dəyişməlisiniz.
terminalda render edərkən isDeleted false olanlar görsənməlidir.*/

