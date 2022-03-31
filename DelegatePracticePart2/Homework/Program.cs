using Homework.Exceptions;
using Homework.Models;
using System;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Medicine medicine1 = new Medicine() 
           {
               Name = "test1",
               Price = 12,
               Count = 5,
               IsDeleted = false
           };
            Medicine medicine2 = new Medicine()
            {
                Name = "test2",
                Price = 13,
                Count = 6,
                IsDeleted = false
            };
            Medicine medicine3 = new Medicine()
            {
                Name = "test3",
                Price = 22,
                Count = 2,
                IsDeleted = false
            };

            Pharmacy pharmacy = new Pharmacy(3);

            try
            {
                pharmacy.AddMedicine(medicine1);
                pharmacy.AddMedicine(medicine2);
                pharmacy.AddMedicine(medicine3);
                //pharmacy.DeleteMedicineById(1);
                //pharmacy.EditMedicineName(2, "testest");
                //pharmacy.GetMedicineById(1).ShowInfo();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(CapacityLimitException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(MedicineAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var item in pharmacy.GetAllMedicines())
            {
                item.ShowInfo();
            }
            Console.WriteLine("-----");
            foreach (var item in pharmacy.FilterMedicinesByPrice(10, 20))
            {
                item.ShowInfo();
            }
        }
    }
}
