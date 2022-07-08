using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public struct Request
    {
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DisplayName("Номер заявки")]
        public int Request_num { get; set; }

        [DisplayName("Цель обращения")]
        public string Purpose { get; set; }

        [DisplayName("Дата обращения")]
        public string Request_date { get; set; }

        [DisplayName("Дата ответа")]
        public string Answer_date { get; set; }

        [DisplayName("Фамилия работника")]
        public string Empl_surname { get; set; }

        [DisplayName("Имя работника")]
        public string Empl_name { get; set; }

        [DisplayName("Отчество работника")]
        public string Empl_patronymic { get; set; }

        
    }
}
