using System.Data;
using System.Reflection;
using agkik.businesslogic.models;
using log4net;
using System.Linq;
using System.Collections.Generic;

namespace agkik.businesslogic.businessapi
{
    public class InventoryManager
    {
        /*
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Public Methods
        public static List<UOM> GetUOMList()
        {
            MedInventusEntities entity = new MedInventusEntities();

            IQueryable<uom> uomQuery = from u in entity.uoms
                                       orderby u.Name
                                       select u;
            try
            {
                List<UOM> ret = new List<UOM>();
                foreach (uom uom in uomQuery)
                {
                    log.Debug(string.Format("UOM: Id[{0}],Name[{1}],ConversionFactor[{2}]", uom.idUOM, uom.Name, uom.UOMConversionFactor));

                    ret.Add(new UOM()
                    {
                        UomId = uom.idUOM,
                        UomName = uom.Name,
                        UOMConversionFactor = uom.UOMConversionFactor
                    });
                }
                return ret;
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
            }
            return null;
        }

        public static ResponseWrapper AddNewMedicine(Medicine medTobeAdded)
        {
            MedInventusEntities entity = new MedInventusEntities();

            medicine med = populateMedicine(medTobeAdded);

            try
            {
                entity.AddTomedicines(med);
                return new ResponseWrapper()
                {
                    HasError = !(entity.SaveChanges() > 0)
                };
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return new ResponseWrapper(true, "Database connection error");
            }
        }


        public static ResponseWrapper UpdateMedicine(Medicine medicine)
        {
            MedInventusEntities entity = new MedInventusEntities();

            medicine medicineTobeUpdated = entity.medicines.First<medicine>(i => i.idMedicine == medicine.MedicineId);

            medicineTobeUpdated.Name = medicine.MedicineName;
            medicineTobeUpdated.GenericName = medicine.GenericName;
            medicineTobeUpdated.IsH1 = medicine.IsH1;
            medicineTobeUpdated.IsRetail = medicine.IsRetail;
            medicineTobeUpdated.UOM_idUOM = medicine.Uom.UomId;
            medicineTobeUpdated.QuantityAlert = medicine.QuantityAlert;
            medicineTobeUpdated.QuantityAlertTime = medicine.QuantityAlertDays;
            try
            {
                return new ResponseWrapper()
                {
                    HasError = !(entity.SaveChanges() > 0)
                };
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return new ResponseWrapper(true, "Database connection error");
            }
        }

        public static ResponseWrapper AddUpdateUom(UOM inputUOM)
        {
            MedInventusEntities entity = new MedInventusEntities();
            IQueryable<int> uomQuery = from u in entity.uoms
                                       where u.Name == inputUOM.UomName
                                       select u.idUOM;

            if (inputUOM.UomId == 0)
            {
                uom uomTobeAdded = new uom()
                {
                    Name = inputUOM.UomName,
                    UOMConversionFactor = (int)inputUOM.UOMConversionFactor
                };
                entity.AddTouoms(uomTobeAdded);
            }
            else
            {
                uom uomTobeUpdated = entity.uoms.First<uom>(i => i.idUOM == inputUOM.UomId);
                uomTobeUpdated.Name = inputUOM.UomName;
                uomTobeUpdated.UOMConversionFactor = inputUOM.UOMConversionFactor;
            }

            try
            {
                return new ResponseWrapper()
                {
                    HasError = !(entity.SaveChanges() > 0)
                };
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return new ResponseWrapper(true, "Database connection error");
            }
        }

        public static List<Medicine> GetMedicineList()
        {
            MedInventusEntities entity = new MedInventusEntities();

            IQueryable<medicine> meds = from md in entity.medicines
                                         select md;

            try
            {

                if (meds.Count<medicine>() > 0)
                {
                    List<Medicine> medList = new List<Medicine>();
                    foreach (var med in meds)
                    {
                        log.Debug(string.Format("idMedicine[{0}],MedicineName[{1}],GenericName[{2}], IsH1[{3}], IsRetail[{4}]", med.idMedicine, med.Name, med.GenericName, med.IsH1, med.IsRetail));

                        medList.Add(new Medicine()
                        {
                            MedicineId = med.idMedicine,
                            MedicineName = med.Name,
                            GenericName = med.GenericName,
                            IsH1 = med.IsH1,
                            IsRetail = med.IsRetail,
                            QuantityAlert = med.QuantityAlert,
                            QuantityAlertDays = med.QuantityAlertTime,
                            Uom = new UOM
                            {
                                UomId = med.UOM_idUOM
                            }
                        });
                    }
                    return medList;
                }
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);

            }
            return null;
        }

        public static UOM FindUOMById(int uomId)
        {
            MedInventusEntities entity = new MedInventusEntities();
            IQueryable<UOM> joinQuery = from um in entity.uoms
                                        where um.idUOM == uomId
                                        select new UOM
                                        {
                                            UomId = um.idUOM,
                                            UomName = um.Name,
                                            UOMConversionFactor = um.UOMConversionFactor,
                                        };
            try
            {

                if (joinQuery.Count<UOM>() == 1)
                {
                    UOM retUOM = joinQuery.First<UOM>();
                    return retUOM;
                }
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
            }
            return null;
        }

        public static Medicine FindMedicineById(int medId)
        {
            MedInventusEntities entity = new MedInventusEntities();


            IQueryable<Medicine> joinQuery = from md in entity.medicines
                                             join u in entity.uoms
                                             on md.UOM_idUOM equals u.idUOM into x
                                             from um in x
                                             where md.idMedicine == medId
                                             select new Medicine
                                             {
                                                 MedicineId = md.idMedicine,
                                                 MedicineName = md.Name,
                                                 GenericName = md.GenericName,
                                                 IsH1 = md.IsH1,
                                                 IsRetail = md.IsRetail,
                                                 QuantityAlert = md.QuantityAlert,
                                                 QuantityAlertDays = md.QuantityAlertTime,
                                                 Uom = new UOM
                                                 {
                                                     UomId = um.idUOM,
                                                     UomName = um.Name,
                                                     UOMConversionFactor = um.UOMConversionFactor,
                                                 },
                                             };
            try
            {

                if (joinQuery.Count<Medicine>() == 1)
                {
                    Medicine retMed = joinQuery.First<Medicine>();
                    return retMed;
                }
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
            }
            return null;
        }
        #endregion

        #region Private Methods
        private static medicine populateMedicine(Medicine med)
        {
            return new medicine()
            {
                Name = med.MedicineName,
                GenericName = med.GenericName,
                QuantityAlert = med.QuantityAlert,
                QuantityAlertTime = med.QuantityAlertDays,
                UOM_idUOM = med.Uom.UomId,
                IsH1=med.IsH1,
                IsRetail=med.IsRetail
            };
        }
        #endregion*/
    }
}
