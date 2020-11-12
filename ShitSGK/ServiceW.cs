using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShitSGK.Database;

namespace ShitSGK
{
    public class ServiceW
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Cost1 { get; set; }
        public String Cost2 { get; set; }
        public String Time { get; set; }
        public String CostString { get; set; }
        public String ImgSrc { get; set; }

        public string btn_edit { get; set; }
        public string btn_delete { get; set; }
        public string btn_write { get; set; }
        public string ImagePath { get; set; }

        public ServiceW(Database.Service service)
        {
            ID = service.ID;
            Name = service.Title;
            Cost1 = GetCost1(service);
            Cost2 = GetCose2(service);
            Time = GetTime(service);
            CostString = GetCostString(service);
            ImagePath = GetImagePath(service);

            btn_delete = "Visible";
            btn_edit = "Visible";
            btn_write = "Visible";
        }

        private string GetImagePath(Service service)
        {
            if (service.MainImagePath != null )
            {
                return service.MainImagePath;
            }
            else
            {
                return "NoImage.png";
            }
             
        }

        private string GetCostString(Service service)
        {
            if (service.Discount != null && service.Discount > 0)
            {
                return service.Discount * 100 + "%";
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetTime(Service service)
        {
            return " руб за " +  service.DurationInSeconds / 60 + " мин";
        }

        //проверка цены
        private string GetCose2(Service service)
        {
            if (service.Discount != null && service.Discount >0)
            {
                decimal realcost = service.Cost * (Convert.ToDecimal(1) - Convert.ToDecimal(service.Discount));
                return Math.Round(realcost, 2).ToString();
            }
            else
            {
                return service.Cost.ToString();
            }
        }

        //
        private string GetCost1(Service service)
        {
            if (service.Discount!=null && service.Discount >0)
            {
                return service.Cost.ToString();
            }
            else
            {
                return string.Empty;
            }
             
        }
    }
}
