namespace ByteCart.Admin.Web.Resources {
    using System;
    using System.Resources;
    using System.Globalization;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SharedResources {
        
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal SharedResources() {
        }

        internal static ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    ResourceManager temp = new ResourceManager("ByteCart.Admin.Web.Resources.SharedResources", typeof(SharedResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        internal static CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }

        public static string Description {
            get {
                return ResourceManager.GetString("Description", resourceCulture);
            }
        }

        public static string Edit {
            get {
                return ResourceManager.GetString("Edit", resourceCulture);
            }
        }

        public static string Delete {
            get {
                return ResourceManager.GetString("Delete", resourceCulture);
            }
        }

        public static string BackToList {
            get {
                return ResourceManager.GetString("BackToList", resourceCulture);
            }
        }

        public static string Create {
            get {
                return ResourceManager.GetString("Create", resourceCulture);
            }
        }

        public static string Update {
            get {
                return ResourceManager.GetString("Update", resourceCulture);
            }
        }

        public static string Cancel {
            get {
                return ResourceManager.GetString("Cancel", resourceCulture);
            }
        }

        public static string Save {
            get {
                return ResourceManager.GetString("Save", resourceCulture);
            }
        }

        public static string ConfirmDelete {
            get {
                return ResourceManager.GetString("ConfirmDelete", resourceCulture);
            }
        }

        public static string SuccessMessage {
            get {
                return ResourceManager.GetString("SuccessMessage", resourceCulture);
            }
        }

        public static string ErrorMessage {
            get {
                return ResourceManager.GetString("ErrorMessage", resourceCulture);
            }
        }

        public static string LoadingData {
            get {
                return ResourceManager.GetString("LoadingData", resourceCulture);
            }
        }

        public static string NoItemsFound {
            get {
                return ResourceManager.GetString("NoItemsFound", resourceCulture);
            }
        }

        public static string CategoryManagement {
            get {
                return ResourceManager.GetString("CategoryManagement", resourceCulture);
            }
        }

        public static string CategoryManagementDescription {
            get {
                return ResourceManager.GetString("CategoryManagementDescription", resourceCulture);
            }
        }

        public static string AddNewCategory {
            get {
                return ResourceManager.GetString("AddNewCategory", resourceCulture);
            }
        }

        public static string CategoryDetails {
            get {
                return ResourceManager.GetString("CategoryDetails", resourceCulture);
            }
        }

        public static string ParentCategory {
            get {
                return ResourceManager.GetString("ParentCategory", resourceCulture);
            }
        }

        public static string TopLevelCategory {
            get {
                return ResourceManager.GetString("TopLevelCategory", resourceCulture);
            }
        }

        public static string NoParent {
            get {
                return ResourceManager.GetString("NoParent", resourceCulture);
            }
        }

        public static string DirectProducts {
            get {
                return ResourceManager.GetString("DirectProducts", resourceCulture);
            }
        }

        public static string SubCategories {
            get {
                return ResourceManager.GetString("SubCategories", resourceCulture);
            }
        }

        public static string NoDirectSubCategories {
            get {
                return ResourceManager.GetString("NoDirectSubCategories", resourceCulture);
            }
        }

        public static string SupplierManagement {
            get {
                return ResourceManager.GetString("SupplierManagement", resourceCulture);
            }
        }

        public static string SupplierManagementDescription {
            get {
                return ResourceManager.GetString("SupplierManagementDescription", resourceCulture);
            }
        }

        public static string AddNewSupplier {
            get {
                return ResourceManager.GetString("AddNewSupplier", resourceCulture);
            }
        }

        public static string ContactPerson {
            get {
                return ResourceManager.GetString("ContactPerson", resourceCulture);
            }
        }

        public static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }

        public static string PhoneNumber {
            get {
                return ResourceManager.GetString("PhoneNumber", resourceCulture);
            }
        }

        public static string Address {
            get {
                return ResourceManager.GetString("Address", resourceCulture);
            }
        }

        public static string ProductsSupplied {
            get {
                return ResourceManager.GetString("ProductsSupplied", resourceCulture);
            }
        }

        public static string SupplierDetails {
            get {
                return ResourceManager.GetString("SupplierDetails", resourceCulture);
            }
        }

        public static string EditSupplier {
            get {
                return ResourceManager.GetString("EditSupplier", resourceCulture);
            }
        }

        public static string CreateSupplier {
            get {
                return ResourceManager.GetString("CreateSupplier", resourceCulture);
            }
        }

        public static string Category {
            get {
                return ResourceManager.GetString("Category", resourceCulture);
            }
        }

        public static string Categories {
            get {
                return ResourceManager.GetString("Categories", resourceCulture);
            }
        }

        public static string Supplier {
            get {
                return ResourceManager.GetString("Supplier", resourceCulture);
            }
        }

        public static string Suppliers {
            get {
                return ResourceManager.GetString("Suppliers", resourceCulture);
            }
        }

        public static string Products {
            get {
                return ResourceManager.GetString("Products", resourceCulture);
            }
        }

        public static string Actions {
            get {
                return ResourceManager.GetString("Actions", resourceCulture);
            }
        }

        public static string SelectLanguage {
            get {
                return ResourceManager.GetString("SelectLanguage", resourceCulture);
            }
        }

    }
}