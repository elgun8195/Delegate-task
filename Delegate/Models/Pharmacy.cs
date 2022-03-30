using Delegate.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate.Models
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
        public void Add(Medicine medicine)
        {
            //Medicine medicine 
            Medicine med = _medicines.Find(e => e.Name == medicine.Name);
            if (med!=null)
            {
                throw new MedicineAlreadyExistsException("Artiq var");
            }
            if (_medicines.Count < MedicineLimit)
            {
                _medicines.Add(medicine);
                return;
            }
            throw new CapacityLimitException("Limit Ashildi!");
        }// DONE

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicinesCopy = new List<Medicine>();
            medicinesCopy.AddRange(_medicines);
            return medicinesCopy;
        }// xxxxxxx

        public List<Medicine> FilterMedicinesByPrice(double minPrice, double maxPrice)
        {
            return _medicines.FindAll(e => e.Price >= minPrice && e.Price <= maxPrice);
        }// DONE
        public Medicine GetMedicineById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("Id null ola bilmez axi");

            Medicine medicine = _medicines.Find(e => e.Id == id && e.IsDeleted == false);
            return medicine;

        } // DONE

        public void DeleteMedicineById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            Medicine medicine = _medicines.Find(e => e.Id == id && e.IsDeleted);
            if (!(medicine.Id == id && medicine.IsDeleted))
            {
                throw new NotFoundException("bele bir ishci yoxdur");
            }
            _medicines.Remove(medicine);
        } // xxxxxxx

        public void EditEmployeeEmail(int? id, string name)
        {
            if (id == null || string.IsNullOrWhiteSpace(name))
                throw new NullReferenceException("id ve email null ola bilmez");

            Medicine medicine = _medicines.Find(e => e.Id == id);
            if (medicine == null)
                throw new NotFoundException("bele bir ishci yoxdur");

            medicine.Name = name;
        } //DONE
    }
}
