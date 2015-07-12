using System;
using log4net;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using agkik.businesslogic.models;


namespace agkik.businesslogic.businessapi
{
    public class VendorManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Public Methods
        public static bool AddVendor(Vendor vendor)
        {
            AgkikdbEntities entity = new AgkikdbEntities();
            vendor vendorTobeAdded = populateVendor(vendor);

            try
            {
                entity.AddTovendors(vendorTobeAdded);
                return entity.SaveChanges() > 0;
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return false;
            }
        }

        public static bool UpdateVendor(Vendor vendor)
        {
            AgkikdbEntities entity = new AgkikdbEntities();
            //vendor vendorTobeUpdated = populateVendor(vendor);

            try
            {
                vendor vendorTobeUpdated = entity.vendors.First<vendor>(i => i.idVendors == vendor.VendorId);


                vendorTobeUpdated.FirstName = vendor.FirstName;
                vendorTobeUpdated.LastName = vendor.LastName;
                vendorTobeUpdated.VendorCompany = vendor.CompanyName;

                vendorTobeUpdated.Email = vendor.Contact.Email;
                vendorTobeUpdated.MobileNo = vendor.Contact.MobileNo;
                vendorTobeUpdated.PhoneNo = vendor.Contact.PhoneNo;
                vendorTobeUpdated.Fax = vendor.Contact.Fax;
                vendorTobeUpdated.MobileNo = vendor.Contact.MobileNo;
                vendorTobeUpdated.address = populateAddress(vendor.PrimaryAddress);
                vendorTobeUpdated.address1 = populateAddress(vendor.AlternateAddress);

                return entity.SaveChanges() > 0;
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
                return false;
            }
        }

        public static List<Vendor> GetVendors()
        {
            AgkikdbEntities entity = new AgkikdbEntities();

            IQueryable<vendor> vendors = from vndr in entity.vendors
                                         select vndr;

            try
            {

                if (vendors.Count<vendor>() > 0)
                {
                    List<Vendor> vendorList = new List<Vendor>();
                    foreach (var vendor in vendors)
                    {
                        log.Debug(string.Format("FirstName[{0}],LastName[{1}],VendorCompany[{2}], RegistrationDate[{3}]", vendor.FirstName, vendor.LastName, vendor.VendorCompany, vendor.RegistrationDate));

                        vendorList.Add(new Vendor()
                        {
                            VendorId = vendor.idVendors,
                            FirstName = vendor.FirstName,
                            LastName = vendor.LastName,
                            CompanyName = vendor.VendorCompany,
                            RegistrationDate = vendor.RegistrationDate,
                        });
                    }
                    return vendorList;
                }
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);

            }
            return null;
        }

        public static Vendor FindVendorById(int vendorId)
        {
            AgkikdbEntities entity = new AgkikdbEntities();


            IQueryable<Vendor> joinQuery = from vndr in entity.vendors
                                           join add in entity.addresses
                                           on vndr.Address_idAddress equals add.idAddress
                                           join alt in entity.addresses
                                           on vndr.AltAddress_idAddress equals alt.idAddress into x
                                           from altAdd in x.DefaultIfEmpty()
                                           where vndr.idVendors == vendorId
                                           select new Vendor
                                           {
                                               VendorId = vndr.idVendors,
                                               FirstName = vndr.FirstName,
                                               LastName = vndr.LastName,
                                               CompanyName = vndr.VendorCompany,
                                               ShowAltAddress = true,
                                               PrimaryAddress = new Address
                                               {
                                                   AddressLine1 = add.AddressLine1,
                                                   AddressLine2 = add.AddressLine2,
                                                   City = add.City,
                                                   State = add.State,
                                                   Country = add.Country,
                                                   PIN = (int?)add.Zip
                                               },
                                               AlternateAddress = new Address
                                               {
                                                   AddressLine1 = altAdd.AddressLine1,
                                                   AddressLine2 = altAdd.AddressLine2,
                                                   City = altAdd.City,
                                                   State = altAdd.State,
                                                   Country = altAdd.Country,
                                                   PIN = (int?)altAdd.Zip
                                               },
                                               Contact = new Contact()
                                               {
                                                   MobileNo = vndr.MobileNo,
                                                   PhoneNo = vndr.PhoneNo,
                                                   Email = vndr.Email,
                                                   AltEmail = vndr.AlternateEmail,
                                                   Fax = vndr.Fax
                                               }
                                           };
            try
            {

                if (joinQuery.Count<Vendor>() == 1)
                {
                    Vendor retVendor = joinQuery.First<Vendor>();
                    if (retVendor.AlternateAddress.AddressLine1 == null)
                        retVendor.ShowAltAddress = false;
                    return retVendor;
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

        private static vendor populateVendor(Vendor vendor)
        {
            return new vendor()
            {
                FirstName = vendor.FirstName,
                LastName = vendor.LastName,
                VendorCompany = vendor.CompanyName,
                Email = vendor.Contact.Email,
                AlternateEmail = vendor.Contact.AltEmail,
                PhoneNo = vendor.Contact.PhoneNo,
                MobileNo = vendor.Contact.MobileNo,
                Fax = vendor.Contact.Fax,
                address = populateAddress(vendor.PrimaryAddress),
                address1 = populateAddress(vendor.AlternateAddress),
                RegistrationDate = DateTime.Now
            };
        }

        private static address populateAddress(Address address)
        {
            if (address != null)
            {
                return new address()
                {
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine2,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    Zip = Convert.ToInt32(address.PIN)
                };
            }
            return null;
        }
        #endregion
    }
}
