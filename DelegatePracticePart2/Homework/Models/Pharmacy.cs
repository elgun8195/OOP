using Homework.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Models
{
    internal class Pharmacy
    {
        private List<Medicine> _medicines;

        public int MedicineLimit { get; set; }

        public Pharmacy(int medicineLimit)
        {
            _medicines = new List<Medicine>();
            MedicineLimit = medicineLimit;
        }

        public void AddMedicine(Medicine medicine)
        {
            if (medicine == null)
                throw new NullReferenceException("medicene null ola bilmez");

            if (_medicines.Exists(m => m.Name == medicine.Name && !m.IsDeleted))
                throw new MedicineAlreadyExistsException("bu addda derman var");

            if(_medicines.Count < MedicineLimit)
            {
                _medicines.Add(medicine);
                return;
            }

            throw new CapacityLimitException("limit doldu");
        }
        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicinesCopy = new List<Medicine>();
            //List<Medicine> list = _medicines.FindAll(m => !m.IsDeleted);
            medicinesCopy.AddRange(_medicines.FindAll(m => !m.IsDeleted));

            return medicinesCopy;
        }
        public List<Medicine> FilterMedicinesByPrice(double minPrice, double maxPrice)
        {
            return _medicines.FindAll(m => !m.IsDeleted && m.Price >= minPrice && m.Price <= maxPrice);
        }
        public Medicine GetMedicineById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            return _medicines.Find(m => !m.IsDeleted && m.Id == id);
        }
        public void DeleteMedicineById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            Medicine medicine = _medicines.Find(m => !m.IsDeleted && m.Id == id);
            if (medicine == null)
                throw new NotFoundException("bele bir derman yoxdur");

            medicine.IsDeleted = true;
        }
        public void EditMedicineName(int? id, string name)
        {
            if (id == null || string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("id ve name null ola bilmez");

            Medicine medicine = _medicines.Find(m => !m.IsDeleted && m.Id == id);
            if (medicine == null)
                throw new NotFoundException("bele bir derman yoxdur");

            medicine.Name = name;
        }
    }
}
