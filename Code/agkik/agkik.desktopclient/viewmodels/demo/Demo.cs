using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agkik.desktopclient.viewmodels.demo
{
    // demo data and supporting classes
    class Demo
    {
    }

    public abstract class DemoCategoryVM
    {
        protected List<DemoMainCategory> _MainCategories;

        public List<DemoMainCategory> MainCategories
        {
            get { return getMainCategories(); }
            set { _MainCategories = value; }
        }
        protected List<DemoSubCategory> _SubCategories;

        public List<DemoSubCategory> SubCategories
        {
            get { return getSubCategories(); }
            set { _SubCategories = value; }
        }

        protected abstract List<DemoMainCategory> getMainCategories();
        protected abstract List<DemoSubCategory> getSubCategories();
        
    }

    public class DemoExpsenseCategoryVM : DemoCategoryVM
    {
        protected override List<DemoMainCategory> getMainCategories()
        {
            if (_MainCategories == null)
            {
                _MainCategories = new List<DemoMainCategory>();
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "1", Name = "Administration", Description = "this field is not editable", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "2", Name = "Motor Vehicle", Description = "", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "4", Name = "Repairs and maintenance", Description = "", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "5", Name = "Staff Costs", Description = "", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "6", Name = "Telephone", Description = "", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "7", Name = "Accounting", Description = "A custom Field", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "8", Name = "Insurance", Description = "Another Custom Field", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "9", Name = "Projects", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "10", Name = "Purchasing", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "11", Name = "Theft", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "12", Name = "Building", Description = "", CategoryType = MainCategoryType.Custom });
            }
            _MainCategories.Sort(delegate(DemoMainCategory val1, DemoMainCategory val2) { return val1.Name.CompareTo(val2.Name); });
            return _MainCategories;
        }

        protected override List<DemoSubCategory> getSubCategories()
        {
            if (_SubCategories == null)
            {
                _SubCategories = new List<DemoSubCategory>();
                //DemoMainCategory p1 = getMainCategories().Find(x => x.CategoryId == "1");
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "1", Name = "Misc", Description = "misc. items", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "2", Name = "Printing", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "4", Name = "Computers", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "5", Name = "Internet Costs", Description = "Internet Costs", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "6", Name = "Fuel", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "7", Name = "Insurance", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "8", Name = "Employee Insurance", Description = "Another Custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "8") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "9", Name = "Projects", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "10", Name = "Equipment Repairs", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "4") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "11", Name = "Office Supplies", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "12", Name = "Employee Salary", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "5") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "13", Name = "Registration", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "14", Name = "Services", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
            }
            _SubCategories.Sort(delegate(DemoSubCategory v1, DemoSubCategory v2) { return v1.Name.CompareTo(v2.Name); });
            return _SubCategories;
        }
    }

    public class DemoIncomeCategoryVM : DemoCategoryVM
    {
        protected override List<DemoMainCategory> getMainCategories()
        {
            if (_MainCategories == null)
            {
                _MainCategories = new List<DemoMainCategory>();
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "1", Name = "Sales", Description = "this field is not editable", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "2", Name = "Tour", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "3", Name = "Hotel", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "4", Name = "Food", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "5", Name = "Services", Description = "", CategoryType = MainCategoryType.System });
            }
            _MainCategories.Sort(delegate(DemoMainCategory val1, DemoMainCategory val2) { return val1.Name.CompareTo(val2.Name); });
            return _MainCategories;
        }

        protected override List<DemoSubCategory> getSubCategories()
        {
            if (_SubCategories == null)
            {
                _SubCategories = new List<DemoSubCategory>();
                //DemoMainCategory p1 = getMainCategories().Find(x => x.CategoryId == "1");
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "1", Name = "Paintings", Description = "misc. items", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "2", Name = "Photos", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "4", Name = "Boxes", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "5", Name = "T-Shirt", Description = "Internet Costs", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "6", Name = "Tour Plan 1", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "7", Name = "Tour Plan 2", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "8", Name = "Tour Plan 3", Description = "Another Custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "9", Name = "Trousers", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "10", Name = "Breakfast", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "4") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "11", Name = "Lunch", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "4") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "12", Name = "Dinner", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "4") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "13", Name = "Rent - Room type 1", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "3") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "14", Name = "Rent - Room type 2", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "3") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "15", Name = "Rent - Room type 3", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "3") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "16", Name = "Room service", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "5") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "17", Name = "Consultation", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "5") });
            }
            //_SubCategories.Sort(delegate(DemoSubCategory v1, DemoSubCategory v2) { return v2.Name.CompareTo(v1.Name); });
            return _SubCategories;
        }
    }

    public class DemoNonInvoicedIncomeCategoryVM : DemoCategoryVM
    {
        protected override List<DemoMainCategory> getMainCategories()
        {
            if (_MainCategories == null)
            {
                _MainCategories = new List<DemoMainCategory>();
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "1", Name = "Donation", Description = "this field is not editable", CategoryType = MainCategoryType.System });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "2", Name = "Interest Income", Description = "", CategoryType = MainCategoryType.Custom });
                _MainCategories.Add(new DemoMainCategory() { CategoryId = "3", Name = "Others", Description = "", CategoryType = MainCategoryType.Custom });
            }
            _MainCategories.Sort(delegate(DemoMainCategory val1, DemoMainCategory val2) { return val1.Name.CompareTo(val2.Name); });
            return _MainCategories;
        }

        protected override List<DemoSubCategory> getSubCategories()
        {
            if (_SubCategories == null)
            {
                _SubCategories = new List<DemoSubCategory>();
                //DemoMainCategory p1 = getMainCategories().Find(x => x.CategoryId == "1");
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "1", Name = "Cash Donation", Description = "misc. items", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "2", Name = "Food Donation", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "4", Name = "Clothes Donation", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "1") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "5", Name = "Bank 1 interest", Description = "Internet Costs", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "6", Name = "Bank 2 interest", Description = "", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "7", Name = "Bank 3 interest", Description = "A custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "2") });
                _SubCategories.Add(new DemoSubCategory() { CategoryId = "8", Name = "Other income", Description = "Another Custom Field", ParentCategory = getMainCategories().Find(x => x.CategoryId == "3") });
            }
            _SubCategories.Sort(delegate(DemoSubCategory v1, DemoSubCategory v2) { return v1.Name.CompareTo(v2.Name); });
            return _SubCategories;
        }
    }
    
    public enum MainCategoryType { System, Custom };

    public class DemoMainCategory
    {
        private string _CategoryId;

        public string CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Description;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private MainCategoryType _CategoryType;

        public MainCategoryType CategoryType
        {
            get { return _CategoryType; }
            set { _CategoryType = value; }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class DemoSubCategory : DemoMainCategory
    {
        private DemoMainCategory _parentCategory;

        public DemoMainCategory ParentCategory
        {
            get { return _parentCategory; }
            set { _parentCategory = value; }
        }

        public String ParentCategoryName
        {
            get { return _parentCategory.Name; }
        }
    }
}
