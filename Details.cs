using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Project2
{

    interface Details
    {
        int Id { get; set; }
        string Name { get; set; }

        void AddBook();

        void RemoveBook();

        void SearchBook();

        void Borrow();

        void ReturnBook();
    }
}
