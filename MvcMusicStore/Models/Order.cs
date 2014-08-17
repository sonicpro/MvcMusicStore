using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MvcMusicStore.Validation;

namespace MvcMusicStore.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
		[ScaffoldColumn(false)]
        public int OrderId { get; set; }

		[ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

		[ScaffoldColumn(false)]
        public string Username { get; set; }

		[Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
		[StringLength(160, ErrorMessage = "Your first name is too long")]
		[MaxWordsAttribute(10)]
        public string FirstName { get; set; }

		[Required(ErrorMessage = "First Name is required")]
        [DisplayName("Last Name")]
		[StringLength(160, ErrorMessage = "Your last name is too long")]
		public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
			ErrorMessage = "Email is is not valid.")]
		public string Email { get; set; }

		[ScaffoldColumn(false)]
		public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
