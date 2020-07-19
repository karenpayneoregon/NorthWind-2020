using System;
using System.Linq;
using North.Classes;
using North.Classes.Components;

namespace LanguageExtensions
{
    /// <summary>
    /// Helpers to keep form code clean
    /// </summary>
    public static class SortableBindingListExtensions
    {
        /// <summary>
        /// Wrapper to get current CustomerEntity by current position in a BindingSource attached to a DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static CustomerEntity CurrentCustomer(this SortableBindingList<CustomerEntity> sender, int position)
        {
            return sender[position];
        }
        /// <summary>
        /// Find CustomerEntity by company name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="companyName"></param>
        /// <returns>CustomerEntity if found in list or Nothing if not found in list</returns>
        /// <remarks>
        /// The BindingSource set to the SortableBindingList(Of CustomerEntity) does not support Find method
        /// which means either modifying the SortableBindingList or have this extension method. Using
        /// and extension method makes sense here than modify the SortableBindingList.
        /// </remarks>
        public static CompanyItem FindCompanyByName(this SortableBindingList<CustomerEntity> sender, string companyName)
        {

            return sender.Select((customerEntity, index) => new CompanyItem
            {
                RowIndex = index,
                Entity = customerEntity
            }).FirstOrDefault((companyItem) => companyItem.Entity.CompanyName == companyName);

        }
        /// <summary>
        /// Find CustomerEntity by contact first and last name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="firstName">Contact first name</param>
        /// <param name="lastName">Contact last name</param>
        /// <returns>CustomerEntity if found in list or Nothing if not found in list</returns>
        /// <remarks>
        /// The BindingSource set to the SortableBindingList(Of CustomerEntity) does not support Find method
        /// which means either modifying the SortableBindingList or have this extension method. Using
        /// and extension method makes sense here than modify the SortableBindingList.
        /// </remarks>
        public static CompanyItem FindCompanyByContactName(this SortableBindingList<CustomerEntity> sender, string firstName, string lastName)
        {

            return sender.Select((customerEntity, index) => new CompanyItem
            {
                RowIndex = index,
                Entity = customerEntity
            }).FirstOrDefault((companyItem) => companyItem.Entity.FirstName == firstName && companyItem.Entity.LastName == lastName);

        }
        /// <summary>
        /// Find first company name using starts with case insensitive 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public static CompanyItem FindCompanyByNameStartsWith(this SortableBindingList<CustomerEntity> sender, string companyName)
        {
            return sender.Select((customerEntity, index) => new CompanyItem
            {
                RowIndex = index,
                Entity = customerEntity
            }).FirstOrDefault((item) => item.Entity.CompanyName.StartsWith(companyName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
